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
        Task<IHttpActionResult> Delete(int Id);
        Task<IHttpActionResult> Update(T item);
        Task<IHttpActionResult> Get();
        Task<IHttpActionResult> Get(int studentId);
    }
}
