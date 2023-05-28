using MIG.API;
using URandom = UnityEngine.Random;

namespace MIG.Main
{
    public sealed class RandomService : IRandomService
    {
        public int GetRandomInt(int limit) =>
            URandom.Range(0, limit);

        public float GetRandomFloat(IRange<float> range) =>
            URandom.Range(range.Min, range.Max);
    }
}
