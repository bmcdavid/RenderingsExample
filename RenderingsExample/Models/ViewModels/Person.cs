using Renderings;
using RenderingsExample.Business;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace RenderingsExample.Models.ViewModels
{
    [RenderingDocumentAlias("person")]
    public class Person : PageBase
    {
        public Person(IPublishedContent content, ViewDependencies viewDependencies) : base(content, viewDependencies)
        {
        }

        
        [RenderingPropertyAlias("department")]
        public IEnumerable<string> Department
        {
            get { return Content.GetPropertyValue<IEnumerable<string>>("department"); }
        }
        
        [RenderingPropertyAlias("email")]
        public string Email
        {
            get { return Content.GetPropertyValue<string>("email"); }
        }
        
        [RenderingPropertyAlias("facebookUsername")]
        public string FacebookUsername
        {
            get { return Content.GetPropertyValue<string>("facebookUsername"); }
        }
        
        [RenderingPropertyAlias("instagramUsername")]
        public string InstagramUsername
        {
            get { return Content.GetPropertyValue<string>("instagramUsername"); }
        }
        
        [RenderingPropertyAlias("linkedInUsername")]
        public string LinkedInUsername
        {
            get { return Content.GetPropertyValue<string>("linkedInUsername"); }
        }
        
        [RenderingPropertyAlias("photo")]
        public IPublishedContent Photo
        {
            get { return Content.GetPropertyValue<IPublishedContent>("photo"); }
        }
        
        [RenderingPropertyAlias("twitterUsername")]
        public string TwitterUsername
        {
            get { return Content.GetPropertyValue<string>("twitterUsername"); }
        }
    }
}