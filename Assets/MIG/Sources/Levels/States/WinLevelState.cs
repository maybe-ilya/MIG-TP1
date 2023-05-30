using MIG.API;

namespace MIG.Levels
{
    public class WinLevelState : AbstractLevelState
    {
        private readonly IPlayerService _playerService;
        private readonly IUIService _uiService;

        public WinLevelState(IPlayerService playerService, IUIService uiService)
        {
            _playerService = playerService;
            _uiService = uiService;
        }

        public override void Enter()
        {
            _playerService.GetPlayer().ActivateUIInput();
            _uiService.OpenWindow(WindowType.VictoryWindow);
        }

        public override void Exit()
        {
            _uiService.CloseWindow(WindowType.VictoryWindow);
        }
    }
}
