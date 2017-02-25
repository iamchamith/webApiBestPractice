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
    public interface ISchoolDbService: IRepositoryRead<SchoolBo>
    {
        IEnumerable<SchoolBo> Get(out int recodeCount, int skip = 0, int take = 0, string sortBy = "", bool isASC = false, string search = null);
    }
}
