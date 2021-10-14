using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SimpleCrud.MVVM.Commands.Parameters;

namespace SimpleCrud.MVVM.ViewModels
{
    public sealed class TaskWatcher : ViewModel, ITaskWatcher
    {
        public static ITaskWatcher NullObject { get; } =
            new TaskWatcher(AsyncFunctionContainer.NullObject, (_) => { });

        public Task Task { get; }
        public Operation Operation { get; }
        public ObservableCollection<string> Stages { get; }

        private double _progress;
        public double Progress
        {
            get { return _progress; }
            set => OnSet(ref _progress, value);
        }

        public TaskWatcher(AsyncFunctionContainer container, Action<Operation> onCompletedCallBack)
        {
            Stages = new ObservableCollection<string>();
            Operation = container.Operation;
            var progress = new Progress<JobStage>(stage =>
            {
                Progress = stage.PercentageFinish;
                Stages.Add(stage.Name);
            });
            
            Task = container.Job.Invoke(progress);
            if (!Task.IsCompleted)
            {
                var _ = WatchTaskAsync(Task, onCompletedCallBack);
            }
        }

        private async Task WatchTaskAsync(Task task, Action<Operation> onCompletedCallBack)
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
            onCompletedCallBack?.Invoke(Operation);
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
