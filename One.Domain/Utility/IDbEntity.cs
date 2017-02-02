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
        DbSet<Subject> Subjects { get; set; }
        DbSet<StudentSubject> StudentSubjects { get; set; }
    }
}
