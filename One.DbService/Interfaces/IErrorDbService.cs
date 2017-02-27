using One.Bo;
using One.DbService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.DbService.Interfaces
{
    public interface IErrorDbService : IRepositoryRead<ErrorBo>, IRepositoryUpdateAsync<ErrorBo>
    {
        IEnumerable<ErrorBo> Get(out int recodeCount, int skip = 0, int take = 0, string sortBy = "", bool isASC = false, string search = null);
    }
}
