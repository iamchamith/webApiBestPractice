using One.DbService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using One.Bo;
using System.Linq.Expressions;
using One.DbService.Infrastructure;
using One.Domain;

namespace One.DbService.Services
{
    public class EntityOrderService : IEntityOrderService
    {

        public IUnitOfWork uow;
        public EntityOrderService(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }

        public async Task DeleteAsync()
        {
            try
            {
                this.uow.Context.StudentOrders.RemoveRange(Get().Select(x => AutoMapper.Mapper.Map<StudentOrder>(x)).ToList());
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IEnumerable<EntityOrderBo> Get(Expression<Func<EntityOrderBo, bool>> filter = null, Func<IQueryable<EntityOrderBo>, IOrderedQueryable<EntityOrderBo>> orderBy = null, string includeProperties = "")
        {
            try
            {
                return this.uow.StudentOrder.Get(null, null, null).Select(x => AutoMapper.Mapper.Map<EntityOrderBo>(x)).ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public async Task InsertAsync(List<EntityOrderBo> list)
        {
            try
            {
                await DeleteAsync();
                this.uow.Context.StudentOrders.AddRange(list.Select(x => AutoMapper.Mapper.Map<StudentOrder>(x)).ToList());
                await this.uow.SaveAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        #region not use
        [Obsolete("NotImplementedException")]
        public Task<int> InsertAsync(EntityOrderBo entity)
        {
            throw new NotImplementedException();
        }
        [Obsolete("NotImplementedException")]
        public Task UpdateAsync(EntityOrderBo entityToUpdate)
        {
            throw new NotImplementedException();
        }
        [Obsolete("NotImplementedException")]
        public EntityOrderBo GetByID(object id)
        {
            throw new NotImplementedException();
        }
        [Obsolete("NotImplementedException")]
        public Task DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
