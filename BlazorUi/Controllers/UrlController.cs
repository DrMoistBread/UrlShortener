using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebUi.Controllers
{
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly UrlShorteningService _urlShorteningService;

        public UrlController(UrlShorteningService urlShorteningService)
        {
            _urlShorteningService = urlShorteningService;
        }

        [HttpGet("r/{shortUrl}")]
        public async Task<IActionResult> RedirectShortUrl(string shortUrl)
        {
           
            var originalUrl = await _urlShorteningService.GetOriginalUrl(shortUrl);

            return Redirect(originalUrl);
        }
    }
}