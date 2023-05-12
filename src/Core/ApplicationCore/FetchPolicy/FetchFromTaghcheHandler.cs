using TaghcheCC.ApplicationCore.Exceptions;
using TaghcheCC.ApplicationCore.Ports;

namespace TaghcheCC.ApplicationCore.FetchPolicy;
internal class FetchFromTaghcheHandler : AbstractHandler
{
    private readonly ITaghcheService _taghcheService;
    public FetchFromTaghcheHandler(ITaghcheService taghcheService)
    {
        _taghcheService = taghcheService;
    }
    public override async Task<string> HandleAsync(string request)
    {
        string result = await _taghcheService.GetBookAsync(request);
        if (result is null)
        {
            throw new AppException();
        }
        return result;

    }


}
