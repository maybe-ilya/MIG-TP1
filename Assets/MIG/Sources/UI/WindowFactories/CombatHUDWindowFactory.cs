using MIG.API;

namespace MIG.UI
{
    public class CombatHUDWindowFactory : AbstractWindowFactory<CombatHUDWindow>
    {
        private readonly ICharacterEvents _characterEvents;
        private readonly IHordeModeEvents _hordeModeEvents;

        public CombatHUDWindowFactory(
            ICharacterEvents characterEvents,
            IHordeModeEvents hordeModeEvents,
            IWindowSettings settings,
            IWindowsRootHolder rootHolder)
            : base(settings, rootHolder)
        {
            _characterEvents = characterEvents;
            _hordeModeEvents = hordeModeEvents;
        }

        public override WindowType CreatedWindowType => WindowType.CombatHUD;

        protected override void SetupWindow(CombatHUDWindow window)
        {
            window.Init(_characterEvents, _hordeModeEvents);
        }
    }
}
