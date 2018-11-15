using System;
using System.Collections;

namespace Net.Lab.Liashkevich.Reflection.Comparer.Guards
{
    public static class ReflectionGuard
    {
        public static bool IsPrimitiveType(Type type)
        {
            ValidationGuard.CheckNull(type, nameof(type));

            return typeof(IComparable).IsAssignableFrom(type) 
                || type.IsPrimitive 
                || type.IsValueType;
        }

        public static bool IsEnumerableType(Type type)
        {
            ValidationGuard.CheckNull(type, nameof(type));

            return (typeof(IEnumerable)).IsAssignableFrom(type);
        }

        public static bool IsClass(Type type)
        {
            ValidationGuard.CheckNull(type, nameof(type));

            return type.IsClass;
        }
    }
}
