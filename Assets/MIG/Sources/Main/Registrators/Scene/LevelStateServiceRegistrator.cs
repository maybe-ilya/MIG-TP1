using MIG.API;
using MIG.Levels;
using VContainer;

namespace MIG.Main
{
    public sealed class LevelStateServiceRegistrator : SceneRegistrator
    {
        public override void Register(IContainerBuilder builder)
        {
            builder.Register<LevelStateService>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<AbstractLevelState, BootstrapLevelState>(Lifetime.Transient);
            builder.Register<AbstractLevelState, BattleLevelState>(Lifetime.Transient);
            builder.Register<AbstractLevelState, WinLevelState>(Lifetime.Transient);
            builder.Register<AbstractLevelState, LoseLevelState>(Lifetime.Transient);

            builder.RegisterBuildCallback(container => container.Resolve<ILevelEntryPoint>().LaunchLevel());
        }
    }
}
