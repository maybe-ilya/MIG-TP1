using MIG.API;
using System;
using UnityEngine;

namespace MIG.Character
{
    public abstract class AbstractWeapon : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private WeaponType _weaponType;
        [SerializeField]
        private AmmoType _ammoType;
        [SerializeField]
        private int _ammoUsagePerShot;
        [SerializeField]
        private float _fireRateTime;

        private float _weaponCooldown;
        private bool _isFiringActivated;

        public WeaponType Type => _weaponType;

        public AmmoType AmmoType => _ammoType;

        public int AmmoUsagePerShot => _ammoUsagePerShot;

        protected IDamageService DamageService { get; private set; }
        protected IRandomService RandomService { get; private set; }
        protected IWeaponAmmoHandler AmmoHandler { get; private set; }

        public void Init(
            IDamageService damageService,
            IRandomService randomService)
        {
            DamageService = damageService;
            RandomService = randomService;
        }

        public void SetAmmoHandler(IWeaponAmmoHandler ammoHandler)
        {
            AmmoHandler = ammoHandler;
        }

        public virtual void OnEquip()
        {
            gameObject.SetActive(true);
        }

        public virtual void OnUnequip()
        {
            gameObject.SetActive(false);
        }

        public virtual void StartFire()
        {
            _isFiringActivated = true;
        }

        public virtual void StopFire()
        {
            _isFiringActivated = false;
        }

        private void Update()
        {
            _weaponCooldown = Math.Max(_weaponCooldown - Time.deltaTime, 0);

            if (_isFiringActivated && _weaponCooldown < float.Epsilon)
            {
                TryToAttack();
            }
        }

        private void TryToAttack()
        {
            if (!AmmoHandler.HasEnoughAmmo(AmmoType, AmmoUsagePerShot))
            {
                return;
            }

            AmmoHandler.SpendAmmo(AmmoType, AmmoUsagePerShot);
            Attack();
            _weaponCooldown = _fireRateTime;
        }

        protected abstract void Attack();
    }
}
