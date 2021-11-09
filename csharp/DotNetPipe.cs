namespace Benchmark;

public class DotNetPipe
{
    // And define a method with the Benchmark attribute
    [Benchmark]
    public void Sleep() => Thread.Sleep(1);

    // You can write a description for your method.
    [Benchmark(Description = "Thread.Sleep(1)")]
    public void SleepWithDescription() => Thread.Sleep(1);
}