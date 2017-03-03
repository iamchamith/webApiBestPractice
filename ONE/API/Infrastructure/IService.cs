using ONE.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ONE.API
{

    public interface IService<T>
    {
        Task<IHttpActionResult> Insert(T item);
        Task<IHttpActionResult> Delete(int id);
        Task<IHttpActionResult> Update(T item, int id);
        Task<IHttpActionResult> Get(int skip, int take, string sortBy, bool isASC, string search);
        Task<IHttpActionResult> Get(int id);
        Task<IHttpActionResult> SaveOrder(IEnumerable<EntityOrderViewModel> list);
        Task<IHttpActionResult> GetOrder();
    }
}
