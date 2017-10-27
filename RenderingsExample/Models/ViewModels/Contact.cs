using System.Web;
using RenderingsExample.Business;
using Umbraco.Core.Models;
using Renderings;
using Umbraco.Web;

namespace RenderingsExample.Models.ViewModels
{
    [RenderingDocumentAlias("contact")]
    public class Contact : PageBase
    {
        public Contact(IPublishedContent content, ViewDependencies viewDependencies) : base(content, viewDependencies)
        {
        }
        
        [RenderingPropertyAlias("apiKey")]
        public string ApiKey
        {
            get { return Content.GetPropertyValue<string>("apiKey"); }
        }
        
        [RenderingPropertyAlias("contactForm")]
        public string ContactForm
        {
            get { return Content.GetPropertyValue<string>("contactForm"); }
        }
        
        [RenderingPropertyAlias("contactFormHeader")]
        public string ContactFormHeader
        {
            get { return Content.GetPropertyValue<string>("contactFormHeader"); }
        }
        
        [RenderingPropertyAlias("contactIntro")]
        public IHtmlString ContactIntro
        {
            get { return Content.GetPropertyValue<IHtmlString>("contactIntro"); }
        }
        
        [RenderingPropertyAlias("map")]
        public Terratype.Models.Model Map
        {
            get { return Content.GetPropertyValue<Terratype.Models.Model>("map"); }
        }
        
        [RenderingPropertyAlias("mapHeader")]
        public string MapHeader
        {
            get { return Content.GetPropertyValue<string>("mapHeader"); }
        }

    }
}