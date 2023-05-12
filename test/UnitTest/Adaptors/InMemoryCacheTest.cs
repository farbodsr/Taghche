using TaghcheCC.InMemoryCacheAdaptor;

namespace UnitTest.Adaptors;
public class InMemoryCacheTest
{
    [Fact]
    public async Task SetAndGet()
    {
        // Arrange
        var cache = new CacheManager();
        var key = "testKey";
        var value = "testValue";
        var expirationTime = TimeSpan.FromMinutes(5);

        // Act
        await cache.SetAsync(key, value, expirationTime);
        var result = await cache.GetAsync<string>(key);

        // Assert
        Assert.Equal(value, result);
    }

    [Fact]
    public async Task Remove()
    {
        // Arrange
        var cache = new CacheManager();
        var key = "testKey";
        var value = "testValue";
        var expirationTime = TimeSpan.FromMinutes(5);

        // Act
        await cache.SetAsync(key, value, expirationTime);
        await cache.RemoveAsync(key);
        var result = await cache.GetAsync<string>(key);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Clear()
    {
        // Arrange
        var cache = new CacheManager();
        var key1 = "testKey1";
        var key2 = "testKey2";
        var value = "testValue";
        var expirationTime = TimeSpan.FromMinutes(5);

        // Act
        await cache.SetAsync(key1, value, expirationTime);
        await cache.SetAsync(key2, value, expirationTime);
        await cache.ClearAsync();
        var result1 = await cache.GetAsync<string>(key1);
        var result2 = await cache.GetAsync<string>(key2);

        // Assert
        Assert.Null(result1);
        Assert.Null(result2);
    }
}
