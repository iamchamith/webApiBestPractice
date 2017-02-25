using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.AutomationTest.automations
{
    interface IAutomationTest
    {
        void Create();
        void Update();
        void Delete();
        void Read();
        void SetValues();
        void SetValuesWithoutValidation();
    }
}
