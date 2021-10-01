namespace SimpleCrud.MVVM.ViewModels
{
    public class TaskExecutionViewModel : ViewModel
    {
        private ITaskWatcher _currentTask;
        public ITaskWatcher CurrentTask { get => _currentTask; set => OnSet(ref _currentTask, value, (o, _) => o?.Dispose()); }
    }
}
