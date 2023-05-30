using MIG.API;

namespace MIG.UI
{
    public sealed class VictoryWindowFactory : AbstractWindowFactory<VictoryWindow>
    {
        public VictoryWindowFactory(IWindowSettings settings, IWindowsRootHolder rootHolder)
            : base(settings, rootHolder) { }

        public override WindowType CreatedWindowType => WindowType.VictoryWindow;

        protected override void SetupWindow(VictoryWindow window)
        {
            window.Init(UIDependencies.GameStateService);
        }
    }
}
