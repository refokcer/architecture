using System.Globalization;

namespace Lab2.Models;

public class CalculatorModel
{
    private const string DefaultDisplay = "0";

    private double _leftOperand;
    private OperationType _pendingOperation = OperationType.None;
    private bool _replaceDisplay = true;

    public string Display { get; private set; } = DefaultDisplay;

    public void InputDigit(char digit)
    {
        if (!char.IsDigit(digit))
        {
            return;
        }

        if (_replaceDisplay || Display == DefaultDisplay)
        {
            Display = digit.ToString();
            _replaceDisplay = false;
            return;
        }

        Display += digit;
    }

    public void InputDecimalSeparator()
    {
        if (_replaceDisplay)
        {
            Display = "0.";
            _replaceDisplay = false;
            return;
        }

        if (!Display.Contains('.'))
        {
            Display += ".";
        }
    }

    public void ToggleSign()
    {
        if (Display == DefaultDisplay)
        {
            return;
        }

        Display = Display.StartsWith('-') ? Display[1..] : $"-{Display}";
    }

    public void SetOperation(OperationType operation)
    {
        if (_pendingOperation != OperationType.None && !_replaceDisplay)
        {
            Evaluate();
        }

        _leftOperand = ParseDisplay();
        _pendingOperation = operation;
        _replaceDisplay = true;
    }

    public void Evaluate()
    {
        if (_pendingOperation == OperationType.None)
        {
            return;
        }

        var rightOperand = ParseDisplay();
        var result = _pendingOperation switch
        {
            OperationType.Add => _leftOperand + rightOperand,
            OperationType.Subtract => _leftOperand - rightOperand,
            OperationType.Multiply => _leftOperand * rightOperand,
            OperationType.Divide => rightOperand == 0 ? double.NaN : _leftOperand / rightOperand,
            _ => rightOperand
        };

        Display = FormatResult(result);
        _pendingOperation = OperationType.None;
        _replaceDisplay = true;
    }

    public void ClearEntry()
    {
        Display = DefaultDisplay;
        _replaceDisplay = true;
    }

    public void ClearAll()
    {
        _leftOperand = 0;
        _pendingOperation = OperationType.None;
        Display = DefaultDisplay;
        _replaceDisplay = true;
    }

    public void Backspace()
    {
        if (_replaceDisplay || Display == DefaultDisplay)
        {
            return;
        }

        Display = Display.Length > 1 ? Display[..^1] : DefaultDisplay;

        if (Display == "-" || string.IsNullOrWhiteSpace(Display))
        {
            Display = DefaultDisplay;
        }
    }

    private double ParseDisplay()
    {
        return double.TryParse(Display, NumberStyles.Float, CultureInfo.InvariantCulture, out var value)
            ? value
            : 0;
    }

    private static string FormatResult(double value)
    {
        if (double.IsNaN(value) || double.IsInfinity(value))
        {
            return "Error";
        }

        return value.ToString("G15", CultureInfo.InvariantCulture);
    }
}
