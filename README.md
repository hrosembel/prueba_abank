# Guía para Ejecutar y Probar el proyecto
Esta guía proporciona los pasos necesarios para configurar y probar una API REST en .NET 8 con una base de datos MySQL utilizando Dapper. 

## Paso 1: Configuración de la Base de Datos
1. **Ejecutar scripts para la creación de la base de datos:**
   - Asegurarse de tener instalado un cliente MySQL para crear la base de datos.
   - El script que se debe ejecutar, se encuentra en la carpeta `Base de datos` y tiene el nombre `Crear base de datos.sql`

## Paso 2: Configuración del proyecto
1. **Abrir la solucion:**
   - Ingresar a la carpeta Backend y luego a la carpeta PruebaABANK.
   - Abrir la solución del proyecto.
2. **Configura la cadena de conexión:**
   - Abrir el archivo `appsettings.json` en el proyecto PruebaABANK.API y modificar la cadena de conexión de la sección `ConnectionStrings` con el nombre `MySQLConnection`.
   - Sustituir los valores de server, user y password para que coincidan con los valores de la conexión donde se ejecutó el script.

## Paso 3: Prueba la API

1. **Ejecuta la aplicación:**
   - Iniciar la aplicación usando el comando `dotnet run` o a través de un entorno de desarrollo.

2. **Prueba los endpoints:**
   - Utilizar herramientas como [Postman](https://www.postman.com/) para probar los endpoints.
   - La API también puede probarse desde swagger que debería mostrarse al ejecutar el proyecto.
   - Cuando se ejecutó el script para la creación de la base de datos, este script insertó un usuario administrador, este será el único usuario que debe devolver el endpoint GetUsers en un inicio.
   - El usuario indicado puede utilizarse para el proceso de login, obteniendo el token que se utilizará para los endpoints que requieren autorización.



