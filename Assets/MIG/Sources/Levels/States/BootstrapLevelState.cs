using MIG.API;

namespace MIG.Levels
{
    public sealed class BootstrapLevelState : AbstractLevelState
    {
        private readonly IPlayerService _playerService;
        private readonly ICharacterFactory _characterFactory;
        private readonly ICharacterCameraFactory _characterCameraFactory;
        private readonly IPlayerStart _playerStart;

        public BootstrapLevelState(
            IPlayerService playerService,
            ICharacterFactory characterFactory,
            ICharacterCameraFactory characterCameraFactory,
            IPlayerStart playerStart)
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

            StateMachine.ChangeState<BattleLevelState>();
        }
    }
}
