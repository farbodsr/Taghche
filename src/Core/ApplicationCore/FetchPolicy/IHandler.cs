
namespace TaghcheCC.ApplicationCore.FetchPolicy;
internal interface IHandler
{
    IHandler SetNext(IHandler handler);

    Task<string?> HandleAsync(string request);
}
