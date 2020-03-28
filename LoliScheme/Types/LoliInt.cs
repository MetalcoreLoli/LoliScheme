using LoliScheme.Core;
using LoliScheme.Operations.TypeOperations;
using System;

namespace LoliScheme.Types
{
    public readonly struct LoliInt : IAdd<LoliInt>, ISubtraction<LoliInt>, IDivision<LoliInt>, IMultiplication<LoliInt>, ITypeParser<LoliInt>
    {
        public Int32 Value { get; }
        public LoliInt(int value) => Value = value;
        public LoliInt Add(LoliInt other)               => new LoliInt(Value + other.Value);
        public LoliInt Division(LoliInt other)          => new LoliInt(Value / other.Value);
        public LoliInt Multiplication(LoliInt other)    => new LoliInt(Value * other.Value);
        public LoliInt Subtraction(LoliInt other)       => new LoliInt(Value - other.Value);

        public static implicit operator LoliInt(int value) => new LoliInt(value);

        public override bool Equals(object obj)
        {
            if (obj is LoliInt other)
                return Value == other.Value;
            else
                throw new Exception("Wrong type");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(LoliInt left, LoliInt right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LoliInt left, LoliInt right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public LoliInt Parser(string value)
        {
            return Int32.Parse(value);
        }
    }
}
