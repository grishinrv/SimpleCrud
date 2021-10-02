using SimpleCrud.MVVM.Commands;

namespace SimpleCrud.MVVM.ViewModels
{
    public abstract class TaskExecutionViewModel : ViewModel
    {
        protected TaskExecutionViewModel()
        {
            AsyncCommand = new RunLongTaskCommand(this);
        }
        public RunLongTaskCommand AsyncCommand { get; }
        private ITaskWatcher _currentTask;
        public ITaskWatcher CurrentTask { get => _currentTask; set => OnSet(ref _currentTask, value, (o, _) => o?.Dispose()); }
    }
}
