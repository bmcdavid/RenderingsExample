using DotNetStarter.Abstractions;
using Renderings;
using Renderings.UmbracoCms;
using System.Collections.Generic;
using Umbraco.Core.Models;

namespace RenderingsExample.Business
{
    /// <summary>
    /// Simplifies conversions from IPublishedContent to IUmbracoRendering
    /// </summary>
    [Registration(typeof(ContentConversionService), Lifecycle.Scoped)]
    public class ContentConversionService
    {
        private readonly IRenderingAliasResolver _Resolver;
        private readonly IRenderingCreatorScoped _Creator;

        public ContentConversionService(IRenderingAliasResolver renderingAliasResolver, IRenderingCreatorScoped renderingCreatorScoped)
        {
            _Resolver = renderingAliasResolver;
            _Creator = renderingCreatorScoped;            
        }

        /// <summary>
        /// Assumes all content is same type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="publishedContent"></param>
        /// <returns></returns>
        public IEnumerable<T> ConvertToRenderings<T>(IEnumerable<IPublishedContent> publishedContent) where T : IUmbracoRendering
        {
            if (publishedContent == null)
                yield break;

            var alias = _Resolver.ResolveType(typeof(T));
            var creator = _Creator.GetCreator<IPublishedContent>(alias);

            foreach (var item in publishedContent)
            {
                yield return (T)creator.Invoke(item);
            }            
        }
    }
}