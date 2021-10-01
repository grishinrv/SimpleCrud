using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleCrud.Desktop.ViewModels;

namespace SimpleCrud.Desktop.Commands
{
    public class RunLongTaskCommand : ICommand
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
                _vewModel.CurrentTask = new TaskWatcher(job.Invoke());
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
