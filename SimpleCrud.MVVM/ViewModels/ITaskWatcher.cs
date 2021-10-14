using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using SimpleCrud.MVVM.Commands.Parameters;

namespace SimpleCrud.MVVM.ViewModels
{
    public interface ITaskWatcher : INotifyPropertyChanged
    {
        Operation Operation { get; }
        TaskStatus Status { get; }
        bool IsCompleted { get; }
        bool IsNotCompleted { get; }
        bool IsSuccessfullyCompleted { get; }
        bool IsCanceled { get; }
        bool IsFaulted { get; }
        AggregateException Exception { get; }
        Exception InnerException { get; }
        string ErrorMessage { get; }
        ObservableCollection<string> Stages { get; }
        double Progress { get; }
    }
}