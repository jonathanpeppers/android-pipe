using BenchmarkDotNet.Toolchains.InProcess.Emit;

namespace Benchmark;

[Instrumentation(Name = "com.microsoft.BenchmarkInstrumentation")]
public class BenchmarkInstrumentation : Instrumentation
{
    const string Tag = "BENCH";

    protected BenchmarkInstrumentation(IntPtr handle, JniHandleOwnership transfer)
        : base(handle, transfer)
    {
        Log.Debug (Tag, "BenchmarkInstrumentation ctor()");
    }

    public override void OnCreate (Bundle? arguments)
    {
        Log.Debug (Tag, "OnCreate()");

        base.OnCreate (arguments);
        Start ();
    }

    public async override void OnStart ()
    {
        base.OnStart ();

        Log.Debug (Tag, "OnStart()");
        var success = await Task.Factory.StartNew (Run);

        Log.Debug (Tag, $"Calling Finish(), success: {success}");
        Finish (success ? Result.Ok : Result.Canceled, new Bundle());
    }

    public static bool Run()
    {
        Log.Debug (Tag, "Run() on background thread");

        bool success = false;
        try {
            var logger = new Logger();

#if DEBUG
            var baseConfig = new DebugInProcessConfig();
#else
            var baseConfig = DefaultConfig.Instance;
#endif

            var config = new ManualConfig();
            foreach (var e in baseConfig.GetExporters())
                config.AddExporter (e);
            foreach (var d in baseConfig.GetDiagnosers())
                config.AddDiagnoser (d);
            foreach (var a in baseConfig.GetAnalysers())
                config.AddAnalyser (a);
            foreach (var v in baseConfig.GetValidators())
                config.AddValidator (v);
            foreach (var p in baseConfig.GetColumnProviders())
                config.AddColumnProvider(p);
            config.AddJob(JobMode<Job>.Default.WithToolchain(new InProcessEmitToolchain(TimeSpan.FromMinutes(10), logOutput: true)));
            config.UnionRule = ConfigUnionRule.AlwaysUseGlobal; // Overriding the default
            config.AddLogger(logger);

            BenchmarkRunner.Run<DotNetPipe>(config.WithOptions(ConfigOptions.DisableLogFile));
            success = true;
        } catch (Exception ex) {
            Log.Error (Tag, $"Error: {ex}");
        }
        return success;
    }

    class Logger : ILogger
    {
        public string Id => "AndroidLogger";

        public int Priority => 0;

        public void Flush() { }

        public void Write(LogKind logKind, string text) => Console.Write(text);

        public void WriteLine() => Console.WriteLine();

        public void WriteLine(LogKind logKind, string text) => Console.WriteLine(text);
    }
}