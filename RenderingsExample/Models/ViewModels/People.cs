using Renderings;
using RenderingsExample.Business;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace RenderingsExample.Models.ViewModels
{
    [RenderingDocumentAlias("people")]
    public class People : PageBase
    {
        private readonly IRenderingAliasResolver _Resolver;
        private readonly ContentConversionService _ContentConverter;

        public People(IPublishedContent content, ViewDependencies viewDependencies) : base(content, viewDependencies)
        {
            _Resolver = viewDependencies.RenderingAliasResolver;
            _ContentConverter = viewDependencies.ContentConversionService;
        }
        
		[RenderingPropertyAlias("featuredPeople")]
        public IEnumerable<Person> FeaturedPeople
        {
            get
            {
                var featured = Content.GetPropertyValue<IEnumerable<IPublishedContent>>("featuredPeople");

                return _ContentConverter.ConvertToRenderings<Person>(featured);
            }
        }

        public IEnumerable<Person> PeopleList
        {
            get
            {
                var alias = _Resolver.ResolveType(typeof(Person));
                var children = Content.Children.Where(x => x.DocumentTypeAlias == alias);

                return _ContentConverter.ConvertToRenderings<Person>(children);
            }
        }
    }
}