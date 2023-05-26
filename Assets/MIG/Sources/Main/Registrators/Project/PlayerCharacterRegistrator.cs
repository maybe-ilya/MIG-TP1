using MIG.Character;
using MIG.Player;
using VContainer;

namespace MIG.Main
{
    public sealed class PlayerCharacterRegistrator : ProjectRegistrator
    {
        public override void Register(IContainerBuilder builder)
        {
            builder.Register<PlayerFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlayerService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CharacterFactory>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
