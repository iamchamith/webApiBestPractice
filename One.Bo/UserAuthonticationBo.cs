using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static One.Bo.Utility.Enums;

namespace One.Bo
{
    public class UserAuthonticationBo
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EUserRole Role { get; set; }
    }
}
