# Bakery

## Commands

### Create Projects

```shell
# Create a solution
dotnet new sln --name Bakery

# Create a web API project
dotnet new webapi --help
dotnet new webapi --name Bakery.Api --output src/Bakery.Api

# Add the web API project to the solution
dotnet sln add --help
dotnet sln src/Bakery.slnx add src/Bakery.Api/Bakery.Api.csproj

# Create a database project
dotnet new classlib --name Bakery.Database --output src/Bakery.Database
# Add the database project to the solution
dotnet sln src/Bakery.slnx add src/Bakery.Database/Bakery.Database.csproj
# Add a reference from the web API project to the database project
dotnet add src/Bakery.Api/Bakery.Api.csproj reference src/Bakery.Database/Bakery.Database.csproj
```

### Add Packages

```shell
dotnet add package --help

# Add Entity Framework Core packages to the web API project
dotnet add src/Bakery.Api/Bakery.Api.csproj package Microsoft.EntityFrameworkCore.Design

# Add Entity Framework Core packages to the database project
dotnet add src/Bakery.Database/Bakery.Database.csproj package Microsoft.EntityFrameworkCore.SqlServer
dotnet add src/Bakery.Database/Bakery.Database.csproj package Microsoft.EntityFrameworkCore.Tools
```

### Local Development

#### Create a Docker container for SQL Server

> Note:
> The SQL Server container will be running in the background.
> You can stop the container by running `docker stop sqlserver`.

```shell
docker run \
  -e "ACCEPT_EULA=Y" \
  -e "MSSQL_SA_PASSWORD=YourStrong@Passw0rd" \
  -p 1433:1433 \
  --name sqlserver \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

#### Update the connection string in appsettings

```
# appsettings.Development.json
{
  ...
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=BakeryDb;User Id=sa;Password=YourStrong@Passw0rd;"
  }
}
```

### Entity Framework Core Migrations

```shell
dotnet ef migrations add --help

# Create the initial migration
dotnet ef migrations add InitialCreate \
  --project src/Bakery.Data \
  --startup-project src/Bakery.Api \
  --verbose

# Apply the migration to the database
dotnet ef database update \
  --project src/Bakery.Data \
  --startup-project src/Bakery.Api \
  --verbose
```
