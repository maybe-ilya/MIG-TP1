using MIG.API;
using UnityEngine;

namespace MIG.UI
{
    public sealed class GlobalCanvas : 
        MonoBehaviour, 
        IGlobalCanvas,
        IWindowsRootHolder
    {
        [SerializeField]
        [CheckObject]
        private RectTransform _windowsRoot;

        public GameObject GameObject => gameObject;

        public RectTransform WindowsRoot => _windowsRoot;
    }
}
