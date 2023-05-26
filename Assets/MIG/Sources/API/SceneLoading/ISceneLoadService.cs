using Cysharp.Threading.Tasks;

namespace MIG.API
{
    public interface ISceneLoadService : IService
    {
        UniTask LoadLevelAsync(int level);
    }
}
