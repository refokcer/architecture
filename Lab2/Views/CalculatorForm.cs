using System.Drawing;
using System.Windows.Forms;
using Lab2.Models;

namespace Lab2.Views;

public class CalculatorForm : Form, ICalculatorView
{
    private readonly TextBox _display;

    public event Action<char>? DigitPressed;
    public event Action? DecimalSeparatorPressed;
    public event Action<OperationType>? OperationPressed;
    public event Action? EqualsPressed;
    public event Action? ClearEntryPressed;
    public event Action? ClearAllPressed;
    public event Action? BackspacePressed;
    public event Action? ToggleSignPressed;

    public CalculatorForm()
    {
        Text = "Lab2 - MVC Calculator";
        Width = 360;
        Height = 480;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        _display = new TextBox
        {
            ReadOnly = true,
            TextAlign = HorizontalAlignment.Right,
            Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point),
            Dock = DockStyle.Top,
            Height = 70,
            Text = "0"
        };

        var keypad = BuildKeypad();

        Controls.Add(keypad);
        Controls.Add(_display);
    }

    public void SetDisplay(string value)
    {
        _display.Text = value;
    }

    private TableLayoutPanel BuildKeypad()
    {
        var panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4,
            RowCount = 6,
            Padding = new Padding(10)
        };

        for (var i = 0; i < 4; i++)
        {
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
        }

        for (var i = 0; i < 6; i++)
        {
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 6));
        }

        AddButton(panel, "CE", 0, 0, () => ClearEntryPressed?.Invoke());
        AddButton(panel, "C", 1, 0, () => ClearAllPressed?.Invoke());
        AddButton(panel, "⌫", 2, 0, () => BackspacePressed?.Invoke());
        AddButton(panel, "÷", 3, 0, () => OperationPressed?.Invoke(OperationType.Divide));

        AddButton(panel, "7", 0, 1, () => DigitPressed?.Invoke('7'));
        AddButton(panel, "8", 1, 1, () => DigitPressed?.Invoke('8'));
        AddButton(panel, "9", 2, 1, () => DigitPressed?.Invoke('9'));
        AddButton(panel, "×", 3, 1, () => OperationPressed?.Invoke(OperationType.Multiply));

        AddButton(panel, "4", 0, 2, () => DigitPressed?.Invoke('4'));
        AddButton(panel, "5", 1, 2, () => DigitPressed?.Invoke('5'));
        AddButton(panel, "6", 2, 2, () => DigitPressed?.Invoke('6'));
        AddButton(panel, "−", 3, 2, () => OperationPressed?.Invoke(OperationType.Subtract));

        AddButton(panel, "1", 0, 3, () => DigitPressed?.Invoke('1'));
        AddButton(panel, "2", 1, 3, () => DigitPressed?.Invoke('2'));
        AddButton(panel, "3", 2, 3, () => DigitPressed?.Invoke('3'));
        AddButton(panel, "+", 3, 3, () => OperationPressed?.Invoke(OperationType.Add));

        AddButton(panel, "±", 0, 4, () => ToggleSignPressed?.Invoke());
        AddButton(panel, "0", 1, 4, () => DigitPressed?.Invoke('0'));
        AddButton(panel, ".", 2, 4, () => DecimalSeparatorPressed?.Invoke());
        AddButton(panel, "=", 3, 4, () => EqualsPressed?.Invoke());

        var info = new Label
        {
            Text = "MVC: Model обчислює, View показує, Controller координує.",
            AutoSize = false,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 9F)
        };
        panel.Controls.Add(info, 0, 5);
        panel.SetColumnSpan(info, 4);

        return panel;
    }

    private static void AddButton(TableLayoutPanel panel, string text, int column, int row, Action onClick)
    {
        var button = new Button
        {
            Text = text,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point),
            Margin = new Padding(4)
        };

        button.Click += (_, _) => onClick();
        panel.Controls.Add(button, column, row);
    }
}
