using MIG.API;
using System;
using UnityEngine;

namespace MIG.Battle
{
    [Serializable]
    public struct EnemyTypePrefabData
    {
        [SerializeField]
        private EnemyType _enemyType;

        [SerializeField]
        [CheckObject]
        private AbstractEnemy _enemyPrefab;

        public EnemyType EnemyType => _enemyType;

        public AbstractEnemy EnemyPrefab => _enemyPrefab;
    }
}
