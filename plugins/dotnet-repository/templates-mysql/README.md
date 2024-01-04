
# Infrastructure

## Install EF Cli:
> ```dotnet tool install --global dotnet-ef```

## Add migration:
1. ```cd src/{{solution_name}}.Infrastructure```
2. ```dotnet ef migrations add [NomeDaMigration] --startup-project ./../{{solution_name}}.Api -- --environment Development```

## Update:
1. ```cd src/{{solution_name}}.Infrastructure```
2. ```dotnet ef database update --startup-project ./../{{solution_name}}.Api -- --environment Development```