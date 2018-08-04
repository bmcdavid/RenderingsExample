using DotNetStarter.Abstractions;

namespace RenderingsExample.Business.StartupModules
{
    /// <summary>
    /// Custom locator configure which runs after Registration and Register attributes are added
    /// </summary>
    [StartupModule(typeof(RegistrationConfiguration))]
    public class CustomStartup : ILocatorConfigure
    {
        public void Configure(ILocatorRegistry registry, IStartupEngine engine)
        {
            // todo: can add addtional wire-ups here
            //registry.Add<ISomeService, SomeService>(lifetime: LifeTime.Singleton);
        }
    }
}