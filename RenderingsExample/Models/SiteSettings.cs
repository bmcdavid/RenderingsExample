using Renderings;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace RenderingsExample.Models
{
    public class SiteSettings
    {
        private IPublishedContent _SiteLogo;

        private string _Sitename;

        public SiteSettings(IPublishedContent content, UmbracoHelper umbracoHelper)
        {
            Content = content;
            _umbracoHelper = umbracoHelper;
        }

        ///<summary>
        /// Color Theme: This will be a custom property editor later
        ///</summary>
        [RenderingPropertyAlias("colorTheme")]
        public string ColorTheme
        {
            get
            {
                return _umbracoHelper.GetPreValueAsString(Content.GetPropertyValue<int>("colorTheme"));
            }
        }

        public IPublishedContent Content { get; }

        private readonly UmbracoHelper _umbracoHelper;

        ///<summary>
        /// Font: This will be a custom property editor later
        ///</summary>
        [RenderingPropertyAlias("font")]
        public string Font
        {
            get { return _umbracoHelper.GetPreValueAsString(Content.GetPropertyValue<int>("font")); }
        }

        ///<summary>
        /// Address
        ///</summary>
        [RenderingPropertyAlias("footerAddress")]
        public string FooterAddress
        {
            get { return Content.GetPropertyValue<string>("footerAddress"); }
        }
       
        ///<summary>
        /// Logo: Optional. If you add a logo it'll be used in the upper left corner instead of the site name. Make sure to use a transparent logo for best results
        ///</summary>
        [RenderingPropertyAlias("SiteLogo")]
        public IPublishedContent SiteLogo
        {
            get { return _SiteLogo = _SiteLogo ?? Content.GetPropertyValue<IPublishedContent>("SiteLogo"); }
        }
        ///<summary>
        /// Sitename: Used on the homepage as well as the title and social cards
        ///</summary>
        [RenderingPropertyAlias("sitename")]
        public string Sitename
        {
            get { return _Sitename = _Sitename ?? Content.GetPropertyValue<string>("sitename"); }
        }
    }
}