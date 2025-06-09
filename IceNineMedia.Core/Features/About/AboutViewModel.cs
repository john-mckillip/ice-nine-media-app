using IceNineMedia.Core.Features.Shared.Models;
using UContentMapper.Core.Models.Attributes;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace IceNineMedia.Core.Features.About
{
    [MapperConfiguration(SourceType = typeof(IPublishedContent), ContentTypeAlias = "about")]
    public class AboutViewModel : BasePageModel
    {

    }
}