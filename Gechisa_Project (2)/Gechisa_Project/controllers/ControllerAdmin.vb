Imports System.Data

Public Class ControllerAdmin
    ' Función para manejar el inicio de sesión del administrador
    Public Function LoginAdministrator(dni As String, password As String) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@DNI_Person", dni},
            {"@plain_password", password}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spAdministrator_Login", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                ' Guardar datos en la sesión
                Dim session As Session = Session.GetInstance()
                session.UserID = row("ID_Administrator").ToString()
                session.FirstName = row("first_name").ToString()
                session.LastName = row("last_name").ToString()
                session.Email = row("email").ToString()
                session.Phone = row("phone").ToString()
                session.CityID = row("city_id").ToString()
                session.CityName = row("city_name").ToString()

                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

    ' Función para obtener la lista de viajes
    Public Function ShowTrips() As DataTable
        Dim result As DataTable = DB.ExecuteProcedure("spAdministrator_ShowTrips", New Dictionary(Of String, Object)())

        If result.Rows.Count > 0 Then
            Return result
        Else
            Throw New Exception("No se recibieron datos de viajes del servidor.")
        End If
    End Function

    ' Función para obtener opciones de creación de viaje
    Public Function GetTripCreationOptions() As Tuple(Of Dictionary(Of Integer, String), Dictionary(Of String, String), Dictionary(Of String, String))
        Dim originCityID As Integer = Session.GetInstance().CityID
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID_origin_city", originCityID}
        }

        Dim result As DataSet = DB.ExecuteProcedureWithDataSet("spAdministrator_CreateTrip_GetOptions", parameters)

        If result.Tables.Count >= 3 Then
            ' Convertir las tablas en diccionarios
            Dim destinationCities As New Dictionary(Of Integer, String)
            For Each row As DataRow In result.Tables(0).Rows
                destinationCities.Add(Convert.ToInt32(row("destination_city_id")), row("destination_city_name").ToString())
            Next

            Dim buses As New Dictionary(Of String, String)
            For Each row As DataRow In result.Tables(1).Rows
                buses.Add(row("bus_placa").ToString(), row("bus_placa").ToString() & " - " & row("seats_count"))
            Next

            Dim drivers As New Dictionary(Of String, String)
            For Each row As DataRow In result.Tables(2).Rows
                drivers.Add(row("driver_id").ToString(), row("driver_id").ToString() & " - " & row("driver_first_name").ToString() & " " & row("driver_last_name").ToString())
            Next

            Return New Tuple(Of Dictionary(Of Integer, String), Dictionary(Of String, String), Dictionary(Of String, String))(destinationCities, buses, drivers)
        Else
            Throw New Exception("No se recibieron datos de opciones del servidor.")
        End If
    End Function

    ' Función para crear un viaje
    Public Function CreateTrip(destinationCityID As Integer, busID As String, driverID As String, scheduledDeparture As DateTime, Optional price As Decimal? = Nothing) As Boolean
        Dim originCityID As Integer = Session.GetInstance().CityID
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@FK_ID_Origin_City", originCityID},
            {"@FK_ID_Destination_City", destinationCityID},
            {"@FK_ID_Bus", busID},
            {"@FK_ID_Driver", driverID},
            {"@scheduled_departure_dateTime", scheduledDeparture}
        }

        If price.HasValue Then
            parameters.Add("@price", price.Value)
        End If

        Dim result As DataTable = DB.ExecuteProcedure("spAdministrator_CreateTrip", parameters)

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

    ' Función para iniciar un viaje
    Public Function StartTrip(tripID As Integer, Optional dateTime As DateTime? = Nothing) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID_Trip", tripID}
        }

        If dateTime.HasValue Then
            parameters.Add("@dateTime", dateTime.Value)
        End If

        Dim result As DataTable = DB.ExecuteProcedure("spAdministrator_Trip_Start", parameters)

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

    ' Función para finalizar un viaje
    Public Function FinishTrip(tripID As Integer, Optional dateTime As DateTime? = Nothing) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID_Trip", tripID}
        }

        If dateTime.HasValue Then
            parameters.Add("@dateTime", dateTime.Value)
        End If

        Dim result As DataTable = DB.ExecuteProcedure("spAdministrator_Trip_Finish", parameters)

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
