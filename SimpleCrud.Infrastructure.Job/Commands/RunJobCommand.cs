using System;
using System.Windows.Input;
using SimpleCrud.Infrastructure.Job.Services;

namespace SimpleCrud.Infrastructure.Job.Commands
{
    public sealed class RunJobCommand : ICommand
    {
        private readonly IJobLauncher _launcher;

        public RunJobCommand(IJobLauncher launcher)
        {
            _launcher = launcher;
        }

        public bool CanExecute(object parameter) => _launcher.LastJobStatus == JobCompletionStatus.Default;

        public void Execute(object parameter)
        {
            if (CanExecute(null) && parameter is JobData data)
            {
                _launcher.BeginExecute(data);
            }
        }
        // todo
        // private void OnJobCompleted(OperationData completedOperationData)
        // {
        //     completedOperationData.CompletionTime = DateTime.Now;
        //     CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        //     OperationTrackerService.OperationFinished(completedOperationData);
        // }
        public event EventHandler CanExecuteChanged;
    }
}
