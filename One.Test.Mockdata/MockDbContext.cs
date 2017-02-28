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
        public MockDbContext() : base(@"Data Source=DELL\SQLEXPRESS;Initial Catalog=ASS_1_Test;Integrated Security=True;Pooling=False")
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
