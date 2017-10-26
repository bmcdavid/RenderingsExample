using DotNetStarter.Abstractions;
using RenderingsExample.Models.ViewModels;
using System.Collections.Generic;
using Renderings;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Linq;

namespace RenderingsExample.Business.Blogs
{
    [Registration(typeof(BlogListingService), Lifecycle.Scoped)]
    public class BlogListingService
    {
        private readonly IRenderingCreatorScoped _renderignCreator;
        private readonly IRenderingAliasResolver _renderingResolver;
        private readonly UmbracoHelper _umbracoHelper;

        public BlogListingService(ViewDependencies viewDependencies)
        {
            _renderignCreator = viewDependencies.RenderingCreatorScoped;
            _renderingResolver = viewDependencies.RenderingAliasResolver;
            _umbracoHelper = viewDependencies.UmbracoHelper;
        }

        public IEnumerable<BlogPost> GetBlogPosts(object parentNode, int max)
        {
            var parentNodeContent = _umbracoHelper.TypedContent(parentNode);
            var postAlias = _renderingResolver.ResolveType(typeof(BlogPost));
            var creator = _renderignCreator.GetCreator<IPublishedContent>(postAlias);

            var children = parentNodeContent.Children
                        .Where(x => x.DocumentTypeAlias == postAlias)
                        .OrderByDescending(x => x.CreateDate)
                        .Take(max);

            foreach (var x in children)
            {
                yield return creator.Invoke(x) as BlogPost;
            }
        }
    }
}