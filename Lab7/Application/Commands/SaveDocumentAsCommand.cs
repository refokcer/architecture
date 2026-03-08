using Lab7.Application.Abstractions;
using Lab7.Application.Services;

namespace Lab7.Application.Commands;

public sealed class SaveDocumentAsCommand : IEditorCommand
{
    public void Execute(EditorUiContext context)
    {
        using var dialog = new SaveFileDialog
        {
            Filter = context.FileService.BuildDialogFilter(),
            Title = "Save document as"
        };

        if (dialog.ShowDialog(context.Owner) != DialogResult.OK)
        {
            return;
        }

        context.FileService.Save(dialog.FileName, context.Editor.Text);
        context.Session.SetContent(context.Editor.Text);
        context.Session.MarkSaved(dialog.FileName);
    }
}
