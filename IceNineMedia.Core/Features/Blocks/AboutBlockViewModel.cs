using IceNineMedia.Core.Features.Shared.Models;
using Microsoft.AspNetCore.Html;
using Umbraco.Cms.Core.Models;

namespace IceNineMedia.Core.Features.Blocks
{
    public class AboutBlockViewModel : BaseBlockModel
    {
        public IEnumerable<Link> Links { get; set; } = [];
        public IHtmlContent? Teaser { get; set; }
    }
}