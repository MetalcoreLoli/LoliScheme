using LoliScheme.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoliScheme.Core
{
    public static class OperationHelper
    {

        public static Operation GetOperationFromChar(this char op)
        {
            return op switch
            {
                 '+' => Operation.Add,
                 '-' => Operation.Sub,
                 '*' => Operation.Mul,
                 '/' => Operation.Div,
            };
        }
    }
}
