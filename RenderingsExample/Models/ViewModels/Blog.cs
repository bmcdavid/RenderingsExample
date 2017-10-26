using Renderings;
using System.Collections.Generic;
using RenderingsExample.Business;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Linq;

namespace RenderingsExample.Models.ViewModels
{
    [RenderingDocumentAlias("blog")]
    public class Blog : PageBase
    {
        private readonly IRenderingCreatorScoped _renderignCreator;

        public IRenderingAliasResolver _renderingResolver { get; }

        public Blog(IPublishedContent content, ViewDependencies viewDependencies) : base(content, viewDependencies)
        {
            _renderignCreator = viewDependencies.RenderingCreatorScoped;
            _renderingResolver = viewDependencies.RenderingAliasResolver;
        }

        public IEnumerable<BlogPost> BlogPosts
        {
            get
            {
                var postAlias = _renderingResolver.ResolveType(typeof(BlogPost));
                var creator = _renderignCreator.GetCreator<IPublishedContent>(postAlias);

                var children = Content.Children
                            .Where(x => x.DocumentTypeAlias == postAlias)
                            .OrderByDescending(x => x.CreateDate)
                            .Take(HowManyPostsShouldBeShown);

                foreach(var x in children)
                {
                    yield return creator.Invoke(x) as BlogPost;
                }
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