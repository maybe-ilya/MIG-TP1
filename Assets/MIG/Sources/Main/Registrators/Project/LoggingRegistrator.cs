using MIG.API;
using MIG.Logging;
using VContainer;
using UnityEngine;

namespace MIG.Main
{
    internal sealed class LoggingRegistrator : ProjectRegistrator
    {
        [SerializeField]
        private LogServiceSettings _defaultLogServiceSettings;

        [SerializeField]
        private LogServiceSettings _editorLogServiceSettings;

        public override void Register(IContainerBuilder builder)
        {
            builder.RegisterInstance(ApplicationExtensions.IsEditor ? _editorLogServiceSettings : _defaultLogServiceSettings);
            builder.Register<UnityLogTarget>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<LogService>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
