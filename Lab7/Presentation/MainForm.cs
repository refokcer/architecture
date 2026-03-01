using Lab7.Application.Abstractions;
using Lab7.Application.Services;

namespace Lab7.Presentation;

public sealed class MainForm : Form
{
    private readonly DocumentSession _documentSession;
    private readonly IEditorCommandFactory _commandFactory;
    private readonly RichTextBox _editor;
    private readonly ToolStripStatusLabel _statusLabel;

    public MainForm(DocumentSession documentSession, IEditorCommandFactory commandFactory)
    {
        _documentSession = documentSession;
        _commandFactory = commandFactory;

        Text = "Lab7 - Text Editor";
        Width = 1000;
        Height = 700;

        var menuStrip = BuildMenu();
        var toolStrip = BuildTools();
        var statusStrip = new StatusStrip();
        _statusLabel = new ToolStripStatusLabel("Ready");
        statusStrip.Items.Add(_statusLabel);

        _editor = new RichTextBox
        {
            Dock = DockStyle.Fill,
            Font = new Font("Consolas", 12)
        };
        _editor.TextChanged += (_, _) =>
        {
            _documentSession.SetContent(_editor.Text);
            UpdateStatus();
        };

        Controls.Add(_editor);
        Controls.Add(toolStrip);
        Controls.Add(menuStrip);
        Controls.Add(statusStrip);

        MainMenuStrip = menuStrip;
        toolStrip.Dock = DockStyle.Top;
        menuStrip.Dock = DockStyle.Top;

        _documentSession.Changed += (_, _) => UpdateStatus();
        UpdateStatus();
    }

    private MenuStrip BuildMenu()
    {
        var menu = new MenuStrip();

        var file = new ToolStripMenuItem("File");
        file.DropDownItems.Add(CreateMenuItem("New", "new"));
        file.DropDownItems.Add(CreateMenuItem("Open", "open"));
        file.DropDownItems.Add(CreateMenuItem("Save", "save"));
        file.DropDownItems.Add(CreateMenuItem("Save As", "saveas"));

        var edit = new ToolStripMenuItem("Edit");
        edit.DropDownItems.Add(CreateMenuItem("Undo", "undo"));
        edit.DropDownItems.Add(CreateMenuItem("Redo", "redo"));
        edit.DropDownItems.Add(new ToolStripSeparator());
        edit.DropDownItems.Add(CreateMenuItem("Cut", "cut"));
        edit.DropDownItems.Add(CreateMenuItem("Copy", "copy"));
        edit.DropDownItems.Add(CreateMenuItem("Paste", "paste"));

        menu.Items.Add(file);
        menu.Items.Add(edit);

        return menu;
    }

    private ToolStrip BuildTools()
    {
        var tools = new ToolStrip();
        tools.Items.Add(CreateToolButton("New", "new"));
        tools.Items.Add(CreateToolButton("Open", "open"));
        tools.Items.Add(CreateToolButton("Save", "save"));
        tools.Items.Add(new ToolStripSeparator());
        tools.Items.Add(CreateToolButton("Cut", "cut"));
        tools.Items.Add(CreateToolButton("Copy", "copy"));
        tools.Items.Add(CreateToolButton("Paste", "paste"));

        return tools;
    }

    private ToolStripMenuItem CreateMenuItem(string caption, string command)
    {
        var menuItem = new ToolStripMenuItem(caption);
        menuItem.Click += (_, _) => Execute(command);
        return menuItem;
    }

    private ToolStripButton CreateToolButton(string caption, string command)
    {
        var button = new ToolStripButton(caption);
        button.Click += (_, _) => Execute(command);
        return button;
    }

    private void Execute(string commandName)
    {
        try
        {
            var command = _commandFactory.Create(commandName);
            var context = _commandFactory.CreateUiContext(_editor, this);
            command.Execute(context);
        }
        catch (Exception exception)
        {
            MessageBox.Show(this, exception.Message, "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void UpdateStatus()
    {
        var filePath = _documentSession.Document.FilePath ?? "Unsaved document";
        var dirty = _documentSession.Document.IsDirty ? "*" : string.Empty;
        var charsCount = _editor.TextLength;

        _statusLabel.Text = $"{filePath}{dirty} | Characters: {charsCount}";
    }
}
