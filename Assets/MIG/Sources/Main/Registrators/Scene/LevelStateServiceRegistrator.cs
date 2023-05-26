using MIG.API;
using MIG.Levels;
using VContainer;

namespace MIG.Main
{
    public sealed class LevelStateServiceRegistrator : SceneRegistrator
    {
        public override void Register(IContainerBuilder builder)
        {
            builder.Register<LevelStateService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<LevelStateMachineFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterBuildCallback(container => container.Resolve<ILevelEntryPoint>().LaunchLevel());
        }
    }
}
