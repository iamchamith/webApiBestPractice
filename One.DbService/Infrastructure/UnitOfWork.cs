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
        GenericRepository<Subject> SubjectRepository { get; }
        GenericRepository<StudentSubject> StudentSubjectRepository { get; }
        GenericRepository<UserAuthontication> UserAuthonticationRepository { get; }
        void Save();
        Task SaveAsync();
        DbContext Context { get; }

    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(IContext cnt,Enums.ERunType type)
        {
            if (type == Enums.ERunType.Debug) {
                context = (SchoolContext)cnt;
            }
            else {
               context = (MockDbContext)cnt;
            }
        }
        private DbContext context;
        private GenericRepository<Student> studentRepository;
        private GenericRepository<Subject> subjectRepository;
        private GenericRepository<StudentSubject> studentSubjectRepository;
        private GenericRepository<UserAuthontication> userAuthonticationRepository;
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
        public GenericRepository<StudentSubject> StudentSubjectRepository
        {
            get
            {
                if (this.studentSubjectRepository == null)
                {
                    this.studentSubjectRepository = new GenericRepository<StudentSubject>(context);
                }
                return studentSubjectRepository;
            }
        }
        public GenericRepository<Subject> SubjectRepository
        {
            get
            {

                if (this.subjectRepository == null)
                {
                    this.subjectRepository = new GenericRepository<Subject>(context);
                }
                return subjectRepository;
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
