using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONE.API;
using ONE.Models.VM;
using System.Web.Http.Results;
using System.Threading.Tasks;
using One.Test.Mockdata;
using System.Collections.Generic;
using One.Test;
using One.Test.Infrastructure;
using System.Diagnostics;
using static One.Bo.Utility.Enums;
using One.DbService.Services;
using One.DbService.Infrastructure;

namespace One.Test.IntergrationTest
{
    [TestClass]
    public class IntergrationTest_StudentServiceController : BaseTest, IGenericTester<StudentViewModel, int, string>
    {
        StudentServiceController c;
        public IntergrationTest_StudentServiceController() : base()
        {
            var uow = new UnitOfWork(new MockDbContext(), ERunType.Test);
            c = new StudentServiceController(uow);
        }

        [TestMethod]
        [TestCategory("Student")]
        public async Task StudentServiceController_IntergrationTest()
        {
            Trace.WriteLine("Start StudentServiceController_IntergrationTest");
            try
            {
                // insert
                string email = string.Empty;
                if (!Insert_Success(out email))
                {
                    throw new Exception("Insert is not working");
                }

                //select *
                var studentId = Get();

                //select 1
                GetSingle(studentId, email);

                //update
                Update(studentId);

                //delete
                Delete(studentId);

                //insert validation
                Insert_ValidationError();

                Trace.WriteLine("Success StudentServiceController_IntergrationTest");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        public bool Insert_Success(out string key)
        {
            //arrange
            string email = $"{Guid.NewGuid()}@gmail.com";
            var model = new StudentViewModel
            {
                Address = "Test Address",
                Dob = new DateTime(1998, 2, 2),
                Email = email,
                Name = "test Name",
                Phone = "0123456789"
            };

            //act
            var response = c.Insert(model).Result;

            //asset
            Assert.IsTrue(response is OkResult, "Insert_Success");

            key = email;
            return response is OkResult;
        }

        public void Insert_ValidationError()
        {

            //arrange 
            var model = new StudentViewModel
            {
                Address = "address",
                Dob = new DateTime(1998, 2, 2),
                Email = string.Empty,
                Name = string.Empty,
                Phone = "0123456789123123123"
            };

            //act
            var response = c.Insert(model).Result as InvalidModelStateResult;
            //asset
            Assert.IsTrue(response.ModelState.Count == 3, "Insert_ValidationError");
        }

        public int Get()
        {
            //act
            var response = (OkNegotiatedContentResult<IEnumerable<StudentViewModel>>)c.Get().Result;
            //asset
            var content = (List<StudentViewModel>)response.Content;
            Assert.IsNotNull(content, "Get:-content is null");
            Assert.IsTrue(content.Count != 0, "Get:- content length is 0");
            var obj = content[content.Count - 1];

            return obj == null ? 0 : obj.Id;
        }

        public void GetSingle(int Id, string key)
        {
            //act
            var response = (OkNegotiatedContentResult<StudentViewModel>)c.Get(Id).Result;
            //asset
            var content = (StudentViewModel)response.Content;
            Assert.IsNotNull(content, "GetSingle");

            Assert.IsTrue(content.Email == key, "GetSingle");

        }

        public void Update(int id)
        {
            //arrange
            string email = $"{Guid.NewGuid()}@gmail.com";
            var model = new StudentViewModel
            {
                Id = id,
                Address = "Test Address",
                Dob = new DateTime(1998, 2, 2),
                Email = email,
                Name = "test Name",
                Phone = "0123456789"
            };

            //act
            var response = c.Update(model,id).Result;

            //asset
            Assert.IsTrue(response is OkResult, "Update");
        }

        public void Delete(int id)
        {

            var response = c.Delete(id).Result;
            //asset
            Assert.IsTrue(response is OkResult, "Delete");

        }


        public bool Insert_Success(StudentViewModel item, out string key)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentViewModel item, int id)
        {
            throw new NotImplementedException();
        }

        void IGenericTester<StudentViewModel, int, string>.IntergrationTest()
        {
            throw new NotImplementedException();
        }
    }
}
