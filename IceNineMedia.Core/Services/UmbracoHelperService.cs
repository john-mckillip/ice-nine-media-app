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
		IContentMapper<HomeViewModel> homeMapper,
		IContentMapper<AboutViewModel> aboutMapper,
		IContentMapper<PageMetadata> pageMetadataMapper,
		IContentMapper<SiteSettingsViewModel> siteSettingsMapper) : IUmbracoHelperService
	{
		private readonly IPublishedContentQuery _publishedContentQuery = publishedContentQuery;
		private readonly IContentMapper<HomeViewModel> _homeMapper = homeMapper;
		private readonly IContentMapper<AboutViewModel> _aboutMapper = aboutMapper;
		private readonly IContentMapper<PageMetadata> _pageMetadataMapper = pageMetadataMapper;
		private readonly IContentMapper<SiteSettingsViewModel> _siteSettingsMapper = siteSettingsMapper;

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

			if (pageContent is not null && _pageMetadataMapper.CanMap(pageContent))
			{
				return _pageMetadataMapper.Map(pageContent);
			}

			return null;
		}

		public SiteSettingsViewModel? GetSiteSettings()
		{
			var siteSettingsContent = _publishedContentQuery
				.ContentAtRoot()?
				.SelectMany(x => x.DescendantsOrSelf())
				.FirstOrDefault(x => x.ContentType.Alias == ContentTypeAliases.SiteSettings);

			if (siteSettingsContent is not null && _siteSettingsMapper.CanMap(siteSettingsContent))
			{
				return _siteSettingsMapper.Map(siteSettingsContent);
			}

			return null;
		}
	}
}