Imports System.Data

Public Class ControllerGerent
    ' Función para manejar el inicio de sesión del gerente
    Public Function LoginGerent(dni As String, password As String) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@DNI_Person", dni},
            {"@plain_password", password}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Login", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                ' Guardar datos en la sesión
                Dim session As Session = Session.GetInstance()
                session.UserID = row("ID_Gerent").ToString()
                session.FirstName = row("first_name").ToString()
                session.LastName = row("last_name").ToString()
                session.Email = row("email").ToString()
                session.Phone = row("phone").ToString()

                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

    ' Función para obtener la lista de ciudades
    Public Function ShowCities() As DataTable
        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Show_Cities", New Dictionary(Of String, Object)())

        If result.Rows.Count > 0 Then
            Return result
        Else
            MsgBox("No hay ciudades registradas.")
            Return Nothing
        End If
    End Function

    ' Función para buscar una ciudad
    Public Function SearchCity(search As String) As DataTable
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@search", search}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Search_City", parameters)

        If result.Rows.Count > 0 Then
            Return result
        Else
            Return Nothing
        End If
    End Function

    ' Función para registrar una nueva ciudad
    Public Function RegisterCity(cityName As String) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@city_name", cityName}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Register_City", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

    ' Función para actualizar una ciudad existente
    Public Function UpdateCity(cityID As Integer, cityName As String) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID_City", cityID},
            {"@city_name", cityName}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Update_City", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

    ' Función para eliminar una ciudad
    Public Function DeleteCity(cityID As Integer) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID_City", cityID}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Delete_City", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

    ' Función para mostrar todas las rutas
    Public Function ShowRoutes() As DataTable
        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Show_Routes", New Dictionary(Of String, Object)())

        If result.Rows.Count > 0 Then
            Return result
        Else
            MsgBox("No hay rutas registradas.")
            Return Nothing
        End If
    End Function

    ' Función para buscar una ruta
    Public Function SearchRoute(search As String) As DataTable
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@search", search}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Search_Route", parameters)

        If result.Rows.Count > 0 Then
            Return result
        Else
            Return Nothing
        End If
    End Function

    ' Función para traer las ciudades
    Public Function GetCities() As Dictionary(Of Integer, String)
        Dim result As DataTable = DB.ExecuteProcedure("spGerent_GetCities", New Dictionary(Of String, Object)())
        If result.Rows.Count > 0 Then
            ' Convierte result a Dictionary(Of Integer, String) city_id, city_name
            Dim cities As New Dictionary(Of Integer, String)
            For Each row As DataRow In result.Rows
                cities.Add(Convert.ToInt32(row("city_id")), row("city_name").ToString())
            Next
            Return cities
        Else
            Throw New Exception("No se recibieron datos de ciudades del servidor.")
        End If
    End Function


    ' Función para registrar una nueva ruta
    Public Function RegisterRoute(originCityID As Integer, destinationCityID As Integer, defaultPrice As Decimal) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@FK_ID_Origin_City", originCityID},
            {"@FK_ID_Destination_City", destinationCityID},
            {"@default_price", defaultPrice}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Register_Route", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

    ' Función para eliminar una ruta
    Public Function DeleteRoute(routeID As Integer) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID_Route", routeID}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Delete_Route", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

    ' Función para mostrar todos los administradores
    Public Function ShowAdministrators() As DataTable
        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Show_Administrators", New Dictionary(Of String, Object)())

        If result.Rows.Count > 0 Then
            Return result
        Else
            MsgBox("No hay administradores registrados.")
            Return Nothing
        End If
    End Function

    ' Función para buscar un administrador
    Public Function SearchAdministrator(search As String) As DataTable
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@search", search}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Search_Administrator", parameters)

        If result.Rows.Count > 0 Then
            Return result
        Else
            Return Nothing
        End If
    End Function

    ' Función para registrar un nuevo administrador
    Public Function RegisterAdministrator(dni As String, firstName As String, lastName As String, email As String, address As String, phone As String, password As String, cityID As Integer) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@DNI_Person", dni},
            {"@first_name", firstName},
            {"@last_name", lastName},
            {"@email", email},
            {"@address", address},
            {"@phone", phone},
            {"@plain_password", password},
            {"@FK_ID_City", cityID}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Register_Administrator", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

    ' Función para mostrar todos los vendedores
    Public Function ShowSalespersons() As DataTable
        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Show_Salespersons", New Dictionary(Of String, Object)())

        If result.Rows.Count > 0 Then
            Return result
        Else
            MsgBox("No hay vendedores registrados.")
            Return Nothing
        End If
    End Function

    ' Función para buscar un vendedor
    Public Function SearchSalesperson(search As String) As DataTable
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@search", search}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Search_Salesperson", parameters)

        If result.Rows.Count > 0 Then
            Return result
        Else
            Return Nothing
        End If
    End Function

    ' Función para registrar un nuevo vendedor
    Public Function RegisterSalesperson(dni As String, firstName As String, lastName As String, email As String, address As String, phone As String, password As String, cityID As Integer) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@DNI_Person", dni},
            {"@first_name", firstName},
            {"@last_name", lastName},
            {"@email", email},
            {"@address", address},
            {"@phone", phone},
            {"@plain_password", password},
            {"@FK_ID_City", cityID}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Register_Salesperson", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

    ' Función para mostrar todos los conductores
    Public Function ShowDrivers() As DataTable
        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Show_Drivers", New Dictionary(Of String, Object)())

        If result.Rows.Count > 0 Then
            Return result
        Else
            MsgBox("No hay conductores registrados.")
            Return Nothing
        End If
    End Function

    ' Función para buscar un conductor
    Public Function SearchDriver(search As String) As DataTable
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@search", search}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Search_Driver", parameters)

        If result.Rows.Count > 0 Then
            Return result
        Else
            Return Nothing
        End If
    End Function

    ' Función para registrar un nuevo conductor
    Public Function RegisterDriver(dni As String, firstName As String, lastName As String, email As String, address As String, phone As String, licenseNumber As String) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@DNI_Person", dni},
            {"@first_name", firstName},
            {"@last_name", lastName},
            {"@email", email},
            {"@address", address},
            {"@phone", phone},
            {"@license_number", licenseNumber}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Register_Driver", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

    ' Función para mostrar todos los autobuses
    Public Function ShowBuses() As DataTable
        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Show_Buses", New Dictionary(Of String, Object)())

        If result.Rows.Count > 0 Then
            Return result
        Else
            MsgBox("No hay autobuses registrados.")
            Return Nothing
        End If
    End Function

    ' Función para buscar un autobús
    Public Function SearchBus(search As String) As DataTable
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@search", search}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Search_Bus", parameters)

        If result.Rows.Count > 0 Then
            Return result
        Else
            Return Nothing
        End If
    End Function

    ' Función para registrar un nuevo autobús
    Public Function RegisterBus(busID As String, brand As String, model As String, seatsCount As Integer) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID_Bus", busID},
            {"@brand", brand},
            {"@model", model},
            {"@seats_count", seatsCount}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Register_Bus", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

    ' Función para actualizar un autobús existente
    Public Function UpdateBus(busID As String, brand As String, model As String, seatsCount As Integer) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID_Bus", busID},
            {"@brand", brand},
            {"@model", model},
            {"@seats_count", seatsCount}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Update_Bus", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

    Public Function DeleteBus(busID As String) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
        {"@ID_Bus", busID}
    }

        Dim result As DataTable = DB.ExecuteProcedure("spGerent_Delete_Bus", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

End Class
