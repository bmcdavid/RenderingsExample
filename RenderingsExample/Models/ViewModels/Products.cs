using Renderings;
using RenderingsExample.Business;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace RenderingsExample.Models.ViewModels
{
    [RenderingDocumentAlias("products")]
    public class Products : PageBase
    {
        private IRenderingCreatorScoped _Creator;
        private IRenderingAliasResolver _Resolver;

        public Products(IPublishedContent content, ViewDependencies viewDependencies) : base(content, viewDependencies)
        {
            _Creator = viewDependencies.RenderingCreatorScoped;
            _Resolver = viewDependencies.RenderingAliasResolver;
        }

        ///<summary>
		/// Default Currency: This is just used to prefix pricing
		///</summary>
		[RenderingPropertyAlias("defaultCurrency")]
        public string DefaultCurrency
        {
            get { return Content.GetPropertyValue<string>("defaultCurrency"); }
        }

        ///<summary>
        /// Featured Products
        ///</summary>
        [RenderingPropertyAlias("featuredProducts")]
        public IEnumerable<Product> FeaturedProducts
        {
            get
            {
                var alias = _Resolver.ResolveType(typeof(Product));
                var creator = _Creator.GetCreator<IPublishedContent>(alias);
                var featured = Content.GetPropertyValue<IEnumerable<IPublishedContent>>("featuredProducts");

                foreach (var product in featured)
                {
                    yield return creator.Invoke(product) as Product;
                }
            }
        }
    }
}