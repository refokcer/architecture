using System;
using System.Windows.Forms;
using Lab2.Controllers;
using Lab2.Models;
using Lab2.Views;

namespace Lab2;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var model = new CalculatorModel();
        var view = new CalculatorForm();
        _ = new CalculatorController(model, view);

        Application.Run(view);
    }
}
