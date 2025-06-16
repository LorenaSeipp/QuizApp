using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace QuizApp.Commands;

public class RelayCommand : ICommand
{
    private readonly Func<bool> _canExecute;
    private readonly Action _execute;

    public RelayCommand(Action execute, Func<bool> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute ?? (() => true);
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        try
        {
            return _canExecute();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[RelayCommand.CanExecute] Fehler: {ex.Message}");
            return false;
        }
    }

    public void Execute(object parameter)
    {
        try
        {
            _execute();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[RelayCommand.Execute] Ausnahme: {ex}");

            MessageBox.Show("Beim Ausführen des Befehls ist ein Fehler aufgetreten.", "Fehler", MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }

    public void RaiseCanExecuteChanged()
    {
        try
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[RelayCommand.RaiseCanExecuteChanged] Fehler: {ex.Message}");
        }
    }
}