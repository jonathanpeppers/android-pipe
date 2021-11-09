using Android.Graphics;
using Android.Views;
using Java.Interop;
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
        textView.LetterSpacing = 10f;
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

    readonly Java.Lang.Object[] parameters;
    readonly IntPtr native_parameters;

    public DotNetPipe()
    {
        parameters = new Java.Lang.Object[] {

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewText,
            "foo",

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewTypeface,
            Typeface.Monospace,

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewTextSize,
            (int)ComplexUnitType.Pt, 12f,

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewTextColor,
            (int)Color.Red,

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewLetterSpacing,
            10f,

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewTextAlignment,
            (int)TextAlignment.Center,

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewGravity,
            (int)GravityFlags.Center,

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewSingleLine,
            true,

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewMaxLines,
            10,

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewEllipsize,
            Android.Text.TextUtils.TruncateAt.Middle,

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewPadding,
            1, 2, 3, 4,

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewPaintFlags,
            (int)PaintFlags.StrikeThruText,

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewLineSpacing,
            1f, 2f,

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewLayoutDirection,
            (int)LayoutDirection.Rtl,

            Com.Microsoft.Android.Pipe.DotNetPipe.TextviewTextDirection,
            (int)TextDirection.Rtl,
        };

        native_parameters = JNIEnv.NewArray(parameters);
    }

    [Benchmark]
    public unsafe void CallWithPipe()
    {
        var textView = new TextView(Application.Context);
        JniArgumentValue* arguments = stackalloc JniArgumentValue[2];
        arguments[0] = new JniArgumentValue(textView.Handle);
        arguments[1] = new JniArgumentValue(native_parameters);
        Send(arguments);
    }

    static readonly JniPeerMembers Members = new Com.Microsoft.Android.Pipe.DotNetPipe().JniPeerMembers;

    public static unsafe void Send(JniArgumentValue* __args)
    {
       Members.StaticMethods.InvokeVoidMethod("Send.(Landroid/widget/TextView;[Ljava/lang/Object;)V", __args);
    }
}