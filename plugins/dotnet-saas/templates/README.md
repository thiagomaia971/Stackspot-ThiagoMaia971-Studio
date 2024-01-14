# {{solution_name}}

Application created by StackSpot ```dotnet-base``` plugin from [Stackspot-ThiagoMaia971-Studio](https://github.com/thiagomaia971/Stackspot-ThiagoMaia971-Studio)

To add new Entity:
> stk apply plugin thiagomaia971/thiagomaia971/dotnet-saas-entity@0.0.23

# Api
All of Api request is using by this NuGet [CruderSimple.Core](https://github.com/thiagomaia971/CruderSimple)

## Insomnia
To correctly import your requests. Use [Insomnia 2023.1.0](https://github.com/Kong/insomnia/releases/tag/core%402023.1.0)Using [Dotnet Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/setup-tooling?tabs=dotnet-cli)

## Dotnet Aspire
Install Dotnet Aspire
> dotnet workload install aspire

# Infrastructure

## Install EF Cli:
> ```dotnet tool install --global dotnet-ef```

## Add migration:
1. ```cd src/{{solution_name}}.Infrastructure```
2. ```dotnet ef migrations add [NomeDaMigration] --startup-project ./../{{solution_name}}.Api```

## Update:
1. ```cd src/{{solution_name}}.Infrastructure```
2. ```dotnet ef database update --startup-project ./../{{solution_name}}.Api```


# How to Debug Blazor WebAssembly in Browser
1. Win + R: "C:\Program Files\Google\Chrome\Application\chrome.exe" --remote-debugging-port=9222
2. Put the Url of Blazor: https://localhost:{{web_host_port}}
3. Shift + Alt + D