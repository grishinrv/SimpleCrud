using System;
using System.Threading;
using System.Threading.Tasks;
using SimpleCrud.Infrastructure.Job.Services;

namespace SimpleCrud.Infrastructure.Job
{
    public record JobData
    {
        public static JobData NullObject =>
            new JobData { Job = (p, t) => Task.CompletedTask};
        public Func<IProgress<JobStage>, CancellationToken, Task> Job { get; init; }
        public JobCompletionDelegate CompletedCallBack { get; init; }
        public string Name { get; init; }
        public bool IsCancellable { get; init; }
    }
}
