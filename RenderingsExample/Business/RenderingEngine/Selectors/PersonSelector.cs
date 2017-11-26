using Renderings;
using RenderingsExample.Models.ViewModels;
using DotNetStarter.Abstractions;

namespace RenderingsExample.Business.RenderingEngine.Selectors
{
    /// <summary>
    /// The typeof(DefaultPageSelector) allows this selector to override the default
    /// </summary>
    [Registration(typeof(ITemplateSelector), Lifecycle.Singleton, typeof(DefaultPageSelector))]
    public class PersonSelector : ITemplateSelector
    {
        public bool IsMatch(IRendering rendering, string tagName)
        {
            return rendering is Person; // no tag allows this to be a fallback
        }

        public string ViewPath(IRendering rendering, string tagName)
        {
            return string.Format(RenderingCoordinator.PagePartialFormat, nameof(Person));
        }
    }
}