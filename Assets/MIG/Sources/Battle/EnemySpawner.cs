using MIG.API;
using UnityEngine;

namespace MIG.Battle
{
    public sealed class EnemySpawner : MonoBehaviour, IEnemySpawner
    {
        [SerializeField]
        [CheckObject]
        private Transform _transform;
        [SerializeField]
        private Vector3 _size;

        [Header("Debug")]
        [SerializeField]
        private Color _debugCudeColor;
        [SerializeField]
        private Color _debugWireColor;

        public Vector3 Position => _transform.position;

        public Vector3 Size => _size;

#if UNITY_EDITOR
        private void Reset()
        {
            _transform = transform;
        }

        private void OnDrawGizmos()
        {
            using var _1 = new GizmosMatrixScope(_transform.localToWorldMatrix);

            using var _2 = new GizmosColorScope(_debugCudeColor);
            Gizmos.DrawCube(Vector3.zero, _size);

            using var _3 = new GizmosColorScope(_debugWireColor);
            Gizmos.DrawWireCube(Vector3.zero, _size);
        }
#endif
    }
}
