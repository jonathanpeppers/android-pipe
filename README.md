# android-pipe

A native messaging pipe to call from C#

|         Method |      Mean |     Error |    StdDev | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
|   CallWithPipe |  4.352 μs | 0.0431 μs | 0.0403 μs |         - |
| CallFromCSharp | 53.471 μs | 0.2661 μs | 0.2489 μs |     120 B |
