﻿using One.Bo.Utility;
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
        void Save();
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

        public void Save()
        {
            context.SaveChanges();
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