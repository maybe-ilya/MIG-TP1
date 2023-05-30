using MIG.API;
using MIG.Battle;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MIG.Main
{
    public sealed class BattleSceneRegistrator : SceneRegistrator
    {
        [SerializeField]
        [CheckObject]
        private HordeModeSettings _hordeModeSettings;

        [SerializeField]
        [CheckObject]
        private EnemySpawnerCollection _enemySpawnerCollection;

        public override void Register(IContainerBuilder builder)
        {
            builder.RegisterComponent<IEnemySpawnerCollection>(_enemySpawnerCollection);
            builder.RegisterInstance(_hordeModeSettings);
            builder.Register<BattleService>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<BattleModeFactory>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<BattleLevelDependencies>(Lifetime.Transient).AsSelf();
            builder.RegisterBuildCallback(container => container.Resolve<BattleLevelDependencies>());
        }
    }
}
