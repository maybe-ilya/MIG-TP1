using MIG.API;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace MIG.Main
{
    internal sealed class SceneLoadService : ISceneLoadService
    {
        private readonly IReadOnlyList<IBeforeSceneLoadListener> _beforeSceneLoadListeners;

        public SceneLoadService(
            IReadOnlyList<IBeforeSceneLoadListener> beforeSceneLoadListeners)
        {
            _beforeSceneLoadListeners = beforeSceneLoadListeners;
        }

        public async UniTask LoadLevelAsync(int level)
        {
            foreach (var listener in _beforeSceneLoadListeners)
            {
                listener.OnBeforeSceneLoad();
            }

            await SceneManager.LoadSceneAsync(level);
        }
    }
}
