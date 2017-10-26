using Renderings;
using Renderings.UmbracoCms;
using System;
using System.Globalization;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace RenderingsExample.Controllers
{
    public class CustomUmbracoMvcRenderingController : RenderMvcController
    {
        private readonly IRenderingCreatorScoped _RenderingCreator;

        public CustomUmbracoMvcRenderingController(IRenderingCreatorScoped renderingCreator)
        {
            _RenderingCreator = renderingCreator;
        }

        public override ActionResult Index(RenderModel model)
        {
            var rendering = BuildRendering(model.Content, model.CurrentCulture);

            if (rendering == null)
            {
                return CurrentTemplate(model); // Fallback to default behaviour
            }

            if (rendering.IsFullPage == false)
            {
                return new HttpNotFoundResult(); // don't allow non full page models to return
            }

            return CurrentTemplate(rendering);
        }

        private IUmbracoRendering BuildRendering(IPublishedContent content, CultureInfo cultureInfo)
        {
            var creator = _RenderingCreator.GetCreator<IPublishedContent>(content.DocumentTypeAlias);
            var returnModel = creator?.Invoke(content) as IUmbracoRendering;

            if (returnModel is IUmbracoRenderingWithCulture cultureModel)
            {
                cultureModel.CurrentCulture = cultureInfo;
            }

            return returnModel;
        }
    }
}