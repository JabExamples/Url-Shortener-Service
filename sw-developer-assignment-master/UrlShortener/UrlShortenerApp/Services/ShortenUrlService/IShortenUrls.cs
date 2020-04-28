using System.Threading.Tasks;

namespace UrlShortenerApp.Services.ShortenUrlService
{
    public interface IShortenUrls
    {
         Task<string> ShortenUrl(string url);
    }
}
