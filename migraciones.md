## 🗃️ Base de datos y migraciones

Este proyecto utiliza **Entity Framework Core** con un `DbContext` ubicado en la capa **Infrastructure**. Debido a esto, las migraciones deben ejecutarse desde ese proyecto, pero usando `ProductManager.API` como proyecto de inicio para acceder a la configuración.

---

### ⚙️ Desde la línea de comandos (`.NET CLI`)

1. Eliminá la carpeta de migraciones (si fue creada automáticamente en otro proyecto):

   ```bash
   rm -r ProductManager.Infrastructure/Migrations
   ```

2. Creá la migración desde la raíz del proyecto:

   ```bash
   dotnet ef migrations add InitialCreate 
     --project ProductManager.Infrastructure 
     --startup-project ProductManager.API
   ```

3. Aplicá la migración a la base de datos:

   ```bash
   dotnet ef database update 
     --project ProductManager.Infrastructure 
     --startup-project ProductManager.API
   ```

> 📌 Esto garantiza que EF Core utilice el `DbContext` correcto definido en Infrastructure, y que se aplique correctamente la configuración de la API.

---

### 🧠 Desde Visual Studio

1. Establecé `ProductManager.API` como proyecto de inicio (clic derecho → "Establecer como proyecto de inicio").

2. Abrí la **Consola del Administrador de paquetes**:
   - `Herramientas` → `Administrador de paquetes NuGet` → `Consola del Administrador de paquetes`.

3. En el desplegable de **Proyecto predeterminado**, seleccioná `ProductManager.Infrastructure`.

4. Ejecutá:

   ```powershell
   Add-Migration InitialCreate -StartupProject ProductManager.API
   ```

5. Luego:

   ```powershell
   Update-Database -StartupProject ProductManager.API
   ```

> ⚠️ Recordá: EF solo guarda migraciones en carpetas existentes si son creadas desde el proyecto correcto. Por eso es importante limpiar cualquier carpeta `Migrations` inválida previamente creada.

---

📌 Este enfoque permite una arquitectura desacoplada, centralización de infraestructura, y compatibilidad con pruebas, otros entornos o interfaces futuras como Angular.

