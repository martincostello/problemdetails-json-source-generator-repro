# ProblemDetails JSON Source Generator Repro

A repro demonstrating how `ProblemDetails` cannot be used with the JSON source generator.

If a request is made to the `/echo` endpoint without [registering `ProblemDetails`](https://github.com/martincostello/problemdetails-json-source-generator-repro/blob/9bfd1c0f32b06a84921c3ad5f8a5ccfcaab8ace4/Repro/Program.cs#L28) with the JSON source generation context, then an exception is thrown at runtime:

```
NotSupportedException: Metadata for type 'Microsoft.AspNetCore.Mvc.ProblemDetails' was not provided by TypeInfoResolver of type 'ApplicationJsonSerializerContext'. If using source generation, ensure that all root types passed to the serializer have been indicated with 'JsonSerializableAttribute', along with any types that might be serialized polymorphically.
```

If the `ProblemDetails` type is registered with the JSON source generation context, then the project fails to compile.

```
❯ dotnet build
MSBuild version 17.4.0-preview-22368-02+c8492483a for .NET
  Determining projects to restore...
  All projects are up-to-date for restore.
C:\Coding\martincostello\problemdetails-json-source-generator-repro\Repro\System.Text.Json.SourceGeneration\System.Text.Json.SourceGeneration.JsonSourceGenerator\ApplicationJsonSerializerContext.ProblemDetails.g.cs(24,120): error CS0122: 'ProblemDetailsJsonConverter' is inaccessible due to its protection level [C:\Coding\martincostello\problemdetails-json-source-generator-repro\Repro\Repro.csproj]

Build FAILED.

C:\Coding\martincostello\problemdetails-json-source-generator-repro\Repro\System.Text.Json.SourceGeneration\System.Text.Json.SourceGeneration.JsonSourceGenerator\ApplicationJsonSerializerContext.ProblemDetails.g.cs(24,120): error CS0122: 'ProblemDetailsJsonConverter' is inaccessible due to its protection level [C:\Coding\martincostello\problemdetails-json-source-generator-repro\Repro\Repro.csproj]
    0 Warning(s)
    1 Error(s)

Time Elapsed 00:00:02.46
```
