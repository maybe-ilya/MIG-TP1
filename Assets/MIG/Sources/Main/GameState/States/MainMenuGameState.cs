using Cysharp.Threading.Tasks;
using MIG.API;

namespace MIG.Main
{
    internal sealed class MainMenuGameState : AbstractGameState
    {
        private readonly IPlayerService _playerService;
        private readonly ISceneLoadService _sceneLoadService;
        private readonly IUIService _uiService;

        private const int MAIN_MENU_SCENE_INDEX = 1;

        public MainMenuGameState(
            IPlayerService playerService,
            ILogService logService,
            ISceneLoadService sceneLoadService,
            IUIService uIService)
            : base(logService)
        {
            _playerService = playerService;
            _sceneLoadService = sceneLoadService;
            _uiService = uIService;
        }

        public override void Enter() =>
            LoadMainMenuScene().Forget();

        public override void Exit()
        {
            _uiService.CloseWindow(WindowType.MainMenu);
        }

        private async UniTaskVoid LoadMainMenuScene()
        {
            _playerService.GetPlayer().ActivateUIInput();
            await _sceneLoadService.LoadLevelAsync(MAIN_MENU_SCENE_INDEX);
            _uiService.OpenWindow(WindowType.MainMenu);
        }
    }
}
