using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleCrud.Infrastructure.Configuration;
using SimpleCrud.MVVM.Commands;
using SimpleCrud.MVVM.Commands.Parameters;

namespace SimpleCrud.MVVM.ViewModels
{
    public abstract class TaskExecutionViewModel : ViewModel
    {
        public abstract string ActivityName { get; }

        protected JobData CreateJob(Func<IProgress<JobStage>, CancellationToken, Task> task,
            string operationName, bool isCancellable = false)
        {
            Operation operation = new Operation { Activity = ActivityName, Name = operationName };
            return new JobData { Job = task, Operation = operation, IsCancellable = isCancellable };
        }

        protected TaskExecutionViewModel()
        {
            ProcessErrorCommand = new SendEmailCommand(
                ConfigProvider.GetSetting("SupportEmail", String.Empty), 
                "SimpleCrud: error occured");
            AsyncCommand = new RunLongTaskCommand(this);
            _currentTask = TaskWatcher.NullObject;
        }

        public ICommand ProcessErrorCommand { get; }
        public RunLongTaskCommand AsyncCommand { get; }
        private ITaskWatcher _currentTask;

        public ITaskWatcher CurrentTask
        {
            get => _currentTask;
            set => OnSet(ref _currentTask, value);
        }

        private bool _autoCloseProgressDialogOnSuccess;
        public bool AutoCloseProgressDialogOnSuccess
        {
            get => _autoCloseProgressDialogOnSuccess;
            set => OnSet(ref _autoCloseProgressDialogOnSuccess, value);
        }
    }
}