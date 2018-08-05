namespace Net.Lab.Liashkevich.Reflection.Comparer.Interfaces
{
    public interface IUserComparer
    {
        bool Compare<T>(T first, T second)
            where T : class;
    }
}
