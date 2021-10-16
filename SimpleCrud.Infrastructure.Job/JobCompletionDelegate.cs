namespace SimpleCrud.Infrastructure.Job
{
    public delegate void JobCompletionDelegate(JobCompletionStatus completionStatus, string jobName, string activity,
        object resultData = null);
}