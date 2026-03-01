using Lab7.Application.Services;

namespace Lab7.Application.Abstractions;

public interface IEditorCommand
{
    void Execute(EditorUiContext context);
}
