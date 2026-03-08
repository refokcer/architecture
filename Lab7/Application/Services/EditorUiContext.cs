using System.Windows.Forms;
using Lab7.Application.Abstractions;

namespace Lab7.Application.Services;

public sealed class EditorUiContext(
    RichTextBox editor,
    Form owner,
    DocumentSession session,
    IFileService fileService)
{
    public RichTextBox Editor { get; } = editor;
    public Form Owner { get; } = owner;
    public DocumentSession Session { get; } = session;
    public IFileService FileService { get; } = fileService;
}
