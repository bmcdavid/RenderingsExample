using System.Globalization;
using Umbraco.Core.Models;

namespace RenderingsExample.Models
{
    public interface IWebPage
    {
        string PageTitle { get; }

        CultureInfo CurrentCulture { get; }

        IPublishedContent Content { get; }

        LayoutModel Layout { get; }
    }
}