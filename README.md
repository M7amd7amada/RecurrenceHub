# RecurrenceHub API

RecurrenceHub API is an ASP.NET Core Web API built using .NET 8. This API manages recurring schedules, allowing users to create, update, delete, and retrieve recurring events based on flexible intervals.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Running the API](#running-the-api)
- [Environment Variables](#environment-variables)
- [Database Migration](#database-migration)
- [API Documentation](#api-documentation)
- [Testing](#testing)
- [Endpoints](#endpoints)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- Flexible recurrence intervals (daily, weekly, monthly, yearly).
- Customizable time zones.
- Advanced schedule management: pause, skip, and resume schedules.
- Notification options for upcoming events.
- User authentication and authorization.

---

## Prerequisites

- **.NET SDK 8.0**: [Download .NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server** or **SQLite**: Ensure a compatible database for development.

---

## Getting Started

1. **Clone the repository:**

   ```bash
   git clone https://github.com/yourusername/chronoflow-api.git
   cd chronoflow-api
   ```

2. **Install dependencies:**

   Restore NuGet packages by navigating to the project folder and running:

   ```bash
   dotnet restore
   ```

---

## Running the API

1. **Set up the environment variables** (see [Environment Variables](#environment-variables)).

2. **Apply database migrations**:

   ```bash
   dotnet ef database update
   ```

3. **Start the API**:

   Run the application with:

   ```bash
   dotnet run
   ```

   The API will be accessible at `http://localhost:5000` by default.

---

## Environment Variables

To configure the API, create a `.env` file in the root directory with the following variables:

```plaintext
ASPNETCORE_ENVIRONMENT=Development
DATABASE_CONNECTION_STRING=YourDatabaseConnectionString
JWT_SECRET_KEY=YourJwtSecretKey
```

| Variable                   | Description                       |
|----------------------------|-----------------------------------|
| `ASPNETCORE_ENVIRONMENT`   | Environment (Development/Production). |
| `DATABASE_CONNECTION_STRING` | Connection string for the database. |
| `JWT_SECRET_KEY`           | Secret key for JWT authentication. |

---

## Database Migration

Run migrations to set up the initial database structure:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This will apply all migrations to your database based on the latest schema.

---

## API Documentation

The API provides a Swagger UI for easy testing and exploration of endpoints. Once the API is running, you can access Swagger at:

- **URL**: `http://localhost:5000/swagger`

Swagger provides documentation for each endpoint, along with sample requests and responses.

---

## Testing

The project includes unit and integration tests to ensure reliable functionality.

1. **Run Tests**:

   ```bash
   dotnet test
   ```

2. **Test Coverage** (optional): If you want to see code coverage, you can use a tool like `Coverlet`.

---

## Endpoints

Below is a brief overview of the main endpoints. For detailed information, refer to the Swagger documentation.

### Authentication

- **POST** `/api/auth/login`: User login, returns a JWT token.

### Schedules

- **POST** `/api/schedules`: Create a new recurring schedule.
- **GET** `/api/schedules`: Retrieve all schedules.
- **GET** `/api/schedules/{id}`: Retrieve a specific schedule by ID.
- **PUT** `/api/schedules/{id}`: Update an existing schedule.
- **DELETE** `/api/schedules/{id}`: Delete a schedule.

### Advanced Schedule Management

- **POST** `/api/schedules/{id}/pause`: Pause a schedule.
- **POST** `/api/schedules/{id}/resume`: Resume a paused schedule.
- **POST** `/api/schedules/{id}/skip`: Skip the next occurrence.

### Notifications

- **POST** `/api/schedules/{id}/notifications`: Configure notifications for a schedule.

---

## Contributing

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a new feature branch (`git checkout -b feature-branch-name`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch-name`).
5. Open a pull request.

---

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

---

## Additional Notes

- **Logging**: The API uses `Serilog` for structured logging. Configuration can be modified in `appsettings.json`.
- **Error Handling**: A global error handler returns consistent error responses.
- **Rate Limiting**: The API includes optional rate-limiting middleware to control request rates.