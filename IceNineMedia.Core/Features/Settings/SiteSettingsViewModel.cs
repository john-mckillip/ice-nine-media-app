using UContentMapper.Core.Models.Attributes;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using static IceNineMedia.Core.Features.Shared.AppConstants;

namespace IceNineMedia.Core.Features.Settings
{
    [MapperConfiguration(SourceType = typeof(IPublishedContent), ContentTypeAlias = ContentTypeAliases.SiteSettings)]
    public class SiteSettingsViewModel
    {
        public string? Copyright { get; set; }
        public string? ContactEmail { get; set; }
        public string? IntroText { get; set; }
        public IEnumerable<Link> Navigation { get; set; } = [];
    }
}