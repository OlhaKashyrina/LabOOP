using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public class CannotAddUnitException : ZooException
    {
        public CannotAddUnitException(string message) : base(message)
        {
        }
    }
}
