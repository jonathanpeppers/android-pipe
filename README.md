# android-pipe

A native messaging pipe to call from C#

|         Method |     Mean |   Error |  StdDev | Allocated |
|--------------- |---------:|--------:|--------:|----------:|
|   CallWithPipe | 128.9 μs | 1.78 μs | 1.58 μs |     280 B |
| CallFromCSharp | 181.9 μs | 2.47 μs | 1.93 μs |     400 B |
