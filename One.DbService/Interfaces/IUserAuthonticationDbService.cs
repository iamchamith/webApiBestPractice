using One.Bo;
using One.DbService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.DbService.Interfaces
{
    public interface IUserAuthonticationDbService
    {
        UserAuthonticationBo Login(string userName, string password);
    }
}
