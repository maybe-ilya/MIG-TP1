using MIG.API;
using UnityEngine;
using UnityEngine.UI;

namespace MIG.UI
{
    public sealed class MainMenuWindow : MonoBehaviour, IWindow
    {
        [SerializeField]
        [CheckObject]
        private Button _launchDemoButton;

        [SerializeField]
        [CheckObject]
        private Button _quitGameButton;

        public WindowType WindowType => WindowType.MainMenu;

        private IGameStateService _gameStateService;

        public void Init(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        public void Open()
        {
            _launchDemoButton.onClick.AddListener(OnLaunchDemoButtonClick);
            _quitGameButton.onClick.AddListener(OnQuitGameButtonClick);

            _launchDemoButton.Select();
        }

        public void Close()
        {
            _launchDemoButton.onClick.RemoveAllListeners();
            _quitGameButton.onClick.RemoveAllListeners();
            _gameStateService = null;
            Destroy(gameObject);
        }

        private void OnLaunchDemoButtonClick()
        {
            _gameStateService.LaunchDemoBattle();
        }

        private void OnQuitGameButtonClick()
        {
            _gameStateService.QuitGame();
        }
    }
}
