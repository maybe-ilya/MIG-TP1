using MIG.API;
using UnityEngine;

namespace MIG.Player
{
    public sealed class Player : MonoBehaviour, IPlayer
    {
        public int Index { get; private set; }

        public ICharacter Character { get; private set; }

        private IInputController InputController { get; set; }

        public void Init(int index, IInputController inputController)
        {
            Index = index;
            InputController = inputController;
            InputController.SetupInputForPlayer(this);
        }

        public void ControlCharacter(ICharacter character)
        {
            ReleaseCharacter();
            Character = character;
            Character.SetupInputs(InputController);
            Character.OnGainControl();
        }

        public void ReleaseCharacter()
        {
            Character?.OnLoseControl();
            Character = null;
        }

        public void ActivateCharacterInput()
        {
            InputController.SwitchToGameScheme();
        }

        public void ActivateUIInput()
        {
            InputController.SwitchToUIScheme();
        }
    }
}
