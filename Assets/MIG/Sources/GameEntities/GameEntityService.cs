using MIG.API;
using System;
using System.Collections.Generic;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace MIG.GameEntities
{
    public sealed class GameEntityService :
        IGameEntityService,
        IBeforeSceneLoadListener
    {
        private readonly ILogService _logService;
        private readonly LogChannel _logChannel;
        private readonly Dictionary<int, GameEntity> _gameEntityMap;
        private int _gameEntityCounter;

        public GameEntityService(ILogService logService)
        {
            _logService = logService;
            _logChannel = "[GAME ENTITIES]";
            _gameEntityMap = new Dictionary<int, GameEntity>();
        }

        public GameEntity RegisterGameObject(GameObject gameObject)
        {
            if (!gameObject.TryGetComponent<GameEntity>(out var gameEntity))
            {
                gameEntity = gameObject.AddComponent<GameEntity>();
            }

            if (gameEntity.Id != 0 && _gameEntityMap.ContainsKey(gameEntity.Id))
            {
                throw new Exception($"GameObject {gameObject.name} is already registered with id = {gameEntity.Id}");
            }

            gameEntity.Init(++_gameEntityCounter);
            _gameEntityMap[gameEntity.Id] = gameEntity;

            _logService.Info(_logChannel, $"Initialized GameObject {gameObject.name} with id = {gameEntity.Id}");

            return gameEntity;
        }

        public void DestroyEntity(GameEntity gameEntity)
        {
            var id = gameEntity.Id;
            _gameEntityMap.Remove(id);
            UObject.Destroy(gameEntity.gameObject);
        }

        public void OnBeforeSceneLoad()
        {
            Reset();
        }

        private void Reset()
        {
            _gameEntityCounter = 0;
            _gameEntityMap.Clear();
        }
    }
}
