using ApplicationCore.Ports;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCacheAdaptor
{


    public class CacheManager : IInMemoryCache
    {
        private readonly MemoryCache _cache;

        public CacheManager()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public T? Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public void Set<T>(string key, T value, TimeSpan expirationTime)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(expirationTime);

            _cache.Set<T>(key, value, cacheEntryOptions);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Clear()
        {
            _cache.Clear();
        }
    }

}