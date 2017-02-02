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

namespace One.Test.IntergrationTest
{
    [TestClass]
    public class StudentServiceControllerIntergrationTest : BaseTest, IGenericTester<StudentViewModel,int, string>
    {
        StudentServiceController c;
        public StudentServiceControllerIntergrationTest() : base()
        {
            c = new StudentServiceController(new MockDbContext());
        }

        [TestMethod]
        [TestCategory("Student")]
        public async Task IntergrationTest()
        {
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
            // arrange
            var c = new StudentServiceController(new MockDbContext());
            //act
            var response = (OkNegotiatedContentResult<IEnumerable<StudentViewModel>>)c.Get().Result;
            //asset
            var content = (List<StudentViewModel>)response.Content;
            Assert.IsNotNull(content, "Get");

            var obj = content[content.Count - 1];
             
            return obj == null ? 0 : obj.Id;
        }

        public void GetSingle(int Id, string key)
        {
            // arrange
            var c = new StudentServiceController(new MockDbContext());
            //act
            var response = (OkNegotiatedContentResult<StudentViewModel>)c.GetSingle(Id).Result;
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
            var response = c.Update(model).Result;

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
