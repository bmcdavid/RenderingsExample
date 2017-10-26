using DotNetStarter.Abstractions;
using Renderings;
using Renderings.UmbracoCms;
using RenderingsExample.Models.ViewModels;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace RenderingsExample.Models
{
    /// <summary>
    /// This class is for non content specific layout settings
    /// </summary>
    [Registration(typeof(LayoutModel), Lifecycle.Scoped)]
    public class LayoutModel
    {
        private readonly IHomepageResolver _homepageResolver;
        private readonly UmbracoHelper _umbracoHelper;
        private readonly IRenderingCreatorScoped _renderingCreatorScoped;
        private Home _Home;
        private SiteSettings _Settings;

        public LayoutModel(IHomepageResolver homepageResolver, UmbracoHelper umbracoHelper, IRenderingCreatorScoped renderingCreatorScoped)
        {
            _homepageResolver = homepageResolver;
            _umbracoHelper = umbracoHelper;
            _renderingCreatorScoped = renderingCreatorScoped;
        }

        public Home HomePage
        {
            get
            {
                if (_Home == null)
                {
                    var homepageId = _homepageResolver.ResolveHomepageNodeId(_umbracoHelper);
                    var publishedHome = _umbracoHelper.TypedContent(homepageId);
                    var creator = _renderingCreatorScoped.GetCreator<IPublishedContent>(publishedHome.DocumentTypeAlias);
                    _Home = creator.Invoke(publishedHome) as Home;
                }

                return _Home;
            }
        }

        public SiteSettings SiteSettings
        {
            get
            {
                if (_Settings == null)
                {
                    _Settings = new SiteSettings(HomePage.Content, _umbracoHelper);
                }

                return _Settings;
            }
        }

    }
}
