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
    //[RoutePrefix("api/student")]
    public class StudentServiceController : BaseServiceController, IService<StudentViewModel>
    {
        IStudentDbService service;
        public StudentServiceController() : base()
        {
            this.service = new StudentDbService(new UnitOfWork(new SchoolContext(), ERunType.Debug));
        }
        //test
        public StudentServiceController(IContext testContext) : base(ERunType.Test)
        {
            this.service = new StudentDbService(new UnitOfWork(testContext, ERunType.Test));
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int Id)
        {
            try
            {
                await service.DeleteAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                return Ok<IEnumerable<StudentViewModel>>(service.Get().Select(x => AutoMapper.Mapper.Map<StudentViewModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetSingle(int studentId)
        {
            try
            {
                var response = service.Get(filter: p => p.Id == studentId).Select(x => AutoMapper.Mapper.Map<StudentViewModel>(x)).FirstOrDefault();
                return Ok<StudentViewModel>(response);

            }
            catch (Exception ex)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPost]
        public async Task<IHttpActionResult> Insert(StudentViewModel item)
        {
            try
            {
                var validateError = new ModelStateDictionary();
                if (!Utility.IsModelValied(item, out validateError))
                {
                    return BadRequest(validateError);
                }
                await ((StudentDbService)service).InsertAsync(Mapper.Map<StudentBo>(item));
                return Ok();
            }
            catch (Exception ex)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPut]
        public async Task<IHttpActionResult> Update(StudentViewModel item)
        {
            try
            {
                var validateError = new ModelStateDictionary();
                if (!Utility.IsModelValied(item, out validateError))
                {
                    return BadRequest(validateError);
                }
                await service.UpdateAsync(Mapper.Map<StudentBo>(item));
                return Ok();
            }
            catch (Exception ex)
            {
                return Content<Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
