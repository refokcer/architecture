using Lab7.Application.Abstractions;
using Lab7.Application.Services;

namespace Lab7.Application.Commands;

public sealed class UndoCommand : IEditorCommand
{
    public void Execute(EditorUiContext context)
    {
        if (context.Editor.CanUndo)
        {
            context.Editor.Undo();
        }
    }
}
