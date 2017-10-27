using Renderings;
using RenderingsExample.Models.ViewModels;
using DotNetStarter.Abstractions;

namespace RenderingsExample.Business.RenderingEngine.Selectors
{
    [Register(typeof(ITemplateSelector), LifeTime.Singleton, typeof(DefaultPageSelector))]
    public class ProductSelector : ITemplateSelector
    {
        public bool IsMatch(IRendering rendering, string tagName)
        {
            return rendering is Product && string.IsNullOrWhiteSpace(tagName);
        }

        public string ViewPath(IRendering rendering, string tagName)
        {
            return string.Format(RenderingCoordinator.PagePartialFormat, nameof(Product));
        }
    }
}