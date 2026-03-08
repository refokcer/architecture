using Lab7.Application.Abstractions;
using Lab7.Application.Services;

namespace Lab7.Application.Commands;

public sealed class PasteCommand : IEditorCommand
{
    public void Execute(EditorUiContext context) => context.Editor.Paste();
}
