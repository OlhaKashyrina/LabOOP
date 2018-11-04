using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public class CannotRemoveUnitException : ZooException
    {
        public CannotRemoveUnitException(string message) : base(message)
        {
        }
    }
}
