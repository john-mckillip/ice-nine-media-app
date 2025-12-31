using IceNineMedia.Core.Features.Shared.Models;
using UContentMapper.Core.Models.Attributes;
using Umbraco.Cms.Core.Models.PublishedContent;
using static IceNineMedia.Core.Features.Shared.AppConstants;

namespace IceNineMedia.Core.Features.Blocks
{
    [MapperConfiguration(SourceType = typeof(IPublishedElement), ContentTypeAlias = ContentTypeAliases.TechnologiesBlock)]
    public class TechnologiesBlockViewModel : BaseBlockModel
    {
        public IEnumerable<string> Technologies { get; set; } = [];
    }
}