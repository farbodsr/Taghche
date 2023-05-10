namespace TaghcheCC.ApplicationCore.Ports;
public interface ICacheManager
{
    T? Get<T>(string key);
    void Set<T>(string key, T value, TimeSpan expirationTime);
    void Remove(string key);
}

public interface IInMemoryCache : ICacheManager
{
    void Clear();
}
