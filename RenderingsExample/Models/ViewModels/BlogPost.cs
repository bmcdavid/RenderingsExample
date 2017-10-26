using Renderings;
using RenderingsExample.Business;
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace RenderingsExample.Models.ViewModels
{
    [RenderingDocumentAlias("blogpost")]
    public class BlogPost : PageBase
    {
        public BlogPost(IPublishedContent content, ViewDependencies viewDependencies) : base(content, viewDependencies)
        {
        }

        public DateTime CreateDate => Content.CreateDate;

        [RenderingPropertyAlias("categories")]
        public IEnumerable<string> Categories
        {
            get { return Content.GetPropertyValue<IEnumerable<string>>("categories"); }
        }

        ///<summary>
        /// Excerpt: Introduction to your blog post. This is also used in the summaries on the front of the blog as well as the homepage
        ///</summary>
        [RenderingPropertyAlias("excerpt")]
        public string Excerpt
        {
            get { return Content.GetPropertyValue<string>("excerpt"); }
        }        
    }
}