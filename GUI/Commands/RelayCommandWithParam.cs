using System.Windows.Input;

namespace QuizApp.Commands;

public class RelayCommandWithParam<T> : ICommand
{
    private readonly Action<T> _execute;
    private readonly Predicate<T> _canExecute;

    public RelayCommandWithParam(Action<T> execute, Predicate<T> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        if (parameter == null && typeof(T).IsValueType) return _canExecute == null;
        return _canExecute?.Invoke((T)parameter) ?? true;
    }

    public void Execute(object parameter)
    {
        if (parameter is T t)
        {
            _execute(t);
        }
        else if (parameter == null && !typeof(T).IsValueType)
        {
            _execute((T)parameter);
        }
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}
