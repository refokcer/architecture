using Lab7.Application.Abstractions;
using Lab7.Application.Services;

namespace Lab7.Application.Commands;

public sealed class SaveDocumentCommand : IEditorCommand
{
    public void Execute(EditorUiContext context)
    {
        var path = context.Session.Document.FilePath;
        if (string.IsNullOrWhiteSpace(path))
        {
            new SaveDocumentAsCommand().Execute(context);
            return;
        }

        context.FileService.Save(path, context.Editor.Text);
        context.Session.SetContent(context.Editor.Text);
        context.Session.MarkSaved(path);
    }
}
