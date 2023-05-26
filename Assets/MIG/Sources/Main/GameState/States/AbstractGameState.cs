using MIG.API;

namespace MIG.Main
{
    internal abstract class AbstractGameState : IState
    {
        protected readonly StateMachine _stateMachine;
        protected readonly ILogService _logService;

        public AbstractGameState(
            StateMachine stateMachine,
            ILogService logService)
        {
            _stateMachine = stateMachine;
            _logService = logService;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }
    }
}
