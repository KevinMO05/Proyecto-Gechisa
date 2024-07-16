USE TICKET_MANAGEMENT_GECHISA
GO

-- Function Empty or Null Validation
CREATE FUNCTION isNullOrEmpty (@value NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	RETURN (
		CASE
			WHEN @value IS NULL OR @value = '' THEN 1
			ELSE 0
		END
	)
END
GO

-- Stored Procedures TICKET_MANAGEMENT_GECHISA

-- Stored Procedures for Gerent
CREATE PROCEDURE spGerent_Login
    @DNI_Person CHAR(20),
    @plain_password VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@DNI_Person) = 1 OR
        dbo.isNullOrEmpty(@plain_password) = 1
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de DNI
    IF NOT @DNI_Person LIKE REPLICATE('[0-9]', 8)
    BEGIN
        SELECT -1 AS StatusCode, 'El DNI debe contener solo 8 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        DECLARE @ID_Gerent CHAR(11) = 'GER' + @DNI_Person;
        DECLARE @ID_Employee CHAR(11) = 'EMP' + @DNI_Person;
        DECLARE @password VARBINARY(64) = HASHBYTES('SHA2_256', @plain_password);

        -- Verificación de existencia del gerente
        IF NOT EXISTS (SELECT 1 FROM GERENT WHERE ID_Gerent = @ID_Gerent)
        BEGIN
            SELECT -10 AS StatusCode, 'Gerente no encontrado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        -- Verificación de estado gerente
		IF NOT EXISTS (SELECT 1 FROM EMPLOYEE WHERE ID_Employee = @ID_Employee AND status = 'A')
        BEGIN
            SELECT -11 AS StatusCode, 'Gerente no habilitado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        -- Verificación de la contraseña
        IF NOT EXISTS (SELECT 1 FROM GERENT WHERE ID_Gerent = @ID_Gerent AND password = @password)
        BEGIN
            SELECT -12 AS StatusCode, 'Contraseña incorrecta' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        -- Obtención de datos del gerente
        SELECT 
            0 AS StatusCode, 
            'Inicio de sesión exitoso' AS Message,
            G.ID_Gerent,
            P.first_name,
            P.last_name,
            P.email,
            P.phone
        FROM GERENT G
        INNER JOIN EMPLOYEE E ON G.FK_ID_Employee = E.ID_Employee
        INNER JOIN PERSON P ON E.FK_DNI_Person = P.DNI_Person
        WHERE G.ID_Gerent = @ID_Gerent;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Show_Cities
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todas las ciudades con sus IDs y nombres
        SELECT
            ID_City AS ID,
            name AS Nombre
        FROM 
            CITY;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Search_City
    @search VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
        IF 
            dbo.isNullOrEmpty(@search) = 1
        BEGIN
            SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
            RETURN;
        END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todas las ciudades con sus IDs y nombres
        SELECT
            ID_City AS ID,
            name AS Nombre
        FROM 
            CITY
        WHERE ID_City LIKE '%' + @search + '%' 
        OR name LIKE '%' + @search + '%';

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Register_City
    @city_name VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
        IF 
            dbo.isNullOrEmpty(@city_name) = 1
        BEGIN
            SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
            RETURN;
        END

    -- Validación de nombre de la ciudad
    IF LEN(@city_name) = 0
    BEGIN
        SELECT -1 AS StatusCode, 'El nombre de la ciudad no puede estar vacío' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Verificación de existencia previa de la ciudad
        IF EXISTS (SELECT 1 FROM CITY WHERE name = @city_name)
        BEGIN
            SELECT -10 AS StatusCode, 'La ciudad ya está registrada' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        INSERT INTO CITY (name)
        VALUES (@city_name);

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Registro exitoso' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Update_City
    @ID_City INT,
    @city_name VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@ID_City) = 1 OR
        dbo.isNullOrEmpty(@city_name) = 1
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de nombre de la ciudad
    IF LEN(@city_name) = 0
    BEGIN
        SELECT -1 AS StatusCode, 'El nombre de la ciudad no puede estar vacío' AS ErrorMessage;
        RETURN;
    END


    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Verificación de existencia previa de la ciudad
        IF NOT EXISTS (SELECT 1 FROM CITY WHERE ID_City = @ID_City)
        BEGIN
            SELECT -10 AS StatusCode, 'La ciudad no está registrada' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        UPDATE CITY
        SET name = @city_name
        WHERE ID_City = @ID_City;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Actualización exitosa' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Delete_City
    @ID_City INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@ID_City) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Verificación de existencia previa de la ciudad
        IF NOT EXISTS (SELECT 1 FROM CITY WHERE ID_City = @ID_City)
        BEGIN
            SELECT -10 AS StatusCode, 'La ciudad no está registrada' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        DELETE FROM CITY
        WHERE ID_City = @ID_City;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Eliminación exitosa' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO


