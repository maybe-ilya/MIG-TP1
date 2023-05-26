using MIG.API;

namespace MIG.Main
{
    internal sealed class GameStateMachineFactory : IGameStateMachineFactory
    {
        private readonly ILogService _logService;
        private readonly ISceneLoadService _sceneLoadService;
        private readonly IPlayerService _playerService;

        public GameStateMachineFactory(
            ILogService logService,
            ISceneLoadService sceneLoadService,
            IPlayerService playerService)
        {
            _logService = logService;
            _sceneLoadService = sceneLoadService;
            _playerService = playerService;
        }

        public StateMachine CreateObject()
        {
            var result = new StateMachine();

            result.AddState(new BootstrapGameState(result, _logService, _playerService));
            result.AddState(new LaunchDemoSceneState(result, _logService, _sceneLoadService));
            result.AddState(new QuitGameState(result, _logService));

            return result;
        }
    }
}
