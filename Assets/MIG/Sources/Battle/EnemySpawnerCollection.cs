using MIG.API;
using System.Collections.Generic;
using UnityEngine;

namespace MIG.Battle
{
    public sealed class EnemySpawnerCollection : MonoBehaviour, IEnemySpawnerCollection
    {
        [SerializeField]
        [CheckObject]
        private EnemySpawner[] _spawners;

        public IReadOnlyList<IEnemySpawner> Spawners => _spawners;
    }
}