CREATE PROCEDURE spGerent_GetCities
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todas las ciudades con sus IDs y nombres
        SELECT
            ID_City AS city_id,
            name AS city_name
        FROM 
            CITY;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Show_Routes
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todas las rutas con sus IDs y nombres
        SELECT
            R.ID_Route AS ID,
            O.name AS Origen,
            D.name AS Destino,
            R.default_price AS Precio,
            SR.description AS Estado
        FROM 
            ROUTE R
        INNER JOIN STATUS_ROUTE SR ON R.status = SR.status
        INNER JOIN CITY O ON R.FK_ID_Origin_City = O.ID_City
        INNER JOIN CITY D ON R.FK_ID_Destination_City = D.ID_City;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Search_Route
    @search VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@search) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todas las rutas con sus IDs y nombres
        SELECT
            R.ID_Route AS ID,
            O.name AS Origen,
            D.name AS Destino,
            R.default_price AS Precio,
            SR.description AS Estado
        FROM 
            ROUTE R
        INNER JOIN CITY O ON R.FK_ID_Origin_City = O.ID_City
        INNER JOIN CITY D ON R.FK_ID_Destination_City = D.ID_City
        INNER JOIN STATUS_ROUTE SR ON R.status = SR.status
        WHERE O.name LIKE '%' + @search + '%'
           OR D.name LIKE '%' + @search + '%';

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Register_Route
    @FK_ID_Origin_City INT,
    @FK_ID_Destination_City INT,
    @default_price MONEY,
    @status CHAR(1) = 'A'
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(CAST(@FK_ID_Origin_City AS NVARCHAR(MAX))) = 1 OR
        dbo.isNullOrEmpty(CAST(@FK_ID_Destination_City AS NVARCHAR(MAX))) = 1 OR
        dbo.isNullOrEmpty(CAST(@default_price AS NVARCHAR(MAX))) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de ciudades
    IF @FK_ID_Origin_City = @FK_ID_Destination_City
    BEGIN
        SELECT -1 AS StatusCode, 'La ciudad de origen y destino no pueden ser la misma' AS ErrorMessage;
        RETURN;
    END

    -- Validación de precio
    IF @default_price <= 0
    BEGIN
        SELECT -2 AS StatusCode, 'El precio debe ser mayor a cero' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Verificación de existencia previa de la ruta
        IF EXISTS (SELECT 1 FROM ROUTE WHERE FK_ID_Origin_City = @FK_ID_Origin_City AND FK_ID_Destination_City = @FK_ID_Destination_City)
        BEGIN
            SELECT -10 AS StatusCode, 'Ruta ya registrada' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        INSERT INTO ROUTE (FK_ID_Origin_City, FK_ID_Destination_City, default_price, status)
        VALUES (@FK_ID_Origin_City, @FK_ID_Destination_City, @default_price, @status);

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Registro exitoso' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Delete_Route
    @ID_Route INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@ID_Route) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Verificación de existencia previa de la ruta
        IF NOT EXISTS (SELECT 1 FROM ROUTE WHERE ID_Route = @ID_Route)
        BEGIN
            SELECT -10 AS StatusCode, 'La ruta no está registrada' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        -- Si existe mas de 1 viaje con la ruta, no se puede eliminar
        IF EXISTS (SELECT 1 FROM TRIP WHERE FK_ID_Route = @ID_Route)
        BEGIN
            SELECT -11 AS StatusCode, 'No se puede eliminar la ruta porque tiene viajes asociados' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        -- Si solo hay un registro en history route se elimina el history route y luego el route
        IF (SELECT COUNT(*) FROM HISTORY_ROUTE WHERE FK_ID_Route = @ID_Route) = 1
        BEGIN
            DELETE FROM HISTORY_ROUTE
            WHERE FK_ID_Route = @ID_Route;
        END
        -- Sino no se puede eliminar esta ruta
        ELSE
        BEGIN
            SELECT -12 AS StatusCode, 'No se puede eliminar la ruta porque tiene historial asociado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        DELETE FROM ROUTE
        WHERE ID_Route = @ID_Route;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Eliminación exitosa' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Show_Administrators
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todos los administradores con sus IDs y nombres
        SELECT
            A.ID_Administrator AS ID,
            C.name AS Ciudad,
            P.first_name AS Nombre,
            P.last_name AS Apellido,
            P.email AS Correo,
            P.phone AS Teléfono,
            SE.description AS Estado
        FROM 
            ADMINISTRATOR A
        INNER JOIN EMPLOYEE E ON A.FK_ID_Employee = E.ID_Employee
        INNER JOIN STATUS_EMPLOYEE SE ON E.status = SE.status
        INNER JOIN PERSON P ON E.FK_DNI_Person = P.DNI_Person
        INNER JOIN CITY C ON A.FK_ID_City = C.ID_City;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Search_Administrator
    @search VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@search) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todos los administradores con sus IDs y nombres
        SELECT
            A.ID_Administrator AS ID,
            C.name AS Ciudad,
            P.first_name AS Nombre,
            P.last_name AS Apellido,
            P.email AS Correo,
            P.phone AS Teléfono,
            SE.description AS Estado
        FROM 
            ADMINISTRATOR A
        INNER JOIN EMPLOYEE E ON A.FK_ID_Employee = E.ID_Employee
        INNER JOIN STATUS_EMPLOYEE SE ON E.status = SE.status
        INNER JOIN PERSON P ON E.FK_DNI_Person = P.DNI_Person
        INNER JOIN CITY C ON A.FK_ID_City = C.ID_City
        WHERE A.ID_Administrator LIKE '%' + @search + '%'
           OR P.first_name LIKE '%' + @search + '%'
           OR P.last_name LIKE '%' + @search + '%'
           OR P.email LIKE '%' + @search + '%'
           OR P.phone LIKE '%' + @search + '%';

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Register_Administrator
    -- Variables Table Person
    @DNI_Person CHAR(20),
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @email VARCHAR(50),
    @address VARCHAR(50),
    @phone CHAR(20),

    -- Variables Table Employee
    @status CHAR(1) = 'A',

    -- Variables Table Administrator
    @plain_password VARCHAR(50),
    @FK_ID_City INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@DNI_Person) = 1 OR
        dbo.isNullOrEmpty(@first_name) = 1 OR
        dbo.isNullOrEmpty(@last_name) = 1 OR
        dbo.isNullOrEmpty(@email) = 1 OR
        dbo.isNullOrEmpty(@address) = 1 OR
        dbo.isNullOrEmpty(@phone) = 1 OR
        dbo.isNullOrEmpty(@plain_password) = 1 OR
        dbo.isNullOrEmpty(@FK_ID_City) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de DNI
    IF NOT @DNI_Person LIKE REPLICATE('[0-9]', 8)
    BEGIN
        SELECT -1 AS StatusCode, 'El DNI debe contener solo 8 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    -- Validación de teléfono
    IF @phone IS NOT NULL AND NOT @phone LIKE REPLICATE('[0-9]', 9)
    BEGIN
        SELECT -2 AS StatusCode, 'El teléfono debe contener solo 9 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    -- Validación básica de email
    IF @email IS NOT NULL AND CHARINDEX('@', @email) = 0
    BEGIN
        SELECT -3 AS StatusCode, 'El correo electrónico no es válido' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

				DECLARE @ID_Employee CHAR(11) = 'EMP' + @DNI_Person;
        DECLARE @ID_Administrator CHAR(11) = 'ADM' + @DNI_Person;
        DECLARE @password VARBINARY(64) = HASHBYTES('SHA2_256', @plain_password);

        -- Verificación de existencia previa del DNI
        IF NOT EXISTS (SELECT 1 FROM PERSON WHERE DNI_Person = @DNI_Person)
        BEGIN
            INSERT INTO PERSON (DNI_Person, first_name, last_name, email, address, phone)
            VALUES (@DNI_Person, @first_name, @last_name, @email, @address, @phone);
        END

        -- Verificación de existencia previa del empleado
        IF NOT EXISTS (SELECT 1 FROM EMPLOYEE WHERE ID_Employee = @ID_Employee)
        BEGIN
            INSERT INTO EMPLOYEE (ID_Employee, FK_DNI_Person, status)
            VALUES (@ID_Employee, @DNI_Person, @status);
        END

        -- Verificación de existencia previa del administrador
        IF EXISTS (SELECT 1 FROM ADMINISTRATOR WHERE ID_Administrator = @ID_Administrator)
        BEGIN
            SELECT -10 AS StatusCode, 'Administrador ya registrado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        INSERT INTO ADMINISTRATOR (ID_Administrator, FK_ID_Employee, FK_ID_City, password)
        VALUES (@ID_Administrator, @ID_Employee, @FK_ID_City, @password);

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Registro exitoso' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Show_Salespersons
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todos los vendedores con sus IDs y nombres
        SELECT
            S.ID_Salesperson AS ID,
            C.name AS Ciudad,
            P.first_name AS Nombre,
            P.last_name AS Apellido,
            P.email AS Correo,
            P.phone AS Teléfono,
            SE.description AS Estado
        FROM 
            SALESPERSON S
        INNER JOIN EMPLOYEE E ON S.FK_ID_Employee = E.ID_Employee
        INNER JOIN STATUS_EMPLOYEE SE ON E.status = SE.status
        INNER JOIN PERSON P ON E.FK_DNI_Person = P.DNI_Person
        INNER JOIN CITY C ON S.FK_ID_City = C.ID_City;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Search_Salesperson
    @search VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validación de null or empty
        IF 
        dbo.isNullOrEmpty(@search) = 1 
        BEGIN
            SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
        END

        BEGIN TRY
            IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todos los vendedores con sus IDs y nombres
        SELECT
            S.ID_Salesperson AS ID,
            C.name AS Ciudad,
            P.first_name AS Nombre,
            P.last_name AS Apellido,
            P.email AS Correo,
            P.phone AS Teléfono,
            SE.description AS Estado
        FROM 
            SALESPERSON S
        INNER JOIN EMPLOYEE E ON S.FK_ID_Employee = E.ID_Employee
        INNER JOIN STATUS_EMPLOYEE SE ON E.status = SE.status
        INNER JOIN PERSON P ON E.FK_DNI_Person = P.DNI_Person
        INNER JOIN CITY C ON S.FK_ID_City = C.ID_City
        WHERE S.ID_Salesperson LIKE '%' + @search + '%'
           OR P.first_name LIKE '%' + @search + '%'
           OR P.last_name LIKE '%' + @search + '%'
           OR P.email LIKE '%' + @search + '%'
           OR P.phone LIKE '%' + @search + '%';

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Register_Salesperson
    -- Variables Table Person
    @DNI_Person CHAR(20),
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @email VARCHAR(50),
    @address VARCHAR(50),
    @phone CHAR(20),

    -- Variables Table Employee
    @status CHAR(1) = 'A',

    -- Variables Table Salesperson
    @plain_password VARCHAR(50),
    @FK_ID_City INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@DNI_Person) = 1 OR
        dbo.isNullOrEmpty(@first_name) = 1 OR
        dbo.isNullOrEmpty(@last_name) = 1 OR
        dbo.isNullOrEmpty(@email) = 1 OR
        dbo.isNullOrEmpty(@address) = 1 OR
        dbo.isNullOrEmpty(@phone) = 1 OR
        dbo.isNullOrEmpty(@plain_password) = 1 OR
        dbo.isNullOrEmpty(@FK_ID_City) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de DNI
    IF NOT @DNI_Person LIKE REPLICATE('[0-9]', 8)
    BEGIN
        SELECT -1 AS StatusCode, 'El DNI debe contener solo 8 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    -- Validación de teléfono
    IF @phone IS NOT NULL AND NOT @phone LIKE REPLICATE('[0-9]', 9)
    BEGIN
        SELECT -2 AS StatusCode, 'El teléfono debe contener solo 9 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    -- Validación básica de email
    IF @email IS NOT NULL AND CHARINDEX('@', @email) = 0
    BEGIN
        SELECT -3 AS StatusCode, 'El correo electrónico no es válido' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        DECLARE @ID_Employee CHAR(11) = 'EMP' + @DNI_Person;
        DECLARE @ID_Salesperson CHAR(11) = 'SAL' + @DNI_Person;
        DECLARE @password VARBINARY(64) = HASHBYTES('SHA2_256', @plain_password);

        -- Verificación de existencia previa del DNI
        IF NOT EXISTS (SELECT 1 FROM PERSON WHERE DNI_Person = @DNI_Person)
        BEGIN
            INSERT INTO PERSON (DNI_Person, first_name, last_name, email, address, phone)
            VALUES (@DNI_Person, @first_name, @last_name, @email, @address, @phone);
        END

        -- Verificación de existencia previa del empleado
        IF NOT EXISTS (SELECT 1 FROM EMPLOYEE WHERE ID_Employee = @ID_Employee)
        BEGIN
            INSERT INTO EMPLOYEE (ID_Employee, FK_DNI_Person, status)
            VALUES (@ID_Employee, @DNI_Person, 'A');
        END

        -- Verificación de existencia previa del vendedor
        IF EXISTS (SELECT 1 FROM SALESPERSON WHERE ID_Salesperson = @ID_Salesperson)
        BEGIN
            SELECT -10 AS StatusCode, 'Vendedor ya registrado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        INSERT INTO SALESPERSON (ID_Salesperson, FK_ID_Employee, FK_ID_City, password)
        VALUES (@ID_Salesperson, @ID_Employee, @FK_ID_City, @password);

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Registro exitoso' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Show_Drivers
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todos los conductores con sus IDs y nombres
        SELECT
            D.ID_Driver AS ID,
            D.license_number AS Licencia,
            P.first_name AS Nombre,
            P.last_name AS Apellido,
            P.email AS Correo,
            P.phone AS Teléfono,
            SE.description AS Estado
        FROM 
            DRIVER D
        INNER JOIN EMPLOYEE E ON D.FK_ID_Employee = E.ID_Employee
        INNER JOIN STATUS_EMPLOYEE SE ON E.status = SE.status
        INNER JOIN PERSON P ON E.FK_DNI_Person = P.DNI_Person;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Search_Driver
    @search VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validación de null or empty
        IF 
        dbo.isNullOrEmpty(@search) = 1 
        BEGIN
            SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
        END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todos los conductores con sus IDs y nombres
        SELECT
            D.ID_Driver AS ID,
            D.license_number AS Licencia,
            P.first_name AS Nombre,
            P.last_name AS Apellido,
            P.email AS Correo,
            P.phone AS Teléfono,
            SE.description AS Estado
        FROM 
            DRIVER D
        INNER JOIN EMPLOYEE E ON D.FK_ID_Employee = E.ID_Employee
        INNER JOIN STATUS_EMPLOYEE SE ON E.status = SE.status
        INNER JOIN PERSON P ON E.FK_DNI_Person = P.DNI_Person
        WHERE D.ID_Driver LIKE '%' + @search + '%'
           OR D.license_number LIKE '%' + @search + '%'
           OR P.first_name LIKE '%' + @search + '%'
           OR P.last_name LIKE '%' + @search + '%'
           OR P.email LIKE '%' + @search + '%'
           OR P.phone LIKE '%' + @search + '%';

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Register_Driver
    -- Variables Table Person
    @DNI_Person CHAR(20),
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @email VARCHAR(50),
    @address VARCHAR(50),
    @phone CHAR(20),

    -- Variables Table Employee
    @status CHAR(1) = 'A',

    -- Variables Table Driver
    @license_number CHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@DNI_Person) = 1 OR
        dbo.isNullOrEmpty(@first_name) = 1 OR
        dbo.isNullOrEmpty(@last_name) = 1 OR
        dbo.isNullOrEmpty(@email) = 1 OR
        dbo.isNullOrEmpty(@address) = 1 OR
        dbo.isNullOrEmpty(@phone) = 1 OR
        dbo.isNullOrEmpty(@license_number) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de DNI
    IF NOT @DNI_Person LIKE REPLICATE('[0-9]', 8)
    BEGIN
        SELECT -1 AS StatusCode, 'El DNI debe contener solo 8 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    -- Validación de teléfono
    IF @phone IS NOT NULL AND NOT @phone LIKE REPLICATE('[0-9]', 9)
    BEGIN
        SELECT -2 AS StatusCode, 'El teléfono debe contener solo 9 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    -- Validación básica de email
    IF @email IS NOT NULL AND CHARINDEX('@', @email) = 0
    BEGIN
        SELECT -3 AS StatusCode, 'El correo electrónico no es válido' AS ErrorMessage;
        RETURN;
    END

    -- Validación de licencia de conducir
    IF NOT @license_number LIKE REPLICATE('[A-Za-z0-9]', 9)
    BEGIN
        SELECT -5 AS StatusCode, 'El número de licencia debe contener solo 9 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        DECLARE @ID_Employee CHAR(11) = 'EMP' + @DNI_Person;
        DECLARE @ID_Driver CHAR(11) = 'DRI' + @DNI_Person;

        -- Verificación de existencia previa del DNI
        IF NOT EXISTS (SELECT 1 FROM PERSON WHERE DNI_Person = @DNI_Person)
        BEGIN
            INSERT INTO PERSON (DNI_Person, first_name, last_name, email, address, phone)
            VALUES (@DNI_Person, @first_name, @last_name, @email, @address, @phone);
        END

        -- Verificación de existencia previa del empleado
        IF NOT EXISTS (SELECT 1 FROM EMPLOYEE WHERE ID_Employee = @ID_Employee)
        BEGIN
            INSERT INTO EMPLOYEE (ID_Employee, FK_DNI_Person, status)
            VALUES (@ID_Employee, @DNI_Person, 'A');
        END

        -- Verificación de existencia previa del conductor
        IF EXISTS (SELECT 1 FROM DRIVER WHERE ID_Driver = @ID_Driver)
        BEGIN
            SELECT -10 AS StatusCode, 'Conductor ya registrado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        INSERT INTO DRIVER (ID_Driver, FK_ID_Employee, license_number)
        VALUES (@ID_Driver, @ID_Employee, @license_number);

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Registro exitoso' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Show_Buses
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todos los autobuses con sus IDs y nombres
        SELECT
            B.ID_Bus AS Placa,
            B.seats_count AS Asientos,
            B.brand AS Marca,
            B.model AS Modelo,
            SB.description AS Estado
        FROM 
            BUS B
        INNER JOIN STATUS_BUS SB ON B.status = SB.status;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Search_Bus
    @search VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validación de null or empty
        IF 
        dbo.isNullOrEmpty(@search) = 1 
        BEGIN
            SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
        END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todos los autobuses con sus IDs y nombres
        SELECT
            B.ID_Bus AS Placa,
            B.seats_count AS Asientos,
            B.brand AS Marca,
            B.model AS Modelo,
            SB.description AS Estado
        FROM 
            BUS B
        INNER JOIN STATUS_BUS SB ON B.status = SB.status
        WHERE B.ID_Bus LIKE '%' + @search + '%'
           OR B.brand LIKE '%' + @search + '%'
           OR B.model LIKE '%' + @search + '%';

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Register_Bus
    @ID_Bus CHAR(20),
    @brand VARCHAR(50),
    @model VARCHAR(50),
    @seats_count INT,
    @status CHAR(1) = 'A'
