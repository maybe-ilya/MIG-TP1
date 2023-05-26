using MIG.API;

namespace MIG.Main
{
    internal sealed class GameStateService :
        IGameStateService,
        IGameEntryPoint
    {
        private readonly IGameStateMachineFactory _gameStateMachineFactory;
        private readonly StateMachine _gameStateMachine;

        public GameStateService(IGameStateMachineFactory gameStateMachineFactory)
        {
            _gameStateMachineFactory = gameStateMachineFactory;
            _gameStateMachine = _gameStateMachineFactory.CreateObject();
        }

        void IGameEntryPoint.LaunchGame()
        {
            _gameStateMachine.ChangeState<BootstrapGameState>();
        }
    }
}
