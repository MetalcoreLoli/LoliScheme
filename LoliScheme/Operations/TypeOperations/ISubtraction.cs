using System;
using System.Collections.Generic;
using System.Text;

namespace LoliScheme.Operations.TypeOperations
{
    /// <summary>
    /// Обеспечирает реализацию операции вычитания
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISubtraction<T>
    {
        /// <summary>
        /// Вычитание
        /// </summary>
        /// <returns></returns>
        T Subtraction(T other);
    }
}
