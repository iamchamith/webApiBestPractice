namespace One.DbAccess.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static Bo.Utility.Enums;
    internal sealed class Configuration : DbMigrationsConfiguration<One.DbAccess.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(One.DbAccess.SchoolContext context)
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
       new Student { Id = 31, Address = "Colombo", Dob = new DateTime(1988, 1, 24),SchoolId=1,StreemId=1, Email = "iamchamith@gmail.com", Name = "Chamith", Phone = "0718920205" },
         new Student { Id = 32, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "saranga@gmail.com", Name = "Saranga", Phone = "0718920205" },
         new Student { Id = 32, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Nuwan@gmail.com", Name = "Nuwan", Phone = "0718920205" },
         new Student { Id = 33, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Rajitha@gmail.com", Name = "Rajitha", Phone = "0718920205" },
         new Student { Id = 34, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Suranga@gmail.com", Name = "Suranga", Phone = "0718920205" },
         new Student { Id = 35, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Samantha@gmail.com", Name = "Samantha", Phone = "0718920205" },
         new Student { Id = 36, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Suranimal@gmail.com", Name = "Suranimal", Phone = "0718920205" },
         new Student { Id = 37, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Sommeshwaran@gmail.com", Name = "Sommeshwaran", Phone = "0718920205" },
         new Student { Id = 38, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Damith@gmail.com", Name = "Damith", Phone = "0718920205" },
         new Student { Id = 39, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Kasun@gmail.com", Name = "Kasun", Phone = "0718920205" },
         new Student { Id = 40, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Gihan@gmail.com", Name = "Gihan", Phone = "0718920205" },
         new Student { Id = 41, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Upul@gmail.com", Name = "Upul", Phone = "0718920205" },
         new Student { Id = 42, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Jayan@gmail.com", Name = "Jayan", Phone = "0718920205" },
         new Student { Id = 43, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Nissanka@gmail.com", Name = "Nissanka", Phone = "0718920205" },
         new Student { Id = 44, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Asanka@gmail.com", Name = "Asanka", Phone = "0718920205" },
         new Student { Id = 45, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Ravi@gmail.com", Name = "Ravi", Phone = "0718920205" },
         new Student { Id = 46, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Kumara@gmail.com", Name = "Kumara", Phone = "0718920205" },
         new Student { Id = 47, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Welgama@gmail.com", Name = "Welgama", Phone = "0718920205" },
         new Student { Id = 48, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Kosswaththa@gmail.com", Name = "Kosswaththa", Phone = "0718920205" },
         new Student { Id = 49, Address = "Gampaha", Dob = new DateTime(1988, 1, 24), SchoolId = 1, StreemId = 1, Email = "Nihal@gmail.com", Name = "Nihal", Phone = "0718920205" }
    );
           
            context.UserAuthontications.AddOrUpdate(
                new UserAuthontication {Email="iamchamith@gmail.com",Role=EUserRole.Admin,Password="123",UserId="123" },
                new UserAuthontication { Email = "damith@gmail.com", Role = EUserRole.User, Password = "123", UserId = "456" }
                );
           
        }
    }
}
