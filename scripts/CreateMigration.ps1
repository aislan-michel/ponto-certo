param(
    [string]$name
)

Set-Location ..\src\PontoCerto.WebApplication\

dotnet ef migrations add $name -o Infrastructure/Migrations