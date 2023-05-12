namespace TaghcheCC.ApplicationCore.Ports
{
    public interface IInMemoryCache : ICacheManager
    {
        Task ClearAsync();
    }
}