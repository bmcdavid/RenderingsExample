using Renderings;
using RenderingsExample.Models.ViewModels;
using DotNetStarter.Abstractions;

namespace RenderingsExample.Business.RenderingEngine.Selectors
{
    [Register(typeof(ITemplateSelector), LifeTime.Singleton)]
    public class DefaultPageSelector : ITemplateSelector
    {
        public bool IsMatch(IRendering rendering, string tagName)
        {
            return rendering is PageBase;
        }

        public string ViewPath(IRendering rendering, string tagName)
        {
            return string.Format(RenderingCoordinator.PagePartialFormat, nameof(PageBase));
        }
    }
}