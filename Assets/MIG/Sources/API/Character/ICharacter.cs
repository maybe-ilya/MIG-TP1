namespace MIG.API
{
    public interface ICharacter : IGameEntityComponent
    {
        void OnGainControl(IInputController inputController);
        void OnLoseControl();
    }
}
