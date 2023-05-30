using MIG.API;
using MIG.GameEntities;
using VContainer;

namespace MIG.Main
{
    public sealed class GameRegistrator : ProjectRegistrator
    {
        public override void Register(IContainerBuilder builder)
        {
            builder.Register<AbstractGameState, BootstrapGameState>(Lifetime.Transient);
            builder.Register<AbstractGameState, MainMenuGameState>(Lifetime.Transient);
            builder.Register<AbstractGameState, DemoBattleGameState>(Lifetime.Transient);
            builder.Register<AbstractGameState, QuitGameState>(Lifetime.Transient);

            builder.Register<GameStateService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GameEntityService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DamageService>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.RegisterBuildCallback(container => container.Resolve<IGameEntryPoint>().LaunchGame());
        }
    }
}
