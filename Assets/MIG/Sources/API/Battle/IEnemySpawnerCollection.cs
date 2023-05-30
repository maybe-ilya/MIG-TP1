using MIG.API;
using System.Collections.Generic;

namespace MIG.Battle
{
    public interface IEnemySpawnerCollection
    {
        IReadOnlyList<IEnemySpawner> Spawners { get; }
    }
}
