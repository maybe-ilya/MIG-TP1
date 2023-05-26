using MIG.API;
using MIG.Logging;
using VContainer;
using UnityEngine;

namespace MIG.Main
{
    internal sealed class LoggingRegistrator : ProjectRegistrator
    {
        [SerializeField]
        private LogServiceSettings _logServiceSettings;

        public override void Register(IContainerBuilder builder)
        {
            builder.RegisterInstance(_logServiceSettings);
            builder.Register<UnityLogTarget>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<LogService>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.RegisterBuildCallback(container =>
            {
                container.Resolve<ILogService>();
            });
        }
    }
}
