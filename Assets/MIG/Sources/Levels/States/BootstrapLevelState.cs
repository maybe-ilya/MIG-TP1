using MIG.API;

namespace MIG.Levels
{
    internal sealed class BootstrapLevelState : AbstractLevelState
    {
        private readonly IPlayerService _playerService;
        private readonly ICharacterFactory _characterFactory;
        private readonly ICharacterCameraFactory _characterCameraFactory;
        private readonly IPlayerStart _playerStart;

        public BootstrapLevelState(
            StateMachine stateMachine,
            ILogService logService,
            IPlayerService playerService,
            ICharacterFactory characterFactory,
            ICharacterCameraFactory characterCameraFactory,
            IPlayerStart playerStart) :
            base(stateMachine, logService)
        {
            _playerService = playerService;
            _characterFactory = characterFactory;
            _characterCameraFactory = characterCameraFactory;
            _playerStart = playerStart;
        }

        public override void Enter()
        {
            var player = _playerService.GetPlayer();
            var playerPosition = _playerStart.Position;
            var character = _characterFactory.CreateObject(playerPosition);

            player.ControlCharacter(character);

            var camera = _characterCameraFactory.CreateObject();
            camera.LookAt(character);

            _stateMachine.ChangeState<BattleLevelState>();
        }
    }
}
