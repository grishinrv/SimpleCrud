using System;
using System.Threading.Tasks;

namespace SimpleCrud.MVVM.Commands.Parameters
{
    public record AsyncFunctionContainer
    {
        public static AsyncFunctionContainer NullObject =>
            new AsyncFunctionContainer { Job = (p) => Task.CompletedTask, Operation = Operation.NullObject};
        public Func<IProgress<JobStage>, Task> Job { get; init; }
        public Operation Operation { get; init; }
    }
}
