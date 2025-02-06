using IceNineMedia.Core.Features.About;
using IceNineMedia.Core.Features.Home;
using IceNineMedia.Core.Features.Shared.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace IceNineMedia.Core.Features.Shared.Abstractions
{
    public interface IUmbracoMapper
    {
        HomeViewModel MapHomeViewModel(IPublishedContent? content);
        AboutViewModel MapAboutViewModel(IPublishedContent? content);
        PageMetadata MapPageMetadata(IPublishedContent? content);
    }
}