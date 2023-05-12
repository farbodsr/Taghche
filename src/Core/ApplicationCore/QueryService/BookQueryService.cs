using TaghcheCC.ApplicationCore.FetchPolicy;

namespace TaghcheCC.ApplicationCore.QueryService;

public class BookQueryService : IBookQueryService
{
    private readonly FetchService _fetchService;

    public BookQueryService(FetchService fetchService)
    {
        _fetchService = fetchService;
    }
    public async Task<string> GetBook(string id)
    {
        return await _fetchService.FetchBookAsync(id);
    }
}
