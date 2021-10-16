namespace SimpleCrud.Infrastructure.Job
{
    public readonly struct JobStage
    {
        public double PercentageFinish { get; init; }
        public string Name { get; init; }
    }
}