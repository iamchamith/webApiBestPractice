using One.Bo.Utility.Exceptions;
using One.DbAccess;
using One.DbService.Infrastructure;
using One.DbService.Interfaces;
using One.DbService.Services;
using ONE.App_Start;
using ONE.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using static One.Bo.Utility.Enums;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
namespace ONE.API
{
    [RoutePrefix("api/v0")]
    public class BaseServiceController : ApiController
    {
        IErrorDbService errorService;
        Account account = new Account("ddrdp74on", "542442481541475", "TyAv9ZGUpCinkwFdDCreS1TSLWI");
        public BaseServiceController()
        {
            this.errorService = new ErrorDbService(new UnitOfWork(new SchoolContext(), ERunType.Debug));
        }
        protected string connectionString = string.Empty;

        public BaseServiceController(IUnitOfWork ufo, ERunType type = ERunType.Debug)
        {
            switch (type)
            {
                case ERunType.Debug:
                    this.connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    break;
                case ERunType.Test:
                    new AutomapperConfig().Register();
                    break;
                case ERunType.Release:
                    break;
                default:
                    throw new ArgumentException();
            }
            this.errorService = new ErrorDbService(ufo);
        }
        [HttpGet]
        [Route("error")]
        public async Task<IHttpActionResult> Error(string page, string stackTrace = "")
        {
            try
            {
                await LogErrors(new JavascriptException($"page:{page}^stackTrace{stackTrace}"), ErrorType.ClientSideError);
                return Ok();
            }
            catch (Exception e)
            {

                return Content<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpGet]
        [Route("error")]
        public async Task<IHttpActionResult> Error(int skip = 0, int take = 0, string sortBy = "", bool isASC = false, string search = null)
        {
            try
            {
                int recodeCount = 0;
                var res = errorService.Get(out recodeCount, skip, take, sortBy, isASC, search)
                    .Select(x => AutoMapper.Mapper.Map<ErrorViewModel>(x)).ToList();
                return Ok<List<ErrorViewModel>>(res);
            }
            catch (Exception ex)
            {
                return Content<string>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IHttpActionResult> LogErrors(Exception ex, ErrorType et = ErrorType.ServerError)
        {
            try
            {
                await errorService.InsertAsync(new One.Bo.ErrorBo
                {
                    CreatedTime = DateTime.UtcNow,
                    Exception = ex.Message,
                    ExceptionMessage = (et == ErrorType.ClientSideError) ? ex.Message.Split('^')[0] : ex.Message,
                    ExceptionStackTrace = (et == ErrorType.ClientSideError) ? ex.Message.Split('^')[1] : ex.StackTrace,
                    ExceptionType = et,
                    IsChecked = false,
                });
                var err = string.Empty;
#if DEBUG
                err = ex.Message;
#endif
                return Content<string>(HttpStatusCode.InternalServerError, err);
            }
            catch (Exception e)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, e);
            }
        }

        public void UploadImage(string fileName)
        {
            try
            {
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(fileName, null)
                };
                var uploadResult = cloudinary.Upload(uploadParams);
            }
            catch
            {

            }
        }
        public void DeleteImage(string[] ids)
        {
            try
            {
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadResult = cloudinary.DeleteResources(ids);
            }
            catch
            {

            }
        }
    }
}
