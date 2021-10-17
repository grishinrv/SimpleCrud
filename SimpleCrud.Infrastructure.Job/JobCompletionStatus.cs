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

    public static class JobCompletionStatusBoxes
    {
        public static readonly object DefaultBox = JobCompletionStatus.Default;
        public static readonly object InProgressBox = JobCompletionStatus.InProgress;
        public static readonly object CompetedSuccessfullyBox = JobCompletionStatus.CompetedSuccessfully;
        public static readonly object CompetedWithErrorBox = JobCompletionStatus.CompetedWithError;
        public static readonly object CancelledBox = JobCompletionStatus.Cancelled;
        public static object Box(JobCompletionStatus value) 
        {
            switch (value)
            {
                case JobCompletionStatus.Default:
                    return DefaultBox;
                case JobCompletionStatus.InProgress:
                    return InProgressBox;
                case JobCompletionStatus.CompetedSuccessfully:
                    return CompetedSuccessfullyBox;
                case JobCompletionStatus.CompetedWithError:
                    return CompetedWithErrorBox;
                case JobCompletionStatus.Cancelled:
                    return CancelledBox;
                default:
                    return value;
            }
        }
    }
}