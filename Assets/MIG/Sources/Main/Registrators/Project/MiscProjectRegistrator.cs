using MIG.API;
using VContainer;
using UnityEngine;

namespace MIG.Main
{
    public class MiscProjectRegistrator : ProjectRegistrator
    {
        [SerializeField]
        [CheckObject]
        private GameSettings _gameSettings;

        public override void Register(IContainerBuilder builder)
        {
            builder.Register<ISceneLoadService, SceneLoadService>(Lifetime.Singleton);
            builder.RegisterInstance<IGameSettings>(_gameSettings);
        }
    }
}
