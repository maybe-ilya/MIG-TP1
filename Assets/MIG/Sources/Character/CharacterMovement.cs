using MIG.API;
using System;
using System.Diagnostics;
using UnityEngine;
using UDebug = UnityEngine.Debug;

namespace MIG.Character
{
    [RequireComponent(typeof(CharacterController))]
    internal sealed class CharacterMovement : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField]
        [CheckObject]
        private Transform _transform;
        [SerializeField]
        [CheckObject]
        private CharacterController _characterController;

        [Header("Properties")]
        [SerializeField]
        private float _maxSpeed;
        [SerializeField]
        private float _acceleration;
        [SerializeField]
        private float _deceleration;
        [SerializeField]
        private float _rotationSpeed;

        [Header("Debug")]
        [SerializeField]
        private Color _debugDirectionColor;
        [SerializeField]
        [Min(1.0f)]
        private float _debugDirectionMagnitude = 1.0f;

        private const float GRAVITY = -9.81f;

        private Vector3 _moveInput;
        private bool _isAccelerating;
        private float _verticalVelocity;
        private Vector3 _lookInput;
        private float _currentSpeed;

        private bool IsGrounded => _characterController.isGrounded;

        public void ApplyMoveInput(Vector2 input)
        {
            _isAccelerating = input.sqrMagnitude > 0;
            if (_isAccelerating)
            {
                _moveInput = new Vector3(input.x, 0.0f, input.y);
            }
        }

        public void ApplyLookInput(Vector2 input)
        {
            if (input.sqrMagnitude > 0)
            {
                _lookInput = new Vector3(input.x, 0.0f, input.y);
            }
        }

        public void SetCollisionEnabled(bool enabled)
        {
            _characterController.enabled = enabled;
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            UpdateRotation(deltaTime);
            UpdatePosition(deltaTime);
            ShowDebugDirection(deltaTime);
        }

        private void UpdatePosition(float deltaTime)
        {
            if (IsGrounded && _verticalVelocity < 0.0f)
            {
                _verticalVelocity = 0.0f;
            }
            _verticalVelocity += GRAVITY * deltaTime;

            _currentSpeed = _isAccelerating
              ? Math.Min(_currentSpeed + _acceleration * deltaTime, _maxSpeed)
              : Math.Max(_currentSpeed - _deceleration * deltaTime, 0.0f);

            var shift = _moveInput.normalized * _currentSpeed;
            shift.y = _verticalVelocity;

            _characterController.Move(shift * deltaTime);
        }

        private void UpdateRotation(float deltaTime)
        {
            _transform.forward = Vector3.Slerp(_transform.forward, _lookInput, deltaTime * _rotationSpeed);
        }

        [Conditional("UNITY_EDITOR")]
        private void ShowDebugDirection(float deltaTime)
        {
            var origin = _transform.position;
            var target = origin + _transform.forward * _debugDirectionMagnitude;

            UDebug.DrawLine(origin, target, _debugDirectionColor, deltaTime);
        }

#if UNITY_EDITOR
        private void Reset()
        {
            _transform = transform;
            _characterController = GetComponent<CharacterController>();
        }
#endif
    }
}
