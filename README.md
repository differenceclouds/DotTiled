# 📚 DotTiled

<img src="https://www.mapeditor.org/img/tiled-logo-white.png" align="right" width="20%"/>

DotTiled is a simple and easy-to-use library for loading, saving, and managing [Tiled maps and tilesets](https://mapeditor.org) in your .NET projects. After [TiledCS](https://github.com/TheBoneJarmer/TiledCS) unfortunately became unmaintained (since 2022), I aimed to create a new library that could fill its shoes. DotTiled is the result of that effort.

- [Feature coverage](#feature-coverage)
- [Alternative libraries and comparison + benchmarks](#alternative-libraries-and-comparison)
- [Quickstart](#quickstart)
  - [Installing DotTiled](#installing-dottiled)
  - [Constructing a `TmxSerializer`](#constructing-a-tmxserializer)
  - [Loading a `.tmx` map](#loading-a-tmx-map)
  - [Loading a `.tsx` tileset](#loading-a-tsx-tileset)
  - [Constructing a `TmjSerializer`](#constructing-a-tmjserializer)
  - [Loading a `.tmj` map](#loading-a-tmj-map)
  - [Loading a `.tsj` tileset](#loading-a-tsj-tileset)

# Feature coverage

# Alternative libraries and comparison

Other similar libraries exist, and you may want to consider them for your project as well:

| **Comparison**                  |       **DotTiled**      | [TiledLib](https://github.com/Ragath/TiledLib.Net) | [TiledCSPlus](https://github.com/nolemretaWxd/TiledCSPlus) | [TiledSharp](https://github.com/marshallward/TiledSharp) | [TiledCS](https://github.com/TheBoneJarmer/TiledCS) | [TiledNet](https://github.com/napen123/Tiled.Net) |
|---------------------------------|:-----------------------:|:--------:|:-----------:|:----------:|:-------:|:------:|
| Actively maintained             |            ✅          |     ✅   |     ✅      |      ❌   |    ❌  |   ❌   |
| Docs                            | Usage,<br>XML Docs      |  Usage   | Usage, API,<br>XML Docs  | Usage, API | Usage, XML Docs | Usage, XML Docs |
| License                         |           MIT           |   MIT    |     MIT     | Apache-2.0 |   MIT   | BSD 3-Clause |
| Benchmark (time)*               |           1.00          |   1.81   |     2.12    |      -     |    -    |    -   |
| Benchmark (memory)*             |           1.00          |   1.42   |     2.03    |      -     |    -    |    -   |
| *Feature coverage<br>comparison*|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|
| `.tmx` (Map XML format)         |✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|
| `.tsx` (Tileset XML format)     |✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|
| `.tx` (Template XML format)     |✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|
| `.tmj` (Map JSON format)        |✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|
| `.tsj` (Tileset JSON format)    |✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|
| `.tj` (Template JSON format)    |✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|
| Load from string (implies file) |✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|
| Load from file                  |✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|
| External tilesets               |✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|
| Template files                  |✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|
| Property custom types           |✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|
| Hierarchical layers (groups)    |✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|
| Infinite maps                   |✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|✅/❌|

> [!NOTE]
> *Both benchmark time and memory ratios are relative to DotTiled. Lower is better. Benchmark (time) refers to the execution time of loading the same map from an in-memory string that contains XML data in the `.tmx` format. Benchmark (memory) refers to the memory allocated during that loading process. For further details on the benchmark results, see the collapsible section below.

<details>
<summary>
Benchmark details
</summary>

#### Benchmark results

The following benchmark results were gathered using the `DotTiled.Benchmark` project which uses [BenchmarkDotNet](https://benchmarkdotnet.org/) to compare the performance of DotTiled with other similar libraries. The benchmark results are grouped by category and show the mean execution time, memory consumption metrics, and ratio to DotTiled.

```
BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4651/22H2/2022Update)
12th Gen Intel Core i7-12700K, 1 CPU, 20 logical and 12 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
```
| Method      | Categories               | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------ |------------------------- |----------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| DotTiled    | MapFromInMemoryTmxString |  2.991 μs | 0.0266 μs | 0.0236 μs |  1.00 |    0.00 | 1.2817 | 0.0610 |  16.37 KB |        1.00 |
| TiledLib    | MapFromInMemoryTmxString |  5.405 μs | 0.0466 μs | 0.0413 μs |  1.81 |    0.02 | 1.8158 | 0.1068 |  23.32 KB |        1.42 |
| TiledCSPlus | MapFromInMemoryTmxString |  6.354 μs | 0.0703 μs | 0.0587 μs |  2.12 |    0.03 | 2.5940 | 0.1831 |  33.23 KB |        2.03 |
|             |                          |           |           |           |       |         |        |        |           |             |
| DotTiled    | MapFromTmxFile           | 28.570 μs | 0.1216 μs | 0.1137 μs |  1.00 |    0.00 | 1.0376 |      - |  13.88 KB |        1.00 |
| TiledCSPlus | MapFromTmxFile           | 33.377 μs | 0.1086 μs | 0.1016 μs |  1.17 |    0.01 | 2.8076 | 0.1221 |  36.93 KB |        2.66 |
| TiledLib    | MapFromTmxFile           | 36.077 μs | 0.1900 μs | 0.1777 μs |  1.26 |    0.01 | 2.0752 | 0.1221 |   27.1 KB |        1.95 |

</details>

[MonoGame](https://www.monogame.net) users may also want to consider using [MonoGame.Extended](https://github.com/craftworkgames/MonoGame.Extended) for loading Tiled maps and tilesets. Like MonoGame.Extended, DotTiled also provides a way to properly import Tiled maps and tilesets with the MonoGame content pipeline (with the DotTiled.MonoGame.Pipeline NuGet). However, unlike MonoGame.Extended, DotTiled does *not* include any kind of rendering capabilities, and it is up to you as a developer to implement any kind of rendering for your maps when using DotTiled. The feature coverage by MonoGame.Extended is less than that of DotTiled, so you may want to consider using DotTiled if you need access to more Tiled features and flexibility.

# Quickstart

### Installing DotTiled

DotTiled is available as a NuGet package. You can install it by using the NuGet Package Manager UI in Visual Studio, or equivalent, or using the following command for the .NET CLI:

```pwsh
dotnet add package DotTiled
```
