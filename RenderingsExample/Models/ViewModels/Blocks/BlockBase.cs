using Renderings.UmbracoCms;
using RenderingsExample.Business;
using Umbraco.Core.Models;

namespace RenderingsExample.Models.ViewModels.Blocks
{
    public abstract class BlockBase : IUmbracoRendering
    {
        private readonly RenderingCoordinator _renderingCoordinator;

        public BlockBase(IPublishedContent publishedContent, ViewDependencies viewDependencies)
        {
            _renderingCoordinator = viewDependencies.RenderingCoordinator;
            Content = publishedContent;
        }

        public bool IsFullPage => false;

        public IPublishedContent Content { get; }

        public string GetPartialView(string renderTag = null)
        {
            return _renderingCoordinator.GetViewForRendering(this, renderTag);
        }
    }
}