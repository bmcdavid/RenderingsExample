using DotNetStarter.Abstractions;
using DotNetStarter.Configure;
using System.Configuration;

namespace RenderingsExample
{
    public class Application : Umbraco.Web.UmbracoApplication
    {
        private static StartupBuilder _startupBuilder; // to avoid trying to start twice

        /// <summary>
        /// Executs DotNetStarter.ApplicationContext.Startup, this class is used in the global.asax inherits
        /// </summary>
        public Application()
        {
            if (_startupBuilder != null) return;
            _startupBuilder = StartupBuilder.Create()
                .UseEnvironment(new DotNetStarter.Web.StartupEnvironmentWeb(environmentName: ConfigurationManager.AppSettings["UmbracoEnv"]))
                .ConfigureAssemblies(assemblies =>
                {
                    assemblies
                    .WithDiscoverableAssemblies()
                    .WithAssemblyFromType<Umbraco.Web.UmbracoApplication>()// Scan for backoffice controllers
                    // add additional umbraco plugins, which inject controllers
                    //.WithAssemblyFromType<Umbraco.Forms.Web.Controllers.UmbracoFormsController>()
                    //.WithAssemblyFromType<Diplo.TraceLogViewer.Controllers.TraceLogTreeController>()
                    .WithAssemblyFromType<Application>();//types in this project
                })
                .OverrideDefaults(defaults =>
                {
                    defaults
                    // hack: Each of these implementations may also be passed an already configured DI container instances
                    //.UseLocatorRegistryFactory(new DotNetStarter.Locators.DryIocLocatorFactory())
                    .UseLocatorRegistryFactory(new DotNetStarter.Locators.StructureMapFactory())
                    //.UseLocatorRegistryFactory(new DotNetStarter.Locators.LightInjectLocatorRegistryFactory())
                    .UseLogger(new DotNetStarter.StringLogger(LogLevel.Error, 1024000)); // clears log after 1MB
                })
                .Build();
            _startupBuilder.Run();
        }
    }
}