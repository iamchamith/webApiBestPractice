using AutoMapper;
using One.Bo;
using One.Bo.Utility;
using One.DbService.Infrastructure;
using One.DbService.Interfaces;
using One.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace One.DbService.Services
{
    public class StreemService : IStreemDbService
    {
        IUnitOfWork uof;
        public StreemService(IUnitOfWork _uof)
        {
            this.uof = _uof;
        }

        public IEnumerable<StreemBo> Get(Expression<Func<StreemBo, bool>> filter = null, Func<IQueryable<StreemBo>, IOrderedQueryable<StreemBo>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StreemBo> Get(out int recodeCount, int skip = 0, int take = 0, string sortBy = "", bool isASC = false, string search = null)
        {
            try
            {
                var details = MemoryCacher.GetValue(CacheVariables.StreemList.ToString());
                if (details != null)
                {
                    recodeCount = 0;
                    return (IEnumerable<StreemBo>)details;
                }
                else
                {
                    Expression<Func<Streem, bool>> filter = null;
                    Func<IQueryable<Streem>, IOrderedQueryable<Streem>> orderBy = null;
                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        filter = (e) => e.Name.ToLower().Trim().StartsWith(search.ToLower().Trim());
                    }
                    if (!string.IsNullOrWhiteSpace(sortBy))
                    {
                        if (sortBy == "id")
                        {
                            orderBy = (e) => (isASC) ? e.OrderBy(p => p.Id) : e.OrderByDescending(p => p.Id);
                        }
                        else if (sortBy == "name")
                        {
                            orderBy = (e) => (isASC) ? e.OrderBy(p => p.Name) : e.OrderByDescending(p => p.Name);
                        }
                        else
                        {
                            throw new ArgumentException("invalied sorting type");
                        }
                    }
                    // query
                    var res = uof.StreemRepository.Get(filter, orderBy, "");
                    // add to the cache
                    var result = res.Select(x => Mapper.Map<StreemBo>(x)).ToList();
                    MemoryCacher.Add(CacheVariables.StreemList.ToString(), result);
                    recodeCount = uof.StreemRepository.GetRecodeCount();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public StreemBo GetByID(object id)
        {
            throw new NotImplementedException();
        }
    }
}
