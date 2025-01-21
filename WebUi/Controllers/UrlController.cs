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

        // [HttpPost("api/[controller]/shorten")]
        // public async Task<IActionResult> ShortenUrl([FromBody] string originalUrl)
        // {
        //     var shortUrl = await _urlShortenerService.ShortenUrl(originalUrl);
        //     return Ok(new { originalUrl, shortUrl });
        // }

        [HttpGet("{shortUrl}")]
        public async Task<IActionResult> RedirectShortUrl(string shortUrl)
        {
            var originalUrl = await _urlShorteningService.GetOriginalUrl(shortUrl);

            if (originalUrl == null)
            {
                return NotFound();
            }

            return Redirect(originalUrl);
        }
    }
}
