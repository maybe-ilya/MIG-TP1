using VContainer;

namespace MIG.Main
{
    public class ProjectLifetimeScope : AbstractLifetimeScope<ProjectRegistrator>
    {
        protected override void Configure(IContainerBuilder builder)
        {
            DontDestroyOnLoad(this);
            base.Configure(builder);
        }
    }
}
