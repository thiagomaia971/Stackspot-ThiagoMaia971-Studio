echo off
set startup-project=%1
powershell -command "Start-Sleep -s 5"
dotnet ef migrations add Initial --startup-project %startup-project% --no-build -- --environment Development
dotnet ef database update --startup-project %startup-project% --no-build -- --environment Development