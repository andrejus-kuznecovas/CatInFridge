using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI2.Entities
{
    [Serializable]
    public class Category
    {
        public string type;

        public Category(string name)
        {
            this.type = name;
        }

        public Category() { }
    }
}
