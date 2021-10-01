using System;
using System.Threading.Tasks;

namespace SimpleCrud.MVVM.Commands.Parameters
{
    public record AsyncFunctionContainer
    {
        public Func<Task> Job { get; init; }
        public string Operation { get; init; }
    }
}
