using ONE.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace ONE.Controllers
{
 
    public class ValuesController : ApiController
    {
        [HttpGet]
        public string SomeText(string some) {

            return "this text for jquery load function : with "+some;
        }

        // caching demo
        public string GetTime() {

            var val = MemoryCacher.GetValue("a");
            if (val == null) {
                Thread.Sleep(5000);
                val = DateTime.Now;
                MemoryCacher.Add("a", DateTime.Now, DateTimeOffset.UtcNow.AddSeconds(10));
            }
           
            return val.ToString();
        }

        // web api rederect demo
        [HttpGet]
        public IHttpActionResult RederectToGoogle() {

            return Redirect("http://www.google.com");
        }
    }
}