AS
BEGIN
    SET NOCOUNT ON;

     -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@ID_Bus) = 1 OR
        dbo.isNullOrEmpty(@brand) = 1 OR
        dbo.isNullOrEmpty(@model) = 1 OR
        dbo.isNullOrEmpty(CAST(@seats_count AS NVARCHAR(MAX))) = 1
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de ID_Bus
    IF @ID_Bus LIKE REPLICATE('[a-zA-Z0-9]', 6)
    BEGIN
        SELECT -1 AS StatusCode, 'El ID del autobús debe contener 6 caracteres' AS ErrorMessage;
        RETURN;
    END

    -- Validación de seats_count
    IF @seats_count <= 0
    BEGIN
        SELECT -2 AS StatusCode, 'El número de asientos debe ser mayor a cero' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Verificación de existencia previa del autobús
        IF EXISTS (SELECT 1 FROM BUS WHERE ID_Bus = @ID_Bus)
        BEGIN
            SELECT -10 AS StatusCode, 'Autobús ya registrado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        INSERT INTO BUS (ID_Bus, brand, model, seats_count, status)
        VALUES (@ID_Bus, @brand, @model, @seats_count, @status);

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Registro exitoso' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Update_Bus
    @ID_Bus CHAR(20),
    @brand VARCHAR(50),
    @model VARCHAR(50),
    @seats_count INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@ID_Bus) = 1 OR
        dbo.isNullOrEmpty(@brand) = 1 OR
        dbo.isNullOrEmpty(@model) = 1 OR
        dbo.isNullOrEmpty(@seats_count) = 1
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de ID_Bus
    IF LEN(@ID_Bus) <> 6
    BEGIN
        SELECT -1 AS StatusCode, 'El ID del autobús debe contener 6 caracteres' AS ErrorMessage;
        RETURN;
    END

    -- Validación de seats_count
    IF @seats_count <= 0
    BEGIN
        SELECT -2 AS StatusCode, 'El número de asientos debe ser mayor a cero' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Verificación de existencia previa del autobús
        IF NOT EXISTS (SELECT 1 FROM BUS WHERE ID_Bus = @ID_Bus)
        BEGIN
            SELECT -10 AS StatusCode, 'Autobús no registrado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        UPDATE BUS
        SET brand = @brand,
            model = @model,
            seats_count = @seats_count
        WHERE ID_Bus = @ID_Bus;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Actualización exitosa' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spGerent_Delete_Bus
    @ID_Bus CHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@ID_Bus) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Verificación de existencia previa del autobús
        IF NOT EXISTS (SELECT 1 FROM BUS WHERE ID_Bus = @ID_Bus)
        BEGIN
            SELECT -10 AS StatusCode, 'El autobús no está registrado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        -- Si solo hay un registro en history bus se elimina el history bus y luego el bus
        IF (SELECT COUNT(*) FROM HISTORY_BUS WHERE FK_ID_Bus = @ID_Bus) = 1
        BEGIN
            DELETE FROM HISTORY_BUS
            WHERE FK_ID_Bus = @ID_Bus;
        END
        -- Sino no se puede eliminar este bus
        ELSE
        BEGIN
            SELECT -11 AS StatusCode, 'No se puede eliminar el autobús porque tiene historial de mantenimiento' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        DELETE FROM BUS
        WHERE ID_Bus = @ID_Bus;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Eliminación exitosa' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

