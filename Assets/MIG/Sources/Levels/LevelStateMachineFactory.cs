using MIG.API;

namespace MIG.Levels
{
    public sealed class LevelStateMachineFactory : ILevelStateMachineFactory
    {
        private readonly ILogService _logService;
        private readonly IPlayerService _playerService;
        private readonly ICharacterFactory _characterFactory;
        private readonly IPlayerStart _playerStart;

        public LevelStateMachineFactory(
            ILogService logService,
            IPlayerService playerService,
            ICharacterFactory characterFactory,
            IPlayerStart playerStart
            )
        {
            _logService = logService;
            _playerService = playerService;
            _characterFactory = characterFactory;
            _playerStart = playerStart;
        }

        public StateMachine CreateObject()
        {
            var stateMachine = new StateMachine();

            stateMachine.AddState(new BootstrapLevelState(_playerService, _characterFactory, _playerStart, stateMachine, _logService));

            return stateMachine;
        }
    }
}
