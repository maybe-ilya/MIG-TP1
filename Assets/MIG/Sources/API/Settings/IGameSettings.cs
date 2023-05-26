using UnityEngine;

namespace MIG.API
{
    public interface IGameSettings
    {
        GameObject PlayerPrefab { get; }
        GameObject CharacterPrefab { get; }
    }
}