-- Stored Procedures for Administrator
CREATE PROCEDURE spAdministrator_Login
    @DNI_Person CHAR(20),
    @plain_password VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@DNI_Person) = 1 OR
        dbo.isNullOrEmpty(@plain_password) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de DNI
    IF NOT @DNI_Person LIKE REPLICATE('[0-9]', 8)
    BEGIN
        SELECT -1 AS StatusCode, 'El DNI debe contener solo 8 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        DECLARE @ID_Administrator CHAR(11) = 'ADM' + @DNI_Person;
        DECLARE @ID_Employee CHAR(11) = 'EMP' + @DNI_Person;
        DECLARE @password VARBINARY(64) = HASHBYTES('SHA2_256', @plain_password);

        -- Verificación de existencia del administrador
        IF NOT EXISTS (SELECT 1 FROM ADMINISTRATOR WHERE ID_Administrator = @ID_Administrator)
        BEGIN
            SELECT -10 AS StatusCode, 'Administrador no encontrado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

		-- Verificación de estado administrador
		IF NOT EXISTS (SELECT 1 FROM EMPLOYEE WHERE ID_Employee = @ID_Employee AND status = 'A')
        BEGIN
            SELECT -11 AS StatusCode, 'Administrador no habilitado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END


        -- Verificación de la contraseña
        IF NOT EXISTS (SELECT 1 FROM ADMINISTRATOR WHERE ID_Administrator = @ID_Administrator AND password = @password)
        BEGIN
            SELECT -12 AS StatusCode, 'Contraseña incorrecta' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END


        -- Obtención de datos del administrador
        SELECT 
            0 AS StatusCode, 
            'Inicio de sesión exitoso' AS Message,
            A.ID_Administrator,
            P.first_name,
            P.last_name,
            P.email,
            P.phone,
			C.ID_City AS city_id,
			C.name AS city_name
        FROM ADMINISTRATOR A
		INNER JOIN EMPLOYEE E ON E.ID_Employee = A.FK_ID_Employee
        INNER JOIN PERSON P ON P.DNI_Person = E.FK_DNI_Person
		INNER JOIN CITY C ON C.ID_City = A.FK_ID_City
        WHERE A.ID_Administrator = @ID_Administrator;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spAdministrator_ShowTrips
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Selecciona todos los viajes con sus IDs y nombres
        SELECT
            T.ID_Trip AS ID,
            CASE 
                WHEN T.status = 'P' THEN T.scheduled_departure_dateTime
                ELSE T.actual_departure_dateTime -- Default to scheduled_departure_dateTime if status is neither 'P' nor 'S'
            END AS Hora_Salida,
            T.arrival_dateTime AS Hora_Llegada,
            CO.name AS Origen,
            CD.name AS Destino,
            ST.description AS Estado,
            T.price AS Precio,
            T.FK_ID_Bus AS Bus,
            T.FK_ID_Driver AS Conductor
        FROM 
            TRIP T
        INNER JOIN ROUTE R ON T.FK_ID_Route = R.ID_Route
        INNER JOIN STATUS_TRIP ST ON T.status = ST.status
        INNER JOIN CITY CO ON R.FK_ID_Origin_City = CO.ID_City
        INNER JOIN CITY CD ON R.FK_ID_Destination_City = CD.ID_City
        WHERE CAST(T.scheduled_departure_dateTime AS DATE) = CAST(GETDATE() AS DATE);

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO


