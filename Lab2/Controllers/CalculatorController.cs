using Lab2.Models;
using Lab2.Views;

namespace Lab2.Controllers;

public class CalculatorController
{
    private readonly CalculatorModel _model;
    private readonly ICalculatorView _view;

    public CalculatorController(CalculatorModel model, ICalculatorView view)
    {
        _model = model;
        _view = view;

        SubscribeToViewEvents();
        _view.SetDisplay(_model.Display);
    }

    private void SubscribeToViewEvents()
    {
        _view.DigitPressed += digit => ExecuteAndRefresh(() => _model.InputDigit(digit));
        _view.DecimalSeparatorPressed += () => ExecuteAndRefresh(_model.InputDecimalSeparator);
        _view.OperationPressed += op => ExecuteAndRefresh(() => _model.SetOperation(op));
        _view.EqualsPressed += () => ExecuteAndRefresh(_model.Evaluate);
        _view.ClearEntryPressed += () => ExecuteAndRefresh(_model.ClearEntry);
        _view.ClearAllPressed += () => ExecuteAndRefresh(_model.ClearAll);
        _view.BackspacePressed += () => ExecuteAndRefresh(_model.Backspace);
        _view.ToggleSignPressed += () => ExecuteAndRefresh(_model.ToggleSign);
    }

    private void ExecuteAndRefresh(Action action)
    {
        action();
        _view.SetDisplay(_model.Display);
    }
}
