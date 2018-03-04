using System;
using System.Reflection;

namespace ThoughtHaven.Reflection
{
    public static class TypeExtensions
    {
        public static bool HasDefaultConstructor(this Type type)
        {
            if (type == null) { throw new ArgumentNullException(nameof(type)); }

            foreach (var constructor in type.GetTypeInfo().DeclaredConstructors)
            {
                if (!constructor.IsConstructor) { continue; }

                if (constructor.GetParameters().Length == 0) { return true; }
            }

            return false;
        }

        public static bool Implements<TInterface>(this Type type)
            where TInterface : class
        {
            if (type == null) { throw new ArgumentNullException(nameof(type)); }

            var interfaceTypeInfo = typeof(TInterface).GetTypeInfo();

            if (!interfaceTypeInfo.IsInterface)
            { throw new InvalidOperationException("Only interfaces can be implemented."); }

            return interfaceTypeInfo.IsAssignableFrom(type.GetTypeInfo());
        }
    }
}