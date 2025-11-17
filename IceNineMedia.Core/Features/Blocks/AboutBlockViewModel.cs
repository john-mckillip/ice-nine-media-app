using IceNineMedia.Core.Features.Shared.Models;
using Microsoft.AspNetCore.Html;
using UContentMapper.Core.Models.Attributes;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using static IceNineMedia.Core.Features.Shared.AppConstants;

namespace IceNineMedia.Core.Features.Blocks
{
    [MapperConfiguration(SourceType = typeof(IPublishedElement), ContentTypeAlias = ContentTypeAliases.AboutBlock)]
    public class AboutBlockViewModel : BaseBlockModel
    {
        public IEnumerable<Link> Links { get; set; } = [];
        public IHtmlContent? Teaser { get; set; }
    }
}