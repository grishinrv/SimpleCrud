using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrud.MVVM.Commands.Parameters
{
    public record AsyncFunctionContainer
    {
        public static AsyncFunctionContainer NullObject =>
            new AsyncFunctionContainer { Job = (p, t) => Task.CompletedTask, Operation = Operation.NullObject};
        public Func<IProgress<JobStage>, CancellationToken, Task> Job { get; init; }
        public Operation Operation { get; init; }
        public bool IsJobCancellable { get; init; }
    }
}
