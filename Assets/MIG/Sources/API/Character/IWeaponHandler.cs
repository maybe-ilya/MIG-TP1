namespace MIG.API
{
    public interface IWeaponHandler
    {
        void AcquireWeapon(WeaponType weaponType);
        void EquipWeapon(WeaponType newWeapon);
        void AquireAmmo(AmmoType ammoType, int amount);
        void ChangeAmmoLimit(AmmoType ammoType, int newCapacity);
        void StartFire();
        void StopFire();
    }
}
