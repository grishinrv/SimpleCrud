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
            _tokenSource = new CancellationTokenSource();
            CancellationToken = _tokenSource.Token;
            CurrentJob = data;
        }

        public void CancelCurrentJob()
        {
            if (CurrentJob.IsCancellable && !_tokenSource.IsCancellationRequested)
            {
                using (_tokenSource)
                {
                    _tokenSource.Cancel();
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

        public CancellationToken CancellationToken
        {
            get => _cancellationToken;
            set => OnSet(ref _cancellationToken, value);
        }

        public bool AutoCloseProgressDialogOnSuccess
        {
            get => _autoCloseProgressDialogOnSuccess;
            set => OnSet(ref _autoCloseProgressDialogOnSuccess, value);
        }
        #region private fields

        private JobData _currentJob;
        private IProgress<JobStage> _progressStream;
        private CancellationToken _cancellationToken;
        private CancellationTokenSource _tokenSource;
        private bool _autoCloseProgressDialogOnSuccess;

        #endregion
    }
}