using TaghcheCC.ApplicationCore.Ports;
using static System.Net.WebRequestMethods;

namespace TaghcheCC.TaghcheServiceAdaptor;
public class TaghcheService : ITaghcheService
{
    //Todo: dependencies
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public TaghcheService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _baseUrl = "https://get.taaghche.com";
    }

    public async Task<string> GetBookAsync(string id)
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
