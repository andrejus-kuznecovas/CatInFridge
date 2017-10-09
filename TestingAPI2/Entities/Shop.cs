using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI2.Entities
{
    class Shop      //entity
    {
        string name;
        string exp;     //expression

        public Shop(string name, string exp)
        {
            this.name = name;
            this.exp = exp;
        }
    }
}
