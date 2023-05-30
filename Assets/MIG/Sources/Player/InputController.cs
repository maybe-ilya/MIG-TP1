using MIG.API;
using System;
using UnityEngine;
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
        private ILogService _logService;
        private LogChannel _logChannel;
        private InputSystemUIInputModule _uiInputModule;
        private IPlayer _ownerPlayer;
        private GameControls _gameControls;

        public event Action<Vector2> OnMove;
        public event Action<Vector2> OnLook;
        public event Action OnFireStart;
        public event Action OnFireStop;

        public void Init(ILogService logService, InputSystemUIInputModule uIInputModule)
        {
            _logService = logService;
            _logChannel = "[INPUT]";
            _uiInputModule = uIInputModule;
        }

        public void SetupInputForPlayer(IPlayer player)
        {
            _ownerPlayer = player;
            _gameControls = new GameControls();
            ClearCallbacks();
            BindCombatActions();
            BindUIActions();
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
            OnFireStart = null;
        }

        private void BindCombatActions()
        {
            _gameControls.Combat.SetCallbacks(this);
        }

        private void BindUIActions()
        {
            var uiActions = _gameControls.UI;
            _uiInputModule.UnassignActions();

            _uiInputModule.submit = uiActions.Submit.GetActionReference();
            _uiInputModule.cancel = uiActions.Cancel.GetActionReference();
            _uiInputModule.move = uiActions.Navigate.GetActionReference();
            _uiInputModule.leftClick = uiActions.Click.GetActionReference();
            _uiInputModule.point = uiActions.Cursor.GetActionReference();
            _uiInputModule.scrollWheel = uiActions.Scroll.GetActionReference();
        }

        void ICombatActions.OnMovement(InputAction.CallbackContext context)
        {
            var moveVector = context.ReadValue<Vector2>();
            _logService.Info(_logChannel, $"Move = {moveVector}");
            OnMove?.Invoke(moveVector);
        }

        void ICombatActions.OnOrientation(InputAction.CallbackContext context)
        {
            var lookVector = context.ReadValue<Vector2>();
            _logService.Info(_logChannel, $"Look = {lookVector}");
            OnLook?.Invoke(lookVector);
        }

        void ICombatActions.OnFire(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    OnFireStart?.Invoke();
                    break;
                case InputActionPhase.Canceled:
                    OnFireStop?.Invoke();
                    break;
            }
        }
    }
}
