using Newtonsoft.Json.Linq;
using Renderings;
using Renderings.UmbracoCms;
using RenderingsExample.Business;
using System.Collections.Generic;
using System.Globalization;
using Umbraco.Core.Models;
using Umbraco.Web;
using static RenderingsExample.Business.Constants;

namespace RenderingsExample.Models.ViewModels
{
    public abstract class PageBase : IUmbracoRendering, IUmbracoRenderingWithCulture, IUmbracoRenderingWithUmbracoHelper, IWebPage
    {
        public PageBase(IPublishedContent content, ViewDependencies viewDependencies)
        {
            Content = content;
            Umbraco = viewDependencies.UmbracoHelper;
            Layout = viewDependencies.LayoutModel;
            _renderingCoordinator = viewDependencies.RenderingCoordinator;
        }

        //{{"name": "1 column layout",  "sections": [{ "grid": 12,  "rows": [] } ]}}
        public bool HasBodyContent => BodyText.HasValues && BodyText["sections"][0].Value<JArray>("rows").Count > 0;

        private JToken _BodyText;

        [RenderingPropertyAlias(PropertyAliases.BodyTextPropertyAlias)]
        public JToken BodyText
        {
            get { return _BodyText = _BodyText ?? Content.GetPropertyValue<JToken>(PropertyAliases.BodyTextPropertyAlias); }
        }

        public string BodyTextPropertyAlias => PropertyAliases.BodyTextPropertyAlias;

        public IPublishedContent Content { get; }
        public CultureInfo CurrentCulture { get; set; }
        public virtual bool IsFullPage => true;

        [RenderingPropertyAlias("keywords")]
        public IEnumerable<string> Keywords
        {
            get { return Content.GetPropertyValue<IEnumerable<string>>("seoMetaDescription"); }
        }

        public LayoutModel Layout { get; }

        private readonly RenderingCoordinator _renderingCoordinator;

        [RenderingPropertyAlias("pageTitle")]
        public string PageTitle
        {
            get { return Content.GetPropertyValue<string>("pageTitle", true); }
        }

        [RenderingPropertyAlias("seoMetaDescription")]
        public string SeoMetaDescription
        {
            get { return Content.GetPropertyValue<string>("seoMetaDescription"); }
        }

        public UmbracoHelper Umbraco { get; }

        [RenderingPropertyAlias("umbracoNavihide")]
        public bool UmbracoNavihide
        {
            get { return Content.GetPropertyValue<bool>("umbracoNavihide"); }
        }

        public virtual string GetPartialView(string renderTag = null)
        {
            return _renderingCoordinator.GetViewForRendering(this, renderTag);
        }
    }
}