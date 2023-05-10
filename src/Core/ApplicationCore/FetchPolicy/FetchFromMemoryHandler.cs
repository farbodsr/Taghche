using TaghcheCC.ApplicationCore.Ports;

namespace TaghcheCC.ApplicationCore.FetchPolicy;
internal class FetchFromMemoryHandler : AbstractHandler
{
    private readonly IInMemoryCache _inMemoryCache;
    public FetchFromMemoryHandler(IInMemoryCache inMemoryCache)
    {
        _inMemoryCache = inMemoryCache;
    }
    public override async Task<string> HandleAsync(string request)
    {
        var result = _inMemoryCache.Get<string>(request);
        if (result is null)
        {
            result = await this.nextHandler.HandleAsync(request);

            InsertInMomoryCacheIfNotExists(request, result);
        }
        return result;

        #region LocalMethods
        void InsertInMomoryCacheIfNotExists(string request, string result)
        {
            if (result != null)
            {
                _inMemoryCache.Set<string>(request, result, TimeSpan.FromDays(1));
            }
        }
        #endregion
    }


}
