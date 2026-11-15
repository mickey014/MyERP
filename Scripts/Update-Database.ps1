
$Project = ".\MyERP.Infrastructure\MyERP.Infrastructure.csproj"
$StartupProject = ".\MyERP.Web\MyERP.Web.csproj"

dotnet ef database update `
    --project $Project `
    --startup-project $StartupProject `
    --context ApplicationDbContext

if ($LASTEXITCODE -ne 0) {
    throw "Database update failed."
}

Write-Host "Database updated successfully!" -ForegroundColor Green
