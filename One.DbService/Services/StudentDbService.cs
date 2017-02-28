using One.DbService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using One.Bo;
using System.Linq.Expressions;
using One.DbService.Infrastructure;
using AutoMapper;
using One.Domain;
using One.Bo.Utility;

namespace One.DbService.Services
{
    public class StudentDbService : IStudentDbService
    {
        IUnitOfWork uof;
        public StudentDbService(IUnitOfWork _uof)
        {
            this.uof = _uof;
        }
        public IEnumerable<StudentBo> Get(Expression<Func<StudentBo, bool>> filter = null, Func<IQueryable<StudentBo>, IOrderedQueryable<StudentBo>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }
        public IEnumerable<StudentBo> Get(out int recodeCount, int skip = 0, int take = 0, string sortBy = "", bool isASC = false, string search = null)
        {
            try
            {
                Expression<Func<Student, bool>> filter = null;
                Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null;
                if (!string.IsNullOrWhiteSpace(search))
                {
                    var s = search.ToLower().Trim();
                    filter = (e) => e.Address.StartsWith(s) || e.Name.StartsWith(s) || e.School.Name.StartsWith(s);
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
                var res = uof.StudentRepository.Get(filter: filter, orderBy: orderBy, skip: skip, take: take)
                    .Select(p => new Student { Id = p.Id, Name = p.Name, Email = p.Email });
                // add to the cache
                var result = res.Select(x => Mapper.Map<StudentBo>(x)).ToList();
                recodeCount = uof.StudentRepository.GetRecodeCount();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public StudentBo GetByID(object id)
        {
            try
            {
                return Mapper.Map<StudentBo>(uof.StudentRepository.GetByID(id));
            }
            catch
            {
                throw;
            }
        }
        public async Task<int> InsertAsync(StudentBo entity)
        {
            try
            {
                var obj = Mapper.Map<Student>(entity);
                uof.StudentRepository.Insert(obj);
                await uof.SaveAsync();
                return obj.Id;
            }
            catch
            {
                throw;
            }
        }
        public async Task DeleteAsync(object id)
        {
            try
            {
                uof.StudentRepository.Delete(id);
                await uof.SaveAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task UpdateAsync(StudentBo entityToUpdate)
        {
            try
            {
                uof.StudentRepository.Update(Mapper.Map<Student>(entityToUpdate));
                await uof.SaveAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
