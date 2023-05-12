namespace TaghcheServiceAdaptor;
public class TaghcheSettings
{
    public string BaseUrl {  get;init; }
    public string ApiVersion { get; init; }
    public string FetchBookEndpoint { get; init; }

    public string FetchBookurl => $"{BaseUrl}{ApiVersion}{FetchBookEndpoint}";
}
