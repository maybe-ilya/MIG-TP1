using MIG.API;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MIG.Main
{
    internal sealed class LaunchDemoSceneState : AbstractGameState
    {
        private readonly ISceneLoadService _sceneLoadService;

        public LaunchDemoSceneState(
            StateMachine stateMachine,
            ILogService logService,
            ISceneLoadService sceneLoadService)
            : base(stateMachine, logService)
        {
            _sceneLoadService = sceneLoadService;
        }

        public override void Enter()
        {
            LoadSceneAndQaitForQuitButton().Forget();
        }

        private async UniTaskVoid LoadSceneAndQaitForQuitButton()
        {
            await _sceneLoadService.LoadLevelAsync(1);
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Q));
            _stateMachine.ChangeState<QuitGameState>();
        }
    }
}
