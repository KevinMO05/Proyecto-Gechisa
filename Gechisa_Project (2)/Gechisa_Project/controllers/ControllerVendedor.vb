Imports System.Data

Public Class ControllerVendedor
    ' Función para manejar el inicio de sesión del vendedor
    Public Function LoginVendedor(dni As String, password As String) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@DNI_Person", dni},
            {"@plain_password", password}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spSalesperson_Login", parameters)

        If result.Rows.Count > 0 Then
            Dim row As DataRow = result.Rows(0)
            Dim statusCode As Integer = Convert.ToInt32(row("StatusCode"))

            If statusCode = 0 Then
                ' Guardar datos en la sesión
                Dim session As Session = Session.GetInstance()
                session.UserID = row("ID_Salesperson").ToString()
                session.FirstName = row("first_name").ToString()
                session.LastName = row("last_name").ToString()
                session.Email = row("email").ToString()
                session.Phone = row("phone").ToString()
                session.CityID = Convert.ToInt32(row("city_id"))
                session.CityName = row("city_name").ToString()

                Return True
            Else
                Throw New Exception(row("ErrorMessage").ToString())
            End If
        Else
            Throw New Exception("No se recibió respuesta del servidor.")
        End If
    End Function

    ' Función para buscar un cliente
    Public Function SearchClient(dni As String) As DataTable
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@DNI_Person", dni}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spSalesperson_SearchClient", parameters)

        If result.Rows.Count > 0 Then
            Dim statusCode As Integer = Convert.ToInt32(result.Rows(0)("StatusCode"))
            If statusCode = 0 Then
                Return result
            ElseIf statusCode = 1 Then
                Throw New Exception(statusCode)
            Else
                Throw New Exception(result.Rows(0)("ErrorMessage").ToString())
            End If

        Else
            Throw New Exception("Cliente no encontrado.")
        End If
    End Function

    ' Función para registrar un cliente
    Public Function RegisterClient(dni As String, firstName As String, lastName As String, Optional email As String = Nothing, Optional address As String = Nothing, Optional phone As String = Nothing) As Boolean
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@DNI_Person", dni},
            {"@first_name", firstName},
            {"@last_name", lastName},
            {"@email", If(email Is Nothing, DBNull.Value, email)},
            {"@address", If(address Is Nothing, DBNull.Value, address)},
            {"@phone", If(phone Is Nothing, DBNull.Value, phone)}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spSalesperson_RegisterClient", parameters)

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

    ' Función para obtener las ciudades de destino desde una ciudad de origen
    Public Function GetDestinationCities() As Dictionary(Of Integer, String)
        Dim originCityID As Integer = Session.GetInstance().CityID
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID_origin_city", originCityID}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spSalesperson_GetDestinationCities", parameters)

        If result.Rows.Count > 0 Then
            Dim cities As New Dictionary(Of Integer, String)
            For Each row As DataRow In result.Rows
                cities.Add(Convert.ToInt32(row("destination_city_id")), row("destination_city_name").ToString())
            Next
            Return cities
        Else
            Throw New Exception("No se recibieron datos de ciudades de destino del servidor.")
        End If
    End Function

    ' Función para obtener los viajes disponibles por ruta
    Public Function GetTripsByRoute(destinationCityID As Integer) As DataTable
        Dim originCityID As Integer = Session.GetInstance().CityID
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID_origin_city", originCityID},
            {"@ID_destination_city", destinationCityID}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spSalesperson_GetTripsByRoute", parameters)

        If result.Rows.Count > 0 Then
            Return result
        Else
            Throw New Exception("No se recibieron datos de viajes del servidor.")
        End If
    End Function

    ' Función para vender un boleto
    Public Function SellTicket(dni As String, tripID As Integer) As Boolean
        Dim clientID As String = "CLI" & dni
        Dim salespersonID As String = Session.GetInstance().UserID
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID_Client", clientID},
            {"@ID_Salesperson", salespersonID},
            {"@ID_Trip", tripID}
        }

        Dim result As DataTable = DB.ExecuteProcedure("spSalesperson_SellTicket", parameters)

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
