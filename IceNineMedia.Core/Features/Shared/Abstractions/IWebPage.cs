namespace IceNineMedia.Core.Features.Shared.Abstractions
{
    /// <summary>
    /// The base properties that all pages should have
    /// </summary>
    public interface IWebPage : IPageMetadata
    {
        /// <summary>
        /// The search engine friendly url of the page
        /// </summary>
        string CanonicalUrl { get; }

        /// <summary>
        /// Hides page from the sitemap
        /// </summary>
        bool HideFromSitemap { get; }

        /// <summary>
        /// Whether or not the page should show up in search engines
        /// </summary>
        bool DisableSearchIndexing { get; }

        /// <summary>
        /// The title of the page
        /// </summary>
        string PageTitle { get; }

        /// <summary>
        /// The left part of the site url used in the wrapping shared layouts
        /// </summary>
        string SitePath { get; }
    }
}