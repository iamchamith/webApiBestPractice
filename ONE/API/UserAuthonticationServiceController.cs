using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using static One.Bo.Utility.Enums;

namespace ONE.API
{
    public class UserAuthonticationServiceController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetAnonymas()
        {
            return Ok("for anonimas user");
        }

        [HttpGet]
        [Authorize(Roles = "user" )]
        public async Task<IHttpActionResult> GetUser()
        {
            return Ok("for normal user " + ((ClaimsIdentity)User.Identity).Name);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> GetAdmin()
        {
            return Ok("for admin user "+((ClaimsIdentity)User.Identity).Name);
        }

        [HttpGet]
        [Authorize(Roles = "user,admin")]
        public async Task<IHttpActionResult> GetAdminAndUser()
        {
            return Ok("for admin or admin user " + ((ClaimsIdentity)User.Identity).Name);
        }
    }
}
