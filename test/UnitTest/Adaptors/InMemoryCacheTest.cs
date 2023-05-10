using TaghcheCC.InMemoryCacheAdaptor;

namespace UnitTest.Adaptors;
public class InMemoryCacheTest
{
    [Fact]
    public void SetAndGet()
    {
        // Arrange
        var cache = new CacheManager();
        var key = "testKey";
        var value = "testValue";
        var expirationTime = TimeSpan.FromMinutes(5);

        // Act
        cache.Set(key, value, expirationTime);
        var result = cache.Get<string>(key);

        // Assert
        Assert.Equal(value, result);
    }

    [Fact]
    public void Remove()
    {
        // Arrange
        var cache = new CacheManager();
        var key = "testKey";
        var value = "testValue";
        var expirationTime = TimeSpan.FromMinutes(5);

        // Act
        cache.Set(key, value, expirationTime);
        cache.Remove(key);
        var result = cache.Get<string>(key);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Clear()
    {
        // Arrange
        var cache = new CacheManager();
        var key1 = "testKey1";
        var key2 = "testKey2";
        var value = "testValue";
        var expirationTime = TimeSpan.FromMinutes(5);

        // Act
        cache.Set(key1, value, expirationTime);
        cache.Set(key2, value, expirationTime);
        cache.Clear();
        var result1 = cache.Get<string>(key1);
        var result2 = cache.Get<string>(key2);

        // Assert
        Assert.Null(result1);
        Assert.Null(result2);
    }
}
