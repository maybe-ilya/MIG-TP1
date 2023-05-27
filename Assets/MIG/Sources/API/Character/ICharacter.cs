using UnityEngine;

namespace MIG.API
{
    public interface ICharacter
    {
        GameObject GameObject { get; }
        void SetupInputs(IInputController inputController);
        void OnGainControl();
        void OnLoseControl();
    }
}
