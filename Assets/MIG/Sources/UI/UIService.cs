using MIG.API;
using System.Collections.Generic;
using System.Linq;

namespace MIG.UI
{
    public sealed class UIService : IUIService
    {
        private readonly ILogService _logService;
        private readonly LogChannel _logChannel;
        private readonly IGlobalCanvas _globalCanvas;
        private readonly IGlobalEventSystem _globalEventSystem;
        private readonly Dictionary<WindowType, IWindowFactory> _windowFactories;

        private readonly List<IWindow> _openedWindows;

        public UIService(
            ILogService logService,
            IGlobalCanvas globalCanvas,
            IGlobalEventSystem globalEventSystem,
            IReadOnlyList<IWindowFactory> windowFactories)
        {
            _logService = logService;
            _logChannel = "[UI]";
            _globalCanvas = globalCanvas;
            _globalEventSystem = globalEventSystem;
            _windowFactories = windowFactories.ToDictionary(factory => factory.CreatedWindowType, factory => factory);

            _openedWindows = new List<IWindow>();
        }

        public void OpenWindow(WindowType windowType)
        {
            var windowToOpen = _windowFactories[windowType].CreateObject();
            _openedWindows.Add(windowToOpen);
            _logService.Info(_logChannel, $"Opening new window of {windowType} type");
            windowToOpen.Open();
        }

        public void CloseWindow(WindowType windowType)
        {
            var indexOfWindowToClose = _openedWindows.FindIndex(window => window.WindowType == windowType);

            if (indexOfWindowToClose == -1)
            {
                _logService.Warning(_logChannel, $"There is no opened window of {windowType} type");
                return;
            }

            var windowToClose = _openedWindows[indexOfWindowToClose];
            _openedWindows.RemoveAt(indexOfWindowToClose);
            _logService.Info(_logChannel, $"Closing window of {windowType} type");
            windowToClose.Close();
        }

        public void CloseAllWindows()
        {
            _logService.Info(_logChannel, "Closing all windows");

            foreach (var window in _openedWindows)
            {
                _logService.Info(_logChannel, $"Closing window of {window.WindowType} type");
                window.Close();
            }
            _openedWindows.Clear();
        }
    }
}
