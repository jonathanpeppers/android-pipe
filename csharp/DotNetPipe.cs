using Android.Graphics;
using Android.Views;
using LayoutDirection = Android.Views.LayoutDirection;

namespace Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class DotNetPipe
{
    readonly TextView textView;
    readonly Typeface typeface = Typeface.Monospace!;
    readonly Android.Text.TextUtils.TruncateAt truncateAt = Android.Text.TextUtils.TruncateAt.Middle!;

    public DotNetPipe()
    {
        textView = new TextView(Application.Context);
    }

    [Benchmark]
    public void ManyJNICalls()
    {
        textView.Text = "foo";
        textView.Typeface = typeface;
        textView.SetTextColor(Color.Red);
        textView.SetTextSize(ComplexUnitType.Pt, 12f);
        textView.LetterSpacing = 10f;
        textView.TextAlignment = TextAlignment.Center;
        textView.Gravity = GravityFlags.Center;
        textView.SetSingleLine(true);
        textView.SetMaxLines(10);
        textView.Ellipsize = truncateAt;
        textView.SetPadding(1, 2, 3, 4);
        textView.PaintFlags = PaintFlags.StrikeThruText;
        textView.SetLineSpacing(1f, 2f);
        textView.LayoutDirection = LayoutDirection.Rtl;
        textView.TextDirection = TextDirection.Rtl;
    }

    [Benchmark]
    public void OneJNICall()
    {
        Com.Microsoft.Android.Pipe.DotNetPipe.SetTextView(
            textView,
            "foo",
            typeface,
            Color.Red,
            (int)ComplexUnitType.Pt, 12f,
            10f,
            (int)TextAlignment.Center,
            (int)GravityFlags.Center,
            true,
            10,
            truncateAt,
            1, 2, 3, 4,
            (int)PaintFlags.StrikeThruText,
            1f, 2f,
            (int)LayoutDirection.Rtl,
            (int)TextDirection.Rtl
        );
    }
}