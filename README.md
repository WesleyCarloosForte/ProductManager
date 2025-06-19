# 🛠️ ProductManager

Aplicación backend desarrollada en .NET 8 con arquitectura limpia, orientada a la gestión de productos y categorías. Este proyecto forma parte de mi portfolio personal, donde aplico buenas prácticas, patrones modernos y principios de diseño escalable.

---

## 🚀 Tecnologías implementadas

- [x] **.NET 8** + **C# 12**
- [x] **Entity Framework Core**
- [x] **PostgreSQL**
- [x] **Arquitectura limpia**
- [x] **DDD (Domain-Driven Design)**
- [x] **CQRS + MediatR**
- [x] **FluentResults**
- [x] **Swagger**
- [ ] **Autenticación JWT**
- [ ] **Frontend Angular**
- [ ] **Comunicación en tiempo real con SignalR**
- [ ] **Docker para desarrollo y despliegue**


---

## 🧱 Estructura del proyecto

El proyecto sigue una arquitectura en capas basada en separación de responsabilidades:

- **ProductManager.API**  
  Capa de presentación. Expone los endpoints HTTP y configura la aplicación.

- **ProductManager.Application**  
  Contiene la lógica de negocio, casos de uso, comandos y consultas (CQRS), validaciones y contratos.

- **ProductManager.Domain**  
  Define el modelo del dominio: entidades, Value Objects y reglas de negocio puras.

- **ProductManager.Infrastructure**  
  Implementa la persistencia de datos con EF Core, mapeos y acceso a PostgreSQL.

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

3. Migraciones:

   Para conocer cómo se gestionan las migraciones en este proyecto (desde línea de comandos o Visual Studio), consultá el documento completo:

  📄 [Guía de migraciones](docs/migraciones.md)

4. Aplicar migraciones para crear la base de datos:

    ```bash
    dotnet ef database update --project ProductManager.Infrastructure
    ```

5. Ejecutar la API:

    ```bash
    dotnet run --project ProductManager.API
    ```
    
6. Accedé a Swagger en:

    ```bash
     https://localhost:5001/swagger
    ```
    
## 🚧 Estado del proyecto

Este proyecto está en desarrollo activo. Próximas funcionalidades planificadas:

- [x] Backend con arquitectura limpia y CQRS
- [x] CRUD de Productos y Categorías
- [x] Base de datos con EF Core + PostgreSQL
- [x] Documentación Swagger
- [ ] Autenticación con JWT
- [ ] Frontend en Angular (en desarrollo)
- [ ] Comunicación en tiempo real con SignalR
- [ ] Pruebas unitarias con xUnit
- [ ] CI/CD (despliegue automático)

---


## 🔌 Endpoints de la API

### 📦 Productos

| Método | Ruta                   | Descripción                     |
|--------|------------------------|---------------------------------|
| GET    | /Product/all           | Lista todos los productos       |
| GET    | /Product/byId/{id}     | Obtiene un producto por ID      |
| POST   | /Product               | Crea un nuevo producto          |
| PUT    | /Product               | Actualiza un producto existente |
| DELETE | /Product/delete/{id}   | Elimina un producto por ID      |

### 📂 Categorías

| Método | Ruta                     | Descripción                      |
|--------|--------------------------|----------------------------------|
| GET    | /Category/getAll         | Lista todas las categorías       |
| GET    | /Category/getById/{id}   | Obtiene una categoría por ID     |
| POST   | /Category                | Crea una nueva categoría         |
| PUT    | /Category                | Actualiza una categoría existente|
| DELETE | /Category/delete/{id}    | Elimina una categoría por ID     |


## 📄 Licencia

Este proyecto está bajo la licencia [MIT](LICENSE).  
Podés usarlo, modificarlo y compartirlo libremente, siempre que se mantenga el aviso de copyright.

---
