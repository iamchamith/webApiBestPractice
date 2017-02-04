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
    public class UserAuthonticationDbService  
    {
        IUnitOfWork uof;
        public UserAuthonticationDbService(IUnitOfWork _uof)
        {
            this.uof = _uof;
        }

        public UserAuthonticationBo Login(string userName, string password)
        {
            try
            {
                var res = this.uof.UserAuthonticationRepository.Get(filter: p => p.Email == userName && p.Password == password).FirstOrDefault();

                if (res == null) throw new ArgumentException("email or password invalied");
                else return Mapper.Map<UserAuthonticationBo>(res);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(UserAuthonticationBo entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAuthonticationBo> Get(Expression<Func<UserAuthonticationBo, bool>> filter = null, Func<IQueryable<UserAuthonticationBo>, IOrderedQueryable<UserAuthonticationBo>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public UserAuthonticationBo GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(UserAuthonticationBo entity)
        {
            throw new NotImplementedException();
        }



        public void Update(UserAuthonticationBo entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
