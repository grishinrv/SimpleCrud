namespace SimpleCrud.MVVM.Commands.Parameters
{
    public class Operation
    {
        public static Operation NullObject { get; } = new Operation { Name = string.Empty, Activity = "Unknown" };
        public string Name { get; init; }
        public string Activity { get; init; }
        public string CompletionTime { get; internal set; }
    }
}