using Lab7.Application.Abstractions;

namespace Lab7.Infrastructure.Services;

public sealed class FileService(IFileHandlerFactory handlerFactory) : IFileService
{
    public string Read(string path)
    {
        var handler = handlerFactory.ResolveByPath(path);
        return handler.Read(path);
    }

    public void Save(string path, string content)
    {
        var handler = handlerFactory.ResolveByPath(path);
        handler.Write(path, content);
    }

    public string BuildDialogFilter()
    {
        var filters = handlerFactory
            .GetSupportedHandlers()
            .Select(h => $"{h.Description} (*{h.Extension})|*{h.Extension}");

        return string.Join("|", filters) + "|All files (*.*)|*.*";
    }
}
