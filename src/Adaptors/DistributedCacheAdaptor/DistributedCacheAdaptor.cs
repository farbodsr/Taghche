using Microsoft.Extensions.Options;
using StackExchange.Redis;
using TaghcheCC.ApplicationCore.Ports;

namespace TaghcheCC.DistributedCacheAdaptor;
public class DistributedCacheAdaptor : IDistributedCache
{
    private readonly IDatabase _database;

    public DistributedCacheAdaptor(IDatabase database)
    {
        _database = database;
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await _database.StringGetAsync(key);
        if (value.HasValue)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
        else
        {
            return default;
        }
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan expirationTime) 
    {
        if (value is string)
        {
            await _database.StringSetAsync(key, new RedisValue(value.ToString()), expirationTime);
        }
        else throw new ArgumentException("Value is not valid");
    }

    public async Task RemoveAsync(string key)
    {
        await _database.KeyDeleteAsync(key);
    }

}