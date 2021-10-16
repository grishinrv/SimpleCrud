namespace SimpleCrud.Infrastructure.Job.Commands
{
    public interface IJobLauncher
    {
        JobCompletionStatus LastJobStatus { get; }
        void BeginExecute(JobData data);
    }
}