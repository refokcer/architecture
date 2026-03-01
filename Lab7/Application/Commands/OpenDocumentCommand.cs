using Lab7.Application.Abstractions;
using Lab7.Application.Services;

namespace Lab7.Application.Commands;

public sealed class OpenDocumentCommand : IEditorCommand
{
    public void Execute(EditorUiContext context)
    {
        using var dialog = new OpenFileDialog
        {
            Filter = context.FileService.BuildDialogFilter(),
            CheckFileExists = true,
            Title = "Open document"
        };

        if (dialog.ShowDialog(context.Owner) != DialogResult.OK)
        {
            return;
        }

        var content = context.FileService.Read(dialog.FileName);
        context.Editor.Text = content;
        context.Session.SetContent(content);
        context.Session.MarkSaved(dialog.FileName);
    }
}
