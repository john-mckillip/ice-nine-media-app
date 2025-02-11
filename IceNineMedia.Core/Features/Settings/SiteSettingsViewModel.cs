using Umbraco.Cms.Core.Models;

namespace IceNineMedia.Core.Features.Settings
{
    public class SiteSettingsViewModel
    {
        public string? IntroText { get; set; }
        public string? ContactEmail { get; set; }
        public IEnumerable<Link> Navigation { get; set; } = [];
    }
}