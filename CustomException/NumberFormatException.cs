using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    internal class NumberFormatException : Exception
    {
            public NumberFormatException(string varName) : base(varName) { }
        
    }
}

