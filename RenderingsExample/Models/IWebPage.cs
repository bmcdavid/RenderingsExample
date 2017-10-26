using System.Globalization;
using Umbraco.Core.Models;

namespace RenderingsExample.Models
{
    public interface IWebPage
    {
        CultureInfo CurrentCulture { get; }

        IPublishedContent Content { get; }

        LayoutModel Layout { get; }
    }
}
