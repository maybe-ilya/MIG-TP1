using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MIG.Player
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    internal sealed class MouseScreenOrientationProcessor : InputProcessor<Vector2>
    {
#if UNITY_EDITOR
        static MouseScreenOrientationProcessor()
        {
            Initialize();
        }
#endif

        [RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            InputSystem.RegisterProcessor<MouseScreenOrientationProcessor>();
        }

        public override Vector2 Process(Vector2 value, InputControl control)
        {
            var screenCenter = new Vector2(Screen.width, Screen.height) * 0.5f;
            return (value - screenCenter).normalized;
        }
    }
}
