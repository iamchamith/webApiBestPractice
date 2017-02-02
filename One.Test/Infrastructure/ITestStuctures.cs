using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Test.Infrastructure
{
    public interface IGenericTester<T,TId, TKey>  
    {
        void IntergrationTest();
        bool Insert_Success(out TKey key);
        bool Insert_Success(T item,out TKey key);
        void Insert_ValidationError();
        int Get();
        void GetSingle(TId Id, TKey key);
        void Update(T item, TId id);
        void Delete(TId id);
    }
}
