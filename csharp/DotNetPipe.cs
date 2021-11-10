using Android.Graphics;
using Android.Views;
using Java.Interop;
using LayoutDirection = Android.Views.LayoutDirection;

namespace Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class DotNetPipe
{
    readonly TextView textView;
    readonly Java.Lang.Object?[] parameters;
    readonly IntPtr native_parameters;
    readonly Typeface typeface = Typeface.Monospace!;

    public DotNetPipe()
    {
        textView = new TextView(Application.Context);
        parameters = new Java.Lang.Object[35];
        native_parameters = JNIEnv.NewArray(parameters);

        FillParameters();
    }

    [Benchmark]
    public void CallFromCSharp()
    {
        textView.Text = "foo";
        textView.Typeface = typeface;
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

    [Benchmark]
    public unsafe void CallWithPipe()
    {
        // Uncomment to test refilling
        //FillParameters();

        JniArgumentValue* arguments = stackalloc JniArgumentValue[2];
        arguments[0] = new JniArgumentValue(textView.Handle);
        arguments[1] = new JniArgumentValue(native_parameters);
        Send(arguments);
    }

    void FillParameters()
    {
        parameters[0] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewText;
        parameters[1] = "foo";

        parameters[2] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewTypeface;
        parameters[3] = typeface;

        parameters[4] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewTextSize;
        parameters[5] = (int)ComplexUnitType.Pt;
        parameters[6] = 12f;

        parameters[7] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewTextColor;
        parameters[8] = (int)Color.Red;

        parameters[9] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewLetterSpacing;
        parameters[10] = 10f;

        parameters[11] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewTextAlignment;
        parameters[12] = (int)TextAlignment.Center;

        parameters[13] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewGravity;
        parameters[14] = (int)GravityFlags.Center;

        parameters[15] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewSingleLine;
        parameters[16] = true;

        parameters[17] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewMaxLines;
        parameters[18] = 10;

        parameters[19] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewEllipsize;
        parameters[20] = Android.Text.TextUtils.TruncateAt.Middle;

        parameters[21] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewPadding;
        parameters[22] = 1;
        parameters[23] = 2;
        parameters[24] = 3;
        parameters[25] = 4;

        parameters[26] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewPaintFlags;
        parameters[27] = (int)PaintFlags.StrikeThruText;

        parameters[28] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewLineSpacing;
        parameters[29] = 1f;
        parameters[30] = 2f;

        parameters[31] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewLayoutDirection;
        parameters[32] = (int)LayoutDirection.Rtl;

        parameters[33] = Com.Microsoft.Android.Pipe.DotNetPipe.TextviewTextDirection;
        parameters[34] = (int)TextDirection.Rtl;

        JNIEnv.CopyArray(parameters, native_parameters);
    }

    static readonly JniPeerMembers Members = new Com.Microsoft.Android.Pipe.DotNetPipe().JniPeerMembers;

    public static unsafe void Send(JniArgumentValue* __args)
    {
       Members.StaticMethods.InvokeVoidMethod("Send.(Landroid/widget/TextView;[Ljava/lang/Object;)V", __args);
    }
}