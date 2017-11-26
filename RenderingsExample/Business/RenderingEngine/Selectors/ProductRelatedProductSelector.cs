using Renderings;
using RenderingsExample.Models.ViewModels;
using DotNetStarter.Abstractions;

namespace RenderingsExample.Business.RenderingEngine.Selectors
{
    /// <summary>
    /// The typeof(DefaultPageSelector) allows this selector to override the default
    /// </summary>
    [Registration(typeof(ITemplateSelector), Lifecycle.Singleton, typeof(ProductSelector))]
    public class ProductRelatedProductSelector : ITemplateSelector
    {
        public bool IsMatch(IRendering rendering, string tagName)
        {
            return rendering is Product && tagName == Constants.Tags.RelatedProduct;
        }

        public string ViewPath(IRendering rendering, string tagName)
        {
            return string.Format(RenderingCoordinator.PagePartialFormat, $"{nameof(Product)}-{Constants.Tags.RelatedProduct}");
        }
    }
}