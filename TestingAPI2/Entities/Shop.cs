using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI2.Entities
{   [Serializable]
    public class Shop      //entity
    {
        public string name;

        public Shop(string name)
        {
            this.name = name;
        }

        public Shop() { }
    }
}
