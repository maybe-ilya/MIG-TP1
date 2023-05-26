using MIG.API;

namespace MIG.Levels
{
    public sealed class LevelStateService : ILevelStateService, ILevelEntryPoint
    {
        private readonly ILevelStateMachineFactory _levelStateMachineFactory;
        private readonly StateMachine _levelStateMachine;

        public LevelStateService(ILevelStateMachineFactory levelStateMachineFactory)
        {
            _levelStateMachineFactory = levelStateMachineFactory;
            _levelStateMachine = _levelStateMachineFactory.CreateObject();
        }

        public void LaunchLevel()
        {
            _levelStateMachine.ChangeState<BootstrapLevelState>();
        }
    }
}
