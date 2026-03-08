using System;
using System.Windows.Forms;
using Lab2.Controllers;
using Lab2.Models;
using Lab2.Views;
using System.Text;

namespace Lab2;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        ApplicationConfiguration.Initialize();

        var model = new CalculatorModel();
        var view = new CalculatorForm();
        _ = new CalculatorController(model, view);

        Application.Run(view);
    }
}
