using System;
using System.Windows.Input;

namespace SimpleCrud.Infrastructure.Job.Services
{
    public interface IJobController
    {
        string JobSourceName { get; }
        ICommand ProcessErrorCommand { get; }
        ICommand RunJobCommand { get; }
        JobCompletionStatus LastJobStatus { get; }
        IProgress<JobStage> ProgressStream { get; }
        void BeginExecute(JobData data);
    }
}