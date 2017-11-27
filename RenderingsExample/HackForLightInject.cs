using DotNetStarter.Abstractions;
using Umbraco.Core.Models;

namespace RenderingsExample
{
    [StartupModule]
    public class HackForLightInject : IStartupModule
    {
        public void Shutdown() { }

        public void Startup(IStartupEngine engine)
        {
            var lightInjectContainer = (engine.Locator as ILocator)?.InternalContainer as LightInject.IServiceContainer;

            if (lightInjectContainer != null)
            {
                // hack: needed for injecting IPublishedContent into renderings
                lightInjectContainer.RegisterConstructorDependency((factory, info, runArgs) => (IPublishedContent)runArgs[0]);
            }
        }
    }
}