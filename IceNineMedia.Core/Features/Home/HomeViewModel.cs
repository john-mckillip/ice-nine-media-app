using IceNineMedia.Core.Features.Shared.Models;
using UContentMapper.Core.Models.Attributes;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace IceNineMedia.Core.Features.Home
{
    [MapperConfiguration(SourceType = typeof(IPublishedContent), ContentTypeAlias = "home")]
    public class HomeViewModel : BasePageModel
    {

    }
}