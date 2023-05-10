namespace TaghcheServiceAdaptor;
public interface IBookService
{
    Task<string> GetBookAsync(int id);
}

public class BookService : IBookService
{
    //Todo: dependencies
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public BookService(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl;
    }

    public async Task<string> GetBookAsync(int id)
    {
        //Todo:hard coded url
        string url = $"{_baseUrl}/v2/book/{id}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            return json;
        }
        else
        {
            throw new HttpRequestException($"Failed to retrieve book with id {id}. Status code: {response.StatusCode}");
        }
    }
}
