using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public class ZooException : Exception
    {
        public ZooException(string message) : base(message)
        {
        }
    }
}
