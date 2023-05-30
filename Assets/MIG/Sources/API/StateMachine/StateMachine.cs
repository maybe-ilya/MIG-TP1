using System;
using System.Collections.Generic;

namespace MIG.API
{
    public sealed class StateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;

        public StateMachine()
        {
            _states = new Dictionary<Type, IState>();
            _currentState = null;
        }

        public void AddState(IState state)
        {
            _states[state.GetType()] = state;
        }

        public void ChangeState<T>()
        {
            var type = typeof(T);
            if (!_states.TryGetValue(type, out var newState))
            {
                return;
            }

            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }
}
