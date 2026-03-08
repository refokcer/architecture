using Lab7.Domain.Models;

namespace Lab7.Application.Services;

public sealed class DocumentSession
{
    public event EventHandler? Changed;

    public TextDocument Document { get; } = new();

    public void SetContent(string content)
    {
        Document.ReplaceContent(content);
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void MarkSaved(string? path)
    {
        Document.MarkSaved(path);
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void Reset()
    {
        Document.ReplaceContent(string.Empty);
        Document.MarkSaved(null);
        Changed?.Invoke(this, EventArgs.Empty);
    }
}
