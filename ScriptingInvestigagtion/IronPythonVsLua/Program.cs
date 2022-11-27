using BenchmarkDotNet.Running;

internal class Program
{
    private static void Main(string[] args)
    {
        var summery = BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}