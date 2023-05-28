using MIG.API;

namespace MIG.Levels
{
    internal sealed class BattleLevelState : AbstractLevelState
    {
        private readonly IBattleService _battleService;

        public BattleLevelState(
            StateMachine stateMachine,
            ILogService logService,
            IBattleService battleService)
            : base(stateMachine, logService)
        {
            _battleService = battleService;
        }

        public override void Enter()
        {
            _battleService.StartBattle(BattleModeType.Horde);
        }
    }
}
