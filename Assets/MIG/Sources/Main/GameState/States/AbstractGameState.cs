using MIG.API;

namespace MIG.Main
{
    internal abstract class AbstractGameState : IState
    {
        protected readonly ILogService _logService;
        protected StateMachine StateMachine { get; private set; }

        public AbstractGameState(ILogService logService)
        {
            _logService = logService;
        }

        public void SetStateMachine(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }
    }
}
