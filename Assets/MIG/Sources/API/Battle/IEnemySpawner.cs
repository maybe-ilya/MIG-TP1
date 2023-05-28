using UnityEngine;

namespace MIG.API
{
    public interface IEnemySpawner
    {
        Vector3 Position { get; }
        Vector3 Size { get; }
    }
}
