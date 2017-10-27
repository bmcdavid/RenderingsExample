using Renderings;
using RenderingsExample.Business;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace RenderingsExample.Models.ViewModels
{
    [RenderingDocumentAlias("home")]
    public class Home : PageBase
    {
        public Home(IPublishedContent content, ViewDependencies viewDependencies) : base(content, viewDependencies)
        {
        }
        
        [RenderingPropertyAlias("footerCTACaption")]
        public string FooterCtacaption
        {
            get { return Content.GetPropertyValue<string>("footerCTACaption"); }
        }
        
        [RenderingPropertyAlias("FooterCtalink")]
        public IPublishedContent FooterCtalink
        {
            get { return Content.GetPropertyValue<IPublishedContent>("FooterCtalink"); }
        }
        
        [RenderingPropertyAlias("footerDescription")]
        public string FooterDescription
        {
            get { return Content.GetPropertyValue<string>("footerDescription"); }
        }
        
        [RenderingPropertyAlias("footerHeader")]
        public string FooterHeader
        {
            get { return Content.GetPropertyValue<string>("footerHeader"); }
        }
        
        [RenderingPropertyAlias("HeroBackgroundImage")]
        public string HeroBackgroundImage
        {
            get
            {
                var property = Content.GetPropertyValue<IPublishedContent>("HeroBackgroundImage");

                return property?.Url ?? string.Empty;
            }
        }
        
        [RenderingPropertyAlias("heroCTACaption")]
        public string HeroCtacaption
        {
            get { return Content.GetPropertyValue<string>("heroCTACaption"); }
        }
        
        [RenderingPropertyAlias("HeroCtalink")]
        public IPublishedContent HeroCtalink
        {
            get { return Content.GetPropertyValue<IPublishedContent>("HeroCtalink"); }
        }
        
        [RenderingPropertyAlias("heroDescription")]
        public string HeroDescription
        {
            get { return Content.GetPropertyValue<string>("heroDescription"); }
        }
        
        [RenderingPropertyAlias("heroHeader")]
        public string HeroHeader
        {
            get { return Content.GetPropertyValue<string>("heroHeader"); }
        }
    }
}