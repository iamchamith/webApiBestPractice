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
using AutoMapper;

namespace One.DbService.Services
{
    public class SubjectDbService  
    {
        IUnitOfWork uof;
        public SubjectDbService(IUnitOfWork _uof)
        {
            this.uof = _uof;
        }

        public void Delete(SubjectBo entityToDelete)
        {
            try
            {
                uof.SubjectRepository.Delete(Mapper.Map<Subject>(entityToDelete));
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
                uof.SubjectRepository.Delete(id);
                uof.Save();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<SubjectBo> Get(Expression<Func<SubjectBo, bool>> filter = null, Func<IQueryable<SubjectBo>, IOrderedQueryable<SubjectBo>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubjectBo> Get(Expression<Func<Subject, bool>> filter = null, Func<IQueryable<Subject>, IOrderedQueryable<Subject>> orderBy = null, string includeProperties = "")
        {
            try
            {

                return uof.SubjectRepository.Get(filter, orderBy, includeProperties)
                    .Select(x => Mapper.Map<SubjectBo>(x)).ToList();
            }
            catch
            {
                throw;
            }
        }

        public SubjectBo GetByID(object id)
        {
            try
            {
                return Mapper.Map<SubjectBo>(uof.SubjectRepository.GetByID(id));
            }
            catch
            {
                throw;
            }
        }

        public void Insert(SubjectBo entity)
        {
            try
            {
                uof.SubjectRepository.Insert(Mapper.Map<Subject>(entity));
                uof.Save();
            }
            catch
            {
                throw;
            }
        }

        public void Update(SubjectBo entityToUpdate)
        {
            try
            {
                uof.SubjectRepository.Update(Mapper.Map<Subject>(entityToUpdate));
                uof.Save();
            }
            catch
            {
                throw;
            }
        }

      
    }
}
