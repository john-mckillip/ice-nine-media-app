using IceNineMedia.Core.Features.About;
using IceNineMedia.Core.Features.Home;
using IceNineMedia.Core.Features.Settings;
using Microsoft.AspNetCore.Mvc;
using UContentMapper.Core.Abstractions.Mapping;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using static IceNineMedia.Core.Features.Shared.AppConstants;

namespace IceNineMedia.Core.Features.Shared
{
    [ApiController]
    [Route("api/content")]
    public class ContentApiController(
        IPublishedContentQuery contentQuery,
        IContentMapper<HomeViewModel> homeMapper,
        IContentMapper<AboutViewModel> aboutMapper,
        IContentMapper<SiteSettingsViewModel> siteSettingsMapper) : ControllerBase
    {
        private readonly IPublishedContentQuery _contentQuery = contentQuery;
        private readonly IContentMapper<HomeViewModel> _homeMapper = homeMapper;
        private readonly IContentMapper<AboutViewModel> _aboutMapper = aboutMapper;
        private readonly IContentMapper<SiteSettingsViewModel> _siteSettingsMapper = siteSettingsMapper;

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
                ContentTypeAliases.About => Ok(_mapAboutViewModel(content)),
                ContentTypeAliases.SiteSettings => Ok(_mapSiteSettingsViewModel(content)),
                _ => Ok(_mapHomeViewModel(content)),
            };
        }

        #region Helper Methods

        private AboutViewModel _mapAboutViewModel(IPublishedContent? content)
        {
            AboutViewModel aboutViewModel = new();

            if (content is not null && _aboutMapper.CanMap(content))
            {
                aboutViewModel = _aboutMapper.Map(content);
            }

            return aboutViewModel;
        }

        private HomeViewModel _mapHomeViewModel(IPublishedContent? content)
        {
            HomeViewModel homeViewModel = new();

            if (content is not null && _homeMapper.CanMap(content))
            {
                homeViewModel = _homeMapper.Map(content);
            }

            return homeViewModel;
        }

        private SiteSettingsViewModel _mapSiteSettingsViewModel(IPublishedContent? content)
        {
            SiteSettingsViewModel siteSettingsViewModel = new();

            if (content is not null && _siteSettingsMapper.CanMap(content))
            {
                siteSettingsViewModel = _siteSettingsMapper.Map(content);
            }

            return siteSettingsViewModel;
        }

        #endregion
    }
}