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

        ///<summary>
        /// Call To Action Caption: Caption on the Call To Action Button
        ///</summary>
        [RenderingPropertyAlias("footerCTACaption")]
        public string FooterCtacaption
        {
            get { return Content.GetPropertyValue<string>("footerCTACaption"); }
        }

        ///<summary>
        /// Call To Action Link
        ///</summary>
        [RenderingPropertyAlias("FooterCtalink")]
        public IPublishedContent FooterCtalink
        {
            get { return Content.GetPropertyValue<IPublishedContent>("FooterCtalink"); }
        }

        ///<summary>
        /// Description
        ///</summary>
        [RenderingPropertyAlias("footerDescription")]
        public string FooterDescription
        {
            get { return Content.GetPropertyValue<string>("footerDescription"); }
        }

        ///<summary>
        /// Header
        ///</summary>
        [RenderingPropertyAlias("footerHeader")]
        public string FooterHeader
        {
            get { return Content.GetPropertyValue<string>("footerHeader"); }
        }

        ///<summary>
        /// Hero Background: Spice up the homepage by adding a beautiful photo that relates to your business
        ///</summary>
        [RenderingPropertyAlias("HeroBackgroundImage")]
        public string HeroBackgroundImage
        {
            get
            {
                var property = Content.GetPropertyValue<IPublishedContent>("HeroBackgroundImage");

                return property?.Url ?? string.Empty;
            }
        }

        ///<summary>
        /// Call To Action Caption: The caption on the button
        ///</summary>
        [RenderingPropertyAlias("heroCTACaption")]
        public string HeroCtacaption
        {
            get { return Content.GetPropertyValue<string>("heroCTACaption"); }
        }

        ///<summary>
        /// Call To Action Link
        ///</summary>
        [RenderingPropertyAlias("HeroCtalink")]
        public IPublishedContent HeroCtalink
        {
            get { return Content.GetPropertyValue<IPublishedContent>("HeroCtalink"); }
        }

        ///<summary>
        /// Description
        ///</summary>
        [RenderingPropertyAlias("heroDescription")]
        public string HeroDescription
        {
            get { return Content.GetPropertyValue<string>("heroDescription"); }
        }

        ///<summary>
        /// Header: This is the main headline for the hero area on the Homepage
        ///</summary>
        [RenderingPropertyAlias("heroHeader")]
        public string HeroHeader
        {
            get { return Content.GetPropertyValue<string>("heroHeader"); }
        }
    }
}