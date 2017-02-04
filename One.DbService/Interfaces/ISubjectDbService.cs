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
    public  interface ISubjectDbService : IRepositoryRead<SubjectBo>,IRepositoryUpdate<SubjectBo>
    {
        IEnumerable<Subject> Get(Expression<Func<Subject, bool>> filter = null, Func<IQueryable<Subject>, IOrderedQueryable<Subject>> orderBy = null, string includeProperties = "");
    }
}
