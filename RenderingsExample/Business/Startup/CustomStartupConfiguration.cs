using DotNetStarter.Abstractions;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace RenderingsExample.Business.Startup
{
    /// <summary>
    /// Example startup configuration which sets the environment from the app setting 'UmbracoEnv';
    /// </summary>
    public class CustomStartupConfiguration : IStartupConfigurationWithEnvironment<IStartupEnvironmentWeb>
    {
        public CustomStartupConfiguration(IEnumerable<Assembly> assemblies)
        {
            Assemblies = assemblies;
            Environment = new DotNetStarter.Web.StartupEnvironmentWeb(environmentName: ConfigurationManager.AppSettings["UmbracoEnv"]);
            DependencyFinder = new DotNetStarter.DependencyFinder();
            DependencySorter = new DotNetStarter.DependencySorter();
            AssemblyFilter = null;
            AssemblyScanner = new DotNetStarter.AssemblyScanner();
            Logger = new DotNetStarter.StringLogger();
            ModuleFilter = new DotNetStarter.StartupModuleFilter();
            TimedTaskManager = new DotNetStarter.TimedTaskManager();
        }

        public IEnumerable<Assembly> Assemblies { get; }
        public IAssemblyFilter AssemblyFilter { get; }
        public IAssemblyScanner AssemblyScanner { get; }
        public IDependencyFinder DependencyFinder { get; }
        public IDependencySorter DependencySorter { get; }
        public IStartupEnvironmentWeb Environment { get; }
        IStartupEnvironment IStartupConfigurationWithEnvironment.Environment => Environment;
        public IStartupLogger Logger { get; }
        public IStartupModuleFilter ModuleFilter { get; }
        public ITimedTaskManager TimedTaskManager { get; }
    }
}