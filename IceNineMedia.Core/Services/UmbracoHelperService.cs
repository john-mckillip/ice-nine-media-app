using IceNineMedia.Core.Features.About;
using IceNineMedia.Core.Features.Home;
using IceNineMedia.Core.Features.Settings;
using IceNineMedia.Core.Features.Shared.Abstractions;
using IceNineMedia.Core.Features.Shared.Models;
using UContentMapper.Core.Abstractions.Mapping;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using static IceNineMedia.Core.Features.Shared.AppConstants;

namespace IceNineMedia.Core.Services
{
    public class UmbracoHelperService(
        IPublishedContentQuery publishedContentQuery,
        IContentMapperFactory contentMapperFactory) : IUmbracoHelperService
    {
        private readonly IPublishedContentQuery _publishedContentQuery = publishedContentQuery;
        private readonly IContentMapperFactory _contentMapperFactory = contentMapperFactory;

        public AboutViewModel? GetAboutContent(string? slug)
        {
            var aboutContent = GetContent(slug);

            var aboutMapper = _contentMapperFactory.CreateMapper<AboutViewModel>();

            if (aboutContent is not null && aboutMapper.CanMap(aboutContent))
            {
                return aboutMapper.Map(aboutContent);
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

            var pageMetadataMapper = _contentMapperFactory.CreateMapper<PageMetadata>();

            if (pageContent is not null && pageMetadataMapper.CanMap(pageContent))
            {
                return pageMetadataMapper.Map(pageContent);
            }

            return null;
        }

        public HomeViewModel? GetHomeContent(string? slug)
        {
            var homeContent = GetContent(slug);

            var homeMapper = _contentMapperFactory.CreateMapper<HomeViewModel>();

            if (homeContent is not null && homeMapper.CanMap(homeContent))
            {
                return homeMapper.Map(homeContent);
            }
            return null;
        }

        public SiteSettingsViewModel? GetSiteSettings()
        {
            var siteSettingsContent = _publishedContentQuery
                .ContentAtRoot()?
                .SelectMany(x => x.DescendantsOrSelf())
                .FirstOrDefault(x => x.ContentType.Alias == ContentTypeAliases.SiteSettings);

            var siteSettingsMapper = _contentMapperFactory.CreateMapper<SiteSettingsViewModel>();

            if (siteSettingsContent is not null && siteSettingsMapper.CanMap(siteSettingsContent))
            {
                return siteSettingsMapper.Map(siteSettingsContent);
            }

            return null;
        }
    }
}