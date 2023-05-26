using MIG.API;
using UnityEngine;

namespace MIG.Player
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private const string PLAYER_NAME = "[Player Controller]";
        private const int DEFAULT_INDEX = 0;
        private readonly IGameSettings _gameSettings;

        public PlayerFactory(IGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public IPlayer CreateObject()
        {
            var playerPrefab = _gameSettings.PlayerPrefab;
            var playerGO = Object.Instantiate(playerPrefab);
            playerGO.name = PLAYER_NAME;
            Object.DontDestroyOnLoad(playerGO);

            var inputCtrl = playerGO.GetComponent<InputController>();
            var player = playerGO.GetComponent<Player>();

            player.Init(DEFAULT_INDEX, inputCtrl);
            inputCtrl.Init();

            return player;
        }
    }
}
