using Net.Lab.Liashkevich.Reflection.Comparer.Interfaces;

namespace Net.Lab.Liashkevich.Reflection.Comparer.Creators
{
    public class UserComparerCreator : IUserComparerCreator
    {
        // Only for tests
        public IUserComparer Create()
        {
            var primitiveComparer = new PrimitiveComparer();
            var enumerableComparer = new EnumerationComparer(primitiveComparer);

            return new UserComparer(primitiveComparer, enumerableComparer);
        }
    }
}
