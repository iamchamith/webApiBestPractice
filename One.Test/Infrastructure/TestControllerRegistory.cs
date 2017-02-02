using ONE.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static One.Test.Infrastructure.Enums;

namespace One.Test.Infrastructure
{

    public class TestControllerRegistory
    {
        public object GetController(ETestReg type)
        {
            switch (type)
            {
                case ETestReg.StudentServiceControllerTest:
                    return new StudentServiceController();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
