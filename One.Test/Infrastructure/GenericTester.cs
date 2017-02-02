using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONE.API;
using ONE.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using static One.Test.Infrastructure.Enums;

namespace One.Test.Infrastructure
{
    public class GenericTester<T, TId, TKey> : IGenericTester<T, TId, TKey>
    {
        public void Delete(TId id)
        {
            throw new NotImplementedException();
        }

        public int Get()
        {
            throw new NotImplementedException();
        }

        public void GetSingle(TId Id, TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Insert_Success(out TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Insert_Success(T item, out TKey key)
        {
            throw new NotImplementedException();
        }

        public void Insert_ValidationError()
        {
            throw new NotImplementedException();
        }

        public void IntergrationTest()
        {
            throw new NotImplementedException();
        }

        public void Update(T item, TId id)
        {
            throw new NotImplementedException();
        }
    }
}
