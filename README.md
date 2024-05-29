# Proyecto de Integración Netflix IMDb

Este proyecto tiene como objetivo analizar la popularidad y el éxito financiero de los contenidos en Netflix mediante la integración y análisis de datos de Netflix e IMDb. Proporciona una API para acceder a los datos combinados, asegurados con autenticación JWT, y utiliza Redis para mejorar el rendimiento mediante la implementación de caché.

## Tabla de Contenidos
1. [Documentación del Proyecto](#documentacion-del-proyecto)
2. [Requisitos Previos](#requisitos-previos)
3. [Configuración](#configuración)
4. [Uso](#uso)
5. [Endpoints de la API](#endpoints-de-la-api)
6. [Verificación de la Caché Redis](#verificación-de-la-caché-redis)
7. [Verificación de MongoDB](#verificación-de-mongodb)
8. [Verificación de la Base de Datos SQL](#verificación-de-la-base-de-datos-sql)
## Documentación del Proyecto

Para obtener una descripción detallada del proyecto, incluyendo su arquitectura, implementación y análisis de resultados, consulta la documentación completa en el siguiente enlace:

[Documentación del Proyecto](https://github.com/diegofdiazh/TopicosAvanzadosBasesDeDatos/blob/main/DOCUMENTACION%20DEL%20PROYECTO.pdf)
## Requisitos Previos
- Cuenta de MongoDB Atlas
- Servidor Redis (local o alojado, por ejemplo, Redis Cloud)
- Servidor SQL (local o alojado, por ejemplo, Azure SQL Database)
- Cliente de administración de bases de datos SQL (SQL Server Management Studio)
- Cliente de MongoDB (MongoDB Compass)
- Cliente de Redis (RedisInsight o redis-cli)

## Configuración

La aplicación está desplegada en Azure en el siguiente URL:

[https://netfliximdb.azurewebsites.net/swagger/index.html](https://netfliximdb.azurewebsites.net/swagger/index.html)

Para autenticarse y obtener un JWT, usa las siguientes credenciales:
```json
{
  "username": "admin",
  "password": "Colombia123*"
}
```
## Uso

Navega a la URL de Swagger para ver la documentación interactiva de la API:
[https://netfliximdb.azurewebsites.net/swagger/index.html](https://netfliximdb.azurewebsites.net/swagger/index.html)

Autentícate usando el endpoint `/api/auth/login` para obtener el token JWT.

- **Endpoint:** `POST /api/auth/login`
- **Cuerpo de la Solicitud:**
  ```json
  {
    "username": "admin",
    "password": "Colombia123*"
  }
## Endpoints de la API

### Autenticación
- **Login**
  - **Endpoint:** `POST /api/auth/login`
  - **Descripción:** Autentica a un usuario y devuelve un token JWT.
  - **Cuerpo de la Solicitud:**
    ```json
    {
      "username": "admin",
      "password": "Colombia123*"
    }
    ```

### Títulos
- **Obtener Todos los Títulos**
  - **Endpoint:** `GET /api/titles`
  - **Descripción:** Recupera todos los títulos.
  - **Cabeceras:**
    ```http
    Authorization: Bearer <tu-token>
    ```

- **Obtener Todos los Títulos por Ingresos**
  - **Endpoint:** `GET /api/titles/all-by-revenue`
  - **Descripción:** Recupera todos los títulos ordenados por ingresos.
  - **Cabeceras:**
    ```http
    Authorization: Bearer <tu-token>
    ```

- **Buscar Títulos**
  - **Endpoint:** `GET /api/titles/search`
  - **Descripción:** Busca títulos por géneros y puntuación.
  - **Cabeceras:**
    ```http
    Authorization: Bearer <tu-token>
    ```
  - **Parámetros de Consulta:**
    - `genres`: Lista de géneros (separados por comas)
    - `score`: Puntuación mínima

- **Obtener Títulos por Género e Ingresos**
  - **Endpoint:** `GET /api/titles/top-revenue-genres`
  - **Descripción:** Recupera títulos por géneros y ordenados por ingresos.
  - **Cabeceras:**
    ```http
    Authorization: Bearer <tu-token>
    ```
  - **Parámetros de Consulta:**
    - `genres`: Lista de géneros (separados por comas)
## Verificación de la Caché Redis

### Conectar a Redis

Para conectarte a tu instancia Redis y comprobar los datos en caché, usa las siguientes credenciales:

- **Host:** `redisjaveriana.redis.cache.windows.net`
- **Puerto:** `6380`
- **Contraseña:** `GSvg34lNl3umUBoczE3HF1hTUkWQPKT8yAzCaNPXg7g=`

### Usando RedisInsight

1. Descarga e instala [RedisInsight](https://redislabs.com/redisinsight/).
2. Abre RedisInsight y agrega una nueva conexión con los detalles mencionados arriba.

### Usando redis-cli

1. Abre tu terminal y conecta usando redis-cli:
   ```bash
   redis-cli -h redisjaveriana.redis.cache.windows.net -p 6380 -a GSvg34lNl3umUBoczE3HF1hTUkWQPKT8yAzCaNPXg7g= --tls
2. Listar claves de la caché::
   ```bash
   KEYS *
3. Recuperar datos en caché::
   ```bash
   GET "tu-clave-de-caché"
## Verificación de MongoDB

### Conectar a MongoDB Atlas

Usa un cliente de MongoDB como [MongoDB Compass](https://www.mongodb.com/products/compass) y conéctate con la siguiente cadena de conexión:

- **Connection String:** `mongodb+srv://diegofdiazh:Revolucion123*@cluster0.76r8g7c.mongodb.net/`
- **Database Name:** `NetflixI_imdb`

#### Usando MongoDB Compass

1. Descarga e instala [MongoDB Compass](https://www.mongodb.com/products/compass).
2. Abre MongoDB Compass e ingresa la cadena de conexión proporcionada.
3. Conéctate a la base de datos `NetflixI_imdb`.

### Comprobar Colecciones

1. Una vez conectado, navega a la base de datos `NetflixI_imdb`.
2. Deberías ver las colecciones disponibles en esta base de datos.

### Consultar Datos

#### Usando MongoDB Compass

1. Selecciona la colección que deseas consultar.
2. Utiliza la interfaz de MongoDB Compass para ejecutar consultas. Por ejemplo, para ver todos los documentos en una colección:
   ```json
   db.merged_data.find().pretty()
3. Una vez conectado, selecciona la base de datos:
   ```json
   use NetflixI_imdb
4. Consulta los datos en una colección específica:
   ```json
   db.merged_data.find().pretty()
## Verificación de la Base de Datos SQL

### Conectar a SQL Server

Usa SQL Server Management Studio (SSMS) o cualquier cliente SQL para conectarte a tu instancia de SQL Server con las siguientes credenciales:

- **Server:** `tcp:serverjavaeriana.database.windows.net,1433`
- **Database:** `pocjaveriana`
- **User:** `su`
- **Password:** `Colombia123*`

#### Usando SQL Server Management Studio (SSMS)

1. Abre SQL Server Management Studio.
2. Ingresa las credenciales mencionadas arriba para conectarte al servidor.

### Comprobar Tablas

1. Una vez conectado, abre una nueva consulta.
2. Ejecuta el siguiente comando para listar todas las tablas en la base de datos:
   ```sql
   SELECT * FROM INFORMATION_SCHEMA.TABLES;
### Consultar datos
2. Para consultar los datos en una tabla específica, ejecuta el siguiente comando:
   ```sql
   SELECT * FROM Users;
## Licencia

[MIT](https://choosealicense.com/licenses/mit/)
