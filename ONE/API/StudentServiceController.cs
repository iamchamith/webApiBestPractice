using ONE.API;
using ONE.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using One.DbService.Services;
using One.DbService.Interfaces;
using AutoMapper;
using One.Bo;
using One.DbService.Infrastructure;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using ONE.Classes;
using static One.Bo.Utility.Enums;
using One.DbAccess;
using One.Domain.Utility;

namespace ONE.API
{
    // [Authorize(Roles = "User")]
    [RoutePrefix("api/v1")]
    public class StudentServiceController : BaseServiceController, IService<StudentViewModel>
    {
        IStudentDbService service;
        public StudentServiceController() : base()
        {
            this.service = new StudentDbService(new UnitOfWork(new SchoolContext(), ERunType.Debug));
        }
        //test
        public StudentServiceController(IUnitOfWork uow) : base(ERunType.Test)
        {
            this.service = new StudentDbService(uow);
        }

        [HttpGet]
        [Route("students")]
        public async Task<IHttpActionResult> Get(int page = 1, int itemsPerPage = 30, string sortBy = "FirstName",
                     bool reverse = false, string search = null)
        {
            try
            {
                service.Get(filter: p => p.Address == "");
                return Ok<IEnumerable<StudentViewModel>>(service.Get().Select(x => AutoMapper.Mapper.Map<StudentViewModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("students/{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var response = service.Get(filter: p => p.Id == id).Select(x => AutoMapper.Mapper.Map<StudentViewModel>(x)).FirstOrDefault();
                return Ok<StudentViewModel>(response);

            }
            catch (Exception ex)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPost]
        [Route("students")]
        public async Task<IHttpActionResult> Insert(StudentViewModel item)
        {
            try
            {
                var validateError = new List<string>();
                if (!Utility.IsModelValied(item, out validateError))
                {
                    return BadRequest(Utility.ConvertObjectToJsonString(validateError));
                }
                int id = await ((StudentDbService)service).InsertAsync(Mapper.Map<StudentBo>(item));
                return Ok<int>(id);
            }
            catch (Exception ex)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPut]
        [Route("students/{id:int}")]
        public async Task<IHttpActionResult> Update(StudentViewModel item, int id)
        {
            try
            {
                item.Id = id;
                var validateError = new List<string>();
                if (!Utility.IsModelValied(item, out validateError))
                {
                    return BadRequest(Utility.ConvertObjectToJsonString(validateError));
                }
                await service.UpdateAsync(Mapper.Map<StudentBo>(item));
                return Ok();
            }
            catch (Exception ex)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPost]
        [Route("students/{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                await service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
