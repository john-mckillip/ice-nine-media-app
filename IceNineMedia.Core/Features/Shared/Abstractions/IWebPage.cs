using System.Web;

namespace IceNineMedia.Core.Features.Shared.Abstractions
{
    /// <summary>
    /// The base properties that all pages should have
    /// </summary>
    public interface IWebPage
    {
        /// <summary>
        /// Hides page from the navigation
        /// </summary>
        public bool HideFromNavigation { get; set; }
        /// <summary>
        /// Hides page from the sitemap
        /// </summary>
        bool HideFromSitemap { get; }
        /// <summary>
        /// The title of the page
        /// </summary>
        string Title { get; }
        /// <summary>
        /// The main body of content for the page
        /// </summary>
        public IHtmlString? MainBody { get; set; }
    }
}