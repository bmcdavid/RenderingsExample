using Newtonsoft.Json.Linq;
using Renderings;
using RenderingsExample.Business;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace RenderingsExample.Models.ViewModels
{
    [RenderingDocumentAlias("product")]
    public class Product : PageBase
    {
        private readonly IRenderingAliasResolver _Resolver;
        private readonly ContentConversionService _ContentConverter;

        public Product(IPublishedContent content, ViewDependencies viewDependencies) : base(content, viewDependencies)
        {
            _Resolver = viewDependencies.RenderingAliasResolver;
            _ContentConverter = viewDependencies.ContentConversionService;
        }

        ///<summary>
		/// Category
		///</summary>
		[RenderingPropertyAlias("category")]
        public IEnumerable<string> Category
        {
            get { return Content.GetPropertyValue<IEnumerable<string>>("category"); }
        }

        ///<summary>
        /// Description
        ///</summary>
        [RenderingPropertyAlias("description")]
        public string Description
        {
            get { return Content.GetPropertyValue<string>("description"); }
        }

        ///<summary>
        /// Features
        ///</summary>
        [RenderingPropertyAlias("features")]
        public IEnumerable<Blocks.Feature> Features
        {
            get
            {
                var features = Content.GetPropertyValue<IEnumerable<IPublishedContent>>("features");

                return _ContentConverter.ConvertToRenderings<Blocks.Feature>(features);
            }
        }

        ///<summary>
        /// Photos: You can add multiple photos - the first one will be the default and used in overviews and lists
        ///</summary>
        [RenderingPropertyAlias("photos")]
        public IEnumerable<IPublishedContent> Photos
        {
            get { return Content.GetPropertyValue<IEnumerable<IPublishedContent>>("photos"); }
        }

        ///<summary>
        /// Price
        ///</summary>
        [RenderingPropertyAlias("price")]
        public decimal Price
        {
            get { return Content.GetPropertyValue<decimal>("price"); }
        }

        ///<summary>
        /// Product Name
        ///</summary>
        [RenderingPropertyAlias("productName")]
        public string ProductName
        {
            get { return Content.GetPropertyValue<string>("productName"); }
        }

        public string DefaultCurrency
        {
            get
            {
                // Example of getting a property alias without re-typing magic string
                var alias = _Resolver.ResolvePropertyAlias<Products>(p => p.DefaultCurrency);
                return Content.GetPropertyValue<string>(alias, true);
            }
        }

        ///<summary>
        /// SKU
        ///</summary>
        [RenderingPropertyAlias("sku")]
        public string Sku
        {
            get { return Content.GetPropertyValue<string>("sku"); }
        }
    }
}