using NUnit.Framework;
using System.Threading.Tasks;
using UrlShortenerApp.Controllers;
using UrlShortenerApp.Services.ShortenUrlService;

namespace UrlShortenerAppTests
{
    public class ShortenUrlControllerTests
    {
        private ShortenUrlController sut = new ShortenUrlController(new ShortenUrlServiceSpy());
        
        [Test]
        public async Task TestOrchestrationBetweenControllerAndShortenUrlService()
        {            
            var result = await sut.Post("http://www.gooogle.com");
            Assert.AreEqual("http://www.shortUrl.com", result);           
        }
    }

    public class ShortenUrlServiceSpy : IShortenUrls
    {
        public async Task<string> ShortenUrl(string url)
        {
            return "http://www.shortUrl.com";
        }
    }
}
