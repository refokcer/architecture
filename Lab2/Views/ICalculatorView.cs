using Lab2.Models;

namespace Lab2.Views;

public interface ICalculatorView
{
    event Action<char>? DigitPressed;
    event Action? DecimalSeparatorPressed;
    event Action<OperationType>? OperationPressed;
    event Action? EqualsPressed;
    event Action? ClearEntryPressed;
    event Action? ClearAllPressed;
    event Action? BackspacePressed;
    event Action? ToggleSignPressed;

    void SetDisplay(string value);
}
