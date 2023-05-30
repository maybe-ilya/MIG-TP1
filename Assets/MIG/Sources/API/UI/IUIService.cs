namespace MIG.API
{
    public interface IUIService : IService {
        void OpenWindow(WindowType windowType);
        void CloseWindow(WindowType windowType);
        void CloseAllWindows();
    }
}
