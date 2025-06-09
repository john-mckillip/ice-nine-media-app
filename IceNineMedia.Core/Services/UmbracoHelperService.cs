using IceNineMedia.Core.Features.About;
using IceNineMedia.Core.Features.Home;
using IceNineMedia.Core.Features.Settings;
using IceNineMedia.Core.Features.Shared.Abstractions;
using IceNineMedia.Core.Features.Shared.Models;
using UContentMapper.Core.Abstractions.Mapping;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace IceNineMedia.Core.Services
{
    public class UmbracoHelperService(
        IPublishedContentQuery publishedContentQuery, 
        IUmbracoMapper umbracoMapper,
        IContentMapper<HomeViewModel> homeMapper,
        IContentMapper<AboutViewModel> aboutMapper) : IUmbracoHelperService
    {
        private readonly IPublishedContentQuery _publishedContentQuery = publishedContentQuery;
        private readonly IUmbracoMapper _umbracoMapper = umbracoMapper;
        private readonly IContentMapper<HomeViewModel> _homeMapper = homeMapper;
        private readonly IContentMapper<AboutViewModel> _aboutMapper = aboutMapper;

        public AboutViewModel? GetAboutContent(string? slug)
        {
            var aboutContent = GetContent(slug);
            if (aboutContent is not null && _aboutMapper.CanMap(aboutContent)) 
            {
                return _aboutMapper.Map(aboutContent);
            }
            return null;
        }

        public HomeViewModel? GetHomeContent(string? slug)
        {
            var homeContent = GetContent(slug);
            if (homeContent is not null && _homeMapper.CanMap(homeContent))
            {
                return _homeMapper.Map(homeContent);
            }
            return null;
        }

        public IPublishedContent? GetContent(string? slug)
        {          
            if (!string.IsNullOrEmpty(slug))
            {
                if (!slug.Equals("/"))
                {
                    slug = $"{slug}/";
                }
                
                return _publishedContentQuery
                    .ContentAtRoot()?
                    .SelectMany(x => x.DescendantsOrSelf())
                    .FirstOrDefault(x => x.Url() == slug);
            }

            return null;
        }

        public PageMetadata? GetContentMetadata(string? slug)
        {
            var pageContent = GetContent(slug);

            return _umbracoMapper.MapPageMetadata(pageContent);
        }

        public SiteSettingsViewModel? GetSiteSettings()
        {
            var siteSettingsContent = _publishedContentQuery
                .ContentAtRoot()?
                .SelectMany(x => x.DescendantsOrSelf())
                .FirstOrDefault(x => x.ContentType.Alias == "siteSettings");

            return _umbracoMapper.MapSiteSettingsViewModel(siteSettingsContent);
        }
    }
}