using IceNineMedia.Core.Features.Shared.Abstractions;

namespace IceNineMedia.Core.Features.Shared.Models
{
    public abstract class BasePageModel : IWebPage
    {
        public string BrowserTitle { get; set; } = string.Empty;
        public string CanonicalUrl { get; set; } = string.Empty;
        public bool HideFromNavigation { get; set; }
        public bool HideFromSitemap { get; set; }
        public bool DisableSearchIndexing { get; set; }
        public string MetaDescription { get; set; } = string.Empty;
        public string MetaTitle => BrowserTitle ?? string.Empty;
        public string MetaAuthor { get; set; } = string.Empty;
        public string PageTitle { get; set; } = string.Empty;
        public string SitePath { get; set; } = string.Empty;
    }
}