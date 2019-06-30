using System;

namespace ThoughtHaven
{
    public static partial class Guard
    {
        public static double LessThan(string paramName, double value, double minimum)
        {
            ParamName(paramName);

            if (value < minimum)
            {
                throw new ArgumentOutOfRangeException(paramName: paramName,
                    message: $"Value of {value} is less than minimum value {minimum}.");
            }

            return value;
        }

        public static double GreaterThan(string paramName, double value, double maximum)
        {
            ParamName(paramName);

            if (value > maximum)
            {
                throw new ArgumentOutOfRangeException(paramName: paramName,
                    message: $"Value of {value} is greater than maximum value {maximum}.");
            }

            return value;
        }

        public static double OutOfRange(string paramName, double value, double minimum, double maximum)
        {
            return GreaterThan(paramName, LessThan(paramName, value, minimum), maximum);
        }
    }
}