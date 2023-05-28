using MIG.API;
using UnityEngine;

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
            Application.targetFrameRate = 60;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            _playerService.CreateNewPlayer();
            _stateMachine.ChangeState<LaunchDemoSceneState>();
        }
    }
}
