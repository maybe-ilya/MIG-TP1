namespace MIG.API
{
    public interface IFactory<T>
    {
        T CreateObject();
    }
}
