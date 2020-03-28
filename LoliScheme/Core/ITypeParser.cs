using System;
using System.Collections.Generic;
using System.Text;

namespace LoliScheme.Core
{
    public interface ITypeParser<T>
    {
        T Parser(string value);
    }
}