CREATE PROCEDURE spAdministrator_CreateTrip_GetOptions
    @ID_origin_city INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@ID_origin_city) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Obtener las ciudades de destino activas
        SELECT 
            R.FK_ID_Destination_City AS destination_city_id,
            C.name AS destination_city_name
        FROM ROUTE R
        INNER JOIN CITY C ON R.FK_ID_Destination_City = C.ID_City
        WHERE R.FK_ID_Origin_City = @ID_origin_city
          AND R.status = 'A';

        -- Obtener los buses activos
        SELECT 
            B.ID_Bus AS bus_placa,
            B.seats_count
        FROM BUS B
        WHERE B.status = 'A';

        -- Obtener los conductores activos
        SELECT
            D.ID_Driver AS driver_id,
            P.first_name AS driver_first_name,
            P.last_name AS driver_last_name
        FROM DRIVER D
        INNER JOIN EMPLOYEE E ON D.FK_ID_Employee = E.ID_Employee
        INNER JOIN PERSON P ON E.FK_DNI_Person = P.DNI_Person
        WHERE E.status = 'A';

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        -- Devolver el error
        SELECT 
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

CREATE PROCEDURE spAdministrator_CreateTrip
    @FK_ID_Origin_City INT,
    @FK_ID_Destination_City INT,
    @FK_ID_Bus CHAR(6),
    @FK_ID_Driver CHAR(11),
    @scheduled_departure_dateTime DATETIME,
    @price MONEY = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@FK_ID_Origin_City) = 1 OR
        dbo.isNullOrEmpty(@FK_ID_Destination_City) = 1 OR
        dbo.isNullOrEmpty(@FK_ID_Bus) = 1 OR
        dbo.isNullOrEmpty(@FK_ID_Driver) = 1 OR
        dbo.isNullOrEmpty(@scheduled_departure_dateTime) = 1
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Validaciones
        IF @FK_ID_Origin_City = @FK_ID_Destination_City
        BEGIN
            SELECT -1 AS StatusCode, 'La ciudad de origen y destino no pueden ser la misma' AS ErrorMessage;
            ROLLBACK TRANSACTION;
            RETURN;
        END

        IF @scheduled_departure_dateTime <= GETDATE()
        BEGIN
            SELECT -2 AS StatusCode, 'La fecha de salida programada debe ser mayor a la fecha actual' AS ErrorMessage;
            ROLLBACK TRANSACTION;
            RETURN;
        END

        IF @price IS NULL
        BEGIN
            SELECT @price = R.default_price
            FROM ROUTE R
            WHERE R.FK_ID_Origin_City = @FK_ID_Origin_City
              AND R.FK_ID_Destination_City = @FK_ID_Destination_City;
        END

        -- Verificación de existencia previa del bus y conductor en el mismo horario
        IF EXISTS (
            SELECT 1
            FROM TRIP
            WHERE FK_ID_Bus = @FK_ID_Bus
              AND scheduled_departure_dateTime = @scheduled_departure_dateTime
        )
        BEGIN
            SELECT -10 AS StatusCode, 'El bus ya tiene un viaje programado en el mismo horario' AS ErrorMessage;
            ROLLBACK TRANSACTION;
            RETURN;
        END

        IF EXISTS (
            SELECT 1
            FROM TRIP
            WHERE FK_ID_Driver = @FK_ID_Driver
              AND scheduled_departure_dateTime = @scheduled_departure_dateTime
        )
        BEGIN
            SELECT -11 AS StatusCode, 'El conductor ya tiene un viaje programado en el mismo horario' AS ErrorMessage;
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Inserción del viaje
        INSERT INTO TRIP (
            FK_ID_Route,
            FK_ID_Bus,
            FK_ID_Driver,
            scheduled_departure_dateTime,
            price,
            status
        )
        VALUES (
            (SELECT ID_Route FROM ROUTE WHERE FK_ID_Origin_City = @FK_ID_Origin_City AND FK_ID_Destination_City = @FK_ID_Destination_City),
            @FK_ID_Bus,
            @FK_ID_Driver,
            @scheduled_departure_dateTime,
            @price,
            'P'
        );

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Viaje creado exitosamente' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT 
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END
GO

CREATE PROCEDURE spAdministrator_Trip_Start
    @ID_Trip INT,
    @dateTime DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@ID_Trip) = 1 OR
        dbo.isNullOrEmpty(@dateTime) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END


    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Validar existencia del viaje y su estado
        IF NOT EXISTS (SELECT 1 FROM TRIP WHERE ID_Trip = @ID_Trip AND status = 'P')
        BEGIN
            SELECT -1 AS StatusCode, 'El viaje no existe o no está en estado pendiente' AS ErrorMessage;
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Actualizar el estado del viaje a 'S' (Started)
        UPDATE TRIP
        SET status = 'S',
            actual_departure_dateTime = ISNULL(@dateTime, GETDATE())
        WHERE ID_Trip = @ID_Trip;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'El viaje ha comenzado exitosamente' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT 
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END
GO


