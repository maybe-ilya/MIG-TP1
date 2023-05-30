using MIG.API;
using UnityEngine;

namespace MIG.Main
{
    internal sealed class BootstrapGameState : AbstractGameState
    {
        private readonly IPlayerService _playerService;

        public BootstrapGameState(
            ILogService logService,
            IPlayerService playerService)
            : base(logService)
        {
            _playerService = playerService;
        }

        public override void Enter()
        {
            Application.targetFrameRate = 60;
            Cursor.visible = true;
            if (ApplicationExtensions.IsDesktop)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }

            _playerService.CreateNewPlayer();
            StateMachine.ChangeState<MainMenuGameState>();
        }
    }
}
