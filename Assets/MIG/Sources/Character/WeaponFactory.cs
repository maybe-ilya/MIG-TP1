using MIG.API;
using UnityEngine;

namespace MIG.Character
{
    public sealed class WeaponFactory : IWeaponFactory
    {
        private readonly IWeaponSettings _settings;
        private readonly IDamageService _damageService;
        private readonly IRandomService _randomService;

        public WeaponFactory(
            IWeaponSettings weaponSettings,
            IDamageService damageService,
            IRandomService randomService)
        {
            _settings = weaponSettings;
            _damageService = damageService;
            _randomService = randomService;
        }

        public IWeapon CreateObject(WeaponType weaponType, Transform spawnTransform)
        {
            var prefab = _settings.GetWeaponPrefab(weaponType);
            var weaponGO = Object.Instantiate(prefab, spawnTransform);
            var weapon = weaponGO.GetComponent<AbstractWeapon>();
            weapon.Init(_damageService, _randomService);
            return weapon;
        }
    }
}
