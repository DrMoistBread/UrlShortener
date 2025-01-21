using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class UrlShorteningService
    {
        private readonly UrlContext _context;

        public UrlShorteningService(UrlContext context)
        {
            _context = context;
        }

        public async Task<string> ShortenUrl(string originalUrl)
        {
            var existingUrl = _context.Urls.FirstOrDefault(u => u.OriginalUrl == originalUrl);
            if (existingUrl != null)
            {
                return existingUrl.ShortUrl;
            }

            var shortUrl = GenerateShortUrl();
            var url = new Url { OriginalUrl = originalUrl, ShortUrl = shortUrl };

            _context.Urls.Add(url);
            await _context.SaveChangesAsync();

            return shortUrl;
        }

        public async Task<string> GetOriginalUrl(string shortUrl)
        {
            var url = await _context.Urls.FindAsync(shortUrl);
            return url?.OriginalUrl;
        }

        private static string GenerateShortUrl()
        {
            var characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var shortUrl = new char[8];
            var random = new Random();

            for (int i = 0; i < shortUrl.Length; i++)
            {
                shortUrl[i] = characters[random.Next(characters.Length)];
            }

            return new string(shortUrl);
        }
    }
}