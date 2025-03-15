# package-manager

C# console app to manage package delivery

## Database

![](docs/databaseER.png)

### Create database
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```