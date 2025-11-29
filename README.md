# API Gateway Service

This repository hosts a reverse proxy built with ASP.NET Core and YARP. The solution has been flattened so the project files live at the repository root.

## Project Layout

- `ApiGateway.csproj` – main ASP.NET Core project file.
- `Program.cs`, `WeatherForecast.cs`, `Controllers/`, `Properties/` – source code for the gateway.
- `appsettings*.json` – runtime configuration, including YARP reverse proxy routes.
- `ApiGateway.http` – REST client scratch file.
- `src/` – reserved for additional application code (currently empty).
- `tests/` – reserved for future automated tests (currently empty).

## Getting Started

```bash
# Restore dependencies
 dotnet restore

# Run the gateway (Development profile)
 dotnet run
```

The service exposes Swagger UI at `https://localhost:7247/swagger` (or `http://localhost:5249/swagger` when using the HTTP profile).

## Next Steps

1. Populate `src/` with shared libraries or additional services as needed.
2. Add automated tests under `tests/`.
3. Update configuration to match your downstream services and identity provider.
