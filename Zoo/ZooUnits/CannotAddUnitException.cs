using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    class CannotAddUnitException : ZooException
    {
        public CannotAddUnitException(string message) : base(message)
        {
        }
    }
}
