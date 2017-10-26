using RenderingsExample.Business;
using Umbraco.Core.Models;
using Renderings;

namespace RenderingsExample.Models.ViewModels
{
    [RenderingDocumentAlias("contentPage")]
    public class ContentPage : PageBase
    {
        public ContentPage(IPublishedContent content, ViewDependencies viewDependencies) : base(content, viewDependencies)
        {
        }
    }
}