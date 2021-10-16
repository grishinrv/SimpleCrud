using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrud.MVVM.Commands.Parameters
{
    public record JobData
    {
        public static JobData NullObject =>
            new JobData { Job = (p, t) => Task.CompletedTask, OperationData = OperationData.Empty};
        public Func<IProgress<JobStage>, CancellationToken, Task> Job { get; init; }
        public OperationData OperationData { get; init; }
        public bool IsCancellable { get; init; }
    }
}
