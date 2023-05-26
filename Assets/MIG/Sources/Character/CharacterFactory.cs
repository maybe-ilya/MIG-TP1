using MIG.API;
using UnityEngine;

namespace MIG.Character
{
    public sealed class CharacterFactory : ICharacterFactory
    {
        private readonly IGameSettings _gameSettings;

        public CharacterFactory(IGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public ICharacter CreateObject(Vector3 position)
        {
            var prefab = _gameSettings.CharacterPrefab;
            var characterGO = Object.Instantiate(prefab, position, Quaternion.identity);
            var character = characterGO.GetComponent<Character>();
            return character;
        }
    }
}
