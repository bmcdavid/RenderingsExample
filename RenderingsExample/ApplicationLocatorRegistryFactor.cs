﻿using DotNetStarter.Abstractions;

// hack: this is only to demo how you can swap easily between structuremap and dryioc, only 1 is needed
[assembly: LocatorRegistryFactory(typeof(RenderingsExample.ApplicationLocatorRegistryFactor),
    typeof(DotNetStarter.DryIocLocatorFactory),
    typeof(DotNetStarter.StructureMapFactory))]

namespace RenderingsExample
{
    public class ApplicationLocatorRegistryFactor : ILocatorRegistryFactory
    {
        public ILocatorRegistry CreateRegistry()
        {
            // hack: Each of these implementations may also be passed an already configured DI container instances

            // uncomment to use DryIoc
            // return new DotNetStarter.DryIocLocator();

            return new DotNetStarter.StructureMapLocator();
        }
    }
}