using MIG.API;
using System.Collections.Generic;

namespace MIG.Main
{
    internal sealed class GameStateService : 
        IGameStateService,
        IGameEntryPoint
    {
        private readonly StateMachine _gameStateMachine;

        public GameStateService(IReadOnlyList<AbstractGameState> gameStates)
        {
            _gameStateMachine = new StateMachine();
            foreach (var state in gameStates)
            {
                state.SetStateMachine(_gameStateMachine);
                _gameStateMachine.AddState(state);
            }
        }
    
        void IGameEntryPoint.LaunchGame()
        {
            _gameStateMachine.ChangeState<BootstrapGameState>();
        }

        public void GoToMainMenu()
        {
            _gameStateMachine.ChangeState<MainMenuGameState>();
        }

        public void LaunchDemoBattle()
        {
            _gameStateMachine.ChangeState<DemoBattleGameState>();
        }

        public void QuitGame()
        {
            _gameStateMachine.ChangeState<QuitGameState>();
        }
    }
}
