using ApplicationCore.Ports;

namespace ApplicationCore.FetchPolicy
{
    public class FetchService
    {
        private readonly IHandler handler;
        internal FetchService(IInMemoryCache inMemoryCache,ITaghcheService taghcheService)
        {
            handler = new FetchFromMemoryHandler(inMemoryCache);
            handler.SetNext(new FetchFromTaghcheHandler(taghcheService));
        }

        internal async Task<string> FetchBookAsync(string id)
        {
            return await handler.HandleAsync(id);
        }

        
    }
}
