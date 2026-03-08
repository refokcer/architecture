using Lab7.Application.Abstractions;
using Lab7.Infrastructure.FileHandlers;

namespace Lab7.Infrastructure.Factories;

public sealed class FileHandlerFactory : IFileHandlerFactory
{
    private readonly IReadOnlyDictionary<string, IFileHandler> _handlers;

    public FileHandlerFactory()
    {
        var registeredHandlers = new IFileHandler[]
        {
            new TextFileHandler(),
            new MarkdownFileHandler()
        };

        _handlers = registeredHandlers.ToDictionary(h => h.Extension, h => h, StringComparer.OrdinalIgnoreCase);
    }

    public IFileHandler ResolveByPath(string path)
    {
        var extension = Path.GetExtension(path);

        if (_handlers.TryGetValue(extension, out var handler))
        {
            return handler;
        }

        return _handlers[".txt"];
    }

    public IEnumerable<IFileHandler> GetSupportedHandlers() => _handlers.Values;
}
