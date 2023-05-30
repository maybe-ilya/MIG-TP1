using MIG.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MIG.UI
{
    [RequireComponent(typeof(EventSystem), typeof(BaseInputModule))]
    public sealed class GlobalEventSystem :
        MonoBehaviour,
        IGlobalEventSystem
    {
        [SerializeField]
        [CheckObject]
        private EventSystem _eventSystem;

        [SerializeField]
        [CheckObject]
        private BaseInputModule _inputModule;

        public BaseInputModule InputModule => _inputModule;

#if UNITY_EDITOR
        private void Reset()
        {
            _eventSystem = GetComponent<EventSystem>();
            _inputModule = GetComponent<BaseInputModule>();
        }
#endif
    }
}
