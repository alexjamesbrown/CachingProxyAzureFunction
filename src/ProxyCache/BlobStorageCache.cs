using System;
using System.Threading.Tasks;

namespace CachingProxy
{
    class BlobStorageCache : ICache
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
            //1) get meta data (head request?) from blob storage
            //2) if exists - check meta data for ttl
            //3) if ttl expired, delete, return null
            //4) if ttl not expired, get full object, return
            throw new NotImplementedException();
        }

        public Task Store(string key, RequestResult requestResult, int ttlInSeconds)
        {
            return Store(key, requestResult, DateTime.Now.AddSeconds(ttlInSeconds));
        }

        public Task Store(string key, RequestResult requestResult, DateTime expiry)
        {
            throw new NotImplementedException();
        }
    }
}