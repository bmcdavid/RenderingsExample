using DotNetStarter.Abstractions;
using Renderings;
using RenderingsExample.Models.ViewModels;
using RenderingsExample.Models.ViewModels.Blocks;

namespace RenderingsExample.Business
{
    [Registration(typeof(RenderingCoordinator), Lifecycle.Singleton)]
    public class RenderingCoordinator
    {
        public string PagePartialFormat = "~/Views/Partials/Pages/{0}.cshtml";

        public string BlockPartialFormat = "~/Views/Partials/Blocks/{0}.cshtml";

        public string GetViewForRendering(IRendering rendering, string tagName)
        {
            if (rendering is BlogPost)
            {
                return string.Format(PagePartialFormat, nameof(BlogPost));
            }

            if (rendering is BlockBase)
            {
                return string.Format(BlockPartialFormat, rendering.GetType().Name);
            }

            if (rendering is PageBase)
            {
                return string.Format(PagePartialFormat, nameof(PageBase));
            }

            return "Empty";
        }
    }
}