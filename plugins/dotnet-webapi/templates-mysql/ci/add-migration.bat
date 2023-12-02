echo off
dotnet ef migrations add $1 --startup-project ./../{{solution_name}}.{{api_name}} --no-build -- --environment Development