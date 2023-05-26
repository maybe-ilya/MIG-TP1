using System;
using UnityEngine;

namespace MIG.API
{
    public interface IInputController
    {
        void SwitchToGameScheme();
        void SwitchToUIScheme();

        event Action<Vector2> OnMove;
        event Action<Vector2> OnLook;
        event Action OnFire;
        event Action OnAltFire;
    }
}
