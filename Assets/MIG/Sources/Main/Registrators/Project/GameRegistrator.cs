using MIG.API;
using VContainer;

namespace MIG.Main
{
    public sealed class GameRegistrator : ProjectRegistrator
    {
        public override void Register(IContainerBuilder builder)
        {
            builder.Register<IGameStateMachineFactory, GameStateMachineFactory>(Lifetime.Singleton);
            builder.Register<GameStateService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterBuildCallback(container => container.Resolve<IGameEntryPoint>().LaunchGame());
        }
    }
}
