using IceNineMedia.Core.Features.Shared.Abstractions;
using Microsoft.AspNetCore.Html;
using UContentMapper.Core.Models.Content;

namespace IceNineMedia.Core.Features.Shared.Models
{
    public abstract class BasePageModel : BaseContentModel, IWebPage
    {
        public string BrowserTitle { get; set; } = string.Empty;
        public bool HideFromNavigation { get; set; }
        public bool HideFromSitemap { get; set; }
        public IHtmlContent? MainBody { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}