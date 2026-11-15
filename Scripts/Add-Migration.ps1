
param(
    [Parameter(Mandatory = $true)]
    [string]$Name
)

$Project = ".\MyERP.Infrastructure\MyERP.Infrastructure.csproj"
$StartupProject = ".\MyERP.Web\MyERP.Web.csproj"

dotnet ef migrations add $Name `
    --project $Project `
    --startup-project $StartupProject `
    --context ApplicationDbContext `
    --output-dir Migrations

if ($LASTEXITCODE -ne 0) {
    throw "Failed to create migration: $Name"
}
