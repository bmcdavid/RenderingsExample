using DotNetStarter.Abstractions;

namespace RenderingsExample.Business.Startup
{
    /// <summary>
    /// Custom locator configure which runs after Registration and Register attributes are added
    /// </summary>
    [StartupModule(typeof(DotNetStarter.RegistrationConfiguration), typeof(DotNetStarter.RegisterConfiguration))]
    public class CustomStartup : ILocatorConfigure
    {
        public void Configure(ILocatorRegistry registry, IStartupEngine engine)
        {
            // todo: can add addtional wire-ups here
            //registry.Add<ISomeService, SomeService>(lifetime: LifeTime.Singleton);
        }
    }
}