using Android.Graphics;
using Android.Views;
using System.Buffers;
using LayoutDirection = Android.Views.LayoutDirection;

namespace Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class DotNetPipe
{
    [Benchmark]
    public void CallFromCSharp()
    {
        var textView = new TextView(Application.Context);
        textView.Text = "foo";
        textView.Typeface = Typeface.Monospace;
        textView.SetTextSize(ComplexUnitType.Pt, 12f);
        textView.SetTextColor(Color.Red);
        textView.LetterSpacing = 10;
        textView.TextAlignment = TextAlignment.Center;
        textView.Gravity = GravityFlags.Center;
        textView.SetSingleLine(true);
        textView.SetMaxLines(10);
        textView.Ellipsize = Android.Text.TextUtils.TruncateAt.Middle;
        textView.SetPadding(1, 2, 3, 4);
        textView.PaintFlags = PaintFlags.StrikeThruText;
        textView.SetLineSpacing(1f, 2f);
        textView.LayoutDirection = LayoutDirection.Rtl;
        textView.TextDirection = TextDirection.Rtl;
    }

    [Benchmark]
    public void CallWithPipe()
    {
        var textView = new TextView(Application.Context);
        Com.Microsoft.Android.Pipe.DotNetPipe.Send(new Java.Lang.Object[] {

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewText,
            textView,
            "foo",

        });
    }
}