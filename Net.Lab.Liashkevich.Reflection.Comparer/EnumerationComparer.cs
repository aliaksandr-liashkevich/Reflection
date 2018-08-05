using Net.Lab.Liashkevich.Reflection.Comparer.Guards;
using Net.Lab.Liashkevich.Reflection.Comparer.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Net.Lab.Liashkevich.Reflection.Comparer
{
    public class EnumerationComparer : IEnumerationComparer
    {
        private readonly IObjectComparer _primitiveComparer;

        public EnumerationComparer(IObjectComparer primitiveComparer)
        {
            ValidationGuard.CheckNull(primitiveComparer, nameof(primitiveComparer));
            _primitiveComparer = primitiveComparer;
        }

        public bool Compare(IUserComparer userComparer, object first, object second)
        {
            if ((first == null && second != null) 
                || (first != null && second == null))
            {
                return false;
            }
            else if (first != null && second != null)
            {
                IEnumerable<object> enumerableFirst, enumerableSecond;
                enumerableFirst = ((IEnumerable)first).Cast<object>();
                enumerableSecond = ((IEnumerable)second).Cast<object>();


                if (enumerableFirst.Count() != enumerableSecond.Count())
                {
                    return false;
                }
                else
                {
                    int count = enumerableFirst.Count();

                    object itemFirst, itemSecond;
                    Type itemType;
                    for (int index = 0; index < count; index++)
                    {
                        itemFirst = enumerableFirst.ElementAt(index);
                        itemSecond = enumerableSecond.ElementAt(index);
                        itemType = itemFirst.GetType();

                        if (ReflectionGuard.IsPrimitiveType(itemType))
                        {
                            if (!_primitiveComparer.Compare(itemFirst, itemSecond))
                            {
                                return false;
                            }
                        }
                        else if (!userComparer.Compare(itemFirst, itemSecond))
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
