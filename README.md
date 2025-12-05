# Bakery

## Commands

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