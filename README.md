# svc_yarn_api-gateway

Este microservicio es el API Gateway para el proyecto EventMesh, implementado con arquitectura Hexagonal (Ports & Adapters) en .NET 8.0. Actúa como un proxy y punto de entrada para los eventos y servicios relacionados.

## Arquitectura

El proyecto sigue la arquitectura Hexagonal, dividida en capas:

- **Domain**: Contiene las entidades de negocio y puertos (interfaces) para la lógica de dominio.
- **Application**: Implementa los casos de uso y la lógica de aplicación.
- **Infrastructure**: Proporciona implementaciones concretas de los puertos, como repositorios en memoria.
- **Api**: Contiene los controladores REST, configuración de Swagger/OpenAPI y el punto de entrada de la aplicación.

## Estructura del Proyecto

``` bash
src/
├── svc_yarn_api-gateway.Api/          # Capa de API (controladores, configuración)
├── svc_yarn_api-gateway.Application/  # Capa de aplicación (casos de uso)
├── svc_yarn_api-gateway.Domain/       # Capa de dominio (entidades, puertos)
└── svc_yarn_api-gateway.Infrastructure/ # Capa de infraestructura (repositorios)
tests/
├── svc_yarn_api-gateway.Application.Tests/
├── svc_yarn_api-gateway.Domain.Tests/
└── svc_yarn_api-gateway.Infrastructure.IntegrationTests/
```

## Requisitos

- .NET 8.0 SDK
- Docker (opcional, para ejecución en contenedores)

## Instalación y Ejecución

### Usando Docker Compose

Para ejecutar el servicio en un entorno de contenedores:

```bash
docker-compose up
```

### Ejecución Local

1. Restaura las dependencias:

   ```bash
   dotnet restore
   ```

2. Construye el proyecto:

   ```bash
   dotnet build
   ```

3. Ejecuta la aplicación:

   ```bash
   dotnet run --project src/svc_yar_api-gateway.Api
   ```

La API estará disponible en `http://localhost:5000` (o el puerto configurado en `appsettings.json`).

## API Endpoints

La documentación de la API se genera automáticamente con Swagger/OpenAPI. Una vez ejecutada la aplicación, visita `http://localhost:5000/swagger` para explorar los endpoints.

Principales controladores:

- `EventsProxyController`: Proxy para eventos.
- `MockEventosController`: Controlador de mock para eventos (probablemente para desarrollo/pruebas).

Para más detalles, consulta el archivo `openapi.yaml` en `src/svc_yar_api-gateway.Api/`.

## Pruebas

El proyecto incluye pruebas unitarias e de integración. Para ejecutar todas las pruebas:

```bash
dotnet test
```

Para más información sobre las pruebas, consulta el archivo `TESTING.md`.

## Configuración

- `appsettings.json`: Configuración general.
- `appsettings.Development.json`: Configuración específica para desarrollo.

Asegúrate de configurar las variables necesarias, como conexiones a bases de datos o servicios externos, según el entorno.

## Contribución

Para contribuir:

1. Crea una rama para tu feature/bugfix.
2. Implementa los cambios siguiendo la arquitectura Hexagonal.
3. Añade pruebas para nuevos casos de uso.
4. Ejecuta las pruebas y asegura que pasen.
5. Crea un pull request.

## Licencia

Este proyecto está bajo la licencia especificada en el repositorio raíz de EventMesh.
