using IceNineMedia.Core.Features.About;
using IceNineMedia.Core.Features.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace IceNineMedia.Core.Features.Shared
{
    [ApiController]
    [Route("api/content")]
    public class ContentApiController(
        IPublishedContentQuery contentQuery, 
        IHttpContextAccessor httpContextAccessor) : ControllerBase
    {
        private readonly IPublishedContentQuery _contentQuery = contentQuery;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        [HttpGet("{slug}")]
        public IActionResult GetContent(string slug)
        {
            var content = _contentQuery
                .ContentAtRoot()?
                .SelectMany(x => x.DescendantsOrSelf())
                .FirstOrDefault(x => x.ContentType.Alias == slug);

            if (content is null) return NotFound();

            return slug switch
            {
                "home" => Ok(_mapHomeViewModel(content)),  
                "about" => Ok(_mapAboutViewModel(content)),
                _ => Ok(),
            };
        }

        #region Helper Methods

        protected string _getRequestDomain()
        {
            var request = _httpContextAccessor?.HttpContext?.Request;
            if (request is not null)
            {
                return $"{request.Scheme}://{request.Host}";
            }

            return string.Empty;
        }

        private AboutViewModel _mapAboutViewModel(IPublishedContent? content)
        {
            AboutViewModel aboutViewModel = new() { SitePath = _getRequestDomain() };

            if (content is not null)
            {
                aboutViewModel.Title = content?.Name ?? string.Empty;
                aboutViewModel.BrowserTitle = content?.Value<string>("browserTitle") ?? string.Empty;
            }

            return aboutViewModel;
        }

        private HomeViewModel _mapHomeViewModel(IPublishedContent? content)
        {
            HomeViewModel homeViewModel = new() { SitePath = _getRequestDomain() };

            if (content is not null)
            {
                homeViewModel.Title = content?.Name ?? string.Empty;
                homeViewModel.BrowserTitle = content?.Value<string>("browserTitle") ?? string.Empty;
            }

            return homeViewModel;
        }

        #endregion
    }
}