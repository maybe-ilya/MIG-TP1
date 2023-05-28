using MIG.API;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MIG.Battle
{
    [CreateAssetMenu(menuName = "MIG/Enemy Factory Settings")]
    public sealed class EnemyFactorySettings :
        ScriptableObject,
        ISerializationCallbackReceiver
    {
        [SerializeField]
        [OneLine]
        private EnemyTypePrefabData[] _enemyData;

        private readonly Dictionary<EnemyType, AbstractEnemy> _enemyRuntimeData = new();

        public AbstractEnemy GetEnemyPrefab(EnemyType enemyType)
        {
            if (!_enemyRuntimeData.TryGetValue(enemyType, out var result))
            {
                throw new NotImplementedException($"No prefab for {enemyType} enemy");
            }

            return result;
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            _enemyRuntimeData.Clear();
            _enemyData.ForEach(entry => _enemyRuntimeData[entry.EnemyType] = entry.EnemyPrefab);
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize() { }
    }
}
