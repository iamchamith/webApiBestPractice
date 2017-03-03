using One.Domain;
using One.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.DbAccess
{
    public class SchoolContext : DbContext,IContext 
    {
        public SchoolContext(string _connectionString) : base(_connectionString)
        {

        }
        public SchoolContext() : base(@"Data Source=JET-DEV03\TOWNSUITE;Initial Catalog=ONE;Integrated Security=True;")
        {

        }
        public DbSet<Student> Students { get; set; }
  
        public DbSet<UserAuthontication> UserAuthontications
        {
            get;set;
        }

        public DbSet<School> Schools
        {
            get;set;
        }

        public DbSet<Streem> Streems
        {
            get; set;
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
