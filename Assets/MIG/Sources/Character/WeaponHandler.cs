using MIG.API;
using System.Collections.Generic;
using UnityEngine;

namespace MIG.Character
{
    public sealed class WeaponHandler :
        MonoBehaviour,
        IWeaponHandler,
        IWeaponAmmoHandler
    {
        [SerializeField]
        [CheckObject]
        private Transform _weaponSocket;

        private readonly HashSet<WeaponType> _availableWeapons = new();
        private readonly Dictionary<WeaponType, IWeapon> _weaponCache = new();
        private readonly Dictionary<AmmoType, int> _ammoResources = new();
        private readonly Dictionary<AmmoType, IntRange> _ammoLimits = new();

        private IWeapon _currentWeapon;

        private IWeaponFactory _weaponFactory;
        private ILogService _logService;
        private ICharacterEventsInvokerService _characterEventsService;
        private readonly LogChannel _logChannel = "WEAPON";

        private bool IsAnyWeaponEquipped => _currentWeapon != null;

        public void Init(
            IWeaponFactory weaponFactory,
            ILogService logService, 
            ICharacterEventsInvokerService characterEventsService)
        {
            _weaponFactory = weaponFactory;
            _logService = logService;
            _characterEventsService = characterEventsService;
        }

        public void AcquireWeapon(WeaponType weaponType)
        {
            if (_availableWeapons.Add(weaponType))
            {
                _logService.Info(_logChannel, $"Acquired {weaponType} weapon");
            }
            else
            {
                _logService.Warning(_logChannel, $"{weaponType} weapon is already acquired");
            }
        }

        public void EquipWeapon(WeaponType newWeaponType)
        {
            if (!_availableWeapons.Contains(newWeaponType))
            {
                _logService.Warning(_logChannel, $"{newWeaponType} weapon isn't available");
                return;
            }
            UnequipWeapon();

            if (!_weaponCache.TryGetValue(newWeaponType, out _currentWeapon))
            {
                _currentWeapon = _weaponFactory.CreateObject(newWeaponType, _weaponSocket);
                _currentWeapon.SetAmmoHandler(this);
            }
            _currentWeapon.OnEquip();
        }

        public void AquireAmmo(AmmoType ammoType, int amount)
        {
            var currentAmmo = _ammoResources[ammoType];
            _ammoResources[ammoType] = _ammoLimits[ammoType].Clamp(currentAmmo + amount);
            InvokeAmmoChangeEvent(ammoType);
        }

        public void ChangeAmmoLimit(AmmoType ammoType, int newLimit)
        {
            _ammoLimits[ammoType] = new IntRange(0, newLimit);
            _ammoResources[ammoType] = _ammoLimits[ammoType].Max;
            InvokeAmmoChangeEvent(ammoType);
        }

        public void StartFire()
        {
            if (!IsAnyWeaponEquipped)
            {
                return;
            }

            _currentWeapon.StartFire();
        }

        public void StopFire()
        {
            if (!IsAnyWeaponEquipped)
            {
                return;
            }

            _currentWeapon.StopFire();
        }

        public bool HasEnoughAmmo(AmmoType ammoType, int amount)
        {
            if (!_ammoResources.TryGetValue(ammoType, out var currentAmmo))
            {
                return false;
            }
            return currentAmmo >= amount;
        }

        public void SpendAmmo(AmmoType ammoType, int amount)
        {
            if (!_ammoResources.TryGetValue(ammoType, out var currentAmmo))
            {
                return;
            }

            _ammoResources[ammoType] = _ammoLimits[ammoType].Clamp(currentAmmo - amount);
            InvokeAmmoChangeEvent(ammoType);
        }

        private void UnequipWeapon()
        {
            if (!IsAnyWeaponEquipped)
            {
                return;
            }

            _currentWeapon.OnEquip();
            _currentWeapon = null;
        }

        private void InvokeAmmoChangeEvent(AmmoType ammoType)
        {
            _characterEventsService.UpdateCharacterAmmo(ammoType, _ammoResources[ammoType], _ammoLimits[ammoType].Max);
        }
    }
}
