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
        IContentMapperFactory contentMapperFactory) : ControllerBase
    {
        private readonly IPublishedContentQuery _contentQuery = contentQuery;
        private readonly IContentMapperFactory _contentMapperFactory = contentMapperFactory;

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

            var aboutMapper = _contentMapperFactory.CreateMapper<AboutViewModel>();

            if (content is not null && aboutMapper.CanMap(content))
            {
                aboutViewModel = aboutMapper.Map(content);
            }

            return aboutViewModel;
        }

        private HomeViewModel _mapHomeViewModel(IPublishedContent? content)
        {
            HomeViewModel homeViewModel = new();

            var homeMapper = _contentMapperFactory.CreateMapper<HomeViewModel>();

            if (content is not null && homeMapper.CanMap(content))
            {
                homeViewModel = homeMapper.Map(content);
            }

            return homeViewModel;
        }

        private SiteSettingsViewModel _mapSiteSettingsViewModel(IPublishedContent? content)
        {
            SiteSettingsViewModel siteSettingsViewModel = new();

            var siteSettingsMapper = _contentMapperFactory.CreateMapper<SiteSettingsViewModel>();

            if (content is not null && siteSettingsMapper.CanMap(content))
            {
                siteSettingsViewModel = siteSettingsMapper.Map(content);
            }

            return siteSettingsViewModel;
        }

        #endregion
    }
}