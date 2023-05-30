using MIG.API;
using MIG.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MIG.Main
{
    public sealed class UIProjectRegistrator : ProjectRegistrator
    {
        [SerializeField]
        [CheckObject]
        private WindowsSettings _windowSettings;

        [SerializeField]
        [CheckObject]
        private GlobalCanvas _canvasPrefab;

        [SerializeField]
        [CheckObject]
        private GlobalEventSystem _eventSystemPrefab;

        public override void Register(IContainerBuilder builder)
        {
            builder.Register<UIService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterInstance<IWindowSettings>(_windowSettings);
            builder.Register<MainMenuWindowFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<VictoryWindowFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DefeatWindowFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CombatHUDWindowFactory>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.RegisterComponentInNewPrefab(_canvasPrefab, Lifetime.Singleton)
                .DontDestroyOnLoad()
                .AsImplementedInterfaces();

            builder.RegisterComponentInNewPrefab(_eventSystemPrefab, Lifetime.Singleton)
                .DontDestroyOnLoad()
                .AsImplementedInterfaces();

            builder.Register<UIDependencies>(Lifetime.Transient).AsSelf();
            builder.RegisterBuildCallback(container => container.Resolve<UIDependencies>());
        }
    }
}
