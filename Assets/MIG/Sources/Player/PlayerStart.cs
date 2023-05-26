using MIG.API;
using UnityEngine;

namespace MIG.Player
{
    public sealed class PlayerStart : MonoBehaviour, IPlayerStart
    {
        [SerializeField]
        [CheckObject]
        private Transform _transform;

        public Vector3 Position => _transform.position;

#if UNITY_EDITOR
        private void Reset()
        {
            _transform = transform;
        }
#endif
    }
}
