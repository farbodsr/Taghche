using Moq;
using StackExchange.Redis;
using TaghcheCC.DistributedCacheAdaptor;
using TaghcheCC.InMemoryCacheAdaptor;

namespace UnitTest.Adaptors;
public class DistributedCacheTest
{
    [Fact]
    public async Task SetAndGet()
    {
        // Arrange
        var key = "testKey";
        var value = "testValue";
        var databaseMock = new Mock<IDatabase>();
        databaseMock.Setup(db => db.StringSetAsync(key, value, null, When.Always, CommandFlags.None))
            .Returns(Task.FromResult(true));
        databaseMock.Setup(db => db.StringGetAsync(key, CommandFlags.None))
            .Returns(Task.FromResult(new RedisValue(value)));
        var cache = new DistributedCacheAdaptor(databaseMock.Object);

        var expirationTime = TimeSpan.FromMinutes(5);

        // Act
        await cache.SetAsync(key, value, expirationTime);
        var result = await cache.GetAsync<string>(key);

        // Assert
        Assert.Equal(value, result);
    }
}


