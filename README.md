# package-manager

C# console app to manage package delivery with EF, Sqlite

## Database

![](docs/databaseER.png)

## Class Schema

![](docs/classes.png)

## Setup
```
dotnet tool install --global dotnet-ef
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```