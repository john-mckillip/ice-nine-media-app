using IceNineMedia.Core.Features.Shared.Abstractions;
using System.Web;
using UContentMapper.Core.Models.Content;

namespace IceNineMedia.Core.Features.Shared.Models
{
    public abstract class BasePageModel : BaseContentModel, IWebPage
    {
        public bool HideFromNavigation { get; set; }
        public bool HideFromSitemap { get; set; }
        public string Title { get; set; } = string.Empty;
        public string BrowserTitle { get; set; } = string.Empty;
        public IHtmlString? MainBody { get; set; }
    }
}