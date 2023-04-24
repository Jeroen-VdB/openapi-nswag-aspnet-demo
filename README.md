# Demo Description

The repo is setup using a contract-first development approach. Meaning we started by first creating an OpenAPI specification, using file `petstore.yml`. The server and client side implementations will be generated based on the OpenAPI spec.

[NSwagStudio](https://github.com/RicoSuter/NSwag/wiki/NSwagStudio) is used to easily configure an NSwag file using a GUI tool. The configuration result is stored in `demo.nswag`.

[NSwag.MSBuild NuGet package](https://www.nuget.org/packages/NSwag.MSBuild) is included in both the ASP.NET server and the .NET client application to automatically update the generated code when building the projects. See [NSwag.MSBuild wiki page](https://github.com/RicoSuter/NSwag/wiki/NSwag.MSBuild) for more info.

Used NSwag.MSBuild configuration:
```xml
<PropertyGroup>
    <RunPostBuildEvent>OnBuildSuccess</RunPostBuildEvent>
</PropertyGroup>

<Target Name="NSwag" AfterTargets="PostBuildEvent" Condition=" '$(Configuration)' == 'Debug' ">
    <Exec WorkingDirectory="$(ProjectDir)" EnvironmentVariables="ASPNETCORE_ENVIRONMENT=Development" Command="$(NSwagExe_Net60) run v1/demo.nswag /variables:Configuration=$(Configuration)" />
</Target>
```

NSwag server side changed configuration:
```json
{
  "runtime": "Net60",
  "defaultVariables": null,
  "documentGenerator": {
    "fromDocument": {
      "url": "petstore-v1.yml",
      ...
    }
  },
  "codeGenerators": {
    "openApiToCSharpController": {
        ...
      "operationGenerationMode": "MultipleClientsFromFirstTagAndPathSegments",
      ...
      "namespace": "ServerSideApplication.V1",
      ...
      "output": "PetStore.generated.cs",
      "newLineBehavior": "Auto"
    }
  }
}
```

NSwag client side changed configuration:
```json
{
  "runtime": "Net60",
  "defaultVariables": null,
  "documentGenerator": {
    "fromDocument": {
      "url": "petstore-v1.yml",
      ...
    }
  },
  "codeGenerators": {
    "openApiToCSharpClient": {
      ...
      "namespace": "ClientSideApplication.V1",
      ...
      "output": "PetStore.generated.cs",
      ...
    }
  }
}
```

Use NSwagStudio and play around with all the different configuration options to see what could be useful for your use case.

Edge-case code generation requirement not supported out of the box? Check out [Liquid templates](https://github.com/RicoSuter/NSwag/wiki/Templates), these can provide more in depth customizations. Do note that certain template modifications might brake in future NSwag releases.
