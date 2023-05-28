using MIG.API;
using MIG.Battle;
using UnityEngine;
using VContainer;

namespace MIG.Main
{
    public sealed class EnemyRegistrator : ProjectRegistrator
    {
        [SerializeField]
        [CheckObject]
        private EnemyFactorySettings _enemyFactorySettings;

        public override void Register(IContainerBuilder builder)
        {
            builder.RegisterInstance(_enemyFactorySettings);
            builder.Register<EnemyFactory>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
