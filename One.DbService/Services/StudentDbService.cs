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

        public IEnumerable<StudentBo> Get(Expression<Func<Student, bool>> filter = null, Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null, string includeProperties = "")
        {
            try
            {
                var res = uof.StudentRepository.Get(filter, orderBy, includeProperties);
                return res
                    .Select(x => Mapper.Map<StudentBo>(x)).ToList();
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
                return Mapper.Map<StudentBo>(uof.SubjectRepository.GetByID(id));
            }
            catch
            {
                throw;
            }
        }
 
        public async Task InsertAsync(StudentBo entity)
        {
            try
            {
                uof.StudentRepository.Insert(Mapper.Map<Student>(entity));
                await uof.SaveAsync();
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
