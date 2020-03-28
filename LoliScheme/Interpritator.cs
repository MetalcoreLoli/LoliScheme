using LoliScheme.Types;

namespace LoliScheme 
{
    public static class Interpritator
    {
        public static LoliInt Ival(this string expression)
        {
            return Parser.FromString<LoliInt>(expression).Calculate();
        }
    }
}
