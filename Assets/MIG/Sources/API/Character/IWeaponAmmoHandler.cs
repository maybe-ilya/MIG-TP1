namespace MIG.API
{
    public interface IWeaponAmmoHandler
    {
        bool HasEnoughAmmo(AmmoType ammoType, int amount);
        void SpendAmmo(AmmoType ammoType, int amount);
    }
}