CREATE PROCEDURE spAdministrator_Trip_Finish
    @ID_Trip INT,
    @dateTime DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@ID_Trip) = 1 OR
        dbo.isNullOrEmpty(@dateTime) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Validar existencia del viaje y su estado
        IF NOT EXISTS (SELECT 1 FROM TRIP WHERE ID_Trip = @ID_Trip AND status = 'S')
        BEGIN
            SELECT -1 AS StatusCode, 'El viaje no existe o no está en estado iniciado' AS ErrorMessage;
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Actualizar el estado del viaje a 'C' (Completed)
        UPDATE TRIP
        SET status = 'C',
            arrival_dateTime = ISNULL(@dateTime, GETDATE())
        WHERE ID_Trip = @ID_Trip;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'El viaje ha sido completado exitosamente' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT 
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END
GO

-- Stored Procedures for Salesperson
CREATE PROCEDURE spSalesperson_Login
    @DNI_Person CHAR(20),
    @plain_password VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@DNI_Person) = 1 OR
        dbo.isNullOrEmpty(@plain_password) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de DNI
    IF NOT @DNI_Person LIKE REPLICATE('[0-9]', 8)
    BEGIN
        SELECT -1 AS StatusCode, 'El DNI debe contener solo 8 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        DECLARE @ID_Salesperson CHAR(11) = 'SAL' + @DNI_Person;
        DECLARE @ID_Employee CHAR(11) = 'EMP' + @DNI_Person;
        DECLARE @password VARBINARY(64) = HASHBYTES('SHA2_256', @plain_password);

        -- Verificación de existencia del vendedor
        IF NOT EXISTS (SELECT 1 FROM SALESPERSON WHERE ID_Salesperson = @ID_Salesperson)
        BEGIN
            SELECT -10 AS StatusCode, 'Vendedor no encontrado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

		-- Verificación de estado vendedor
		IF NOT EXISTS (SELECT 1 FROM EMPLOYEE WHERE ID_Employee = @ID_Employee AND status = 'A')
        BEGIN
            SELECT -11 AS StatusCode, 'Vendedor no habilitado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END


        -- Verificación de la contraseña
        IF NOT EXISTS (SELECT 1 FROM SALESPERSON WHERE ID_Salesperson = @ID_Salesperson AND password = @password)
        BEGIN
            SELECT -12 AS StatusCode, 'Contraseña incorrecta' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END


        -- Obtención de datos del vendedor
        SELECT 
            0 AS StatusCode, 
            'Inicio de sesión exitoso' AS Message,
            S.ID_Salesperson,
            P.first_name,
            P.last_name,
            P.email,
            P.phone,
			C.ID_City AS city_id,
			C.name AS city_name
        FROM SALESPERSON S
		INNER JOIN EMPLOYEE E ON E.ID_Employee = S.FK_ID_Employee
        INNER JOIN PERSON P ON P.DNI_Person = E.FK_DNI_Person
		INNER JOIN CITY C ON C.ID_City = S.FK_ID_City
        WHERE S.ID_Salesperson = @ID_Salesperson;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spSalesperson_SearchClient
    @DNI_Person CHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@DNI_Person) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de DNI
    IF NOT @DNI_Person LIKE REPLICATE('[0-9]', 8)
    BEGIN
        SELECT -1 AS StatusCode, 'El DNI debe contener solo 8 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        -- Verificación de existencia del cliente
        IF NOT EXISTS (SELECT 1 FROM CLIENT WHERE FK_DNI_Person = @DNI_Person)
        BEGIN
            SELECT 1 AS StatusCode, 'Cliente no encontrado, rellene los campos y registre' AS Message;
            RETURN;
        END

        -- Obtención del ID del cliente
        SELECT 
            0 AS StatusCode, 
            'Cliente encontrado' AS Message,
            P.DNI_Person,
            P.first_name,
            P.last_name,
            P.email,
            P.address,
            P.phone
        FROM CLIENT C
        INNER JOIN PERSON P ON C.FK_DNI_Person = P.DNI_Person
        WHERE C.FK_DNI_Person = @DNI_Person;
    END TRY
    BEGIN CATCH
        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spSalesperson_RegisterClient
    @DNI_Person CHAR(20),
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @email VARCHAR(50) = NULL,
    @address VARCHAR(50) = NULL,
    @phone CHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@DNI_Person) = 1 OR
        dbo.isNullOrEmpty(@first_name) = 1 OR
        dbo.isNullOrEmpty(@last_name) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de DNI
    IF NOT @DNI_Person LIKE REPLICATE('[0-9]', 8)
    BEGIN
        SELECT -1 AS StatusCode, 'El DNI debe contener solo 8 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    -- Validación de teléfono
    IF @phone IS NOT NULL AND NOT @phone LIKE REPLICATE('[0-9]', 9)
    BEGIN
        SELECT -2 AS StatusCode, 'El teléfono debe contener solo 9 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    -- Validación básica de email
    IF @email IS NOT NULL AND CHARINDEX('@', @email) = 0
    BEGIN
        SELECT -3 AS StatusCode, 'El correo electrónico no es válido' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        DECLARE @ID_Client CHAR(11) = 'CLI' + @DNI_Person;

        -- Verificación de existencia previa del DNI
        IF NOT EXISTS (SELECT 1 FROM PERSON WHERE DNI_Person = @DNI_Person)
        BEGIN
            INSERT INTO PERSON (DNI_Person, first_name, last_name, email, address, phone)
            VALUES (@DNI_Person, @first_name, @last_name, @email, @address, @phone);
        END

        -- Verificación de existencia previa del cliente
        IF EXISTS (SELECT 1 FROM CLIENT WHERE ID_Client = @ID_Client)
        BEGIN
            SELECT -10 AS StatusCode, 'Cliente ya registrado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        INSERT INTO CLIENT (ID_Client, FK_DNI_Person)
        VALUES (@ID_Client, @DNI_Person);

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Registro exitoso' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spSalesperson_GetDestinationCities
    @ID_origin_city INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@ID_origin_city) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validar que la ciudad de origen existe
    IF NOT EXISTS (SELECT 1 FROM CITY WHERE ID_City = @ID_origin_city)
    BEGIN
        SELECT -1 AS StatusCode, 'La ciudad de origen no existe' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Obtener las ciudades de destino activas
        SELECT 
            R.FK_ID_Destination_City AS destination_city_id,
            C.name AS destination_city_name
        FROM ROUTE R
        INNER JOIN CITY C ON R.FK_ID_Destination_City = C.ID_City
        WHERE R.FK_ID_Origin_City = @ID_origin_city
          AND R.status = 'A';

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        -- Devolver el error
        SELECT 
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

CREATE PROCEDURE spSalesperson_GetTripsByRoute
    @ID_origin_city INT,
    @ID_destination_city INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@ID_origin_city) = 1 or
        dbo.isNullOrEmpty(@ID_destination_city) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validar que la ciudad de origen exista
    IF NOT EXISTS (SELECT 1 FROM CITY WHERE ID_City = @ID_origin_city)
    BEGIN
        SELECT -1 AS StatusCode, 'La ciudad de origen no existe' AS ErrorMessage;
        RETURN;
    END

    -- Validar que la ciudad de destino exista
    IF NOT EXISTS (SELECT 1 FROM CITY WHERE ID_City = @ID_destination_city)
    BEGIN
        SELECT -1 AS StatusCode, 'La ciudad de destino no existe' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        SELECT 
            T.ID_Trip AS ID,
            T.scheduled_departure_dateTime AS Hora_Salida,
            T.price AS Precio,
            B.ID_Bus AS Bus,
            B.seats_count AS Asientos,
            (B.seats_count - ISNULL(T2.seat_number, 0)) AS Disponibles
        FROM TRIP T
        INNER JOIN BUS B ON T.FK_ID_Bus = B.ID_Bus
        LEFT JOIN (
            SELECT 
                FK_ID_Trip,
                MAX(seat_number) AS seat_number
            FROM TICKET
            GROUP BY FK_ID_Trip
        ) T2 ON T.ID_Trip = T2.FK_ID_Trip
        WHERE T.FK_ID_Route = (
            SELECT ID_Route
            FROM ROUTE
            WHERE FK_ID_Origin_City = @ID_origin_city
              AND FK_ID_Destination_City = @ID_destination_city
        )
          AND T.status = 'P'
          AND CAST(T.scheduled_departure_dateTime AS DATE) = CAST(GETDATE() AS DATE);
        
        
        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        -- Devolver el error
        SELECT 
            -100 AS StatusCode,
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

