using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI2
{
    public interface IParser<T>
    {
        T Parse(string source);
    }
}
