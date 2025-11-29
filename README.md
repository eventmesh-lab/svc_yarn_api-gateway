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

## Containerization

```bash
# Build the production image (feel free to choose the tag that matches your naming convention)
docker build -t api .

# Run the container, publishing port 8080 and overriding downstream targets as needed
docker run --rm --name api -p 8080:8080 \
	-e ReverseProxy__Clusters__cluster1__Destinations__destination1__Address=http://backend-api:7181/api \
	-e Keycloak__Authority=http://keycloak:8180/realms/myrealm \
	-e Keycloak__ClientSecret=<client-secret> \
	api
```

Key points:

- The container listens on port 8080 by default (`ASPNETCORE_URLS=http://+:8080`).
- HTTPS redirection is disabled in the image (`EnableHttpsRedirection=false`); set it to `true` only if the container serves HTTPS traffic directly.
- Any setting from `appsettings.json` can be overridden via environment variables (e.g., `ReverseProxy__...`, `Keycloak__...`).

## Next Steps

1. Populate `src/` with shared libraries or additional services as needed.
2. Add automated tests under `tests/`.
3. Update configuration to match your downstream services and identity provider.
