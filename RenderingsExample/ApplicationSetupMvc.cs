using RenderingsExample.Controllers;
using Umbraco.Core;

namespace RenderingsExample
{
    /// <summary>
    /// This class registers the base application controller and setups up error page routing
    /// </summary>
    public class ApplicationSetupMvc : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationStarting(umbracoApplication, applicationContext);

            // note: this will set all routes to be hijacked by this base controller
            Umbraco.Web.Mvc.DefaultRenderMvcControllerResolver.Current.SetDefaultControllerType(typeof(CustomUmbracoMvcRenderingController));
        }
    }
}