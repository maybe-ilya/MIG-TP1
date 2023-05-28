using MIG.API;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MIG.Character
{
    [CreateAssetMenu(menuName = "MIG/Weapon Settings")]
    public class WeaponSettings :
        ScriptableObject,
        IWeaponSettings,
        ISerializationCallbackReceiver
    {
        [SerializeField]
        [OneLine]
        private WeaponTypePrefabData[] _weaponPrefabData;

        private readonly Dictionary<WeaponType, GameObject> _weaponPrefabRuntimeData = new();

        public GameObject GetWeaponPrefab(WeaponType weaponType)
        {
            if (!_weaponPrefabRuntimeData.TryGetValue(weaponType, out var result))
            {
                throw new Exception($"No prefab for {weaponType} weapon");
            }

            return result;
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            _weaponPrefabRuntimeData.Clear();
            _weaponPrefabData.ForEach(entry => _weaponPrefabRuntimeData[entry.WeaponType] = entry.Prefab);
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize() { }
    }
}
