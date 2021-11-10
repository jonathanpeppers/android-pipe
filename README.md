# android-pipe

This was an experiment to find out of some kind of general purpose
"messaging" pipe could improve performance for .NET MAUI.

Something like:

```java
public static void Send (TextView view, Object[] message) {
    int messageId;
    for (int i = 0; i < message.length;) {
        messageId = (int)message[i];
        if (messageId == TEXTVIEW_TEXT) {
            view.setText((String)message[i + 1]);
            i += 2;
        } else if (messageId == TEXTVIEW_TYPEFACE) {
            view.setTypeface((Typeface) message[i + 1]);
            i += 2;
        } else if (messageId == TEXTVIEW_TEXT_COLOR) {
            view.setTextColor((int) message[i + 1]);
            i += 2;
        } else if (messageId == TEXTVIEW_TEXT_SIZE) {
            view.setTextSize((int) message[i + 1], (float) message[i + 2]);
            i += 3;
        } else if ...
    }
}
```

Short answer: we couldn't find a scenario it helped. It wast just
worse, due to the way we'd have to copy C# arrays to Java arrays.

However!

Something like this *does* help:

```csharp
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
```

It seems dramatically better:

|       Method |     Mean |    Error |   StdDev | Allocated |
|------------- |---------:|---------:|---------:|----------:|
|   OneJNICall | 16.59 μs | 0.184 μs | 0.172 μs |         - |
| ManyJNICalls | 57.24 μs | 0.366 μs | 0.342 μs |     120 B |
