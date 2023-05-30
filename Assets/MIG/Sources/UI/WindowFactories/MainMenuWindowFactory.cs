using MIG.API;

namespace MIG.UI
{
    public sealed class MainMenuWindowFactory : AbstractWindowFactory<MainMenuWindow>
    {
        public MainMenuWindowFactory(
            IWindowSettings settings,
            IWindowsRootHolder rootHolder)
            : base(settings, rootHolder) { }

        public override WindowType CreatedWindowType => WindowType.MainMenu;

        protected override void SetupWindow(MainMenuWindow window)
        {
            window.Init(UIDependencies.GameStateService);
        }
    }
}
