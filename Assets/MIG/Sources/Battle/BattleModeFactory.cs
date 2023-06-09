using System;
using MIG.API;

namespace MIG.Battle
{
    public sealed class BattleModeFactory : IBattleModeFactory
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly ILogService _logService;
        private readonly HordeModeSettings _hordeModeSettings;
        private readonly IGameEntityKillNotifyService _gameEntityKillNotifyService;
        private readonly IRandomService _randomService;
        private readonly IPlayerService _playerService;
        private readonly IHordeModeEventsInvokerService _hordeModeEventsInvokerService;
        private readonly IEnemySpawnerCollection _enemySpawnerCollection;

        public BattleModeFactory(
            IEnemyFactory enemyFactory,
            ILogService logService,
            HordeModeSettings hordeModeSettings,
            IGameEntityKillNotifyService gameEntityKillNotifyService,
            IRandomService randomService,
            IPlayerService playerService,
            IHordeModeEventsInvokerService hordeModeEventsInvokerService,
            IEnemySpawnerCollection enemySpawnerCollection)
        {
            _enemyFactory = enemyFactory;
            _logService = logService;
            _hordeModeSettings = hordeModeSettings;
            _gameEntityKillNotifyService = gameEntityKillNotifyService;
            _randomService = randomService;
            _playerService = playerService;
            _hordeModeEventsInvokerService = hordeModeEventsInvokerService;
            _enemySpawnerCollection = enemySpawnerCollection;
        }

        public IBattleMode CreateObject(BattleModeType input)
        {
            return input switch
            {
                BattleModeType.Horde =>
                new HordeMode(
                    _enemyFactory,
                    _logService,
                    _hordeModeSettings,
                    _gameEntityKillNotifyService,
                    _randomService,
                    _playerService,
                    BattleLevelDependencies.LevelStateService,
                    _hordeModeEventsInvokerService,
                    _enemySpawnerCollection.Spawners),
                _ => throw new NotImplementedException($"Battle mode {input} is not implemented yet"),
            };
        }
    }
}
