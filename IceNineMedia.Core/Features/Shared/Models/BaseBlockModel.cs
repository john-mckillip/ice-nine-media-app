using Microsoft.AspNetCore.Html;
using UContentMapper.Core.Models.Content;

namespace IceNineMedia.Core.Features.Shared.Models
{
    public class BaseBlockModel : BaseElementModel
    {
        public IHtmlContent? MainBody { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}