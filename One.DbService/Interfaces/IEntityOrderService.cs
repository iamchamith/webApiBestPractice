using One.Bo;
using One.DbService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.DbService.Interfaces
{
    public interface IEntityOrderService : IRepositoryRead<EntityOrderBo>, IRepositoryUpdateAsync<EntityOrderBo>
    {
        Task InsertAsync(List<EntityOrderBo> list);
        Task DeleteAsync();
        Task InsertTrigger(int entityId);
    }
}
