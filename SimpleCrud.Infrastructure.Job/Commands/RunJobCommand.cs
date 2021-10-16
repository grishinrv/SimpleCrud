using System;
using System.Windows.Input;
using SimpleCrud.Infrastructure.Job.Services;

namespace SimpleCrud.Infrastructure.Job.Commands
{
    public sealed class RunJobCommand : ICommand
    {
        private readonly IJobController _controller;

        public RunJobCommand(IJobController controller)
        {
            _controller = controller;
        }

        public bool CanExecute(object parameter) => _controller.LastJobStatus == JobCompletionStatus.Default;

        public void Execute(object parameter)
        {
            if (CanExecute(null) && parameter is JobData data)
            {
                _controller.BeginExecute(data);
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
