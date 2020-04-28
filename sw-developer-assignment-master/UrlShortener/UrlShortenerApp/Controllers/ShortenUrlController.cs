using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortenerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenUrlController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] string url)
        {
            return string.Format("TODO: Call 3rd party URL Shortening API to shorten '{0}'", url);
        }
    }
}