using Renderings;
using RenderingsExample.Models.ViewModels;
using DotNetStarter.Abstractions;

namespace RenderingsExample.Business.RenderingEngine.Selectors
{
    /// <summary>
    /// The typeof(DefaultPageSelector), typeof(BlogPostSelector) allows this selector to override both the default and BlogPost when the tagName is Macro
    /// </summary>
    [Registration(typeof(ITemplateSelector), Lifecycle.Singleton, typeof(DefaultPageSelector), typeof(BlogPostSelector))]
    public class BlogPostMacroSelector : ITemplateSelector
    {
        public bool IsMatch(IRendering rendering, string tagName)
        {
            return rendering is BlogPost && tagName == Constants.Tags.Macro;
        }

        public string ViewPath(IRendering rendering, string tagName)
        {
            return string.Format(RenderingCoordinator.PagePartialFormat, $"{nameof(BlogPost)}-{Constants.Tags.Macro}");
        }
    }
}