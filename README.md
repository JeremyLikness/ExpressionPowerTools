# ExpressionPowerTools

![.NET Core](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/.NET%20Core/badge.svg)
![.NET Core Tests](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/.NET%20Core%20Tests/badge.svg)
![Pack and Publish NuGet](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/Pack%20and%20Publish%20NuGet/badge.svg)

User-friendly documentation is coming. Best way to explore now is to browse the tests and read the API documentation.

[API Documentation](docs/index.md)

[Quick Start](docs/quickstart.md)

[Release Notes](./Releases.md)

## Core

[![NuGet Package](https://badgen.net/nuget/v/ExpressionPowerTools.Core)](https://www.nuget.org/packages/ExpressionPowerTools.Core/)

```powershell
Install-Package ExpressionPowerTools.Core -Version 0.8.8-alpha
```

Power tools for working with `IQueryable` and Expression trees. Enables enumeration of the tree, comparisons ("similar" and "equivalent") and interception to take snapshots and/or mutate expressions.  

[API Documentation](docs/api/ExpressionPowerTools.Core.a.md)

## Serialization

[![NuGet Package](https://badgen.net/nuget/v/ExpressionPowerTools.Serialization)](https://www.nuget.org/packages/ExpressionPowerTools.Serialization/)

```powershell
Install-Package ExpressionPowerTools.Serialization -Version 0.8.8-alpha
```

Power tools for writing client-side queries that can be safely serialized to run on the server.

[API Documentation](docs/api/ExpressionPowerTools.Serialization.a.md)

## ASP.NET Core Middleware for EF Core

[![NuGet Package](https://badgen.net/nuget/v/ExpressionPowerTools.Serialization.EFCore.AspNetCore)](https://www.nuget.org/packages/ExpressionPowerTools.Serialization.EFCore.AspNetCore/)

```powershell
Install-Package ExpressionPowerTools.Serialization.EFCore.AspNetCore -Version 0.8.8-alpha
```

Power tools for deserializing queries initiated by remote clients.

[API Documentation](docs/api/ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md)

## Http Client

[![NuGet Package](https://badgen.net/nuget/v/ExpressionPowerTools.Serialization.EFCore.Http)](https://www.nuget.org/packages/ExpressionPowerTools.Serialization.EFCore.Http/)

```poewrshell
Install-Package ExpressionPowerTools.Serialization.EFCore.Http -Version 0.8.8-alpha
```

Power tools for running remote queries over HTTP, for example a Blazor WebAssembly client.

[API Documentation](docs/api/ExpressionPowerTools.Serialization.EFCore.Http.a.md)


## Documentation Generator

Internal utility to auto-generate API documentation based on comments and reflection. Directly generates markdown. Also self-documents.

[API Documentation](docs/api/ExpressionPowerTools.Utilities.DocumentGenerator.a.md)
