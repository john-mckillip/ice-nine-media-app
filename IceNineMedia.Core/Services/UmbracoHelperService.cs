using IceNineMedia.Core.Features.About;
using IceNineMedia.Core.Features.Home;
using IceNineMedia.Core.Features.Settings;
using IceNineMedia.Core.Features.Shared.Abstractions;
using IceNineMedia.Core.Features.Shared.Models;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace IceNineMedia.Core.Services
{
    public class UmbracoHelperService(
        IPublishedContentQuery publishedContentQuery, 
        IUmbracoMapper umbracoMapper) : IUmbracoHelperService
    {
        private readonly IPublishedContentQuery _publishedContentQuery = publishedContentQuery;
        private readonly IUmbracoMapper _umbracoMapper = umbracoMapper;

        public AboutViewModel? GetAboutContent(string? slug)
        {
            var aboutContent = GetContent(slug);

            return _umbracoMapper.MapAboutViewModel(aboutContent);
        }

        public HomeViewModel? GetHomeContent(string? slug)
        {
            var homeContent = GetContent(slug);

            return _umbracoMapper.MapHomeViewModel(homeContent);
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