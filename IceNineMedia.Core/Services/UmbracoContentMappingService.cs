using IceNineMedia.Core.Features.About;
using IceNineMedia.Core.Features.Home;
using IceNineMedia.Core.Features.Shared.Abstractions;
using IceNineMedia.Core.Features.Shared.Models;
using Microsoft.AspNetCore.Http;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace IceNineMedia.Core.Services
{
    public class UmbracoContentMappingService(IHttpContextAccessor httpContextAccessor) : IUmbracoMapper
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public AboutViewModel MapAboutViewModel(IPublishedContent? content)
        {
            AboutViewModel aboutViewModel = new() { SitePath = _getRequestDomain() };

            if (content is not null)
            {
                aboutViewModel.PageTitle = content?.Name ?? string.Empty;
                aboutViewModel.BrowserTitle = content?.Value<string>("browserTitle") ?? string.Empty;
            }

            return aboutViewModel;
        }

        public HomeViewModel MapHomeViewModel(IPublishedContent? content)
        {
            HomeViewModel homeViewModel = new() { SitePath = _getRequestDomain() };

            if (content is not null)
            {
                homeViewModel.PageTitle = content?.Name ?? string.Empty;
                homeViewModel.BrowserTitle = content?.Value<string>("browserTitle") ?? string.Empty;
            }

            return homeViewModel;
        }

        public PageMetadata MapPageMetadata(IPublishedContent? content)
        {
            PageMetadata pageMetadata = new();

            if (content is not null)
            {
                pageMetadata.BrowserTitle = content?.Value<string>("browserTitle") ?? string.Empty;
                pageMetadata.MetaAuthor = content?.Value<string>("metaAuthor") ?? string.Empty;
                pageMetadata.MetaDescription = content?.Value<string>("metaDescription") ?? string.Empty;   
            }

            return pageMetadata;
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