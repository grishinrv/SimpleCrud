using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace SimpleCrud.MVVM.ViewModels
{
    public interface ITaskWatcher : INotifyPropertyChanged, IDisposable
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
        event Action OnTaskCompleted;
    }
}