using MIG.API;

namespace MIG.UI
{
    public sealed class DefeatWindowFactory : AbstractWindowFactory<DefeatWindow>
    {
        public DefeatWindowFactory(IWindowSettings settings, IWindowsRootHolder rootHolder)
            : base(settings, rootHolder) { }

        public override WindowType CreatedWindowType => WindowType.DefeatWindow;

        protected override void SetupWindow(DefeatWindow window)
        {
            window.Init(UIDependencies.GameStateService);
        }
    }
}
