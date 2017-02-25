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
   //[Authorize(Roles = "User")]
    [RoutePrefix("api/v1")]
    public class StudentServiceController : BaseServiceController, IService<StudentViewModel>
    {
        IStudentDbService service;
        IStreemDbService streemDbService;
        ISchoolDbService schoolDbService;
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
        [Route("students/lookup")]
        public async Task<IHttpActionResult> Lookup()
        {
            try
            {
                var uow = new UnitOfWork(new SchoolContext(), ERunType.Debug);
                streemDbService = new StreemDbService(uow);
                schoolDbService = new SchoolDbService(uow);
                int recodeCount = 0;
                return Ok<object>(new
                {
                    steem = streemDbService.Get(out recodeCount, 0, 0, "name", true, "").Select(x => AutoMapper.Mapper.Map<StreemViewModel>(x)),
                    school = schoolDbService.Get(out recodeCount, 0, 0, "name", true, "").Select(x => AutoMapper.Mapper.Map<SchoolViewModel>(x))
                });
            }
            catch (Exception ex)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("students")]
        public async Task<IHttpActionResult> Get(int skip = 0, int take = 0, string sortBy = "", bool isASC = false, string search = null)
        {
            try
            {
                int recodeCount = 0;
                var res = service.Get(out recodeCount, skip, take, sortBy, isASC, search).Select(x => AutoMapper.Mapper.Map<StudentViewModel>(x)).ToList();
                return Ok<object>(new { result = res, recodeCount = recodeCount });
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
                var response = Mapper.Map<StudentViewModel>(service.GetByID(id));
                return Ok<StudentViewModel>(response);

            }
            catch (Exception ex)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPost]
        [ValidateModel]
        [Route("students")]
        public async Task<IHttpActionResult> Insert(StudentViewModel item)
        {
            try
            {
                int id = await ((StudentDbService)service).InsertAsync(Mapper.Map<StudentBo>(item));
                return Ok<int>(id);
            }
            catch (Exception ex)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPut]
        [ValidateModel]
        [Route("students/{id:int}")]
        public async Task<IHttpActionResult> Update(StudentViewModel item, int id)
        {
            try
            {
                item.Id = id;
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
