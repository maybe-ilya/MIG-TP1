using MIG.API;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MIG.Main
{
    public abstract class AbstractLifetimeScope<T> : LifetimeScope where T : AbstractRegistrator
    {
        [SerializeField]
        [CheckObject]
        private T[] _registrators;

        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var registrator in _registrators)
            {
                registrator.Register(builder);
            }
        }
    }
}
