# Blog Project for Learning .Net Core WebAPI

### Install .Net Tools EF(Entity Framework) Core

```sh
dotnet tool update --global dotnet-ef
```
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