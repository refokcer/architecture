namespace Lab7.Application.Abstractions;

public interface IFileService
{
    string Read(string path);
    void Save(string path, string content);
    string BuildDialogFilter();
}
