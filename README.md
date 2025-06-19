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
