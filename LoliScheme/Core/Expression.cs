using LoliScheme.Operations;
using LoliScheme.Operations.TypeOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoliScheme.Core
{
    /// <summary>
    /// Выражение
    /// </summary>
    public class Expression<T> where T: IAdd<T>, ISubtraction<T>, IMultiplication<T>, IDivision<T>
    {
        /// <summary>
        /// Значание выражения
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Тип операции
        /// </summary>
        public Operation Operation { get; private set; }

        /// <summary>
        /// Левая ветвь
        /// </summary>
        public Expression<T> Left { get; set; }

        /// <summary>
        /// Правая ветвь
        /// </summary>
        public Expression<T> Right { get; set; }

        public Expression(
            Operation operation,
            Expression<T> left,
            Expression<T> right) 
            : this(default, operation, left, right) 
        { }
        
        public Expression(
            T value,
            Operation operation = Operation.None,
            Expression<T> left = null,
            Expression<T> right = null
            )
        {
            Value = value;
            Operation = operation;
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Методы вычисляет резульат выражения
        /// </summary>
        /// <returns></returns>
        public T Calculate()
        {
            return Operation switch 
            {
                Operation.Add => Left.Calculate().Add(Right.Calculate()),
                Operation.Sub => Left.Calculate().Subtraction(Right.Calculate()),
                Operation.Mul => Left.Calculate().Multiplication(Right.Calculate()),
                Operation.Div => Left.Calculate().Division(Right.Calculate()),
                Operation.None => Value
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Expression<T> other)
                return Calculate().Equals(other.Calculate());
            else
                throw new Exception("Wrong type !!!");
        }


        public override string ToString()
        {
            if (Left != null && Right != null && Operation != Operation.None)
            {
                char op = Operation switch 
                {
                    Operation.Add => '+',
                    Operation.Sub => '-',
                    Operation.Mul => '*',
                    Operation.Div => '/',
                    Operation.None => throw new Exception($"Broken Expression with type {typeof(T).ToString()}"),
                    _ => throw new Exception($"Broken Expression with type {typeof(T).ToString()}")
                };
                return $"({op} {(Left.ToString())} {(Right.ToString())})";
            }
            else
                return Value.ToString();
        }
    }
}
