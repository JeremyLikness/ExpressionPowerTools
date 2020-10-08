# ExpressionPowerTools

![.NET Core](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/.NET%20Core/badge.svg)
![.NET Core Tests](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/.NET%20Core%20Tests/badge.svg)
![Generate and Publish Documentation](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/Generate%20and%20Publish%20Documentation/badge.svg)
![Pack and Publish NuGet](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/Pack%20and%20Publish%20NuGet/badge.svg)

There are a few options for documentation, including:

- [API Documentation](docs/index.md)
- [Quick Start](docs/quickstart.md)
- [Release Notes](./Releases.md)
- [Test Reports](docs/test/index.md)

**Documentation Tip** Because the documentation is stored in this repo, you can use the GitHub "Go to file" feature to quickly find documentation for a type or member. Just click _Go to File_ and type the name of the method or type and look for the markdown file. You can infer the type of documentation from the extension:

- `.a.md` - assemblies
- `.ns.md` - namespaces
- `.cs.md` - types (classes)
- `.i.md` - types (interfaces)
- `.ctor.md` - constructors
- `.m.md` - methods
- `.prop.md` - properties

## Core

[![NuGet Badge](https://buildstats.info/nuget/ExpressionPowerTools.Core?includePreReleases=true)](https://www.nuget.org/packages/ExpressionPowerTools.Core)
[![Tests](docs/test/ExpressionPowerTools.Core.Tests.svg)](docs/test//ExpressionPowerTools.Core.test.md)
[![Coverage](docs/test/ExpressionPowerTools.Core.Coverage.svg)](docs/test//ExpressionPowerTools.Core.coverage.md)

```powershell
Install-Package ExpressionPowerTools.Core -Version 0.9.2-alpha
```

Power tools for working with `IQueryable` and Expression trees. Enables enumeration of the tree, comparisons ("similar" and "equivalent") and interception to take snapshots and/or mutate expressions.  

[API Documentation](docs/api/ExpressionPowerTools.Core.a.md)

## Serialization

[![NuGet Badge](https://buildstats.info/nuget/ExpressionPowerTools.Serialization?includePreReleases=true)](https://www.nuget.org/packages/ExpressionPowerTools.Serialization)
[![Tests](docs/test/ExpressionPowerTools.Serialization.Tests.svg)](docs/test//ExpressionPowerTools.Serialization.test.md)
[![Coverage](docs/test/ExpressionPowerTools.Serialization.Coverage.svg)](docs/test//ExpressionPowerTools.Serialization.coverage.md)

```powershell
Install-Package ExpressionPowerTools.Serialization -Version 0.9.2-alpha
```

Power tools for writing client-side queries that can be safely serialized to run on the server.

[API Documentation](docs/api/ExpressionPowerTools.Serialization.a.md)

## ASP.NET Core Middleware for EF Core

[![NuGet Badge](https://buildstats.info/nuget/ExpressionPowerTools.Serialization.EFCore.AspNetCore?includePreReleases=true)](https://www.nuget.org/packages/ExpressionPowerTools.Serialization.EFCore.AspNetCore)
[![Tests](docs/test/ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.svg)](docs/test//ExpressionPowerTools.Serialization.EFCore.AspNetCore.test.md)
[![Coverage](docs/test/ExpressionPowerTools.Serialization.EFCore.AspNetCore.Coverage.svg)](docs/test//ExpressionPowerTools.Serialization.EFCore.AspNetCore.coverage.md)

```powershell
Install-Package ExpressionPowerTools.Serialization.EFCore.AspNetCore -Version 0.9.2-alpha
```

Power tools for deserializing queries initiated by remote clients.

[API Documentation](docs/api/ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md)

## Http Client

[![NuGet Badge](https://buildstats.info/nuget/ExpressionPowerTools.Serialization.EFCore.Http?includePreReleases=true)](https://www.nuget.org/packages/ExpressionPowerTools.Serialization.EFCore.Http)
[![Tests](docs/test/ExpressionPowerTools.Serialization.EFCore.Http.Tests.svg)](docs/test//ExpressionPowerTools.Serialization.EFCore.Http.test.md)
[![Coverage](docs/test/ExpressionPowerTools.Serialization.EFCore.Http.Coverage.svg)](docs/test//ExpressionPowerTools.Serialization.EFCore.Http.coverage.md)


```powershell
Install-Package ExpressionPowerTools.Serialization.EFCore.Http -Version 0.9.2-alpha
```

Power tools for running remote queries over HTTP, for example a Blazor WebAssembly client.

[API Documentation](docs/api/ExpressionPowerTools.Serialization.EFCore.Http.a.md)

## Documentation Generator

Internal utility to auto-generate API documentation based on comments and reflection. Directly generates markdown. Also self-documents.

[API Documentation](docs/api/ExpressionPowerTools.Utilities.DocumentGenerator.a.md)
