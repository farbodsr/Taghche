﻿using TaghcheCC.ApplicationCore.Ports;

namespace TaghcheCC.ApplicationCore.FetchPolicy;
internal class FetchFromMemoryHandler : AbstractHandler
{
    private readonly IInMemoryCache _inMemoryCache;
    public FetchFromMemoryHandler(IInMemoryCache inMemoryCache)
    {
        _inMemoryCache = inMemoryCache;
    }
    public override async Task<string?> HandleAsync(string request)
    {
        var result = await _inMemoryCache.GetAsync<string>(request);
        if (result is null)
        {
            result = await this.nextHandler.HandleAsync(request);

            InsertInMomoryCacheIfResultIsValid(request, result);
        }
        return result;

        #region LocalMethods
        void InsertInMomoryCacheIfResultIsValid(string request, string result)
        {
            if (result!="null")
            {
                _inMemoryCache.SetAsync<string>(request, result, TimeSpan.FromDays(1));
            }
        }
        #endregion
    }


}
