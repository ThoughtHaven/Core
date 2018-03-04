using System;

namespace ThoughtHaven
{
    public static partial class Guard
    {
        public static Guid Empty(string paramName, Guid value)
        {
            NullOrWhiteSpace(nameof(paramName), paramName);

            if (value == Guid.Empty)
            {
                throw new ArgumentException(paramName: paramName,
                    message: $"Value cannot be an empty Guid.");
            }

            return value;
        }
    }
}