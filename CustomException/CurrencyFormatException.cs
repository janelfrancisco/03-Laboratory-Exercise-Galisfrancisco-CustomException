using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    internal class CurrencyFormatException : Exception
    {
        public CurrencyFormatException(string varName) : base(varName) { }
    }
}
