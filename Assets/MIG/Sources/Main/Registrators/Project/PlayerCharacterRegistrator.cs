using MIG.Character;
using MIG.Player;
using VContainer;
using UnityEngine;
using MIG.API;

namespace MIG.Main
{
    public sealed class PlayerCharacterRegistrator : ProjectRegistrator
    {
        [SerializeField]
        [CheckObject]
        private WeaponSettings _weaponSettings;

        public override void Register(IContainerBuilder builder)
        {
            builder.Register<PlayerService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlayerFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CharacterFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CharacterCameraFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterInstance<IWeaponSettings>(_weaponSettings);
            builder.Register<WeaponFactory>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
