using MIG.API;
using MIG.Player;
using UnityEngine;
using VContainer;

namespace MIG.Main
{
    public sealed class PlayerStartRegistrator : SceneRegistrator
    {
        [SerializeField]
        [CheckObject]
        private PlayerStart _playerStart;

        public override void Register(IContainerBuilder builder)
        {
            builder.RegisterInstance<IPlayerStart>(_playerStart);
        }
    }
}
