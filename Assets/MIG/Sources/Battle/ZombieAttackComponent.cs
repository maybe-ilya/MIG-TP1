using MIG.API;
using UnityEngine;

namespace MIG.Battle
{
    internal sealed class ZombieAttackComponent : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField]
        [CheckObject]
        private Transform _tracePoint;

        [SerializeField]
        [CheckObject]
        private Animator _animator;

        [Header("Properties")]
        [SerializeField]
        [Min(0.1f)]
        private float _traceRadius = 0.1f;

        [SerializeField]
        [Min(0.1f)]
        private float _traceDistance = 0.1f;

        [SerializeField]
        private LayerMask _traceMask;

        [SerializeField]
        private int _damage;

        [SerializeField]
        private AnimatorHash _attackTrigHash = "Attack";

        [Header("Debug")]
        [SerializeField]
        private Color _gizmoColor;

        private IDamageService _damageService;

        public void Init(IDamageService damageService)
        {
            _damageService = damageService;
        }

        public void PerformAttack()
        {
            if (!Physics.SphereCast(_tracePoint.position, _traceRadius, _tracePoint.forward,
                out var hit, _traceDistance, _traceMask))
            {
                return;
            }

            if (!hit.collider.gameObject.TryGetComponent<GameEntity>(out var entity))
            {
                return;
            }

            _damageService.ApplyDamage(entity, _damage);
            _animator.SetTrigger(_attackTrigHash);
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (_tracePoint == null)
            {
                return;
            }

            using (new GizmosMatrixScope(_tracePoint.localToWorldMatrix))
            using (new GizmosColorScope(_gizmoColor))
            {
                Gizmos.DrawLine(Vector3.zero, Vector3.forward * _traceDistance);
                Gizmos.DrawWireSphere(Vector3.zero, _traceRadius);
                Gizmos.DrawWireSphere(Vector3.forward * _traceDistance, _traceRadius);
            }
        }
#endif
    }
}
