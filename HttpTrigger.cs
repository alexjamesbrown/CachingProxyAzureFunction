using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Linq;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;

namespace CachingProxy
{
    public class HttpTrigger
    {
        public static async Task<IActionResult> Run(HttpRequest req, TraceWriter log)
        {
            // log.Info("C# HTTP trigger function processed a request.");
            //todo: ensure query has url
            if (req.Query.TryGetValue("url", out StringValues value))
            {
                var url = value.First();
                //todo: if url is not valid....

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        var content = await response.Content.ReadAsByteArrayAsync();
                        return new FileContentResult(content, response.Content.Headers.ContentType.MediaType);
                    }
                }
            }

            return new BadRequestObjectResult("Please pass a url in the query string");
        }
    }
}

