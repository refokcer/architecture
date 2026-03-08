using Lab7.Application.Abstractions;
using Lab7.Application.Services;

namespace Lab7.Application.Commands;

public sealed class CutCommand : IEditorCommand
{
    public void Execute(EditorUiContext context) => context.Editor.Cut();
}
