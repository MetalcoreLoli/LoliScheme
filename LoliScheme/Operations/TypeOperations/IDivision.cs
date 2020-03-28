using System;
using System.Collections.Generic;
using System.Text;

namespace LoliScheme.Operations.TypeOperations
{
    /// <summary>
    /// Обоспечивать операцию деления
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDivision<T>
    {
        /// <summary>
        /// Деление
        /// </summary>
        /// <returns>Результат деления</returns>
        T Division(T other);
    }
}
