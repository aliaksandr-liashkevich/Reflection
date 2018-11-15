using Net.Lab.Liashkevich.Reflection.Comparer.Interfaces;
using System;

namespace Net.Lab.Liashkevich.Reflection.Comparer
{
    public class PrimitiveComparer : IObjectComparer
    {
        public bool Compare(object first, object second)
        {
            IComparable selfComparer = first as IComparable;

            if ((first == null && second != null)
                || (first != null && second == null))
            {
                return false;
            }
            else if (selfComparer != null && selfComparer.CompareTo(second) != 0)
            {
                return false;
            }
            else if (!Equals(first, second))
            {
                return false;
            }

            return true;
        }
    }
}
