using System;
using System.Threading.Tasks;

namespace CachingProxy
{
    internal class InMemoryCache : ICache
    {
        public Task Clear()
        {
            throw new NotImplementedException();
        }

        public Task Delete(string key)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> Get(string key)
        {
            throw new NotImplementedException();
        }

        public Task Store(string key, RequestResult requestResult, int ttlInSeconds)
        {
            throw new NotImplementedException();
        }

        public Task Store(string key, RequestResult requestResult, DateTime expiry)
        {
            throw new NotImplementedException();
        }
    }
}