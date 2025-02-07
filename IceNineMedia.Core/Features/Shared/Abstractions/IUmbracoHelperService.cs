using IceNineMedia.Core.Features.About;
using IceNineMedia.Core.Features.Home;
using IceNineMedia.Core.Features.Shared.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace IceNineMedia.Core.Features.Shared.Abstractions
{
    /// <summary>
    /// Service to help with all things Umbraco
    /// </summary>
    public interface IUmbracoHelperService
    {
        /// <summary>
        /// Get the content from Umbraco for the about page
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        AboutViewModel? GetAboutContent(string? slug);
        /// <summary>
        /// Gets the content from Umbraco for the home page
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        HomeViewModel? GetHomeContent(string? slug);
        /// <summary>
        /// Gets the content from Umbraco for a page
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        IPublishedContent? GetContent(string? slug);
        /// <summary>
        /// Gets the content metadata from Umbraco for a page
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        PageMetadata? GetContentMetadata(string? slug);
    }
}