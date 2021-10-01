using System;
using System.Threading.Tasks;
using System.Windows.Input;
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
            if (CanExecute(null) && parameter is Func<Task> job)
            {
                var watcher = new TaskWatcher(job.Invoke());
                watcher.OnTaskCompleted += () => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                _vewModel.CurrentTask = watcher;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
