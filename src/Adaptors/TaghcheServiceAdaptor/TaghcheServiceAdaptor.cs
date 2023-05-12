using TaghcheCC.ApplicationCore.Ports;
using Microsoft.Extensions.Options;
using TaghcheServiceAdaptor;

namespace TaghcheCC.TaghcheServiceAdaptor;
public class TaghcheService : ITaghcheService
{
    private readonly HttpClient _httpClient;
    private readonly TaghcheSettings _taghcheSettings;

    public TaghcheService(HttpClient httpClient,IOptions<TaghcheSettings> taghcheSettings)
    {
        _httpClient = httpClient;
        _taghcheSettings = taghcheSettings.Value;
    }

    public async Task<string> GetBookAsync(string id)
    {
        var url = string.Format(_taghcheSettings.FetchBookurl, id);
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new HttpRequestException($"Failed to retrieve book with id {id}. Status code: {response.StatusCode}");
        }
    }
}

