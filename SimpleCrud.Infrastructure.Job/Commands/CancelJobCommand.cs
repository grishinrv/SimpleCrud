using System;
using System.Windows.Input;

namespace SimpleCrud.Infrastructure.Job.Commands
{
    public class CancelJobCommand : ICommand
    {
        public bool CanExecute(object parameter) => true;

        private readonly IJobController _controller;
        public CancelJobCommand(IJobController controller) => _controller = controller;

        public void Execute(object parameter) => _controller.CancelCurrentJob();

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}