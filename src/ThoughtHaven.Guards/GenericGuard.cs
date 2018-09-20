using System;

namespace ThoughtHaven
{
    public static partial class Guard
    {
        public static T Null<T>(string paramName, T value)
        {
            ParamName(paramName);
            
            if (value == null) { throw new ArgumentNullException(paramName); }

            return value;
        }
        
        private static void ParamName(string paramName)
        {
            if (paramName is null)
            { throw new ArgumentNullException(paramName: nameof(paramName)); }

            if (paramName == string.Empty)
            {
                throw new ArgumentException(
                    paramName: nameof(paramName),
                    message: "Value cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(paramName))
            {
                throw new ArgumentException(
                    paramName: nameof(paramName),
                    message: "Value cannot be white space.");
            }
        }
    }
}