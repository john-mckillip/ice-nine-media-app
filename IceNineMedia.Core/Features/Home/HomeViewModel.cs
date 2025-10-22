using IceNineMedia.Core.Features.Shared.Models;
using UContentMapper.Core.Models.Attributes;
using Umbraco.Cms.Core.Models.PublishedContent;
using static IceNineMedia.Core.Features.Shared.AppConstants;

namespace IceNineMedia.Core.Features.Home
{
    [MapperConfiguration(SourceType = typeof(IPublishedContent), ContentTypeAlias = ContentTypeAliases.Home)]
    public class HomeViewModel : BasePageModel
    {

    }
}