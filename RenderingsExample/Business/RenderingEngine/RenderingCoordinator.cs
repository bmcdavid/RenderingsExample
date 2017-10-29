using DotNetStarter.Abstractions;
using Renderings;
using RenderingsExample.Business.RenderingEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RenderingsExample.Business
{
    /// <summary>
    /// Matches renderings to view paths
    /// </summary>>
    [Registration(typeof(RenderingCoordinator), Lifecycle.Singleton)]
    public class RenderingCoordinator
    {
        public const string PagePartialFormat = "~/Views/Partials/Pages/{0}.cshtml";
        public const string BlockPartialFormat = "~/Views/Partials/Blocks/{0}.cshtml";

        private readonly IEnumerable<ITemplateSelector> _TemplateSelectors;

        /// <summary>
        /// For performance, only resolve view once
        /// </summary>
        private Dictionary<Tuple<Type, string>, string> _Lookups;

        /// <summary>
        /// Injected constructor for all registered ITemplateSelectors
        /// </summary>
        /// <param name="templateSelectors"></param>
        public RenderingCoordinator(IEnumerable<ITemplateSelector> templateSelectors)
        {
            _TemplateSelectors = templateSelectors;
            _Lookups = new Dictionary<Tuple<Type, string>, string>();
        }

        public string GetViewForRendering(IRendering rendering, string tagName)
        {
            var key = Tuple.Create(rendering.GetType(), tagName);

            if (!_Lookups.TryGetValue(key, out string matchView))
            {
                // LastOrDefault uses DotNetStarter depencency system to allow overrides where later matches should be more specific
                var match = _TemplateSelectors.LastOrDefault(t => t.IsMatch(rendering, tagName));

                matchView = match?.ViewPath(rendering, tagName) ??
                    throw new NullReferenceException($"Cannot find view for {rendering.GetType().FullName} and {tagName} combo!");

                _Lookups[key] = matchView;
            }

            return matchView;
        }
    }
}