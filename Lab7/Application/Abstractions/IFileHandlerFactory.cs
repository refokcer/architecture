namespace Lab7.Application.Abstractions;

public interface IFileHandlerFactory
{
    IFileHandler ResolveByPath(string path);
    IEnumerable<IFileHandler> GetSupportedHandlers();
}
