using System;
using System.Threading.Tasks;
using SimpleCrud.MVVM.Commands;
using SimpleCrud.MVVM.Commands.Parameters;

namespace SimpleCrud.MVVM.ViewModels
{
    public abstract class TaskExecutionViewModel : ViewModel
    {
        public abstract string ActivityName { get; }
        protected AsyncFunctionContainer CreateJob(Func<Task> task, string operationName)
        {
            Operation operation = new Operation { Activity = ActivityName, Name = operationName };
            return new AsyncFunctionContainer { Job = task, Operation = operation };
        }
        protected TaskExecutionViewModel()
        {
            AsyncCommand = new RunLongTaskCommand(this);
            _currentTask = TaskWatcher.NullObject;
        }
        public RunLongTaskCommand AsyncCommand { get; }
        private ITaskWatcher _currentTask;

        public ITaskWatcher CurrentTask
        {
            get => _currentTask;
            set => OnSet(ref _currentTask, value);
        }
    }
}
