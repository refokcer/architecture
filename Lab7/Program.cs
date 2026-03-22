using Lab7.Application.Services;
using Lab7.Infrastructure.Factories;
using Lab7.Infrastructure.Services;
using Lab7.Presentation;
using WinFormsApp = System.Windows.Forms.Application;
using System.Text;

namespace Lab7;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var documentSession = new DocumentSession();
        var fileHandlerFactory = new FileHandlerFactory();
        var fileService = new FileService(fileHandlerFactory);
        var commandFactory = new EditorCommandFactory(documentSession, fileService);

        WinFormsApp.Run(new MainForm(documentSession, commandFactory));
    }
}
