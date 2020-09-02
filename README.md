# ExpressionPowerTools

![.NET Core](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/.NET%20Core/badge.svg)
![.NET Core Tests](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/.NET%20Core%20Tests/badge.svg)
![Pack and Publish NuGet](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/Pack%20and%20Publish%20NuGet/badge.svg)

User-friendly documentation is coming. Best way to explore now is to browse the tests and read the API documentation.

[API Documentation](docs/index.md)

[Quick Start](docs/quickstart.md)

## Core

[![NuGet Package](https://badgen.net/nuget/v/ExpressionPowerTools.Core)](https://www.nuget.org/packages/ExpressionPowerTools.Core/)

Power tools for working with `IQueryable` and Expression trees. Enables enumeration of the tree, comparisons ("similar" and "equivalent") and interception to take snapshots and/or mutate expressions.  

[API Documentation](docs/api/ExpressionPowerTools.Core.a.md)

## Serialization

Power tools for writing client-side queries that can be safely serialized to run on the server.

[API Documentation](docs/api/ExpressionPowerTools.Serialization.a.md)

## Documentation Generator

Internal utility to auto-generate API documentation based on comments and reflection. Directly generates markdown. Also self-documents.

[API Documentation](docs/api/ExpressionPowerTools.Utilities.DocumentGenerator.a.md)
