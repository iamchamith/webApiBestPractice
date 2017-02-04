using One.Bo;
using One.DbService.Infrastructure;
using One.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace One.DbService.Interfaces
{
    public interface IStudentDbService : IRepositoryRead<StudentBo>, IRepositoryUpdateAsync<StudentBo>
    {
        IEnumerable<StudentBo> Get(Expression<Func<Student, bool>> filter = null, Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null, string includeProperties = "");
    }
}
