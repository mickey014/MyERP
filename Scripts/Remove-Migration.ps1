$Project = ".\MyERP.Infrastructure\MyERP.Infrastructure.csproj"
$StartupProject = ".\MyERP.Web\MyERP.Web.csproj"

dotnet ef migrations remove `
    --project $Project `
    --startup-project $StartupProject `
    --context ApplicationDbContext