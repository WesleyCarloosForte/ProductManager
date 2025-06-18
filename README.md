# ProductManager

**Proyecto de práctica para gestionar productos y categorías**

Este proyecto tiene como objetivo practicar conceptos de desarrollo con C#, .NET 8 y Entity Framework Core, usando PostgreSQL como base de datos. Aplica patrones como Domain-Driven Design (DDD) y Value Objects.

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

2. Restaurar paquetes:

```bash
dotnet restore

3. Configurar la cadena de conexión en appsettings.json del proyecto ProductManager.API:
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=ProductManagerDb;Username=tu_usuario;Password=tu_contraseña"
}

4. Aplicar migraciones para crear la base de datos:

```bash
dotnet ef database update --project ProductManager.Infrastructure

5. Ejecutar la API:

```bash
dotnet run --project ProductManager.API

---

