using Renderings;
using RenderingsExample.Business;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace RenderingsExample.Models.ViewModels.Blocks
{
    [RenderingDocumentAlias("feature")]
    public class Feature : BlockBase
    {
        public Feature(IPublishedContent publishedContent, ViewDependencies viewDependencies) : base(publishedContent, viewDependencies)
        {
        }

        [RenderingPropertyAlias("featureDetails")]
        public string FeatureDetails
        {
            get { return Content.GetPropertyValue<string>("featureDetails"); }
        }

        [RenderingPropertyAlias("featureName")]
        public string FeatureName
        {
            get { return Content.GetPropertyValue<string>("featureName"); }
        }
    }
}