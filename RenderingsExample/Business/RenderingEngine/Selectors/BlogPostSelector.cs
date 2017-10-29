using Renderings;
using RenderingsExample.Models.ViewModels;
using DotNetStarter.Abstractions;

namespace RenderingsExample.Business.RenderingEngine.Selectors
{
    /// <summary>
    /// The typeof(DefaultPageSelector) allows this selector to override the default
    /// </summary>
    [Register(typeof(ITemplateSelector), LifeTime.Singleton, typeof(DefaultPageSelector))]
    public class BlogPostSelector : ITemplateSelector
    {
        public bool IsMatch(IRendering rendering, string tagName)
        {
            return rendering is BlogPost; // no tag check allows this to be a fallback
        }

        public string ViewPath(IRendering rendering, string tagName)
        {
            return string.Format(RenderingCoordinator.PagePartialFormat, nameof(BlogPost));
        }
    }
}