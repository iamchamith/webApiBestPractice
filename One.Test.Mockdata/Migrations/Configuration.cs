namespace One.Test.Mockdata.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static Bo.Utility.Enums;
    internal sealed class Configuration : DbMigrationsConfiguration<One.Test.Mockdata.MockDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(One.Test.Mockdata.MockDbContext context)
        {
            context.Students.AddOrUpdate(
   new Student { Id = 1, Address = "Colombo", Dob = new DateTime(1988, 1, 24), Email = "iamchamith@gmail.com", Name = "Chamith", Phone = "0718920205" }
);
            context.Subjects.AddOrUpdate(
              new Subject { Id = 1, Name = "DBMS", Fee = 1000 },
               new Subject { Id = 2, Name = "DAA", Fee = 800 },
                new Subject { Id = 3, Name = "DCCN", Fee = 400 }
           );

            context.UserAuthontications.AddOrUpdate(
                new UserAuthontication { Email = "iamchamith@gmail.com", Role = EUserRole.Admin, Password = "123", UserId = "123" },
                new UserAuthontication { Email = "damith@gmail.com", Role = EUserRole.User, Password = "123", UserId = "456" }
                );
        }
    }
}
