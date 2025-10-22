using IceNineMedia.Core.Features.Shared.Models;
using UContentMapper.Core.Models.Attributes;
using Umbraco.Cms.Core.Models.PublishedContent;
using static IceNineMedia.Core.Features.Shared.AppConstants;

namespace IceNineMedia.Core.Features.About
{
    [MapperConfiguration(SourceType = typeof(IPublishedContent), ContentTypeAlias = ContentTypeAliases.About)]
    public class AboutViewModel : BasePageModel
    {

    }
}