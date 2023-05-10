namespace TaghcheCC.ApplicationCore.Ports;
public interface ITaghcheService
{
    Task<string> GetBookAsync(string id);
}
