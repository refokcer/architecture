using Lab7.Application.Abstractions;

namespace Lab7.Infrastructure.FileHandlers;

public sealed class MarkdownFileHandler : IFileHandler
{
    public string Extension => ".md";
    public string Description => "Markdown files";

    public string Read(string path) => File.ReadAllText(path);

    public void Write(string path, string content) => File.WriteAllText(path, content);
}
