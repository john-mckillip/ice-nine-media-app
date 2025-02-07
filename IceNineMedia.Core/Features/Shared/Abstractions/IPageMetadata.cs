namespace IceNineMedia.Core.Features.Shared.Abstractions
{
    /// <summary>
    /// Properties for page metadata that displays in the head tag of each page
    /// </summary>
    public interface IPageMetadata
    {
        /// <summary>
        /// The title displayed in the browser
        /// </summary>
        string BrowserTitle { get; }

        /// <summary>
        /// The search engine friendly url of the page
        /// </summary>
        string CanonicalUrl { get; }

        /// <summary>
        /// Whether or not the page should show up in search engines
        /// </summary>
        bool DisableSearchIndexing { get; }

        /// <summary>
        /// The author of the content page being displayed
        /// </summary>
        string MetaAuthor { get; }

        /// <summary>
        /// The SEO description displayed in the head tag of each page
        /// </summary>
        string MetaDescription { get; }

        /// <summary>
        /// The auto browser title combined with the page browser title
        /// </summary>
        string MetaTitle { get; }
    }
}