using MIG.API;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using static MIG.Player.GameControls;

namespace MIG.Player
{
    public sealed class InputController : 
        MonoBehaviour, 
        IInputController, 
        ICombatActions
    {
        private GameControls _gameControls;

        public event Action<Vector2> OnMove;
        public event Action<Vector2> OnLook;
        public event Action OnFire;
        public event Action OnAltFire;

        private static InputSystemUIInputModule UIInputModule =>
            EventSystem.current.currentInputModule as InputSystemUIInputModule;

        private bool IsCursorLocked
        {
            get { return !Cursor.visible && Cursor.lockState == CursorLockMode.Locked; }
            set
            {
                Cursor.visible = !value;
                Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
            }
        }

        private bool CanProcessInput => true;

        public void Init()
        {
            _gameControls = new GameControls();
            ClearCallbacks();
            BindCombatActions();
            //BindUIActions();
            SwitchToGameScheme();
        }

        public void SwitchToGameScheme()
        {
            _gameControls.UI.Disable();
            _gameControls.Combat.Enable();
        }

        public void SwitchToUIScheme()
        {
            _gameControls.Combat.Disable();
            _gameControls.UI.Enable();
        }

        private void ClearCallbacks()
        {
            OnMove = null;
            OnLook = null;
            OnFire = null;
            OnAltFire = null;
        }

        private void BindCombatActions()
        {
            _gameControls.Combat.SetCallbacks(this);
        }

        private void BindUIActions()
        {
            var uiInputModule = UIInputModule;
            uiInputModule.UnassignActions();

            var uiActions = _gameControls.UI;

            uiInputModule.submit = uiActions.Submit.GetActionReference();
            uiInputModule.cancel = uiActions.Cancel.GetActionReference();
            uiInputModule.move = uiActions.Navigate.GetActionReference();
            uiInputModule.leftClick = uiActions.Click.GetActionReference();
            uiInputModule.point = uiActions.Cursor.GetActionReference();
            uiInputModule.scrollWheel = uiActions.Scroll.GetActionReference();
        }

        void ICombatActions.OnMovement(InputAction.CallbackContext context)
        {
            var moveVector = CanProcessInput ? context.ReadValue<Vector2>() : Vector2.zero;
            OnMove?.Invoke(moveVector);
        }

        void ICombatActions.OnOrientation(InputAction.CallbackContext context)
        {
            var lookVector = CanProcessInput ? context.ReadValue<Vector2>() : Vector2.zero;
            OnLook?.Invoke(lookVector);
        }

        void ICombatActions.OnFire(InputAction.CallbackContext context)
        {
            if (!CanProcessInput || !context.performed)
            {
                return;
            }

            OnFire?.Invoke();
        }

        void ICombatActions.OnAltFire(InputAction.CallbackContext context)
        {
            if (!CanProcessInput || !context.performed)
            {
                return;
            }

            OnAltFire?.Invoke();
        }

        void ICombatActions.OnPause(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
