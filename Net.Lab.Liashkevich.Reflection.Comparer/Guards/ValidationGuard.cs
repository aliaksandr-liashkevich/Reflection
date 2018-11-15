using System;

namespace Net.Lab.Liashkevich.Reflection.Comparer.Guards
{
    public static class ValidationGuard
    {
        public static void CheckNull<T>(T instance, string name)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
