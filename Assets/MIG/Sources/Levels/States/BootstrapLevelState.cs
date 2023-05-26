using MIG.API;

namespace MIG.Levels
{
    internal sealed class BootstrapLevelState : AbstractLevelState
    {
        private readonly IPlayerService _playerService;
        private readonly ICharacterFactory _characterFactory;
        private readonly IPlayerStart _playerStart;

        public BootstrapLevelState(
            IPlayerService playerService,
            ICharacterFactory characterFactory,
            IPlayerStart playerStart,
            StateMachine stateMachine,
            ILogService logService) :
            base(stateMachine, logService)
        {
            _playerService = playerService;
            _characterFactory = characterFactory;
            _playerStart = playerStart;
        }

        public override void Enter()
        {
            var player = _playerService.GetPlayer();
            var playerPosition = _playerStart.Position;
            var character = _characterFactory.CreateObject(playerPosition);

            player.ControlCharacter(character);
        }
    }
}
