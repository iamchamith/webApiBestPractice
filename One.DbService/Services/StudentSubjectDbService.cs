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
    public class StudentSubjectDbService : IStudentSubjectDbService
    {
        IUnitOfWork uof;
        public StudentSubjectDbService(IUnitOfWork _uof)
        {
            this.uof = _uof;
        }

        public void Delete(StudentSubjectBo entityToDelete)
        {
            try
            {
                uof.StudentSubjectRepository.Delete(Mapper.Map<StudentSubject>(entityToDelete));
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
                uof.StudentSubjectRepository.Delete(id);
                uof.Save();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<StudentSubjectBo> Get(Expression<Func<StudentSubjectBo, bool>> filter = null, Func<IQueryable<StudentSubjectBo>, IOrderedQueryable<StudentSubjectBo>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentSubjectBo> Get(Expression<Func<StudentSubject, bool>> filter = null, Func<IQueryable<StudentSubject>, IOrderedQueryable<StudentSubject>> orderBy = null, string includeProperties = "")
        {
            try
            {

                return uof.StudentSubjectRepository.Get(filter, orderBy, includeProperties)
                    .Select(x => Mapper.Map<StudentSubjectBo>(x)).ToList();
            }
            catch
            {
                throw;
            }
        }

        public StudentSubjectBo GetByID(object id)
        {
            try
            {
                return Mapper.Map<StudentSubjectBo>(uof.StudentSubjectRepository.GetByID(id));
            }
            catch
            {
                throw;
            }
        }

        public void Insert(StudentSubjectBo entity)
        {
            try
            {
                uof.StudentSubjectRepository.Insert(Mapper.Map<StudentSubject>(entity));
                uof.Save();
            }
            catch
            {
                throw;
            }
        }

        public void Update(StudentSubjectBo entityToUpdate)
        {
            try
            {
                uof.StudentSubjectRepository.Update(Mapper.Map<StudentSubject>(entityToUpdate));
                uof.Save();
            }
            catch
            {
                throw;
            }
        }
    }
}
