using MIG.API;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MIG.Main
{
    internal sealed class QuitGameState : AbstractGameState
    {
        public QuitGameState(
            StateMachine stateMachine,
            ILogService logService)
            : base(stateMachine, logService) { }

        public override void Enter()
        {
            _logService.Info("Quitting game. Bye bye!..");
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}
