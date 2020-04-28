using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortenerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenUrlController : ControllerBase
    {
        [HttpPost]
        public async Task<string> Post([FromBody] string url)
        {
            var client = new HttpClient();
            var cleanUriUrl = "https://cleanuri.com/api/v1/shorten";
            var dictionary = new Dictionary<string, string>
                {
                    { "url", url }
                };
            var response = await client.PostAsync(cleanUriUrl, new FormUrlEncodedContent(dictionary));
            if (response.IsSuccessStatusCode)
            {
                var shortenedUrl = await response.Content.ReadAsAsync<ShortenedUrl>();
                return shortenedUrl.result_url;
            }
            else
            {
                var error = await response.Content.ReadAsAsync<ShortenedUrlError>();
                return error.error;
            }
        }

        public class ShortenedUrl
        {
            public string result_url { get; set; }
        }

        public class ShortenedUrlError
        {
            public string error { get; set; }
        }
    }
}
