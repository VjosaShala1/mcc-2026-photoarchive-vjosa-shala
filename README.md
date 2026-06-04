# Photo Archive API

## Overview

Photo Archive API is an ASP.NET Core Web API application that allows users to upload photos, store metadata, and search photos by tags.

## Technologies

* ASP.NET Core 7
* Entity Framework Core
* SQL Server
* Swagger
* GitHub

## Features

* Upload photos
* Store photo metadata
* Search photos by tag
* REST API endpoints
* Swagger documentation

## Database

The application uses SQL Server with Entity Framework Core migrations.

Connection string is configured in:

appsettings.json

## Running Locally

1. Clone repository
2. Open solution in Visual Studio 2022
3. Run migrations

```bash
dotnet ef database update
```

4. Start application

```bash
dotnet run
```

5. Open Swagger

http://localhost:5070/swagger

## API Endpoints

GET /api/photos

POST /api/photos

GET /api/photos/search/{tag}

POST /api/photos/upload

## Cloud Component

This project uses cloud deployment/storage as required by the assignment.

## Author

Vjosa Shala
