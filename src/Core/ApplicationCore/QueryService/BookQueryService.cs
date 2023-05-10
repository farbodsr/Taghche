using TaghcheCC.ApplicationCore.FetchPolicy;

namespace ApplicationCore.QueryService;
public class BookQueryService
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
