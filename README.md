# Finance App

## Features
 - Transactions System
 - Budgets
 - Goals
 - Subscriptions

## Requirements
 - .NET 9 SDK 9
 - Docker (Optional but recommended)
 - EF Tools (Optional)

## Installation
1. Install dependencies
```
dotnet restore
```
2. Run (Local)
```
dotnet build
dotnet run
```
3. Run with Docker (Optional)
```
docker compose up
```
## Configuration
Edit connection strings in `appsettings.json` or `appsettings.Development.json`

## Migrations
### Create Migration
```
dotnet tool install --global dotnet-ef  # If not installed
dotnet ef migrations add "Name"
```
### Apply Migrations
```
dotnet ef database update
```
> Running the docker compose file will port forward the database to `localhost:1433`. You can run `docker compose up` then run the above command to update the database.
