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

        ///<summary>
        /// ApiKey: To use the map you'll need your own Google API key. More information here: https://developers.google.com/maps/documentation/javascript/error-messages#no-api-keys
        ///</summary>
        [RenderingPropertyAlias("apiKey")]
        public string ApiKey
        {
            get { return Content.GetPropertyValue<string>("apiKey"); }
        }

        ///<summary>
        /// Pick a Contact Form: If Umbraco Forms is installed you'll be able to select a form here.
        ///</summary>
        [RenderingPropertyAlias("contactForm")]
        public string ContactForm
        {
            get { return Content.GetPropertyValue<string>("contactForm"); }
        }

        ///<summary>
        /// Contact Form Header
        ///</summary>
        [RenderingPropertyAlias("contactFormHeader")]
        public string ContactFormHeader
        {
            get { return Content.GetPropertyValue<string>("contactFormHeader"); }
        }

        ///<summary>
        /// Contact Intro
        ///</summary>
        [RenderingPropertyAlias("contactIntro")]
        public IHtmlString ContactIntro
        {
            get { return Content.GetPropertyValue<IHtmlString>("contactIntro"); }
        }

        ///<summary>
        /// Your Address: Plot your address on the map and it'll be displayed on the contact page
        ///</summary>
        [RenderingPropertyAlias("map")]
        public Terratype.Models.Model Map
        {
            get { return Content.GetPropertyValue<Terratype.Models.Model>("map"); }
        }

        ///<summary>
        /// Map Header
        ///</summary>
        [RenderingPropertyAlias("mapHeader")]
        public string MapHeader
        {
            get { return Content.GetPropertyValue<string>("mapHeader"); }
        }

    }
}