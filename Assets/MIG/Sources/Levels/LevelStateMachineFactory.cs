using MIG.API;

namespace MIG.Levels
{
    public sealed class LevelStateMachineFactory : ILevelStateMachineFactory
    {
        private readonly ILogService _logService;
        private readonly IPlayerService _playerService;
        private readonly ICharacterFactory _characterFactory;
        private readonly ICharacterCameraFactory _characterCameraFactory;
        private readonly IPlayerStart _playerStart;
        private readonly IBattleService _battleService;

        public LevelStateMachineFactory(
            ILogService logService,
            IPlayerService playerService,
            ICharacterFactory characterFactory,
            ICharacterCameraFactory characterCameraFactory,
            IPlayerStart playerStart,
            IBattleService battleService)
        {
            _logService = logService;
            _playerService = playerService;
            _characterFactory = characterFactory;
            _characterCameraFactory = characterCameraFactory;
            _playerStart = playerStart;
            _battleService = battleService;
        }

        public StateMachine CreateObject()
        {
            var stateMachine = new StateMachine();

            stateMachine.AddState(new BootstrapLevelState(stateMachine, _logService, _playerService, _characterFactory, _characterCameraFactory, _playerStart));
            stateMachine.AddState(new BattleLevelState(stateMachine, _logService, _battleService));

            return stateMachine;
        }
    }
}
