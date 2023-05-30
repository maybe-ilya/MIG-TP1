using MIG.API;
using System;
using System.Collections.Generic;

namespace MIG.GameEntities
{
    public sealed class DamageService :
        IDamageService,
        IGameEntityKillNotifyService
    {
        private readonly ILogService _logService;
        private readonly LogChannel _logChannel;
        private readonly IGameEntityService _gameEntityService;

        public DamageService(
            ILogService logService,
            IGameEntityService gameEntityService)
        {
            _logService = logService;
            _logChannel = "[DAMAGE]";
            _gameEntityService = gameEntityService;
        }

        public event Action<int> OnGameEntityKill;

        public void ApplyDamage(GameEntity gameEntity, int damage)
        {
            if (!gameEntity.TryGetComponent<IDamagable>(out var damagable))
            {
                _logService.Warning(_logChannel, $"Can't damage entity {gameEntity} because it doesn't contain IDamagable component");
                return;
            }

            if (!damagable.CanApplyDamage)
            {
                _logService.Info(_logChannel, $"Can't damage entity {gameEntity} because it's already destroyed");
                return;
            }

            var isEntityKilled = damagable.ApplyDamage(damage);

            if (!isEntityKilled)
            {
                return;
            }

            _logService.Info(_logChannel, $"Entity {gameEntity} is killed");
            OnGameEntityKill?.Invoke(gameEntity.Id);
            _gameEntityService.DestroyEntity(gameEntity);
        }
    }
}
