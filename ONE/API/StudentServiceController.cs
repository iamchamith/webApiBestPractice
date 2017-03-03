using ONE.Models.VM;
using System;
using System.Linq;
using System.Web.Http;
using One.DbService.Services;
using One.DbService.Interfaces;
using AutoMapper;
using One.Bo;
using One.DbService.Infrastructure;
using System.Threading.Tasks;
using ONE.Classes;
using static One.Bo.Utility.Enums;
using One.DbAccess;
using System.Collections.Generic;

namespace ONE.API
{
    //[Authorize(Roles = "User")]
    [RoutePrefix("api/v1")]
    public class StudentServiceController : BaseServiceController, IService<StudentViewModel>
    {
        IStudentDbService service;
        IStreemDbService streemDbService;
        ISchoolDbService schoolDbService;
        IEntityOrderService entityOrderService;
        public StudentServiceController() : base()
        {
            this.service = new StudentService(new UnitOfWork(new SchoolContext(), ERunType.Debug));
        }
        //test
        public StudentServiceController(IUnitOfWork uow) : base(uow, ERunType.Test)
        {
            this.service = new StudentService(uow);
        }
        [HttpGet]
        [Route("students/lookup")]
        public async Task<IHttpActionResult> Lookup()
        {
            try
            {
                var uow = new UnitOfWork(new SchoolContext(), ERunType.Debug);
                streemDbService = new StreemService(uow);
                schoolDbService = new SchoolService(uow);
                int recodeCount = 0;
                return Ok<object>(new
                {
                    steem = streemDbService.Get(out recodeCount, 0, 0, "name", true, "").Select(x => AutoMapper.Mapper.Map<StreemViewModel>(x)),
                    school = schoolDbService.Get(out recodeCount, 0, 0, "name", true, "").Select(x => AutoMapper.Mapper.Map<SchoolViewModel>(x))
                });
            }
            catch (Exception ex)
            {
                return await LogErrors(ex);
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
                return await LogErrors(ex);
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
                return await LogErrors(ex);
            }
        }
        [HttpPost]
        [ValidateModel]
        [Route("students")]
        public async Task<IHttpActionResult> Insert(StudentViewModel item)
        {
            try
            {
                int id = await ((StudentService)service).InsertAsync(Mapper.Map<StudentBo>(item));
                return Ok<int>(id);
            }
            catch (Exception ex)
            {
                return await LogErrors(ex);
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
                return await LogErrors(ex);
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
                return await LogErrors(ex);
            }
        }

        [HttpGet]
        [Route("students/order/")]
        public async Task<IHttpActionResult> GetOrder()
        {
            try
            {
                this.entityOrderService = new EntityOrderService(new UnitOfWork(new SchoolContext(), ERunType.Debug));
                return Ok<IEnumerable<EntityOrderViewModel>>(this.entityOrderService.Get().ToList().Select(x => AutoMapper.Mapper.Map<EntityOrderViewModel>(x)));
            }
            catch (Exception ex)
            {
                return await LogErrors(ex);
            }
        }

        [HttpPost]
        [Route("students/order/")]
        public async Task<IHttpActionResult> SaveOrder(IEnumerable<EntityOrderViewModel> list)
        {
            try
            {
                this.entityOrderService = new EntityOrderService(new UnitOfWork(new SchoolContext(), ERunType.Debug));
                await this.entityOrderService.InsertAsync(list.Select(x => AutoMapper.Mapper.Map<EntityOrderBo>(x)).ToList());
                return Ok();
            }
            catch (Exception ex)
            {
                return await LogErrors(ex);
            }
        }
    }
}
