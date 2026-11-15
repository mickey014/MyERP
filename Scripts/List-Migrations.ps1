$Project = ".\MyERP.Infrastructure\MyERP.Infrastructure.csproj"
$StartupProject = ".\MyERP.Web\MyERP.Web.csproj"

dotnet ef migrations list `
    --project $Project `
    --startup-project $StartupProject `
    --context ApplicationDbContext