namespace SimpleCrud.Infrastructure.Job
{
    public enum JobCompletionStatus
    {
        Default = 0,
        InProgress = 1,
        CompetedSuccessfully = 2,
        CompetedWithError = 3,
        Cancelled = 4
    }
}