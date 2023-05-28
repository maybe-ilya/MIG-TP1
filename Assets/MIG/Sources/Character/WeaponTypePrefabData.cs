using MIG.API;
using System;
using UnityEngine;

namespace MIG.Character
{
    [Serializable]
    internal struct WeaponTypePrefabData
    {
        [SerializeField]
        private WeaponType _weaponType;

        [SerializeField]
        [CheckObject]
        private GameObject _prefab;

        public WeaponType WeaponType => _weaponType;

        public GameObject Prefab => _prefab;
    }
}
