using Renderings;
using System.Collections.Generic;
using RenderingsExample.Business;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Linq;
using RenderingsExample.Business.Blogs;

namespace RenderingsExample.Models.ViewModels
{
    [RenderingDocumentAlias("blog")]
    public class Blog : PageBase
    {
        private readonly IRenderingCreatorScoped _renderignCreator;

        public IRenderingAliasResolver _renderingResolver { get; }

        private readonly BlogListingService _blogListingService;

        public Blog(IPublishedContent content, ViewDependencies viewDependencies, BlogListingService blogListingService) : base(content, viewDependencies)
        {
            _renderignCreator = viewDependencies.RenderingCreatorScoped;
            _renderingResolver = viewDependencies.RenderingAliasResolver;
            _blogListingService = blogListingService;
        }

        public IEnumerable<BlogPost> BlogPosts
        {
            get
            {
                return _blogListingService.GetBlogPosts(Content.Id, HowManyPostsShouldBeShown);
            }
        }

        [RenderingPropertyAlias("disqusShortname")]
        public string DisqusShortname
        {
            get { return Content.GetPropertyValue<string>("disqusShortname"); }
        }

        ///<summary>
        /// How many posts should be shown?
        ///</summary>
        [RenderingPropertyAlias("howManyPostsShouldBeShown")]
        public int HowManyPostsShouldBeShown
        {
            get { return Content.GetPropertyValue<int>("howManyPostsShouldBeShown"); }
        }
    }
}