using Lab7.Domain.Abstractions;

namespace Lab7.Domain.Models;

public sealed class TextDocument : ITextDocument
{
    public string Content { get; private set; } = string.Empty;
    public string? FilePath { get; private set; }
    public bool IsDirty { get; private set; }

    public void ReplaceContent(string content)
    {
        Content = content;
        IsDirty = true;
    }

    public void MarkSaved(string? filePath)
    {
        FilePath = filePath;
        IsDirty = false;
    }
}
