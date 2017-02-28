using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Domain.Utility
{
    public interface IContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<School> Schools { get; set; }
        DbSet<Streem> Streems { get; set; }
        DbSet<Error> Errors { get; set; }
        DbSet<StudentOrder> StudentOrders { get; set; }
        DbSet<UserAuthontication> UserAuthontications { get; set; }
    }
}
