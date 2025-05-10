using IceNineMedia.Core.Features.About;
using IceNineMedia.Core.Features.Home;
using IceNineMedia.Core.Features.Settings;
using IceNineMedia.Core.Features.Shared.Abstractions;
using IceNineMedia.Core.Features.Shared.Models;
using Microsoft.AspNetCore.Http;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace IceNineMedia.Core.Services
{
    public class UmbracoContentMappingService(IHttpContextAccessor httpContextAccessor) : IUmbracoMapper
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public AboutViewModel MapAboutViewModel(IPublishedContent? content)
        {
            AboutViewModel aboutViewModel = new();

            if (content is not null)
            {
                aboutViewModel.Title = content?.Value<string>("title") ?? content?.Name() ?? string.Empty;
            }

            return aboutViewModel;
        }

        public HomeViewModel MapHomeViewModel(IPublishedContent? content)
        {
            HomeViewModel homeViewModel = new();

            if (content is not null)
            {
                homeViewModel.Title = content?.Value<string>("title") ?? content?.Name() ?? string.Empty;
            }

            return homeViewModel;
        }

        public PageMetadata MapPageMetadata(IPublishedContent? content)
        {
            PageMetadata pageMetadata = new();

            if (content is not null)
            {
                pageMetadata.CanonicalUrl = $"{_getRequestDomain()}{content?.Url() ?? string.Empty}";
                pageMetadata.BrowserTitle = content?.Value<string>("browserTitle") ?? string.Empty;
                pageMetadata.DisableSearchIndexing = content?.Value<bool>("disableSearchIndexing") ?? false;
                pageMetadata.MetaAuthor = content?.Value<string>("metaAuthor") ?? string.Empty;
                pageMetadata.MetaDescription = content?.Value<string>("metaDescription") ?? string.Empty;
            }

            return pageMetadata;
        }

        public SiteSettingsViewModel MapSiteSettingsViewModel(IPublishedContent? content)
        {
            SiteSettingsViewModel siteSettingsViewModel = new();
            if (content is not null)
            {
                siteSettingsViewModel.ContactEmail = content?.Value<string>("contactEmail") ?? string.Empty;
                siteSettingsViewModel.IntroText = content?.Value<string>("introText") ?? null;
                siteSettingsViewModel.Navigation = content?.Value<IEnumerable<Link>>("navigation") ?? [];
            }

            return siteSettingsViewModel;
        }

        protected string _getRequestDomain()
        {
            var request = _httpContextAccessor?.HttpContext?.Request;
            if (request is not null)
            {
                return $"{request.Scheme}://{request.Host}";
            }

            return string.Empty;
        }
    }
}