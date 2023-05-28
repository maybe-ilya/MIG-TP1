using MIG.API;
using UnityEngine;

namespace MIG.Battle
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyFactorySettings _settings;
        private readonly IGameEntityService _gameEntityService;
        private readonly IPlayerService _playerService;
        private readonly IDamageService _damageService;

        private GameEntity PlayerEntity =>
            _playerService.GetPlayer().Character.GameEntity;

        public EnemyFactory(
            EnemyFactorySettings settings,
            IGameEntityService gameEntityService,
            IPlayerService playerService,
            IDamageService damageService)
        {
            _settings = settings;
            _gameEntityService = gameEntityService;
            _playerService = playerService;
            _damageService = damageService;
        }

        public IEnemy CreateObject(EnemyType enemyType, IEnemySpawner spawner)
        {
            var prefab = _settings.GetEnemyPrefab(enemyType);
            var enemy = Object.Instantiate(prefab, spawner.Position, Quaternion.identity);
            var entity = _gameEntityService.RegisterGameObject(enemy.gameObject);

            enemy.Init(entity, _damageService);
            enemy.SetTarget(PlayerEntity);
            return enemy;
        }
    }
}
