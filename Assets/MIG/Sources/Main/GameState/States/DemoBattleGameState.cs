using MIG.API;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MIG.Main
{
    internal sealed class DemoBattleGameState : AbstractGameState
    {
        private readonly ISceneLoadService _sceneLoadService;
        private readonly IUIService _uiService;
        private const int DEMO_SCENE_INDEX = 2;

        public DemoBattleGameState(
            ILogService logService,
            ISceneLoadService sceneLoadService,
            IUIService uIService)
            : base(logService)
        {
            _sceneLoadService = sceneLoadService;
            _uiService = uIService;
        }

        public override void Enter()
        {
            LoadSceneAndQaitForQuitButton().Forget();
        }

        public override void Exit()
        {
            _uiService.CloseAllWindows();
        }

        private async UniTaskVoid LoadSceneAndQaitForQuitButton()
        {
            await _sceneLoadService.LoadLevelAsync(DEMO_SCENE_INDEX);
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Q));
            StateMachine.ChangeState<QuitGameState>();
        }
    }
}
