using System;
using System.Threading.Tasks;

namespace SimpleCrud.MVVM.ViewModels
{
    public sealed class TaskWatcher<TResult> : ViewModel, ITaskWatcher
    {
        public Task<TResult> Task { get; }
        public event Action OnTaskCompleted;

        public TaskWatcher(Task<TResult> task)
        {
            Task = task;
            if (!task.IsCompleted)
            {
                var _ = WatchTaskAsync(task);
            }
        }

        public void Dispose()
        {
            foreach (var subscriber in OnTaskCompleted?.GetInvocationList() ?? Array.Empty<Delegate>())
            {
                if (subscriber is Action action)
                    OnTaskCompleted -= action;
            }
        }

        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                await task;
            }
            catch
            {
                // ignored
            }

            OnPropertyChanged(nameof(Status));
            OnPropertyChanged(nameof(IsCompleted));
            OnPropertyChanged(nameof(IsNotCompleted));
            if (task.IsCanceled)
                OnPropertyChanged(nameof(IsCanceled));
            else if (task.IsFaulted)
            {
                OnPropertyChanged(nameof(IsFaulted));
                OnPropertyChanged(nameof(Exception));
                OnPropertyChanged(nameof(InnerException));
                OnPropertyChanged(nameof(ErrorMessage));
            }
            else
            {
                OnPropertyChanged(nameof(IsSuccessfullyCompleted));
                OnPropertyChanged(nameof(Result));
            }
            OnTaskCompleted?.Invoke();
        }

        public TResult Result => (Task.Status == TaskStatus.RanToCompletion) ? Task.Result : default(TResult);
        public TaskStatus Status => Task.Status;
        public bool IsCompleted => Task.IsCompleted;
        public bool IsNotCompleted => !Task.IsCompleted;
        public bool IsSuccessfullyCompleted => Task.Status == TaskStatus.RanToCompletion;
        public bool IsCanceled => Task.IsCanceled;
        public bool IsFaulted => Task.IsFaulted;
        public AggregateException Exception => Task.Exception;
        public Exception InnerException => Exception?.InnerException;
        public string ErrorMessage => InnerException?.Message;
    }

    public sealed class TaskWatcher : ViewModel, ITaskWatcher
    {
        public Task Task { get; }
        public event Action OnTaskCompleted;

        public TaskWatcher(Task task)
        {
            Task = task;
            if (!task.IsCompleted)
            {
                var _ = WatchTaskAsync(task);
            }
        }

        public void Dispose()
        {
            foreach (var subscriber in OnTaskCompleted?.GetInvocationList() ?? Array.Empty<Delegate>())
            {
                if (subscriber is Action action)
                    OnTaskCompleted -= action;
            }
        }

        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                await task;
            }
            catch
            {
                // ignored
            }

            OnPropertyChanged(nameof(Status));
            OnPropertyChanged(nameof(IsCompleted));
            OnPropertyChanged(nameof(IsNotCompleted));
            if (task.IsCanceled)
                OnPropertyChanged(nameof(IsCanceled));
            else if (task.IsFaulted)
            {
                OnPropertyChanged(nameof(IsFaulted));
                OnPropertyChanged(nameof(Exception));
                OnPropertyChanged(nameof(InnerException));
                OnPropertyChanged(nameof(ErrorMessage));
            }
            else
            {
                OnPropertyChanged(nameof(IsSuccessfullyCompleted));
            }
            OnTaskCompleted?.Invoke();
        }

        public TaskStatus Status => Task.Status;
        public bool IsCompleted => Task.IsCompleted;
        public bool IsNotCompleted => !Task.IsCompleted;
        public bool IsSuccessfullyCompleted => Task.Status == TaskStatus.RanToCompletion;
        public bool IsCanceled => Task.IsCanceled;
        public bool IsFaulted => Task.IsFaulted;
        public AggregateException Exception => Task.Exception;
        public Exception InnerException => Exception?.InnerException;
        public string ErrorMessage => InnerException?.Message;
    }
}
