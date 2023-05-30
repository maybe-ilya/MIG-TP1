using MIG.API;
using UnityEngine;

namespace MIG.Character
{
    public sealed class Character :
        MonoBehaviour,
        ICharacter,
        IDamagable,
        IHealable
    {
        [SerializeField]
        [CheckObject]
        private CharacterMovement _characterMovement;

        [SerializeField]
        [CheckObject]
        private HealthComponent _healthComponent;

        public GameEntity GameEntity { get; private set; }

        public bool CanApplyDamage => _healthComponent.IsAlive;

        private IWeaponHandler _weaponHandler;
        private IInputController _inputController;
        private ICharacterEventsInvokerService _characterEventsService;
        private ILogService _logService;
        private LogChannel _logChannel;

        public void Init(
            GameEntity gameEntity, 
            IWeaponHandler weaponHandler, 
            ICharacterEventsInvokerService characterEventsService,
            ILogService logService)
        {
            GameEntity = gameEntity;
            _weaponHandler = weaponHandler;
            _characterEventsService = characterEventsService;
            _logService = logService;
            _logChannel = "[CHARACTER]";

            _healthComponent.Init();
            InvokeHealthChangeEvent();
        }

        public void OnGainControl(IInputController inputController)
        {
            _inputController = inputController;
            _inputController.OnMove += OnMove;
            _inputController.OnLook += OnLook;
            _inputController.OnFireStart += OnFireStart;
            _inputController.OnFireStop += OnFireStop;
        }

        public void OnLoseControl()
        {
            _inputController.OnMove -= OnMove;
            _inputController.OnLook -= OnLook;
            _inputController.OnFireStart -= OnFireStart;
            _inputController.OnFireStop -= OnFireStop;
            _inputController = null;
        }

        public bool ApplyDamage(int damage)
        {
            _healthComponent.LoseHealth(damage);
            InvokeHealthChangeEvent();

            var isDead = _healthComponent.IsDead;
            if (isDead)
            {
                _characterEventsService.InvokeCharacterDeadEvent();
            }

            return isDead;
        }

        public void ApplyHeal(int amount)
        {
            _healthComponent.GainHealth(amount);
            InvokeHealthChangeEvent();
        }

        private void OnMove(Vector2 moveVector) =>
            _characterMovement.ApplyMoveInput(moveVector);

        private void OnLook(Vector2 lookVector) =>
            _characterMovement.ApplyLookInput(lookVector);

        private void OnFireStart()
        {
            _weaponHandler.StartFire();
        }

        private void OnFireStop()
        {
            _weaponHandler.StopFire();
        }

        private void InvokeHealthChangeEvent()
        {
            var health = _healthComponent.Health;
            var maxHealth = _healthComponent.MaxHealth;
            _logService.Info(_logChannel, $"Health {health}/{maxHealth}");
            _characterEventsService.UpdateCharacterHealth(health, maxHealth);
        }
    }
}
