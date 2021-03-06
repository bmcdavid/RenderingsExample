﻿using Renderings;
using DotNetStarter.Abstractions;
using RenderingsExample.Models.ViewModels.Blocks;

namespace RenderingsExample.Business.RenderingEngine.Selectors
{
    [Registration(typeof(ITemplateSelector), Lifecycle.Singleton)]
    public class DefaultBlockSelector : ITemplateSelector
    {
        public bool IsMatch(IRendering rendering, string tagName)
        {
            return rendering is BlockBase;
        }

        public string ViewPath(IRendering rendering, string tagName)
        {
            return string.Format(RenderingCoordinator.BlockPartialFormat, rendering.GetType().Name);
        }
    }
}