using DotNetStarter.Abstractions;
using Umbraco.Core.Models;

namespace RenderingsExample
{
    //[StartupModule]
    public class HackForLightInject : IStartupModule
    {
        public void Shutdown() { }

        public void Startup(IStartupEngine engine)
        {
            if ((engine.Locator as ILocator)?.InternalContainer is LightInject.IServiceContainer lightInjectContainer)
            {
                lightInjectContainer.RegisterConstructorDependency((factory, info, runArgs) => (string)runArgs[0]);

                // hack: needed for injecting IPublishedContent into renderings
                lightInjectContainer.RegisterConstructorDependency((factory, info, runArgs) => (IPublishedContent)runArgs[0]);
            }
        }
    }
}