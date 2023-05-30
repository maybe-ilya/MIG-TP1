using MIG.API;
using UnityEngine;
using UDebug = UnityEngine.Debug;

namespace MIG.Character
{
    public class Shotgun : AbstractWeapon
    {
        [Header("Dependencies")]
        [SerializeField]
        [CheckObject]
        private Transform _shotPoint;

        [SerializeField]
        [CheckObject]
        private Animator _animator;

        [Header("Properties")]
        [SerializeField]
        private int _shotCount;

        [SerializeField]
        [Min(0.1f)]
        private float _shotDistance = 0.1f;

        [SerializeField]
        private FloatRange _horizontalSpread;

        [SerializeField]
        private FloatRange _verticalSpread;

        [SerializeField]
        private LayerMask _attackMask;

        [SerializeField]
        private int _attackDamage;

        [SerializeField]
        private AnimatorHash _attackTrigHash = "Attack";

        [Header("Debug")]
        [SerializeField]
        private Color _debugShotRayColor;

        [SerializeField]
        private float _debugShotRayDrawTime;

        protected override void Attack()
        {
            var shotOrigin = _shotPoint.position;
            var shotOriginShift = _shotPoint.forward * _shotDistance;

            for (var iteration = 0; iteration < _shotCount; iteration++)
            {
                var horizontalShift = RandomService.GetRandomFloat(_horizontalSpread);
                var verticalShift = RandomService.GetRandomFloat(_verticalSpread);
                var shift = new Vector3(horizontalShift, verticalShift, 0.0f);
                var attackDirection = shotOriginShift + _shotPoint.TransformDirection(shift);

                UDebug.DrawLine(shotOrigin, shotOrigin + attackDirection, _debugShotRayColor, _debugShotRayDrawTime);

                if (!Physics.Raycast(shotOrigin, attackDirection, out var hit, _shotDistance, _attackMask) ||
                    !hit.collider.TryGetComponent<GameEntity>(out var entity))
                {
                    continue;
                }

                DamageService.ApplyDamage(entity, _attackDamage);
            }

            _animator.SetTrigger(_attackTrigHash);
        }
    }
}
