using System;
using System.Collections.Generic;
using System.Text;

namespace LoliScheme.Operations.TypeOperations
{
    /// <summary>
    /// Обеспечивает реализацию операции сложения
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAdd<T>
    {
        /// <summary>
        /// Сложение
        /// </summary>
        /// <returns>Результат сложения</returns>
        T Add(T other);
    }
}
