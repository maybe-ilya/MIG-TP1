using MIG.API;
using UnityEngine;

namespace MIG.Main
{
    [CreateAssetMenu(menuName = "MIG/Settings/Game Settings")]
    public sealed class GameSettings : ScriptableObject, IGameSettings
    {
        [SerializeField]
        [CheckObject]
        private GameObject _playerPrefab;

        [SerializeField]
        [CheckObject]
        private GameObject _characterPrefab;

        public GameObject PlayerPrefab => _playerPrefab;

        public GameObject CharacterPrefab => _characterPrefab;
    }
}
