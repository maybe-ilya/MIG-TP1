using MIG.API;
using UnityEngine;

namespace MIG.Character
{
    public sealed class Character : MonoBehaviour, ICharacter
    {
        [SerializeField]
        [CheckObject]
        private CharacterMovement _characterMovement;

        public void SetupInputs(IInputController inputController)
        {
            inputController.OnMove += OnMove;
            inputController.OnLook += OnLook;
            inputController.OnFire += OnFire;
            inputController.OnAltFire += OnAltFire;
        }

        public void OnGainControl()
        {
            throw new System.NotImplementedException();
        }

        public void OnLoseControl()
        {
            throw new System.NotImplementedException();
        }

        private void OnMove(Vector2 moveVector)
        {
            _characterMovement.ApplyMoveInput(moveVector);
        }

        private void OnLook(Vector2 lookVector)
        {
            _characterMovement.ApplyLookInput(lookVector);
        }

        private void OnFire()
        {
            throw new System.NotImplementedException();
        }

        private void OnAltFire()
        {
            throw new System.NotImplementedException();
        }
    }
}
