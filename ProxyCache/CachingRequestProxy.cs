using System.Net.Http;
using System.Threading.Tasks;

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
            //todo: if url is not valid....

            //2) hash the url
            //3) look in cache for contents

            //4) if no cache result, retrieve content from URL
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsByteArrayAsync();

                //5) store cache
                return new RequestResult(content, response.Content.Headers.ContentType.MediaType);
            }
        }
    }
}