using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleCrud.MVVM.Commands;
using SimpleCrud.MVVM.Commands.Parameters;

namespace SimpleCrud.MVVM.ViewModels
{
    public sealed class TaskWatcher : ViewModel, ITaskWatcher
    {
        public static ITaskWatcher NullObject { get; } =
            new TaskWatcher(JobData.NullObject, (_) => { });

        private JobCompletionStatus _jobStatus;
        public JobCompletionStatus JobStatus
        {
            get => _jobStatus;
            private set => OnSet(ref _jobStatus, value);
        }

        public Task Task { get; }
        public Operation Operation { get; }
        public ObservableCollection<string> Stages { get; }

        private double _progress;

        public double Progress
        {
            get => _progress;
            private set => OnSet(ref _progress, value);
        }

        public bool IsJobCancellable { get; }

        public ICommand CancelJobCommand { get; }

        public TaskWatcher(JobData container, Action<Operation> onCompletedCallBack)
        {
            _jobStatus = JobCompletionStatus.None;
            Stages = new ObservableCollection<string>();
            Operation = container.Operation;
            var progress = new Progress<JobStage>(stage =>
            {
                Progress = stage.PercentageFinish;
                if (!string.IsNullOrWhiteSpace(stage.Name))
                    Stages.Add(stage.Name);
            });

            var tokenSource = new CancellationTokenSource();
            CancelJobCommand = new CancelJobCommand(tokenSource);
            CancellationToken token = tokenSource.Token;
            IsJobCancellable = container.IsCancellable;

            Task = container.Job.Invoke(progress, token);
            if (!Task.IsCompleted)
            {
                JobStatus = JobCompletionStatus.InProgress;
                var _ = WatchTaskAsync(Task, onCompletedCallBack);
            }
        }

        private async Task WatchTaskAsync(Task task, Action<Operation> onCompletedCallBack)
        {
            try
            {
                await task;
                JobStatus = JobCompletionStatus.CompetedSuccessfully;
            }
            catch
            {
                JobStatus = JobCompletionStatus.CompetedWithError;
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