using MIG.API;
using UnityEngine;

namespace MIG.Battle
{
    public abstract class AbstractEnemy : MonoBehaviour,
        IEnemy,
        IDamagable
    {
        [SerializeField]
        [CheckObject]
        private HealthComponent _healthComponent;

        public GameEntity GameEntity { get; private set; }

        protected GameEntity Target { get; private set; }
        protected IDamageService DamageService { get; private set; }

        protected bool IsTargetSet => Target != null;

        public bool CanApplyDamage => _healthComponent.IsAlive;

        public bool ApplyDamage(int damage)
        {
            _healthComponent.LoseHealth(damage);
            return _healthComponent.IsDead;
        }

        public void Init(GameEntity gameEntity, IDamageService damageService)
        {
            GameEntity = gameEntity;
            DamageService = damageService;
            _healthComponent.Init();
            OnInit();
        }

        public void SetTarget(GameEntity gameEntity)
        {
            Target = gameEntity;
            OnTargetSet();
        }

        protected virtual void OnInit() { }

        protected virtual void OnTargetSet() { }
    }
}
