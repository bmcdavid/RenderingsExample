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
        private readonly ContentConversionService _ContentConverter;

        public Products(IPublishedContent content, ViewDependencies viewDependencies) : base(content, viewDependencies)
        {
            _ContentConverter = viewDependencies.ContentConversionService;
        }
        
		[RenderingPropertyAlias("defaultCurrency")]
        public string DefaultCurrency
        {
            get { return Content.GetPropertyValue<string>("defaultCurrency"); }
        }
        
        [RenderingPropertyAlias("featuredProducts")]
        public IEnumerable<Product> FeaturedProducts
        {
            get
            {
                var featured = Content.GetPropertyValue<IEnumerable<IPublishedContent>>("featuredProducts");

                return _ContentConverter.ConvertToRenderings<Product>(featured);
            }
        }
    }
}