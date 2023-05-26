using MIG.API;

namespace MIG.Levels
{
    internal abstract class AbstractLevelState : IState
    {
        protected readonly StateMachine _stateMachine;
        protected readonly ILogService _logService;

        public AbstractLevelState(
            StateMachine stateMachine,
            ILogService logService)
        {
            _stateMachine = stateMachine;
            _logService = logService;
        }

        public virtual void Enter() { }

        public void Exit() { }
    }
}
