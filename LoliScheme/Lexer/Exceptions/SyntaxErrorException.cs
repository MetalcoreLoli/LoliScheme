using System;
using System.Collections.Generic;
using System.Text;

namespace LoliScheme.Lexer.Exceptions
{
    public class SyntaxErrorException : Exception
    {
        public SyntaxErrorException(string message) : base(message)
        {
        }

        public SyntaxErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
