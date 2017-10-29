using Renderings;
using RenderingsExample.Business;
using RenderingsExample.Business.Blogs;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace RenderingsExample.Models.ViewModels
{
    [RenderingDocumentAlias("blog")]
    public class Blog : PageBase
    {
        private readonly BlogListingService _blogListingService;

        public Blog(IPublishedContent content, ViewDependencies viewDependencies, BlogListingService blogListingService) : base(content, viewDependencies)
        {
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