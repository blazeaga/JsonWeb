using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jsonweb
{
    public class DbService
    {

        public  static TestObject Search(string value)
        {
            return new TestObject(1, 2, "x");
        }
        public  static void Upsert(TestObject obj)
        {
                if(obj.id != null)
            {
                //update
            }
            else
            {
                //insert
            }
        }

        public static void Update(int id, TestObject obj)
        {
            //update object with linq
        }
        public static void Delete(int id)
        {
            //delete object with linq
        }
    }
}
