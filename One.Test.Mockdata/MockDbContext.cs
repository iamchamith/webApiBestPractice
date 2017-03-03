using One.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using One.Domain;

namespace One.Test.Mockdata
{
    public class MockDbContext : DbContext, IContext
    {
        public MockDbContext() : base(@"Data Source=JET-DEV03\TOWNSUITE;Initial Catalog=ONE_TEST;Integrated Security=True;")
        {

        }
        public DbSet<Student> Students
        { get; set; }
        public DbSet<School> Schools
        {
            get; set;
        }

        public DbSet<Streem> Streems
        {
            get; set;
        }
        public DbSet<UserAuthontication> UserAuthontications
        {
            get;set;
        }

        public DbSet<Error> Errors
        {
            get;set;
        }

        public DbSet<StudentOrder> StudentOrders
        {
            get;set;
        }
    }
}
