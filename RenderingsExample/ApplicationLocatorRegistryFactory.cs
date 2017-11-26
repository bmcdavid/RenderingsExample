using DotNetStarter.Abstractions;

// hack: this is only to demo how you can swap easily between structuremap and dryioc, only 1 is needed
[assembly: LocatorRegistryFactory(typeof(RenderingsExample.ApplicationLocatorRegistryFactory),
    typeof(DotNetStarter.Locators.DryIocLocatorFactory),
    typeof(DotNetStarter.Locators.StructureMapFactory))]

namespace RenderingsExample
{
    public class ApplicationLocatorRegistryFactory : ILocatorRegistryFactory
    {
        public ILocatorRegistry CreateRegistry()
        {
            // hack: Each of these implementations may also be passed an already configured DI container instances

            // uncomment to use DryIoc
            // return new DotNetStarter.Locators.DryIocLocator();

            return new DotNetStarter.Locators.StructureMapLocator();
        }
    }
}