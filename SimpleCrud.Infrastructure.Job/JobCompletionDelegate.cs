namespace SimpleCrud.Infrastructure.Job
{
    public delegate void JobCompletionDelegate(string jobName, JobCompletionStatus completionStatus, 
        object resultData = null);
}