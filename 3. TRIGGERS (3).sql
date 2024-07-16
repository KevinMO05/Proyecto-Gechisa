-- Triggers for EMPLOYEE table
CREATE TRIGGER trg_employee_insert_update
ON EMPLOYEE
AFTER INSERT, UPDATE
AS
BEGIN
    INSERT INTO HISTORY_EMPLOYEE (FK_ID_Employee, status, change_datetime)
    SELECT ID_Employee, status, GETDATE()
    FROM INSERTED;
END;
GO

CREATE TRIGGER trg_employee_delete
ON EMPLOYEE
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR ('No se pueden eliminar datos de esta tabla', 16, 1);
    ROLLBACK TRANSACTION;
END;
GO

-- Triggers for BUS table
CREATE TRIGGER trg_bus_insert_update
ON BUS
AFTER INSERT, UPDATE
AS
BEGIN
    INSERT INTO HISTORY_BUS (FK_ID_Bus, status, change_datetime)
    SELECT ID_Bus, status, GETDATE()
    FROM INSERTED;
END;
GO

-- Triggers for ROUTE table
CREATE TRIGGER trg_route_insert_update
ON ROUTE
AFTER INSERT, UPDATE
AS
BEGIN
    INSERT INTO HISTORY_ROUTE (FK_ID_Route, status, change_datetime)
    SELECT ID_Route, status, GETDATE()
    FROM INSERTED;
END;
GO

-- Triggers for RESERVE table
CREATE TRIGGER trg_reserve_insert_update
ON RESERVE
AFTER INSERT, UPDATE
AS
BEGIN
    INSERT INTO HISTORY_RESERVE (FK_ID_Reserve, status, change_datetime)
    SELECT ID_Reserve, status, GETDATE()
    FROM INSERTED;
END;
GO

CREATE TRIGGER trg_reserve_delete
ON RESERVE
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR ('No se pueden eliminar datos de esta tabla', 16, 1);
    ROLLBACK TRANSACTION;
END;
GO

-- Triggers for TRIP table
CREATE TRIGGER trg_trip_insert_update
ON TRIP
AFTER INSERT, UPDATE
AS
BEGIN
    INSERT INTO HISTORY_TRIP (FK_ID_Trip, status, change_datetime)
    SELECT ID_Trip, status, GETDATE()
    FROM INSERTED;
END;
GO

CREATE TRIGGER trg_trip_delete
ON TRIP
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR ('No se pueden eliminar datos de esta tabla', 16, 1);
    ROLLBACK TRANSACTION;
END;
GO

-- Triggers for TICKET table
CREATE TRIGGER trg_ticket_insert_update
ON TICKET
AFTER INSERT, UPDATE
AS
BEGIN
    INSERT INTO HISTORY_TICKET (FK_ID_Ticket, status, change_datetime)
    SELECT ID_Ticket, status, GETDATE()
    FROM INSERTED;
END;
GO

CREATE TRIGGER trg_ticket_delete
ON TICKET
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR ('No se pueden eliminar datos de esta tabla', 16, 1);
    ROLLBACK TRANSACTION;
END;
GO
