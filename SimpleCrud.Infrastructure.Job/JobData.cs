using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrud.Infrastructure.Job
{
    public record JobData
    {
        public static JobData NullObject =>
            new JobData { Job = (p, t) => Task.CompletedTask};
        public Func<IProgress<JobStage>, CancellationToken, Task> Job { get; init; }
        public IProgress<JobStage> ProgressStream { get; init; }
        public JobCompletionDelegate CompletedCallBack { get; init; }
        public string Name { get; init; }
        public string Activity { get; init; }
        public bool IsCancellable { get; init; }
    }
}
