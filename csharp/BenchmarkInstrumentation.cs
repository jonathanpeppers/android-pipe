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
            var logger = new AccumulationLogger();
            var config = default(IConfig);
#if DEBUG
            config = new DebugInProcessConfig();
#endif
            var summary = BenchmarkRunner.Run<DotNetPipe>(config);
            MarkdownExporter.Console.ExportToLog(summary, logger);
            ConclusionHelper.Print(logger,
                    summary.BenchmarksCases
                            .SelectMany(benchmark => benchmark.Config.GetCompositeAnalyser().Analyse(summary))
                            .Distinct()
                            .ToList());

            // TODO: avoid string.Split
            var text = logger.GetLog();
            foreach (var line in text.Split('\n')) {
                Log.Debug (Tag, line);
            }

            success = true;
        } catch (Exception ex) {
            Log.Error (Tag, $"Error: {ex}");
        }
        return success;
    }
}