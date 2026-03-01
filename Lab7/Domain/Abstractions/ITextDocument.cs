namespace Lab7.Domain.Abstractions;

public interface ITextDocument
{
    string Content { get; }
    string? FilePath { get; }
    bool IsDirty { get; }

    void ReplaceContent(string content);
    void MarkSaved(string? filePath);
}
