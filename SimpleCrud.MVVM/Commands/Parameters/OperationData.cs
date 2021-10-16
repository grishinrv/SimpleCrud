using System;

namespace SimpleCrud.MVVM.Commands.Parameters
{
    public struct OperationData
    {
        public static OperationData Empty { get; } = new OperationData { Name = string.Empty, Activity = "Unknown" };
        public string Name { get; init; }
        public string Activity { get; init; }
        public DateTime CompletionTime { get; set; }

        public override string ToString() => Name;
    }
}