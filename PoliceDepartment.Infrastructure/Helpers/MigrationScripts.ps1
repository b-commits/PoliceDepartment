# Add migration:
dotnet ef --startup-project ../PoliceDepartment.Api migrations add InitialMigration

# Execute migration:
dotnet ef --startup-project ../PoliceDepartment.Api database update

# Scripts:
dotnet ef script -o migrationScript.sql
