echo off
powershell -command "Start-Sleep -s 10"
dotnet ef database update --startup-project ./../{{solution_name}}.{{api_name}} --no-build -- --environment Development