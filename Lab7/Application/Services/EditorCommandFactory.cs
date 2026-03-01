using Lab7.Application.Abstractions;
using Lab7.Application.Commands;

namespace Lab7.Application.Services;

public sealed class EditorCommandFactory(DocumentSession session, IFileService fileService) : IEditorCommandFactory
{
    public IEditorCommand Create(string commandName)
    {
        return commandName.ToLowerInvariant() switch
        {
            "new" => new NewDocumentCommand(),
            "open" => new OpenDocumentCommand(),
            "save" => new SaveDocumentCommand(),
            "saveas" => new SaveDocumentAsCommand(),
            "cut" => new CutCommand(),
            "copy" => new CopyCommand(),
            "paste" => new PasteCommand(),
            "undo" => new UndoCommand(),
            "redo" => new RedoCommand(),
            _ => throw new ArgumentException($"Unknown command: {commandName}")
        };
    }

    public EditorUiContext CreateUiContext(RichTextBox editor, Form owner)
    {
        return new EditorUiContext(editor, owner, session, fileService);
    }
}
