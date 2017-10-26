using DotNetStarter.Abstractions;
using Renderings;
using System;

namespace RenderingsExample.Business.Startup
{
    [StartupModule(typeof(DotNetStarter.RegistrationConfiguration))]
    public class CustomStartup : ILocatorConfigure
    {
        public void Configure(ILocatorRegistry registry, IStartupEngine engine)
        {
            registry.Add<IRenderingCreatorScoped, RenderingCreatorScoped>(lifetime: LifeTime.Scoped);
        }
    }

    /// <summary>
    /// Temporary hack
    /// </summary>
    public class RenderingCreatorScoped : IRenderingCreatorScoped
    {
        private readonly IRenderingTypeResolver _RenderingTypeResolver;
        private readonly ILocator _ScopedLocator; // Important: this func should come from a scoped locator.

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="renderingTypeResolver"></param>
        /// <param name="scopedLocator"></param>
        public RenderingCreatorScoped(IRenderingTypeResolver renderingTypeResolver, ILocator scopedLocator)
        {
            _RenderingTypeResolver = renderingTypeResolver;
            _ScopedLocator = scopedLocator;
        }

        /// <summary>
        /// Gets a creator Func for given Type, not if not in a scoped context, there will be issues
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="alias"></param>
        /// <returns></returns>
        public Func<T, object> GetCreator<T>(string alias)
        {
            var creatorType = _RenderingTypeResolver.ResolveCreator<T>(alias);

            //todo: add this fix
            if (creatorType == null)
                return null;

            return _ScopedLocator.Get(creatorType) as Func<T, object>;
        }
    }
}