using MIG.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MIG.Character
{
    [RequireComponent(typeof(CharacterController))]
    internal sealed class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        [CheckObject]
        private Transform _transform;

        [SerializeField]
        [CheckObject]
        private CharacterController _characterController;

        [SerializeField]
        private float _maxSpeed;

        private Vector3 _moveInput;
        private Vector3 _lookInput;
        private Vector3 _velocity;

        public void ApplyMoveInput(Vector2 input)
        {
            _moveInput = new Vector3(input.x, 0.0f, input.y);
        }

        public void ApplyLookInput(Vector2 input)
        {
            _lookInput = new Vector3(input.x, 0.0f, input.y);
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
        }

        private void UpdatePosition(float deltaTime)
        {
            _velocity += _moveInput * _maxSpeed * deltaTime;
            _characterController.Move(_velocity);
        }

        private void UpdateRotation(float deltaTime)
        {

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
