﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace UrlShortenerApp.Services.ShortenUrlService
{
    public class CleanUriUrlShortenerService : IShortenUrls
    {
        private const string cleanUriUrl = "https://cleanuri.com/api/v1/shorten";
        private readonly HttpClient client;

        public CleanUriUrlShortenerService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient();
        }

        public async Task<string> ShortenUrl(string url)
        {        
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
