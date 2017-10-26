using DotNetStarter.Abstractions;
using Renderings;
using RenderingsExample.Models.ViewModels;

namespace RenderingsExample.Business
{
    [Registration(typeof(RenderingCoordinator), Lifecycle.Singleton)]
    public class RenderingCoordinator
    {
        public string PagePartialFormat = "~/Views/Partials/Pages/{0}.cshtml";

        public string GetViewForRendering(IRendering rendering, string tagName)
        {
            if (rendering is BlogPost)
            {
                return string.Format(PagePartialFormat, nameof(BlogPost));
            }

            if (rendering is PageBase)
            {
                return string.Format(PagePartialFormat, nameof(PageBase));
            }

            return "Empty";
        }
    }
}