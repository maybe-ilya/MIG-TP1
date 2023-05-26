namespace MIG.API
{
    public interface IPlayer
    {
        int Index { get; }
        ICharacter Character { get; }
        void ControlCharacter(ICharacter character);
        void ReleaseCharacter();
        void ActivateCharacterInput();
        void ActivateUIInput();
    }
}
