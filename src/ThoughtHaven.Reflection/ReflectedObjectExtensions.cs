using System;

namespace ThoughtHaven.Reflection
{
    public static class ReflectedObjectExtensions
    {
        public static bool Implements<T>(this object @object)
            where T : class
        {
            if (@object == null) { throw new ArgumentNullException(nameof(@object)); }

            return @object.GetType().Implements<T>();
        }
    }
}