using MIG.API;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace MIG.Battle
{
    [Serializable]
    public struct EnemyWaveData
    {
        [SerializeField]
        [FormerlySerializedAs("_initialSpawnSize")]
        private int _simultaneousEnemiesCount;
        [SerializeField]
        private EnemyType[] _enemiesToSpawn;

        public int SimultaneousEnemiesCount => _simultaneousEnemiesCount;
        public EnemyType[] EnemiesToSpawn => _enemiesToSpawn;
    }
}
