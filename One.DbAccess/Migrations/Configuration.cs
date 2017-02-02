namespace One.DbAccess.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<One.DbAccess.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(One.DbAccess.SchoolContext context)
        {
            context.Students.AddOrUpdate(
       new Student { Id = 1, Address = "Colombo", Dob = new DateTime(1988, 1, 24), Email = "iamchamith@gmail.com", Name = "Chamith", Phone = "0718920205" }
    );
            context.Subjects.AddOrUpdate(
              new Subject {Id = 1, Name = "DBMS", Fee = 1000 },
               new Subject { Id = 2, Name = "DAA", Fee = 800 },
                new Subject { Id = 3, Name = "DCCN", Fee = 400 }
           );
           
        }
    }
}
