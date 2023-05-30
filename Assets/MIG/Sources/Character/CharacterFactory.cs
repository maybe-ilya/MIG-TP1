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
        private readonly ICharacterEventsInvokerService _characterEventsService;

        private const int INITIAL_AMMO_COUNT = 64;

        public CharacterFactory(
            IGameSettings gameSettings,
            IGameEntityService gameEntityService,
            IWeaponFactory weaponFactory,
            ILogService logService,
            ICharacterEventsInvokerService characterEventsService)
        {
            _gameSettings = gameSettings;
            _gameEntityService = gameEntityService;
            _weaponFactory = weaponFactory;
            _logService = logService;
            _characterEventsService = characterEventsService;
        }

        public ICharacter CreateObject(Vector3 position)
        {
            var prefab = _gameSettings.CharacterPrefab;
            var characterGO = Object.Instantiate(prefab, position, Quaternion.identity);
            var character = characterGO.GetComponent<Character>();

            var weaponHandler = characterGO.GetComponent<WeaponHandler>();
            weaponHandler.Init(_weaponFactory, _logService, _characterEventsService);
            weaponHandler.ChangeAmmoLimit(AmmoType.Shells, INITIAL_AMMO_COUNT);
            weaponHandler.AcquireWeapon(WeaponType.Shotgun);

            var entity = _gameEntityService.RegisterGameObject(characterGO);
            character.Init(entity, weaponHandler, _characterEventsService, _logService);

            weaponHandler.EquipWeapon(WeaponType.Shotgun);

            return character;
        }
    }
}
