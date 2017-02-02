using ONE.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static One.Bo.Utility.Enums;

namespace ONE.API
{
    [RoutePrefix("api/student")]
    public class BaseServiceController : ApiController
    {
        protected string connectionString = string.Empty;
         
        public BaseServiceController(ERunType type = ERunType.Debug)
        {

            switch (type)
            {
                case ERunType.Debug:
                    this.connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    break;
                case ERunType.Test:
                    new AutomapperConfig().Register();
                    break;
                case ERunType.Release:
                    break;
                default:
                    throw new ArgumentException();
            }
           
             
        }
    }
}
