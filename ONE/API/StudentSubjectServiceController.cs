using AutoMapper;
using One.Bo;
using One.DbService.Infrastructure;
using One.DbService.Interfaces;
using One.DbService.Services;
using ONE.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ONE.API
{
    public class StudentSubjectServiceController : BaseServiceController, IService<StudentSubjectViewModel>
    {
        public Task<IHttpActionResult> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IHttpActionResult> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IHttpActionResult> GetSingle(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<IHttpActionResult> Insert(StudentSubjectViewModel item)
        {
            throw new NotImplementedException();
        }

        public Task<IHttpActionResult> Update(StudentSubjectViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
