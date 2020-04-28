using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortenerApp.Services.ShortenUrlService;

namespace UrlShortenerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenUrlController : ControllerBase
    {
        private IShortenUrls shortenUrlService;
        public ShortenUrlController(IShortenUrls shortenUrlService)
        {
            this.shortenUrlService = shortenUrlService;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] string url)
        {
            return await shortenUrlService.ShortenUrl(url);           
        }       
    }
}
