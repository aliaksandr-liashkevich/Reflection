using Net.Lab.Liashkevich.Reflection.Comparer.Guards;
using Net.Lab.Liashkevich.Reflection.Comparer.Interfaces;
using System;
using System.Reflection;

namespace Net.Lab.Liashkevich.Reflection.Comparer
{
    public class UserComparer : IUserComparer
    {
        private readonly IObjectComparer _primitiveComparer;
        private readonly IEnumerationComparer _enumerationComparer;

        public UserComparer(IObjectComparer primitiveComparer,
            IEnumerationComparer enumerationComparer)
        {
            ValidationGuard.CheckNull(primitiveComparer, nameof(primitiveComparer));
            ValidationGuard.CheckNull(enumerationComparer, nameof(enumerationComparer));

            _primitiveComparer = primitiveComparer;
            _enumerationComparer = enumerationComparer;
        }

        public bool Compare<T>(T first, T second)
            where T : class
        {
            if ((first == null && second != null) 
                || (first != null && second == null))
            {
                return false;
            } 
            else if (first != null && second != null)
            {
                PropertyInfo[] properties = first.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                object propertyValueFirst, propertyValueSecond;
                Type propertyType;
                foreach (PropertyInfo property in properties)
                {
                    if (property.CanRead)
                    {
                        propertyValueFirst = property.GetValue(first, null);
                        propertyValueSecond = property.GetValue(second, null);

                        propertyType = property.PropertyType;

                        if (ReflectionGuard.IsPrimitiveType(propertyType))
                        {
                            if (!_primitiveComparer.Compare(propertyValueFirst, propertyValueSecond))
                            {
                                return false;
                            }
                        }
                        else if (ReflectionGuard.IsEnumerableType(propertyType))
                        {
                            if (!_enumerationComparer.Compare(this, propertyValueFirst, propertyValueSecond))
                            {
                                return false;
                            }
                        }
                        else if (ReflectionGuard.IsClass(propertyType))
                        {
                            if (!this.Compare(propertyValueFirst, propertyValueSecond))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
