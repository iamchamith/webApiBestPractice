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
            context.Streems.AddOrUpdate(
                  new Streem { Id = 1, Name = "Bio" },
                   new Streem { Id = 2, Name = "Maths" },
                    new Streem { Id = 3, Name = "Commarce" },
                     new Streem { Id = 4, Name = "Arts" }
                 );
            context.Schools.AddOrUpdate(
                new School { Id = 1, Name = "DMC" },
                 new School { Id = 2, Name = "RC" },
                  new School { Id = 3, Name = "HCC" },
                   new School { Id = 4, Name = "BC" }
               );
            context.Students.AddOrUpdate(
   new Student { Id = 1, Address = "Colombo", Dob = new DateTime(1988, 1, 24), StreemId=1,SchoolId=1, Email = "iamchamith@gmail.com", Name = "Chamith", Phone = "0718920205" }
);
           
            context.UserAuthontications.AddOrUpdate(
                new UserAuthontication { Email = "iamchamith@gmail.com", Role = EUserRole.Admin, Password = "123", UserId = "123" },
                new UserAuthontication { Email = "damith@gmail.com", Role = EUserRole.User, Password = "123", UserId = "456" }
                );
        }
    }
}
