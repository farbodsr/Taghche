using Microsoft.Extensions.Caching.Memory;
using TaghcheCC.ApplicationCore.Ports;

namespace TaghcheCC.InMemoryCacheAdaptor;
public class CacheManager : IInMemoryCache
{
    private readonly MemoryCache _cache;

    public CacheManager()
    {
        _cache = new MemoryCache(new MemoryCacheOptions());
    }

    public Task<T?> GetAsync<T>(string key)
    {
        return Task.Run(()=>_cache.Get<T>(key));
    }

    public Task SetAsync<T>(string key, T value, TimeSpan expirationTime)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(expirationTime);

        return Task.Run(() => _cache.Set<T>(key, value, cacheEntryOptions));
    }

    public Task RemoveAsync(string key)
    {
        return Task.Run(() => _cache.Remove(key));
    }

    public Task ClearAsync()
    {
        return Task.Run(() => _cache.Clear());
    }
}

