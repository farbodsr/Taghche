namespace TaghcheCC.ApplicationCore.FetchPolicy;
abstract class AbstractHandler : IHandler
{
    private IHandler _nextHandler;
    internal IHandler nextHandler => _nextHandler;

    public IHandler SetNext(IHandler handler)
    {
        this._nextHandler = handler;

        return handler;
    }

    public virtual Task<string> HandleAsync(string request)
    {
        if (this._nextHandler != null)
        {
            return Task<string>.Run(() => this._nextHandler.HandleAsync(request));
        }
        else
        {
            return default;
        }
    }

}
