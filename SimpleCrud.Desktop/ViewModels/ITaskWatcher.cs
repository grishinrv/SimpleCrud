using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace SimpleCrud.Desktop.ViewModels
{
    public interface ITaskWatcher : INotifyPropertyChanged
    {
        TaskStatus Status { get; }
        bool IsCompleted { get; }
        bool IsNotCompleted { get; }
        bool IsSuccessfullyCompleted { get; }
        bool IsCanceled { get; }
        bool IsFaulted { get; }
        AggregateException Exception { get; }
        Exception InnerException { get; }
        string ErrorMessage { get; }
    }
}