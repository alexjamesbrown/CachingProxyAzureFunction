
using System;
using System.Threading.Tasks;

namespace CachingProxy
{
    public interface ICache
    {
        Task<RequestResult> Get(string key);
        Task Delete(string key);
        Task Clear();
        Task Store(string key, object data, string contentType, int ttlInSeconds);
        Task Store(string key, object data, string contentType, DateTime expiry);
    }
}