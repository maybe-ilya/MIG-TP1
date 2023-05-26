using MIG.API;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace MIG.Main
{
    internal sealed class SceneLoadService : ISceneLoadService
    {
        public async UniTask LoadLevelAsync(int level)
        {
            await SceneManager.LoadSceneAsync(level);
        }
    }
}
