using MIG.API;
using UnityEngine;
using UnityEngine.UI;

namespace MIG.UI
{
    public sealed class DefeatWindow : MonoBehaviour, IWindow
    {
        [SerializeField]
        [CheckObject]
        private Button _goToMainMenuButton;

        [SerializeField]
        [CheckObject]
        private Button _quitGameWindow;

        private IGameStateService _gameStateService;

        public WindowType WindowType => WindowType.VictoryWindow;

        public void Init(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        public void Open()
        {
            _goToMainMenuButton.onClick.AddListener(OnGoToMainMenuButtonClick);
            _quitGameWindow.onClick.AddListener(OnQuitGameButtonClick);

            _goToMainMenuButton.Select();
        }

        public void Close()
        {
            _goToMainMenuButton.onClick.RemoveAllListeners();
            _quitGameWindow.onClick.RemoveAllListeners();
            _gameStateService = null;
            Destroy(gameObject);
        }

        private void OnGoToMainMenuButtonClick()
        {
            _gameStateService.GoToMainMenu();
        }

        private void OnQuitGameButtonClick()
        {
            _gameStateService.QuitGame();
        }
    }
}
