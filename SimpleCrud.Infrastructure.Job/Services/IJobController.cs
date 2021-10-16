using System.Windows.Input;

namespace SimpleCrud.Infrastructure.Job.Services
{
    public interface IJobController
    {
        string JobSourceName { get; }
        ICommand ProcessErrorCommand { get; }
        ICommand RunJobCommand { get; }
        JobCompletionStatus LastJobStatus { get; }
        void BeginExecute(JobData data);
    }
}