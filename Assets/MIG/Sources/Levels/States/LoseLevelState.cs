using MIG.API;

namespace MIG.Levels
{
    public class LoseLevelState : AbstractLevelState
    {
        private readonly IPlayerService _playerService;
        private readonly IUIService _uiService;

        public LoseLevelState(IPlayerService playerService, IUIService uiService)
        {
            _playerService = playerService;
            _uiService = uiService;
        }

        public override void Enter()
        {
            _playerService.GetPlayer().ActivateUIInput();
            _uiService.OpenWindow(WindowType.DefeatWindow);
        }

        public override void Exit()
        {
            _uiService.CloseWindow(WindowType.DefeatWindow);
        }
    }
}
