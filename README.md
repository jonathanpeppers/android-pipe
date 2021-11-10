# android-pipe

A native messaging pipe to call from C#

|       Method |     Mean |    Error |   StdDev | Allocated |
|------------- |---------:|---------:|---------:|----------:|
|   OneJNICall | 16.59 μs | 0.184 μs | 0.172 μs |         - |
| ManyJNICalls | 57.24 μs | 0.366 μs | 0.342 μs |     120 B |
