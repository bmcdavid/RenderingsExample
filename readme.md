# Renderings Example

This project is an example site for [Renderings.UmbracoCms](https://github.com/bmcdavid/Renderings) using the [Umbraco Starter Kit](https://our.umbraco.org/projects/starter-kits/the-starter-kit/) to demonstrate how to build rich view models for displaying CMS content.

Renderings will not create models from code, but rather create a friendly way to build razor views with classes using dependency injection (DI).

The database is included and can be login using:

```
Username: admin@noreply.com
Password: 12345678aA!
```

For more information on Renderings please review the [read me](https://github.com/bmcdavid/Renderings) on its GitHub page.

## Highlights

* View models in the Models/ViewModels folder are created by injecting the requested IPublishedContent and any other dependencies the view may require.
    * The Blog view model injects a BlogListingService that is also re-used by the LatestBlogPost macro to consolidate logic.
* View models can be re-used throughout the site using their GetPartialView(string tagName) implementation. All view models in this example pass their implementation to the Business/RenderingEngine/RenderingCoordinator to determine the appropriate razor file to display. 
    * This choice is evaluated by matching ITemplateSelectors based upon the IRendering class type and the tag name. 
    * The more specific template selectors have DotNetStarter **Register** attribute dependencies on the general views, allowing the RenderingCoordinator to choose the last match for display.
* Demonstrates enabling Dependency Injection using DotNetStarter configured in Application.cs with a fine-tuned IStartupConfiguration; which allows for quicker startup by only scanning minimal assemblies.

