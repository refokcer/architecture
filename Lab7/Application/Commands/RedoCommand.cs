using Lab7.Application.Abstractions;
using Lab7.Application.Services;

namespace Lab7.Application.Commands;

public sealed class RedoCommand : IEditorCommand
{
    public void Execute(EditorUiContext context)
    {
        if (context.Editor.CanRedo)
        {
            context.Editor.Redo();
        }
    }
}
