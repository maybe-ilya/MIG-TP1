namespace MIG.API
{
    public interface IRandomService : IService
    {
        int GetRandomInt(int limit);
        float GetRandomFloat(IRange<float> range);
    }
}
