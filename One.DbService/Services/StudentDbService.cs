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

        public void Delete(StudentBo entityToDelete)
        {
            try
            {
                uof.StudentRepository.Delete(Mapper.Map<Student>(entityToDelete));
                uof.Save();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(object id)
        {
            try
            {
                uof.StudentRepository.Delete(id);
                uof.Save();
            }
            catch
            {
                throw;
            }
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

        public void Insert(StudentBo entity)
        {
            try
            {
                uof.StudentRepository.Insert(Mapper.Map<Student>(entity));
                uof.Save();
            }
            catch
            {
                throw;
            }
        }

        public void Update(StudentBo entityToUpdate)
        {
            try
            {
                uof.StudentRepository.Update(Mapper.Map<Student>(entityToUpdate));
                uof.Save();
            }
            catch
            {
                throw;
            }
        }

        public void Test() {

            uof.StudentRepository.Insert(new Student { Name = "Chamith", Email = "iamchamith@gmail.com" });

           // uof.Context.
        }

    }
}
