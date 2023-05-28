using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
using UnityEditor;
#endif

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

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Initialize()
        {
            InputSystem.RegisterProcessor<MouseScreenOrientationProcessor>();
        }

        public override Vector2 Process(Vector2 input, InputControl control)
        {
            var screenSize = new Vector2(Screen.width, Screen.height);
            var screenCenter = screenSize * 0.5f;
            var result = (input - screenCenter).normalized;
            return result;
        }
    }
}
