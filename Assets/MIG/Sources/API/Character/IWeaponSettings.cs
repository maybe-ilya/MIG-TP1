using UnityEngine;

namespace MIG.API
{
    public interface IWeaponSettings
    {
        GameObject GetWeaponPrefab(WeaponType weaponType);
    }
}
