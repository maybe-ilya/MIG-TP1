using MIG.API;
using UnityEngine;

namespace MIG.Player
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private const string PLAYER_NAME = "[Player Controller]";
        private const int DEFAULT_INDEX = 0;
        private readonly ILogService _logService;
        private readonly IGameSettings _gameSettings;

        public PlayerFactory(
            ILogService logService,
            IGameSettings gameSettings)
        {
            _logService = logService;
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

            inputCtrl.Init(_logService);
            player.Init(DEFAULT_INDEX, inputCtrl);

            return player;
        }
    }
}
