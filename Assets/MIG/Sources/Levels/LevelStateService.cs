using MIG.API;
using System.Collections.Generic;

namespace MIG.Levels
{
    public sealed class LevelStateService : ILevelStateService, ILevelEntryPoint
    {
        private readonly StateMachine _levelStateMachine;

        public LevelStateService(IReadOnlyList<AbstractLevelState> levelStates)
        {
            _levelStateMachine = new StateMachine();
            foreach (var state in levelStates)
            {
                state.SetStateMachine(_levelStateMachine);
                _levelStateMachine.AddState(state);
            }
        }

        void ILevelEntryPoint.LaunchLevel()
        {
            _levelStateMachine.ChangeState<BootstrapLevelState>();
        }

        public void WinLevel()
        {
            _levelStateMachine.ChangeState<WinLevelState>();
        }

        public void LoseLevel()
        {
            _levelStateMachine.ChangeState<LoseLevelState>();
        }
    }
}
