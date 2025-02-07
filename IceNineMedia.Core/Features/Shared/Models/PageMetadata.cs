using IceNineMedia.Core.Features.Shared.Abstractions;

namespace IceNineMedia.Core.Features.Shared.Models
{
    public class PageMetadata : IPageMetadata
    {
        public string BrowserTitle { get; set; } = string.Empty;
        public string CanonicalUrl { get; set; } = string.Empty;
        public bool DisableSearchIndexing { get; set; }
        public string MetaAuthor { get; set; } = string.Empty;
        public string MetaDescription { get; set; } = string.Empty;
        public string MetaTitle => BrowserTitle ?? string.Empty;
    }
}