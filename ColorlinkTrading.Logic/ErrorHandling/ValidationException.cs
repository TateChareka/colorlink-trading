using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Logic
{
    public class SystemValidationException : Exception
    {
        public SystemValidationException(string message) : base(message)
        { }
    }
}
