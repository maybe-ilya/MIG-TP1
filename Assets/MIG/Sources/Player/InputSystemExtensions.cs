using UnityEngine.InputSystem;

namespace MIG.Player
{
    public static class InputSystemExtensions
    {
        public static InputActionReference GetActionReference(this InputAction inputAction) =>
            InputActionReference.Create(inputAction);
    }
}
