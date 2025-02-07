using IceNineMedia.Core.Features.Shared.Abstractions;
using System.Web;

namespace IceNineMedia.Core.Features.Shared.Models
{
    public abstract class BasePageModel : IWebPage
    {
        #region IPageMetadata 
        public string BrowserTitle { get; set; } = string.Empty;
        public string CanonicalUrl { get; set; } = string.Empty;
        public bool DisableSearchIndexing { get; set; }
        public string MetaDescription { get; set; } = string.Empty;
        public string MetaTitle => BrowserTitle ?? string.Empty;
        public string MetaAuthor { get; set; } = string.Empty;
        #endregion
        
        public bool HideFromNavigation { get; set; }
        public bool HideFromSitemap { get; set; }
        public string Title { get; set; } = string.Empty;
        public IHtmlString? MainBody { get; set; }
    }
}