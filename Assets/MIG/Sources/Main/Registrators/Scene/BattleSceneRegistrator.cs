using MIG.API;
using MIG.Battle;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace MIG.Main
{
    public sealed class BattleSceneRegistrator : SceneRegistrator
    {
        [SerializeField]
        [CheckObject]
        private HordeModeSettings _hordeModeSettings;

        [SerializeField]
        [CheckObject]
        private EnemySpawner[] _spawners;

        public override void Register(IContainerBuilder builder)
        {
            builder.RegisterInstance<IReadOnlyList<IEnemySpawner>>(_spawners);
            builder.RegisterInstance(_hordeModeSettings);
            builder.Register<BattleService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<BattleModeFactory>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
