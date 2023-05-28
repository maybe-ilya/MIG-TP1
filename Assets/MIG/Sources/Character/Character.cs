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

        private IWeaponHandler _weaponHandler;
        private IInputController _inputController;

        public void Init(GameEntity gameEntity, IWeaponHandler weaponHandler)
        {
            GameEntity = gameEntity;
            _weaponHandler = weaponHandler;
            _healthComponent.Init();
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
            return _healthComponent.IsDead;
        }

        public void ApplyHeal(int amount)
        {
            _healthComponent.GainHealth(amount);
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
    }
}
