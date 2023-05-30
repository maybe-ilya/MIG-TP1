using MIG.API;

namespace MIG.Levels
{
    public sealed class BattleLevelState : AbstractLevelState
    {
        private readonly IPlayerService _playerService;
        private readonly IBattleService _battleService;
        private readonly IUIService _uiService;

        public BattleLevelState(
            IPlayerService playerService,
            IBattleService battleService,
            IUIService uIService)
        {
            _playerService = playerService;
            _battleService = battleService;
            _uiService = uIService;
        }

        public override void Enter()
        {
            _playerService.GetPlayer().ActivateCharacterInput();
            _uiService.OpenWindow(WindowType.CombatHUD);
            _battleService.StartBattle(BattleModeType.Horde);
        }

        public override void Exit()
        {
            _uiService.CloseWindow(WindowType.CombatHUD);
        }
    }
}
