using System;

namespace ThoughtHaven
{
    public static partial class Guard
    {
        public static long LessThan(string paramName, long value, long minimum)
        {
            ParamName(paramName);

            if (value < minimum)
            {
                throw new ArgumentOutOfRangeException(paramName: paramName,
                    message: $"Value of {value} is less than minimum value {minimum}.");
            }

            return value;
        }

        public static long GreaterThan(string paramName, long value, long maximum)
        {
            ParamName(paramName);

            if (value > maximum)
            {
                throw new ArgumentOutOfRangeException(paramName: paramName,
                    message: $"Value of {value} is greater than maximum value {maximum}.");
            }

            return value;
        }

        public static long OutOfRange(string paramName, long value, long minimum, long maximum)
        {
            return GreaterThan(paramName, LessThan(paramName, value, minimum), maximum);
        }
    }
}