using DotNetStarter.Abstractions;
using Umbraco.Core.Models;

namespace RenderingsExample
{
    [StartupModule]
    public class HackForLightInject : ILocatorConfigure
    {
        void ILocatorConfigure.Configure(ILocatorRegistry registry, ILocatorConfigureEngine engine)
        {
            if (registry.InternalContainer is LightInject.IServiceContainer lightInjectContainer)
            {
                lightInjectContainer.RegisterConstructorDependency((factory, info, runArgs) => (string)runArgs[0]);

                // hack: needed for injecting IPublishedContent into renderings
                lightInjectContainer.RegisterConstructorDependency((factory, info, runArgs) => (IPublishedContent)runArgs[0]);
            }
        }
    }
}