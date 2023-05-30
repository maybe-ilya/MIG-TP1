using MIG.API;

namespace MIG.Levels
{
    public abstract class AbstractLevelState : IState
    {
        protected StateMachine StateMachine { get; private set; }

        public void SetStateMachine(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }
    }
}
