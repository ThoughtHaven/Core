using System;
using System.Collections.Generic;

namespace ThoughtHaven
{
    public static partial class Guard
    {
        public static IEnumerable<T> NoItems<T>(string paramName, IEnumerable<T> value)
        {
            if (!HasItems(Null(paramName, value!)))
            {
                throw new ArgumentException(paramName: paramName,
                    message: $"Value cannot contain no items.");
            }

            return value;
        }

        public static IEnumerable<T> NullItem<T>(string paramName, IEnumerable<T> value)
        {
            ParamName(paramName);

            var index = 0;
            foreach (var item in Null(paramName, value))
            {
                if (item == null)
                {
                    throw new ArgumentException(paramName: paramName,
                        message: $"Collection contains a null item at the index: {index}.");
                }

                index++;
            }

            return value;
        }

        private static bool HasItems<T>(IEnumerable<T> items)
        {
            foreach (var _ in items ?? Array.Empty<T>()) { return true; }

            return false;
        }
    }
}