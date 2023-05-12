using TaghcheCC.ApplicationCore.Ports;

namespace TaghcheCC.ApplicationCore.FetchPolicy;
internal class FetchFromDistributedCacheHandler : AbstractHandler
{
    private readonly IDistributedCache _distributedCache;
    public FetchFromDistributedCacheHandler(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }
    public override async Task<string?> HandleAsync(string request)
    {
        string result = await _distributedCache.GetAsync<string>(request);
        if (result is null)
        {
            result = await this.nextHandler.HandleAsync(request);

            await InsertToDistributedCacheIfResultIsValid(request, result);
        }
        return result;

        #region LocalMethods
        async Task InsertToDistributedCacheIfResultIsValid(string request, string result)
        {
            if (result!="null")
            {
                await _distributedCache.SetAsync<string>(request, result, TimeSpan.FromDays(1));
            }
        }
        #endregion
    }


}
