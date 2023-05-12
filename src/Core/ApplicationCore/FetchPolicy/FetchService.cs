﻿using TaghcheCC.ApplicationCore.Ports;

namespace TaghcheCC.ApplicationCore.FetchPolicy;
public class FetchService
{
    private readonly IHandler handler;
    public FetchService(IInMemoryCache inMemoryCache, ITaghcheService taghcheService,
        IDistributedCache distributedCache)
    {
        handler = new FetchFromMemoryHandler(inMemoryCache);
        var inMemoryHandler = handler.SetNext(new FetchFromDistributedCacheHandler(distributedCache));
        inMemoryHandler.SetNext(new FetchFromTaghcheHandler(taghcheService));
    }

    internal async Task<string> FetchBookAsync(string id)
    {
        return await handler.HandleAsync(id);
    }
}
