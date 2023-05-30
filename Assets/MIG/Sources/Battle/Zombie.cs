using MIG.API;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace MIG.Battle
{
    [RequireComponent(typeof(NavMeshAgent))]
    internal sealed class Zombie : AbstractEnemy
    {
        [Header("Dependencies")]
        [SerializeField]
        [CheckObject]
        private NavMeshAgent _navMeshAgent;

        [SerializeField]
        [CheckObject]
        private Transform _transform;

        [SerializeField]
        [CheckObject]
        private ZombieAttackComponent _attackComponent;

        [Header("Properties")]
        [SerializeField]
        private float _targetRefreshRate;

        [SerializeField]
        private float _checkAttackDistanse;

        [SerializeField]
        private float _checkAttackDot;

        [SerializeField]
        private float _attackCooldown;

        private float _targetRefreshCooldown;
        private float _currentAttackCooldown;

        protected override void OnInit()
        {
            _attackComponent.Init(DamageService);
        }

        protected override void OnTargetSet()
        {
            base.OnTargetSet();
            _navMeshAgent.enabled = true;
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            ChaseTarget(deltaTime);
            TryToAttackTarget(deltaTime);
        }

        private void ChaseTarget(float deltaTime)
        {
            _targetRefreshCooldown = Math.Max(0.0f, _targetRefreshCooldown - deltaTime);

            if (!IsTargetSet || _targetRefreshCooldown >= float.Epsilon)
            {
                return;
            }

            _navMeshAgent.SetDestination(Target.GameObject.transform.position);
            _targetRefreshCooldown = _targetRefreshRate;
        }

        private void TryToAttackTarget(float deltaTime)
        {
            _currentAttackCooldown = Math.Max(0.0f, _currentAttackCooldown - deltaTime);

            if (!IsTargetSet || _currentAttackCooldown > float.Epsilon)
            {
                return;
            }

            var targetPoint = Target.GameObject.transform.position;
            var currentPosition = _transform.position;
            var directionToTarget = targetPoint - currentPosition;

            if (directionToTarget.magnitude > _checkAttackDistanse)
            {
                return;
            }

            if (Vector3.Dot(_transform.forward, directionToTarget) < _checkAttackDot)
            {
                return;
            }

            _attackComponent.PerformAttack();
            _currentAttackCooldown = _attackCooldown;
        }

#if UNITY_EDITOR
        private void Reset()
        {
            _transform = transform;
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
#endif
    }
}
