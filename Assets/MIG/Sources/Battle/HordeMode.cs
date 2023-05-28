using MIG.API;
using System.Collections.Generic;
using System.Linq;

namespace MIG.Battle
{
    internal sealed class HordeMode : IBattleMode
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly ILogService _logService;
        private readonly HordeModeSettings _settings;
        private readonly IGameEntityKillNotifyService _entityKillNotify;
        private readonly IRandomService _randomService;
        private readonly IPlayerService _playerService;
        private readonly IReadOnlyList<IEnemySpawner> _enemySpawners;

        private readonly LogChannel _logChannel;
        private readonly HashSet<GameEntity> _spawnedEnemies;
        private int _currentWaveIndex = -1;
        private EnemyWaveData _currentWaveData;
        private int _lastUsedSpawnerIndex = -1;
        private int _enemySpawnCounter;

        private GameEntity PlayerCharacterEntity =>
            _playerService.GetPlayer().Character.GameEntity;

        public HordeMode(
            IEnemyFactory enemyFactory,
            ILogService logService,
            HordeModeSettings settings,
            IGameEntityKillNotifyService entityKillNotify,
            IRandomService randomService,
            IPlayerService playerService,
            IReadOnlyList<IEnemySpawner> enemySpawners)
        {
            _enemyFactory = enemyFactory;
            _logService = logService;
            _settings = settings;
            _entityKillNotify = entityKillNotify;
            _randomService = randomService;
            _playerService = playerService;
            _enemySpawners = enemySpawners;

            _logChannel = "[HORDE MODE]";
            _spawnedEnemies = new HashSet<GameEntity>();
        }

        public void Start()
        {
            _entityKillNotify.OnGameEntityKill += OnEntityKilled;
            StartNewWave();
        }

        public void Stop()
        {
            _entityKillNotify.OnGameEntityKill -= OnEntityKilled;
            _spawnedEnemies.Clear();
            _currentWaveIndex = 0;
            _currentWaveData = default;
            _lastUsedSpawnerIndex = -1;
            _enemySpawnCounter = 0;
        }

        private void OnEntityKilled(int entityIndex)
        {
            if (entityIndex == PlayerCharacterEntity.Id)
            {
                EnterPlayerFailState();
            }
            else
            {
                RemoveEnemyWithId(entityIndex);
                if (CanSpawnAnyone())
                {
                    SpawnEnemy();
                }
                else
                {
                    CheckBattleState();
                }
            }
        }

        private void StartNewWave()
        {
            _currentWaveIndex++;
            _currentWaveData = _settings.HordeWaves[_currentWaveIndex];
            _enemySpawnCounter = 0;
            _lastUsedSpawnerIndex = -1;

            for (var iteration = 0; iteration < _currentWaveData.SimultaneousEnemiesCount; ++iteration)
            {
                SpawnEnemy();
            }

            _logService.Info(_logChannel, $"Starting wave {_currentWaveIndex + 1}");
        }

        private bool CanSpawnAnyone() =>
            _enemySpawnCounter < _currentWaveData.EnemiesToSpawn.Length;

        private void SpawnEnemy()
        {
            var avalaibleSpawnerIndices = Enumerable
                .Range(0, _enemySpawners.Count)
                .Where(item => item != _lastUsedSpawnerIndex)
                .ToArray();
            var randomAvailableSpawnerIndex = _randomService.GetRandomInt(avalaibleSpawnerIndices.Length);

            _lastUsedSpawnerIndex = avalaibleSpawnerIndices[randomAvailableSpawnerIndex];
            var spawner = _enemySpawners[_lastUsedSpawnerIndex];
            var enemyTypeToSpawn = _currentWaveData.EnemiesToSpawn[_enemySpawnCounter++];
            var enemy = _enemyFactory.CreateObject(enemyTypeToSpawn, spawner);
            _spawnedEnemies.Add(enemy.GameEntity);
            _logService.Info(_logChannel, $"Spawned {enemyTypeToSpawn} enemy {enemy.GameEntity}");
        }

        private void RemoveEnemyWithId(int id) =>
            _spawnedEnemies.RemoveWhere(item => item.Id == id);

        private void EnterPlayerFailState()
        {
            // TODO: перенос машины состояний уровня
            _logService.Info(_logChannel, "Player didn't survive horde");
        }

        private void EnterPlayerWinState()
        {
            // TODO: перенос машины состояний уровня
            _logService.Info(_logChannel, "Player victoriously crushed horde");
        }

        private void CheckBattleState()
        {
            if (_spawnedEnemies.Any())
            {
                return;
            }

            var currentWaveIsNotLast = (_settings.HordeWaves.Length - _currentWaveIndex) > 1;

            if (currentWaveIsNotLast)
            {
                StartNewWave();
            }
            else
            {
                EnterPlayerWinState();
                Stop();
            }
        }
    }
}
