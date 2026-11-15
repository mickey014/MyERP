# MyERP Database Scripts and User Secrets

This document explains how to use the PowerShell scripts in the `Scripts` directory to manage Entity Framework Core migrations and database updates. It also covers configuring .NET User Secrets to store sensitive connection strings outside the source code.

## 1. Project Structure

The MyERP solution uses a layered architecture:

```text
MyERP/
├── MyERP.Domain/
├── MyERP.Application/
├── MyERP.Infrastructure/
│   ├── Migrations/
│   └── Persistence/
│       └── ApplicationDbContext.cs
├── MyERP.Web/
│   └── MyERP.Web.csproj
└── Scripts/
    ├── Add-Migration.ps1
    ├── Update-Database.ps1
    ├── Remove-Migration.ps1
    ├── List-Migrations.ps1
    └── README.md
```

### Project responsibilities

| Project                | Responsibility                                                 |
| ---------------------- | -------------------------------------------------------------- |
| `MyERP.Domain`         | Domain entities and business rules                             |
| `MyERP.Application`    | Application services, use cases, and DTOs                      |
| `MyERP.Infrastructure` | EF Core, database context, configurations, and migrations      |
| `MyERP.Web`            | ASP.NET Core MVC startup project and application configuration |
| `Scripts`              | PowerShell shortcuts for database management                   |

**Important:** Migrations are stored in `MyERP.Infrastructure`, while `MyERP.Web` is used as the startup project because it provides the application's configuration and dependency registrations.

## 2. Prerequisites

Before using the scripts, ensure that:

- .NET 10 SDK is installed.
- Entity Framework Core tools are installed.
- The solution restores and builds successfully.
- SQL Server is installed and running.
- The `ApplicationDbContext` is registered in the Web project.
- The Web project has the `Microsoft.EntityFrameworkCore.Design` package.
- Infrastructure has the required EF Core provider and tooling packages.

Install or update the EF Core command-line tool:

```powershell
dotnet tool install --global dotnet-ef --version 10.0.12
```

If it is already installed:

```powershell
dotnet tool update --global dotnet-ef --version 10.0.12
```

Check the installed version:

```powershell
dotnet ef --version
```

## 3. PowerShell Execution Policy

If PowerShell prevents scripts from running, check the current execution policies:

```powershell
Get-ExecutionPolicy -List
```

For a development environment, you can enable locally created scripts for your current Windows user:

```powershell
Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned
```

Alternatively, allow scripts only in the current PowerShell session:

```powershell
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
```

The process-level setting is temporary and resets when the PowerShell session closes.

If a company-managed Group Policy prevents changing the execution policy, contact your IT administrator rather than attempting to bypass organizational restrictions.

## 4. Database PowerShell Scripts

Run the following commands from the solution root directory:

```powershell
D:\projects\dotnet\asp\MyERP
```

### 4.1 Add-Migration.ps1

Creates a new EF Core migration based on changes to the entity model and database configurations.

Usage:

```powershell
.\Scripts\Add-Migration.ps1 -MigrationName InitialCreate
```

Example:

```powershell
.\Scripts\Add-Migration.ps1 -MigrationName AddCustomerEntities
```

Use a descriptive migration name that explains the database change.

Before adding a migration, make sure the entity classes and EF Core configurations are correct.

### 4.2 Update-Database.ps1

Applies pending migrations to the configured SQL Server database.

Usage:

```powershell
.\Scripts\Update-Database.ps1
```

Run this after reviewing a newly generated migration.

**Important:** Review migration files before applying them, especially if they contain operations such as `DropTable`, `DropColumn`, or destructive data changes.

### 4.3 Remove-Migration.ps1

Removes the latest migration when it has not yet been applied to the database.

Usage:

```powershell
.\Scripts\Remove-Migration.ps1
```

Do not use this to remove migrations that have already been applied to a shared or production database. Use a corrective migration instead.

### 4.4 List-Migrations.ps1

Displays the migrations associated with the configured database context.

Usage:

```powershell
.\Scripts\List-Migrations.ps1
```

Use this to review migration history when troubleshooting database updates.

## 5. .NET User Secrets

.NET User Secrets provides a development-time location for storing sensitive configuration values outside the project source code.

For MyERP, the connection string is stored using:

```text
ConnectionStrings:DefaultConnection
```

User Secrets are intended for development only. They are not encrypted and should not be treated as a production secrets-management solution.

### 5.1 Initialize User Secrets

Run this command from the solution root:

```powershell
dotnet user-secrets init --project .\MyERP.Web\MyERP.Web.csproj
```

This adds a `UserSecretsId` to the Web project's `.csproj` file.

### 5.2 Configure the SQL Server connection string

