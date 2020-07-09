using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jsonweb
{
    public class TestObject
    {
       public string id = Guid.NewGuid().ToString();
        int x;
        int y;
        string s;
       public TestObject(int x, int y, string s)
        {
            this.x = x;
            this.y = y;
            this.s = s;
        }
    }
}
