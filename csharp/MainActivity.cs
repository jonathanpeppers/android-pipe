namespace Benchmark;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    protected async override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        var success = await Task.Factory.StartNew (BenchmarkInstrumentation.Run);
        FinishActivity(success ? (int)Result.Ok : (int)Result.Canceled);
    }
}
