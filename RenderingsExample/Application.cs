using RenderingsExample.Business.Startup;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RenderingsExample
{
    public class Application : Umbraco.Web.UmbracoApplication
    {
        public Application()
        {
            // discovers assemblies using: [assembly: DotNetStarter.Abstractions.DiscoverableAssembly]
            IList<Assembly> discoverableAssemblies = DotNetStarter.ApplicationContext.GetScannableAssemblies();
            IEnumerable<Assembly> preFilteredAssemblies = new Assembly[]
            {
                // Scan for backoffice controllers
                typeof(Umbraco.Web.UmbracoApplication).Assembly,

                // add additional umbraco plugins, which inject controllers
                //typeof(Umbraco.Forms.Web.Controllers.UmbracoFormsController).Assembly,
                //typeof(Diplo.TraceLogViewer.Controllers.TraceLogTreeController).Assembly,

                // types in this project
                typeof(Application).Assembly
            };

            //todo: add Extensions.Mvc to setup instructions
            preFilteredAssemblies = preFilteredAssemblies.Union(discoverableAssemblies);

            // can be customized further using a IStartupConfiguration implementation
            DotNetStarter.ApplicationContext.Startup(configuration: new CustomStartupConfiguration(preFilteredAssemblies));
        }
    }    
}