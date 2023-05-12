using TaghcheCC.ApplicationCore.FetchPolicy;

namespace TaghcheCC.ApplicationCore.QueryService;

public class BookQueryService : IBookQueryService
{
    private readonly BookFetchService _fetchService;

    public BookQueryService(BookFetchService fetchService)
    {
        _fetchService = fetchService;
    }
    public async Task<string> GetBook(string id)
    {
        return await _fetchService.FetchBookAsync(id);
    }
}
