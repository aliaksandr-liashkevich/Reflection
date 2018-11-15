namespace Net.Lab.Liashkevich.Reflection.Comparer.Interfaces
{
    public interface IEnumerationComparer
    {
        bool Compare(IUserComparer comparer, object first, object second);
    }
}
