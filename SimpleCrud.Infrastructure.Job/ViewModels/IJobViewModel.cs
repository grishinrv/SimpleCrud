using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;
using SimpleCrud.Infrastructure.Job.Commands;

namespace SimpleCrud.Infrastructure.Job.ViewModel
{
    public interface IJobViewModel : IJobController, INotifyPropertyChanged
    {
        ICommand ProcessErrorCommand { get; }
        ICommand RunJobCommand { get; }
        ICommand CancelJobCommand { get; }
        CancellationTokenSource CancellationTokenSource { get;}
        IProgress<JobStage> ProgressStream { get; }
        ObservableCollection<string> CurrentJobStages { get; }
        JobData CurrentJob { get; }
        bool AutoCloseProgressDialogOnSuccess { get; }
    }
}