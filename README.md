# Blog Project for Learning .Net Core WebAPI

### Install .Net Tools EF(Entity Framework) Core

```sh
dotnet tool update --global dotnet-ef
```

### [Setup ConnectionString Storage](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0)

```sh
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.UserSecrets
dotnet user-secrets init
dotnet user-secrets set ConnectionStrings:BlogCon "Host=localhost;Database=my_blog;Username=postgres;Password=postgres"
```

Replace the values in the connection string as per your local environment setup


### Generate Migration Scafolds

```sh
dotnet ef migrations add InitialSchema
```
### Create database tables and seed data

```sh
dotnet ef database update
```

### Run the application

```sh
dotnet watch run
```