CREATE PROCEDURE spSalesperson_SellTicket
    @ID_Client CHAR(11),
    @ID_Salesperson CHAR(11),
    @ID_Trip INT
AS
BEGIN

    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@ID_Client) = 1 OR
        dbo.isNullOrEmpty(@ID_Salesperson) = 1 OR
        dbo.isNullOrEmpty(@ID_Trip) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validar que el cliente exista
    IF NOT EXISTS (SELECT 1 FROM CLIENT WHERE ID_Client = @ID_Client)
    BEGIN
        SELECT -1 AS StatusCode, 'El cliente no existe' AS ErrorMessage;
        RETURN;
    END

    -- Validar que el vendedor exista
    IF NOT EXISTS (SELECT 1 FROM SALESPERSON WHERE ID_Salesperson = @ID_Salesperson)
    BEGIN
        SELECT -2 AS StatusCode, 'El vendedor no existe' AS ErrorMessage;
        RETURN;
    END

    -- Validar que el viaje exista
    IF NOT EXISTS (SELECT 1 FROM TRIP WHERE ID_Trip = @ID_Trip)
    BEGIN
        SELECT -3 AS StatusCode, 'El viaje no existe' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        -- Validar que el viaje esté en estado pendiente
        IF NOT EXISTS (SELECT 1 FROM TRIP WHERE ID_Trip = @ID_Trip AND status = 'P')
        BEGIN
            SELECT -4 AS StatusCode, 'El viaje no está en estado pendiente' AS ErrorMessage;
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Validar que haya asientos disponibles
        DECLARE @seats_count INT;
        DECLARE @available_seats INT;
        SELECT 
            @seats_count = B.seats_count,
            @available_seats = (B.seats_count - ISNULL(T2.seat_number, 0))
        FROM TRIP T
        INNER JOIN BUS B ON T.FK_ID_Bus = B.ID_Bus
        LEFT JOIN (
            SELECT 
                FK_ID_Trip,
                MAX(seat_number) AS seat_number
            FROM TICKET
            GROUP BY FK_ID_Trip
        ) T2 ON T.ID_Trip = T2.FK_ID_Trip
        WHERE T.ID_Trip = @ID_Trip;

        IF @available_seats <= 0
        BEGIN
            SELECT -5 AS StatusCode, 'No hay asientos disponibles para este viaje' AS ErrorMessage;
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Validar que el cliente no haya comprado un ticket para este mismo viaje
        IF EXISTS (SELECT 1 FROM TICKET WHERE FK_ID_Client = @ID_Client AND FK_ID_Trip = @ID_Trip)
        BEGIN
            SELECT -6 AS StatusCode, 'El cliente ya ha comprado un ticket para este viaje' AS ErrorMessage;
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Insertar el ticket
        INSERT INTO TICKET (FK_ID_Client, FK_ID_Salesperson, FK_ID_Trip, seat_number, ticket_dateTime)
        VALUES (@ID_Client, @ID_Salesperson, @ID_Trip, @seats_count - @available_seats + 1, GETDATE());

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Venta exitosa' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT 
            -100 AS StatusCode,
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END
GO

-- Stored Procedures for Client
CREATE PROCEDURE spClient_Register
    @DNI_Person CHAR(20),
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @email VARCHAR(50) = NULL,
    @address VARCHAR(50) = NULL,
    @phone CHAR(20) = NULL,
    @plain_password VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@DNI_Person) = 1 OR
        dbo.isNullOrEmpty(@first_name) = 1 OR
        dbo.isNullOrEmpty(@last_name) = 1 OR
        dbo.isNullOrEmpty(@plain_password) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de DNI
    IF NOT @DNI_Person LIKE REPLICATE('[0-9]', 8)
    BEGIN
        SELECT -1 AS StatusCode, 'El DNI debe contener solo 8 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    -- Validación de teléfono
    IF @phone IS NOT NULL AND NOT @phone LIKE REPLICATE('[0-9]', 9)
    BEGIN
        SELECT -2 AS StatusCode, 'El teléfono debe contener solo 9 dígitos numeéricos' AS ErrorMessage;
        RETURN;
    END

    -- Validación básica de email
    IF @email IS NOT NULL AND CHARINDEX('@', @email) = 0
    BEGIN
        SELECT -3 AS StatusCode, 'El correo electrónico no es válido' AS ErrorMessage;
        RETURN;
    END

    -- Verificar que al menos uno de los campos de contacto está presente
    IF @phone IS NULL AND @email IS NULL
    BEGIN
        SELECT -4 AS StatusCode, 'Debe proporcionar al menos un número de teléfono o un correo electrónico' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        DECLARE @ID_Client CHAR(11) = 'CLI' + @DNI_Person;
        DECLARE @password VARBINARY(64) = HASHBYTES('SHA2_256', @plain_password);

        -- Verificación de existencia previa del DNI
        IF NOT EXISTS (SELECT 1 FROM PERSON WHERE DNI_Person = @DNI_Person)
        BEGIN
            INSERT INTO PERSON (DNI_Person, first_name, last_name, email, address, phone)
            VALUES (@DNI_Person, @first_name, @last_name, @email, @address, @phone);
        END

        -- Verificación de existencia previa del cliente
        IF EXISTS (SELECT 1 FROM CLIENT WHERE ID_Client = @ID_Client)
        BEGIN
            SELECT -10 AS StatusCode, 'Cliente ya registrado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        INSERT INTO CLIENT (ID_Client, FK_DNI_Person, password)
        VALUES (@ID_Client, @DNI_Person, @password);

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        SELECT 0 AS StatusCode, 'Registro exitoso' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

