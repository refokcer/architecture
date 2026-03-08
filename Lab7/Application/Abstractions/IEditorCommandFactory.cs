using System.Windows.Forms;
using Lab7.Application.Services;

namespace Lab7.Application.Abstractions;

public interface IEditorCommandFactory
{
    IEditorCommand Create(string commandName);
    EditorUiContext CreateUiContext(RichTextBox editor, Form owner);
}
