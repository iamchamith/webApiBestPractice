using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Test.Infrastructure
{
    public interface IGeneticTesterUnitTest
    {
        bool Insert();
        int Get();
        void GetSingle();
        void Update();
        void Delete();
    }
}
