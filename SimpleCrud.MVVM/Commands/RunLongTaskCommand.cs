using System;
using System.Windows.Input;
using SimpleCrud.MVVM.Commands.Parameters;
using SimpleCrud.MVVM.ViewModels;

namespace SimpleCrud.MVVM.Commands
{
    public sealed class RunLongTaskCommand : ICommand
    {
        private readonly TaskExecutionViewModel _vewModel;

        public RunLongTaskCommand(TaskExecutionViewModel viewModel)
        {
            _vewModel = viewModel;
        }

        public bool CanExecute(object parameter) => _vewModel.CurrentTask == null || _vewModel.CurrentTask.IsCompleted;

        public void Execute(object parameter)
        {
            if (CanExecute(null) && parameter is AsyncFunctionContainer container)
            {
                var watcher = new TaskWatcher(container.Job?.Invoke(), container.Operation);
                watcher.OnTaskCompleted += () => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                _vewModel.CurrentTask = watcher;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
