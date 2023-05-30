using System;
using UnityEngine;

namespace MIG.API
{
    [Serializable]
    public struct WindowTypePrefabData
    {
        [SerializeField]
        private WindowType _windowType;

        [SerializeField]
        [CheckObject]
        private GameObject _windowPrefab;

        public WindowType WindowType => _windowType;

        public GameObject WindowPrefab => _windowPrefab;
    }
}
