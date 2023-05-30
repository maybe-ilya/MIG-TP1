namespace MIG.API
{
    public interface IWindowFactory : IFactory<IWindow>
    {
        WindowType CreatedWindowType { get; }
    }
}
