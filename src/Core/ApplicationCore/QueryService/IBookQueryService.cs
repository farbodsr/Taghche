namespace TaghcheCC.ApplicationCore.QueryService
{
    public interface IBookQueryService
    {
        Task<string> GetBook(string id);
    }
}