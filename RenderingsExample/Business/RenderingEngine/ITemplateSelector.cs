using Renderings;

namespace RenderingsExample.Business.RenderingEngine
{
    public interface ITemplateSelector
    {
        bool IsMatch(IRendering rendering, string tagName);

        string ViewPath(IRendering rendering, string tagName);
    }
}
