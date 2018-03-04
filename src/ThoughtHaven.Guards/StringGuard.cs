using System;

namespace ThoughtHaven
{
    public static partial class Guard
    {
        public static string NullOrEmpty(string paramName, string value)
        {
            if (string.IsNullOrEmpty(Null(paramName, value)))
            {
                throw new ArgumentException(paramName: paramName,
                    message: "Value cannot be empty.");
            }

            return value;
        }

        public static string NullOrWhiteSpace(string paramName, string value)
        {
            if (string.IsNullOrWhiteSpace(NullOrEmpty(paramName, value)))
            {
                throw new ArgumentException(paramName: paramName,
                    message: "Value cannot be white space.");
            }

            return value;
        }
    }
}