# 🛠️ ProductManager

Aplicación backend desarrollada en .NET 8 con arquitectura limpia, orientada a la gestión de productos y categorías. Este proyecto forma parte de mi portfolio personal, donde aplico buenas prácticas, patrones modernos y principios de diseño escalable.

---

## 🚀 Tecnologías utilizadas

- **.NET 8** + **C# 12**
- **Entity Framework Core**
- **PostgreSQL**
- **Arquitectura limpia**
- **DDD (Domain-Driven Design)**
- **CQRS + MediatR**
- **FluentResults**
- **Swagger**
- [ ] Próximamente: **Autenticación JWT**, **SignalR**, **Frontend Angular**

---

## 📁 Estructura del proyecto

ProductManager/ ├── ProductManager.API/ ├── ProductManager.Application/ │ ├── Products/ │ │ ├── Commands/ │ │ │ ├── CreateProduct/ │ │ │ ├── DeleteProduct/ │ │ │ └── UpdateProduct/ │ │ ├── Queries/ │ │ │ ├── GetAllProducts/ │ │ │ └── GetProductById/ │ ├── Categories/ │ │ ├── Commands/ │ │ ├── Queries/ │ ├── Interfaces/ ├── ProductManager.Domain/ │ ├── Entities/ │ ├── ValueObjects/ ├── ProductManager.Infrastructure/ │ ├── Persistence/ ├── ProductManager.Shared/

---

## Tecnologías utilizadas

- .NET 8  
- Entity Framework Core  
- PostgreSQL  
- C# 12 (compatible con .NET 8)  
- Arquitectura limpia con separación en capas (Domain, Infrastructure, Application, API)

---

## Estructura del proyecto

- **ProductManager.API**: API REST para gestionar productos y categorías.  
- **ProductManager.Application**: Lógica de negocio y casos de uso.  
- **ProductManager.Domain**: Entidades, Value Objects y reglas del dominio.  
- **ProductManager.Infrastructure**: Acceso a datos con EF Core y PostgreSQL.

---

## Cómo ejecutar

### Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [PostgreSQL](https://www.postgresql.org/download/)

### Pasos

1. Clonar el repositorio:

    ```bash
    git clone https://github.com/WesleyCarloosForte/ProductManager.git
    cd ProductManager
    ```

2. Restaurar paquetes:

    ```bash
    dotnet restore
    ```

3. Configurar la cadena de conexión en `appsettings.json` del proyecto `ProductManager.API`:

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Port=5432;Database=ProductManagerDb;Username=tu_usuario;Password=tu_contraseña"
    }
    ```

4. Aplicar migraciones para crear la base de datos:

    ```bash
    dotnet ef database update --project ProductManager.Infrastructure
    ```

5. Ejecutar la API:

    ```bash
    dotnet run --project ProductManager.API
    ```

---
