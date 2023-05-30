namespace MIG.API
{
    public interface IWindow
    {
        WindowType WindowType { get; }
        void Open();
        void Close();
    }
}