For a local SQL Server Express instance, use:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost\SQLEXPRESS;Database=MyERP;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true" --project .\MyERP.Web\MyERP.Web.csproj
```

Adjust the server name, authentication method, and database name to match your environment.

Do not commit actual credentials or connection strings containing passwords.

### 5.3 List configured secrets

```powershell
dotnet user-secrets list --project .\MyERP.Web\MyERP.Web.csproj
```

### 5.4 Remove a specific secret

```powershell
dotnet user-secrets remove "ConnectionStrings:DefaultConnection" --project .\MyERP.Web\MyERP.Web.csproj
```

### 5.5 Clear all secrets

```powershell
dotnet user-secrets clear --project .\MyERP.Web\MyERP.Web.csproj
```

Use this command carefully because it removes all User Secrets associated with the project.

## 6. Application Configuration

The ASP.NET Core Web project should load User Secrets in the Development environment.

With the standard ASP.NET Core configuration setup, the default configuration builder loads User Secrets when the environment is `Development` and the entry assembly has a configured `UserSecretsId`.

A typical connection string registration in `Program.cs` looks like this:

```csharp
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
```

Do not hardcode database credentials in `appsettings.json`, source files, or committed environment-specific configuration files.

For production, use an appropriate secure configuration provider or secrets manager.

## 7. Recommended Database Migration Workflow

Follow this sequence when adding or changing database entities.

### Step 1: Update the domain and persistence model

Create or modify the necessary entity classes and relationships.

### Step 2: Configure entity mappings

Create `IEntityTypeConfiguration<TEntity>` implementations in the Infrastructure project when explicit Fluent API configuration is needed.

Ensure the configurations are included in the Infrastructure assembly and discovered by `ApplicationDbContext`.

### Step 3: Build the solution

```powershell
dotnet build
```

Resolve compilation errors before creating a migration.

### Step 4: Add a migration

```powershell
.\Scripts\Add-Migration.ps1 -MigrationName DescriptiveMigrationName
```

### Step 5: Review the generated migration

Inspect the generated migration's `Up()` and `Down()` methods and the updated model snapshot.

Verify that the changes reflect your intended entity and relationship updates.

### Step 6: Update the database

```powershell
.\Scripts\Update-Database.ps1
```

### Step 7: Verify the migration

```powershell
.\Scripts\List-Migrations.ps1
```

Confirm that the expected migration was applied.

## 8. Troubleshooting

### PowerShell scripts cannot run

Check the execution policy:

```powershell
Get-ExecutionPolicy -List
```

If permitted by your environment, use the `RemoteSigned` CurrentUser policy or the temporary Process policy described earlier.

### EF Core tools cannot be found

Check the tool installation:

```powershell
dotnet ef --version
```

Install or update `dotnet-ef` if necessary.

### Connection string is missing

Check that User Secrets have been initialized and the connection string is configured:

```powershell
dotnet user-secrets list --project .\MyERP.Web\MyERP.Web.csproj
```

Also verify that the application is running in the Development environment when relying on User Secrets.

### Pending model changes warning

If EF Core reports:

```text
The model for context 'ApplicationDbContext' has pending changes.
Add a new migration before updating the database.
```

The current EF Core model differs from the latest migration snapshot.

Create a migration:

```powershell
.\Scripts\Add-Migration.ps1 -MigrationName SyncModelChanges
```

Review the generated migration before updating the database.

If the generated migration is empty or the warning continues, investigate possible model differences, configuration discovery, design-time configuration, and non-deterministic model values such as `DateTime.Now` or `Guid.NewGuid()` in `HasData()`.

Do not suppress `PendingModelChangesWarning` merely to force a database update.

### Database update fails

Check:

1. SQL Server is running.
2. The configured server and database names are correct.
3. The configured authentication method is valid.
4. The Web project's User Secrets contain the expected connection string.
5. The Infrastructure and Web projects build successfully.
6. The generated migration has been reviewed and is compatible with the existing database.

### NuGet vulnerability warnings

Warnings such as `NU1902` and `NU1903` indicate that NuGet has identified known vulnerabilities in one or more packages.

Review the affected packages and their dependency chains. Update to compatible patched versions and test the solution.

Do not suppress vulnerability warnings simply to obtain a successful build.

## 9. Security Guidelines

- Never commit passwords, API keys, or production connection strings.
- Use .NET User Secrets for local development credentials.
- Use a secure secrets provider for production.
- Keep `appsettings.json` free of sensitive values.
- Do not share User Secrets output containing credentials.
- Review migrations before applying database changes.
- Avoid destructive database operations unless they are intentional and backed up.
- Keep EF Core package versions and the `dotnet-ef` tool compatible with the project's target framework.

## 10. Quick Reference

| Task                    | Command                                                                                                                         |
| ----------------------- | ------------------------------------------------------------------------------------------------------------------------------- |
| Initialize User Secrets | `dotnet user-secrets init --project .\MyERP.Web\MyERP.Web.csproj`                                                               |
| Set connection string   | `dotnet user-secrets set "ConnectionStrings:DefaultConnection" "YOUR_CONNECTION_STRING" --project .\MyERP.Web\MyERP.Web.csproj` |
| List secrets            | `dotnet user-secrets list --project .\MyERP.Web\MyERP.Web.csproj`                                                               |
| Add migration           | `.\Scripts\Add-Migration.ps1 -MigrationName MigrationName`                                                                      |
| Update database         | `.\Scripts\Update-Database.ps1`                                                                                                 |
| Remove latest migration | `.\Scripts\Remove-Migration.ps1`                                                                                                |
| List migrations         | `.\Scripts\List-Migrations.ps1`                                                                                                 |
| Build solution          | `dotnet build`                                                                                                                  |

---

**MyERP Database Management**

Keep database schema changes in the Infrastructure project, use the Web project for application startup and configuration, and store local development credentials outside source control.
