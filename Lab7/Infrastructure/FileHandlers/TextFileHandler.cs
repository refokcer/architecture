using Lab7.Application.Abstractions;

namespace Lab7.Infrastructure.FileHandlers;

public sealed class TextFileHandler : IFileHandler
{
    public string Extension => ".txt";
    public string Description => "Text files";

    public string Read(string path) => File.ReadAllText(path);

    public void Write(string path, string content) => File.WriteAllText(path, content);
}
