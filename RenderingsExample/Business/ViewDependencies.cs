using DotNetStarter.Abstractions;
using Renderings;
using RenderingsExample.Models;
using Umbraco.Web;

namespace RenderingsExample.Business
{
    /// <summary>
    /// This class simplifies passing dependencies to base classes
    /// </summary>
    [Registration(typeof(ViewDependencies), Lifecycle.Scoped)]
    public class ViewDependencies
    {
        public ViewDependencies(UmbracoHelper umbracoHelper,
            LayoutModel layoutModel,
            IRenderingAliasResolver renderingAliasResolver,
            IRenderingCreatorScoped renderingCreatorScoped, 
            RenderingCoordinator renderingCoordinator)
        {
            UmbracoHelper = umbracoHelper;
            LayoutModel = layoutModel;
            RenderingAliasResolver = renderingAliasResolver;
            RenderingCreatorScoped = renderingCreatorScoped;
            RenderingCoordinator = renderingCoordinator;
        }

        public UmbracoHelper UmbracoHelper { get; }
        public LayoutModel LayoutModel { get; }
        public IRenderingAliasResolver RenderingAliasResolver { get; }
        public IRenderingCreatorScoped RenderingCreatorScoped { get; }
        public RenderingCoordinator RenderingCoordinator { get; }
    }
}