using System;
using System.Windows.Input;
using SimpleCrud.Infrastructure.Job.Commands;

namespace SimpleCrud.Infrastructure.Job.Services
{
    public interface IJobController : IJobLauncher
    {
        ICommand ProcessErrorCommand { get; }
        ICommand RunJobCommand { get; }
        IProgress<JobStage> ProgressStream { get; }
        JobData CurrentJob { get; }
    }
}