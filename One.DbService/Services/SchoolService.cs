using One.DbService.Infrastructure;
using One.DbService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using One.Bo;
using System.Linq.Expressions;
using One.Bo.Utility;
using AutoMapper;
using One.Domain;

namespace One.DbService.Services
{
    public class SchoolService : ISchoolDbService
    {
        IUnitOfWork uof;
        public SchoolService(IUnitOfWork _uof)
        {
            this.uof = _uof;
        }

        public IEnumerable<SchoolBo> Get(Expression<Func<SchoolBo, bool>> filter = null, Func<IQueryable<SchoolBo>, IOrderedQueryable<SchoolBo>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SchoolBo> Get(out int recodeCount, int skip = 0, int take = 0, string sortBy = "", bool isASC = false, string search = null)
        {
            try
            {
                var details = MemoryCacher.GetValue(CacheVariables.SchoolList.ToString());
                if (details != null)
                {
                    recodeCount = 0;
                    return (IEnumerable<SchoolBo>)details;
                }
                else
                {
                    Expression<Func<School, bool>> filter = null;
                    Func<IQueryable<School>, IOrderedQueryable<School>> orderBy = null;
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
                    var res = uof.SchoolRepository.Get(filter, orderBy, "");
                    // add to the cache
                    var result = res.Select(x => Mapper.Map<SchoolBo>(x)).ToList();
                    MemoryCacher.Add(CacheVariables.SchoolList.ToString(), result);
                    recodeCount = uof.SchoolRepository.GetRecodeCount();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public SchoolBo GetByID(object id)
        {
            throw new NotImplementedException();
        }

    }
}