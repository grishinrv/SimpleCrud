namespace SimpleCrud.Infrastructure.Job.Commands
{
    public interface IJobController
    {
        void BeginExecute(JobData data);
        void CancelCurrentJob();
    }
}