namespace TaghcheCC.ApplicationCore.Ports;
public interface ICacheManager
{
    Task<T?> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, TimeSpan expirationTime);
    Task RemoveAsync(string key);
}
