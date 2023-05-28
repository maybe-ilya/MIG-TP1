namespace MIG.API
{
    public interface IWeapon
    {
        WeaponType Type { get; }
        AmmoType AmmoType { get; }
        int AmmoUsagePerShot { get; }
        void SetAmmoHandler(IWeaponAmmoHandler ammoHandler);
        void StartFire();
        void StopFire();
        void OnEquip();
        void OnUnequip();
    }
}
