using MIG.API;
using System;

namespace MIG.UI
{
    public abstract class AbstractWindowFactory<TWindow> : IWindowFactory where TWindow : IWindow
    {
        private readonly IWindowSettings _settings;
        private readonly IWindowsRootHolder _rootHolder;

        public AbstractWindowFactory(
            IWindowSettings settings,
            IWindowsRootHolder rootHolder)
        {
            _settings = settings;
            _rootHolder = rootHolder;
        }

        public abstract WindowType CreatedWindowType { get; }

        public IWindow CreateObject()
        {
            var prefab = _settings.GetWindowPrefab(CreatedWindowType);
            var windowGO = UnityEngine.Object.Instantiate(prefab, _rootHolder.WindowsRoot);

            if (!windowGO.TryGetComponent<TWindow>(out var window))
            {
                throw new Exception($"GameObject {windowGO.name} doesn't have {typeof(TWindow).Name} component");
            }

            SetupWindow(window);
            return window;
        }

        protected abstract void SetupWindow(TWindow window);
    }
}
