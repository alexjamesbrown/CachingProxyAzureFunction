using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System;

namespace CachingProxy
{
    public class CachingRequestProxy
    {
        private static HttpClient client = new HttpClient();

        private ICache cache;

        public CachingRequestProxy()
        {
            cache = new InMemoryCache();
        }

        public async Task<RequestResult> RetrieveContents(string url)
        {
            //todo: if url is not valid throw exception

            //2) hash the url
            var urlHash = CreateHash(url);

            //3) look in cache for contents, return if it exists
            var cacheResult = await cache.Get(urlHash);

            if (cacheResult != null)
                return cacheResult;

            //4) if no cache result, retrieve content from URL
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsByteArrayAsync();

                var requestResult = new RequestResult(content, response.Content.Headers.ContentType.MediaType);

                //store in cache
                await cache.Store(urlHash, requestResult, TimeSpan.FromDays(30).Seconds)

                return requestResult;
            }
        }

        public static string CreateHash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input));

                var hashString = string.Empty;

                foreach (var theByte in hash)
                    hashString += theByte.ToString("x2");

                return hashString;
            }
        }
    }
}