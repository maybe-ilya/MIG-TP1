using MIG.API;

namespace MIG.Main
{
    internal sealed class BootstrapGameState : AbstractGameState
    {
        private readonly IPlayerService _playerService;

        public BootstrapGameState(
            StateMachine stateMachine,
            ILogService logService,
            IPlayerService playerService)
            : base(stateMachine, logService)
        {
            _playerService = playerService;
        }

        public override void Enter()
        {
            _playerService.CreateNewPlayer();
            _stateMachine.ChangeState<LaunchDemoSceneState>();
        }
    }
}
