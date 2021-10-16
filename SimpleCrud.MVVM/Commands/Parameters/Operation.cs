using System;

namespace SimpleCrud.MVVM.Commands.Parameters
{
    public struct Operation
    {
        public static Operation Empty { get; } = new Operation { Name = string.Empty, Activity = "Unknown" };
        public string Name { get; init; }
        public string Activity { get; init; }
        public DateTime CompletionTime { get; set; }

        public override string ToString() => Name;
    }
}