using System;
using MIG.API;
using System.Collections.Generic;
using UnityEngine;

namespace MIG.UI
{
    [CreateAssetMenu(menuName = "MIG/Window Settings")]
    public sealed class WindowsSettings :
        ScriptableObject,
        IWindowSettings,
        ISerializationCallbackReceiver
    {
        [SerializeField]
        [OneLine]
        private WindowTypePrefabData[] _windowPrefabData;

        private readonly Dictionary<WindowType, GameObject> _windowPrefabRuntimeData = new();

        public GameObject GetWindowPrefab(WindowType windowType)
        {
            if (!_windowPrefabRuntimeData.TryGetValue(windowType, out var windowPrefab))
            {
                throw new Exception($"No prefab for {windowType} window type");
            }

            return windowPrefab;
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize() { }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            _windowPrefabRuntimeData.Clear();
            _windowPrefabData.ForEach(entry => _windowPrefabRuntimeData[entry.WindowType] = entry.WindowPrefab);
        }
    }
}