CREATE PROCEDURE spClient_Login
    @DNI_Person CHAR(20),
    @plain_password VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación de null or empty
    IF 
        dbo.isNullOrEmpty(@DNI_Person) = 1 or
        dbo.isNullOrEmpty(@plain_password) = 1 
    BEGIN
        SELECT -50 AS StatusCode, 'Todos los campos son obligatorios' AS ErrorMessage;
        RETURN;
    END

    -- Validación de DNI
    IF NOT @DNI_Person LIKE REPLICATE('[0-9]', 8)
    BEGIN
        SELECT -1 AS StatusCode, 'El DNI debe contener solo 8 dígitos numéricos' AS ErrorMessage;
        RETURN;
    END

    BEGIN TRY
        IF @@TRANCOUNT = 0
        BEGIN
            BEGIN TRANSACTION;
        END

        DECLARE @ID_Client CHAR(11) = 'CLI' + @DNI_Person;
        DECLARE @password VARBINARY(64) = HASHBYTES('SHA2_256', @plain_password);

        -- Verificación de existencia del cliente
        IF NOT EXISTS (SELECT 1 FROM CLIENT WHERE ID_Client = @ID_Client)
        BEGIN
            SELECT -10 AS StatusCode, 'Cliente no encontrado' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        -- Verificación de la contraseña
        IF NOT EXISTS (SELECT 1 FROM CLIENT WHERE ID_Client = @ID_Client AND password = @password)
        BEGIN
            SELECT -11 AS StatusCode, 'Contraseña incorrecta' AS ErrorMessage;
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END
            RETURN;
        END

        -- Obtención de datos del cliente
        SELECT 
            0 AS StatusCode, 
            'Inicio de sesión exitoso' AS Message,
            C.ID_Client,
            P.first_name,
            P.last_name,
            P.email,
            P.phone
        FROM CLIENT C
        INNER JOIN PERSON P ON C.FK_DNI_Person = P.DNI_Person
        WHERE C.ID_Client = @ID_Client;

        IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        SELECT -100 AS StatusCode, ERROR_MESSAGE() AS ErrorMessage, ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END
GO

-- Stored Procedures for Python
CREATE PROCEDURE spPy_CreateClient
    @DNI_Person CHAR(20),
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @email VARCHAR(50) = NULL,
    @address VARCHAR(50) = NULL,
    @phone CHAR(20) = NULL,
    @plain_password VARCHAR(50)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @ID_Client CHAR(11) = 'CLI' + @DNI_Person;
        DECLARE @password VARBINARY(64) = HASHBYTES('SHA2_256', @plain_password);

        INSERT INTO PERSON (DNI_Person, first_name, last_name, email, address, phone)
        VALUES (@DNI_Person, @first_name, @last_name, @email, @address, @phone);

        INSERT INTO CLIENT (ID_Client, FK_DNI_Person, password)
        VALUES (@ID_Client, @DNI_Person, @password);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spPy_CreateGerent
    @DNI_Person CHAR(20),
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @email VARCHAR(50) = NULL,
    @address VARCHAR(50) = NULL,
    @phone CHAR(20) = NULL,
    @plain_password VARCHAR(50),
    @status CHAR(1) = 'A'
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @ID_Employee CHAR(11) = 'EMP' + @DNI_Person;
        DECLARE @ID_Gerent CHAR(11) = 'GER' + @DNI_Person;
        DECLARE @password VARBINARY(64) = HASHBYTES('SHA2_256', @plain_password);

        INSERT INTO PERSON (DNI_Person, first_name, last_name, email, address, phone)
        VALUES (@DNI_Person, @first_name, @last_name, @email, @address, @phone);

        INSERT INTO EMPLOYEE (ID_Employee, FK_DNI_Person, status)
        VALUES (@ID_Employee, @DNI_Person, @status);

        INSERT INTO GERENT (ID_Gerent, FK_ID_Employee, password)
        VALUES (@ID_Gerent, @ID_Employee, @password);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spPy_CreateCity
	@name VARCHAR(50)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO CITY (name)
        VALUES (@name);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spPy_CreateAdministrator
    @DNI_Person CHAR(20),
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @email VARCHAR(50) = NULL,
    @address VARCHAR(50) = NULL,
    @phone CHAR(20) = NULL,
    @plain_password VARCHAR(50),
    @status CHAR(1) = 'A',
	@FK_ID_City INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @ID_Employee CHAR(11) = 'EMP' + @DNI_Person;
        DECLARE @ID_Administrator CHAR(11) = 'ADM' + @DNI_Person;
        DECLARE @password VARBINARY(64) = HASHBYTES('SHA2_256', @plain_password);

        INSERT INTO PERSON (DNI_Person, first_name, last_name, email, address, phone)
        VALUES (@DNI_Person, @first_name, @last_name, @email, @address, @phone);

        INSERT INTO EMPLOYEE (ID_Employee, FK_DNI_Person, status)
        VALUES (@ID_Employee, @DNI_Person, @status);

        INSERT INTO ADMINISTRATOR (ID_Administrator, FK_ID_Employee, FK_ID_City, password)
        VALUES (@ID_Administrator, @ID_Employee, @FK_ID_City, @password);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spPy_CreateSalesperson
    @DNI_Person CHAR(20),
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @email VARCHAR(50) = NULL,
    @address VARCHAR(50) = NULL,
    @phone CHAR(20) = NULL,
    @plain_password VARCHAR(50),
    @status CHAR(1) = 'A',
	@FK_ID_City INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @ID_Employee CHAR(11) = 'EMP' + @DNI_Person;
        DECLARE @ID_Salesperson CHAR(11) = 'SAL' + @DNI_Person;
        DECLARE @password VARBINARY(64) = HASHBYTES('SHA2_256', @plain_password);

        INSERT INTO PERSON (DNI_Person, first_name, last_name, email, address, phone)
        VALUES (@DNI_Person, @first_name, @last_name, @email, @address, @phone);

        INSERT INTO EMPLOYEE (ID_Employee, FK_DNI_Person, status)
        VALUES (@ID_Employee, @DNI_Person, @status);

        INSERT INTO SALESPERSON (ID_Salesperson, FK_ID_Employee, FK_ID_City, password)
        VALUES (@ID_Salesperson, @ID_Employee, @FK_ID_City, @password);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spPy_CreateDriver
    @DNI_Person CHAR(20),
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @license_number CHAR(9),
    @email VARCHAR(50) = NULL,
    @address VARCHAR(50) = NULL,
    @phone CHAR(20) = NULL,
    @status CHAR(1) = 'A'
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @ID_Employee CHAR(11) = 'EMP' + @DNI_Person;
        DECLARE @ID_Driver CHAR(11) = 'DRI' + @DNI_Person;

        INSERT INTO PERSON (DNI_Person, first_name, last_name, email, address, phone)
        VALUES (@DNI_Person, @first_name, @last_name, @email, @address, @phone);

        INSERT INTO EMPLOYEE (ID_Employee, FK_DNI_Person, status)
        VALUES (@ID_Employee, @DNI_Person, @status);

        INSERT INTO DRIVER (ID_Driver, FK_ID_Employee, license_number)
        VALUES (@ID_Driver, @ID_Employee, @license_number);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spPy_CreateBus
    @ID_Bus CHAR(20),
    @brand VARCHAR(50),
    @model VARCHAR(50),
    @seats_count INT,
	@status CHAR(1) = 'A'
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO BUS (ID_Bus, brand, model, seats_count, status)
        VALUES (@ID_Bus, @brand, @model, @seats_count, @status);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spPy_CreateRoute
    @FK_ID_Origin_City INT,
    @FK_ID_Destination_City INT,
    @default_price MONEY,
	@status CHAR(1) = 'A'
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO ROUTE (FK_ID_Origin_City, FK_ID_Destination_City, default_price, status)
        VALUES (@FK_ID_Origin_City, @FK_ID_Destination_City, @default_price, @status);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Crear Gerente
EXEC spPy_CreateGerent @DNI_Person = '00000000', @first_name = '007', @last_name = '013', @plain_password = '0';