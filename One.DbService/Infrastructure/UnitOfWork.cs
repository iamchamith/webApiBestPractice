using One.Bo.Utility;
using One.DbAccess;
using One.Domain;
using One.Domain.Utility;
using One.Test.Mockdata;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.DbService.Infrastructure
{
    public interface IUnitOfWork
    {
        GenericRepository<Student> StudentRepository { get; }
        GenericRepository<UserAuthontication> UserAuthonticationRepository { get; }
        GenericRepository<School> SchoolRepository { get; }
        GenericRepository<Streem> StreemRepository { get; }
        GenericRepository<Error> ErrorRepository { get; }
        void Save();
        Task SaveAsync();
        DbContext Context { get; }

    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(IContext cnt, Enums.ERunType type)
        {
            if (type == Enums.ERunType.Debug)
            {
                context = (SchoolContext)cnt;
                context.Configuration.AutoDetectChangesEnabled=false;
            }
            else
            {
                context = (MockDbContext)cnt;
            }
        }
        private DbContext context;
        private GenericRepository<Student> studentRepository;
        private GenericRepository<UserAuthontication> userAuthonticationRepository;
        private GenericRepository<Streem> streemRepository;
        private GenericRepository<School> schoolRepository;
        private GenericRepository<Error> errorRepository;
        public DbContext Context
        {
            get
            {
                return context;
            }
        }
        public GenericRepository<Student> StudentRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }
        public GenericRepository<UserAuthontication> UserAuthonticationRepository
        {
            get
            {

                if (this.userAuthonticationRepository == null)
                {
                    this.userAuthonticationRepository = new GenericRepository<UserAuthontication>(context);
                }
                return userAuthonticationRepository;
            }
        }

        public GenericRepository<School> SchoolRepository
        {
            get
            {
                if (this.schoolRepository == null)
                {
                    this.schoolRepository = new GenericRepository<School>(context);
                }
                return schoolRepository;
            }
        }

        public GenericRepository<Streem> StreemRepository
        {
            get
            {
                if (this.streemRepository == null)
                {
                    this.streemRepository = new GenericRepository<Streem>(context);
                }
                return streemRepository;
            }
        }
 
        GenericRepository<Error> IUnitOfWork.ErrorRepository
        {
            get
            {
                if (this.errorRepository == null)
                {
                    this.errorRepository = new GenericRepository<Error>(context);
                }
                return errorRepository;
            }
        }

        DbContext IUnitOfWork.Context
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
