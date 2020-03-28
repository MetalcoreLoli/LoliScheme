using System;
using System.Collections.Generic;
using System.Text;

namespace LoliScheme.Operations.TypeOperations
{
    /// <summary>
    /// Интерфейс обеспечивающий операцию Умножение
    /// </summary>
    public interface IMultiplication<T>
    {
        /// <summary>
        /// Умножение
        /// </summary>
        /// <returns>Результат умножения</returns>
        T Multiplication(T other);
    }
}
