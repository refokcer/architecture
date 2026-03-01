namespace Lab7.Application.Abstractions;

public interface IFileHandler
{
    string Extension { get; }
    string Description { get; }
    string Read(string path);
    void Write(string path, string content);
}
