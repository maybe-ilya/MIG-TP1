namespace MIG.API
{
    public interface ICharacter
    {
        void SetupInputs(IInputController inputController);
        void OnGainControl();
        void OnLoseControl();
    }
}
