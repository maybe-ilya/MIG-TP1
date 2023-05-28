using UnityEngine;

namespace MIG.API
{
    public interface IWeaponFactory : IFactory<IWeapon, WeaponType, Transform> { }
}
