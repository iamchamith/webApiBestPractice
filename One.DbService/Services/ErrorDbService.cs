using One.DbService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using One.Bo;
using System.Linq.Expressions;
using One.Domain;
using One.DbService.Infrastructure;
using AutoMapper;

namespace One.DbService.Services
{
    public class ErrorDbService : IErrorDbService
    {
        IUnitOfWork uof;
        public ErrorDbService(IUnitOfWork _uof)
        {
            this.uof = _uof;
        }

        public Task DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ErrorBo> Get(Expression<Func<ErrorBo, bool>> filter = null, Func<IQueryable<ErrorBo>, IOrderedQueryable<ErrorBo>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ErrorBo> Get(out int recodeCount, int skip = 0, int take = 0, string sortBy = "", bool isASC = false, string search = null)
        {
            Expression<Func<Error, bool>> filter = null;
            Func<IQueryable<Error>, IOrderedQueryable<Error>> orderBy = null;
            if (!string.IsNullOrWhiteSpace(search))
            {
                filter = (e) => e.Exception.ToLower().Trim().StartsWith(search.ToLower().Trim());
            }
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy == "id")
                {
                    orderBy = (e) => (isASC) ? e.OrderBy(p => p.Id) : e.OrderByDescending(p => p.Id);
                }
                else if (sortBy == "exception")
                {
                    orderBy = (e) => (isASC) ? e.OrderBy(p => p.Exception) : e.OrderByDescending(p => p.Exception);
                }
                else
                {
                    throw new ArgumentException("invalied sorting type");
                }
            }
            // query
            var res = uof.ErrorRepository.Get(filter, orderBy, "");
            // add to the cache
            var result = res.Select(x => Mapper.Map<ErrorBo>(x)).ToList();
            recodeCount = uof.SchoolRepository.GetRecodeCount();
            return result;
        }

        public ErrorBo GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertAsync(ErrorBo entity)
        {
            try
            {
                var obj = Mapper.Map<Error>(entity);
                uof.ErrorRepository.Insert(obj);
                await uof.SaveAsync();
                return obj.Id;
            }
            catch
            {
                throw;
            }
        }

        public Task UpdateAsync(ErrorBo entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
