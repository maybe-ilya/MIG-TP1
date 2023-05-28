using MIG.API;
using UnityEngine;

namespace MIG.Character
{
    public sealed class CharacterFactory : ICharacterFactory
    {
        private readonly IGameSettings _gameSettings;
        private readonly IGameEntityService _gameEntityService;
        private readonly IWeaponFactory _weaponFactory;
        private readonly ILogService _logService;

        public CharacterFactory(
            IGameSettings gameSettings,
            IGameEntityService gameEntityService,
            IWeaponFactory weaponFactory,
            ILogService logService
            )
        {
            _gameSettings = gameSettings;
            _gameEntityService = gameEntityService;
            _weaponFactory = weaponFactory;
            _logService = logService;
        }

        public ICharacter CreateObject(Vector3 position)
        {
            var prefab = _gameSettings.CharacterPrefab;
            var characterGO = Object.Instantiate(prefab, position, Quaternion.identity);
            var character = characterGO.GetComponent<Character>();

            var weaponHandler = characterGO.GetComponent<WeaponHandler>();
            weaponHandler.Init(_weaponFactory, _logService);
            weaponHandler.ChangeAmmoLimit(AmmoType.Shells, 100);
            weaponHandler.AcquireWeapon(WeaponType.Shotgun);

            var entity = _gameEntityService.RegisterGameObject(characterGO);
            character.Init(entity, weaponHandler);

            weaponHandler.EquipWeapon(WeaponType.Shotgun);

            return character;
        }
    }
}
