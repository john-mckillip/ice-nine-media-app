using IceNineMedia.Core.Features.About;
using IceNineMedia.Core.Features.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UContentMapper.Core.Abstractions.Mapping;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace IceNineMedia.Core.Features.Shared
{
	[ApiController]
	[Route("api/content")]
	public class ContentApiController(
		IPublishedContentQuery contentQuery,
		IContentMapper<HomeViewModel> homeMapper,
		IContentMapper<AboutViewModel> aboutMapper) : ControllerBase
	{
		private readonly IPublishedContentQuery _contentQuery = contentQuery;
		private readonly IContentMapper<HomeViewModel> _homeMapper = homeMapper;
		private readonly IContentMapper<AboutViewModel> _aboutMapper = aboutMapper;

		[HttpGet("{slug}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
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

		#endregion
	}
}