# 🏪 Sistema de Ventas - Arquitectura Hexagonal

## 📋 Descripción General

Sistema de gestión de ventas desarrollado en **C# con .NET 8.0**, implementando los principios de **Arquitectura Hexagonal**. 

El proyecto consta de:
- 🔌 **API REST** con autenticación JWT
- 🖥️ **Aplicación de escritorio** Windows Forms como cliente
- 🗄️ **Base de datos SQLite** con Entity Framework Core
- 🔐 **Sistema de seguridad** con JWT Bearer Tokens

## 🚀 Tecnologías Utilizadas

### Backend (API)
- **.NET 8.0** - Framework principal
- **ASP.NET Core Web API** - API REST
- **Entity Framework Core 9.0** - ORM
- **SQLite** - Base de datos
- **JWT Bearer Authentication** - Autenticación y autorización
- **Swagger/OpenAPI** - Documentación de API

### Frontend (Windows Forms)
- **.NET 8.0 Windows Forms** - Interfaz de usuario
- **Newtonsoft.Json** - Serialización JSON
- **HttpClient** - Comunicación con API

## 📦 Módulos del Sistema

### 1. **Módulo de Productos** 📦
### 2. **Módulo de Ventas** 💰
### 3. **Módulo de Histórico de Ventas** 📊
## 4. 🔐 Sistema de Autenticación

## 🛠️ Instalación y Configuración

### ✅ Prerrequisitos

Antes de comenzar, asegúrate de tener instalado:

| Herramienta | Versión | Descargar |
|-------------|---------|-----------|
| .NET SDK | 8.0 o superior | [Descargar](https://dotnet.microsoft.com/download/dotnet/8.0) |
| Visual Studio | 2022 (recomendado) | [Descargar](https://visualstudio.microsoft.com/) |
| Git | Última versión | [Descargar](https://git-scm.com/) |

**Nota**: SQLite viene integrado, no requiere instalación adicional.

### 🚀 Guía de Instalación Paso a Paso

#### **Paso 1: Clonar o Descargar el Proyecto**
```bash
# Navegar a la carpeta del proyecto
cd c:\Users\LeonardoRojas-Junior\Proj\Solution1
```

#### **Paso 2: Restaurar Dependencias**
```bash
# Restaurar todos los paquetes NuGet de la solución
dotnet restore
```

#### **Paso 3: Compilar la Solución**
```bash
# Compilar todos los proyectos
dotnet build

> ✅ Si todo está correcto, verás: `Build succeeded. 0 Error(s)`

#### **Paso 4: Configurar la Base de Datos**

La base de datos SQLite se crea automáticamente al ejecutar la API por primera vez. Se generará en:
```
App.API/Data/appIndigo.db
```

**Datos iniciales incluidos:**
- ✅ 2 productos de ejemplo
- ✅ 2 usuarios (admin y user)

#### **Paso 5: Ejecutar la API**

```bash
# Navegar a la carpeta de la API
cd App.API

# Ejecutar la API
dotnet run
```

**Salida esperada:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7187
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

> 🌐 La API estará disponible en: `https://localhost:7187`
> 📚 Swagger UI disponible en: `https://localhost:7187/swagger`

#### **Paso 6: Configurar URL de la API en Windows Forms**

Si el puerto de la API es diferente, editar `App.Forms/Services/ApiClient.cs`:

```csharp
// Línea 12 aproximadamente
private const string BaseUrl = "https://localhost:7187/api/";
```

**Cambiar por el puerto correspondiente si es necesario.**

#### **Paso 7: Ejecutar Windows Forms**

**IMPORTANTE**: Mantener la API ejecutándose en una terminal separada.

```bash
# Abrir una NUEVA terminal/consola
cd App.Forms

# Ejecutar la aplicación Windows Forms
dotnet run
```

> 🖥️ Se abrirá la ventana de Login automáticamente.

### ⚙️ Configuración Avanzada

#### Cambiar Puerto de la API

Editar `App.API/Properties/launchSettings.json`:
```json
{
  "profiles": {
    "https": {
      "applicationUrl": "https://localhost:TU_PUERTO",
      // ...
    }
  }
}
```

#### Configuración de JWT

Editar `App.API/appsettings.json` para cambiar la clave secreta:
```json
{
  "JwtSettings": {
    "SecretKey": "TU_CLAVE_SECRETA_MINIMO_32_CARACTERES",
    "Issuer": "AppIndigoAPI",
    "Audience": "AppIndigoClient"
  }
}
```

## 🔑 Credenciales de Prueba

El sistema viene con usuarios preconfigurados para testing:

| 👤 Usuario | 🔐 Contraseña | 🎭 Rol | 🔓 Permisos |
|-----------|--------------|--------|-------------|
| **admin** | admin123 | Administrador | Acceso completo a todos los módulos |
| **user** | user123 | Usuario | Solo lectura de productos, crear ventas |

### Inicio de Sesión Rápido

**Opción 1: Usando la Aplicación Windows Forms**
1. Ejecutar `App.Forms`
2. En el formulario de login:
   - Usuario: `admin`
   - Contraseña: `admin123`
3. Click en **Iniciar Sesión**
