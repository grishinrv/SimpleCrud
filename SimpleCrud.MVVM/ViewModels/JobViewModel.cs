using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleCrud.Infrastructure.Configuration;
using SimpleCrud.Infrastructure.Job;
using SimpleCrud.Infrastructure.Job.Commands;
using SimpleCrud.Infrastructure.Job.ViewModel;
using SimpleCrud.MVVM.Commands;

namespace SimpleCrud.MVVM.ViewModels
{
    public abstract class JobViewModel : ViewModel, IJobViewModel
    {
        public abstract string JobSourceName { get; }

        protected JobData CreateJob(Func<IProgress<JobStage>, CancellationToken, Task> task,
            string jobTitle, JobCompletionDelegate completionCallBack = null, bool isCancellable = false) =>
            new JobData
            {
                Job = task, Title = jobTitle, CompletedCallBack = completionCallBack, IsCancellable = isCancellable
            };

        protected JobViewModel()
        {
            ProcessErrorCommand = new SendEmailCommand(
                ConfigProvider.GetSetting("SupportEmail", String.Empty),
                "SimpleCrud: error occured");
            RunJobCommand = new RunJobCommand(this);
            CancelJobCommand = new CancelJobCommand(this);
            CurrentJobStages = new ObservableCollection<string>();
            ProgressStream = new Progress<JobStage>(); // todo - possible OneTime? TEST
        }


        #region IJobController members

        public void BeginExecute(JobData data)
        {
            // the order of calls matters!
            CurrentJobStages.Clear();
            CancellationTokenSource = new CancellationTokenSource();
            CurrentJob = data;
        }

        public void CancelCurrentJob()
        {
            if (CurrentJob.IsCancellable && !CancellationTokenSource.IsCancellationRequested)
            {
                using (CancellationTokenSource)
                {
                    CancellationTokenSource.Cancel();
                }
            }
        }

        #endregion

        public ICommand ProcessErrorCommand { get; }
        public ICommand RunJobCommand { get; }
        public ICommand CancelJobCommand { get; }
        public ObservableCollection<string> CurrentJobStages { get; }

        public JobData CurrentJob
        {
            get => _currentJob;
            set => OnSet(ref _currentJob, value);
        }

        public IProgress<JobStage> ProgressStream
        {
            get => _progressStream;
            set => OnSet(ref _progressStream, value);
        }

        public CancellationTokenSource CancellationTokenSource
        {
            get => _cancellationTokenSource;
            set => OnSet(ref _cancellationTokenSource, value);
        }

        public bool AutoCloseProgressDialogOnSuccess
        {
            get => _autoCloseProgressDialogOnSuccess;
            set => OnSet(ref _autoCloseProgressDialogOnSuccess, value);
        }

        #region private fields

        private JobData _currentJob;
        private IProgress<JobStage> _progressStream;
        private CancellationTokenSource _cancellationTokenSource;
        private bool _autoCloseProgressDialogOnSuccess;

        #endregion
    }
}