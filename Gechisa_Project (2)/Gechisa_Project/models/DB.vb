Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Module DB
    Private conexion As SqlConnection

    ' Obtiene la conexión a la base de datos
    Private Function GetConnection() As SqlConnection
        If conexion Is Nothing Then
            conexion = New SqlConnection("Server=GABRIEL\SQLSERVER19; Database=TICKET_MANAGEMENT_GECHISA; User ID=sa; Password=sa")
        End If
        Return conexion
    End Function

    ' Abre la conexión a la base de datos
    Public Sub Abrir_Conexion()
        Try
            If conexion Is Nothing OrElse conexion.State = ConnectionState.Closed Then
                GetConnection().Open()
                Console.WriteLine("Connected to SQL Server")
            End If
        Catch ex As Exception
            Console.WriteLine("Database connection failed: " & ex.Message)
            Throw
        End Try
    End Sub

    ' Cierra la conexión a la base de datos
    Public Sub Cerrar_Conexion()
        Try
            If conexion IsNot Nothing AndAlso conexion.State = ConnectionState.Open Then
                conexion.Close()
                Console.WriteLine("Connection to SQL Server closed")
            End If
        Catch ex As Exception
            Console.WriteLine("Failed to close the database connection: " & ex.Message)
            Throw
        End Try
    End Sub

    ' Ejecuta un procedimiento almacenado y devuelve un DataTable
    Public Function ExecuteProcedure(procedureName As String, parameters As Dictionary(Of String, Object)) As DataTable
        Dim result As New DataTable()
        Try
            Abrir_Conexion()
            Using cmd As New SqlCommand(procedureName, GetConnection())
                cmd.CommandType = CommandType.StoredProcedure
                For Each param As KeyValuePair(Of String, Object) In parameters
                    cmd.Parameters.AddWithValue(param.Key, param.Value)
                Next
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(result)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error executing stored procedure: " & procedureName & " - " & ex.Message)
            Throw
        Finally
            Cerrar_Conexion()
        End Try
        Return result
    End Function

    ' Ejecuta un procedimiento almacenado y devuelve un DataSet
    Public Function ExecuteProcedureWithDataSet(procedureName As String, parameters As Dictionary(Of String, Object)) As DataSet
        Dim result As New DataSet()
        Try
            Abrir_Conexion()
            Using cmd As New SqlCommand(procedureName, GetConnection())
                cmd.CommandType = CommandType.StoredProcedure
                For Each param As KeyValuePair(Of String, Object) In parameters
                    cmd.Parameters.AddWithValue(param.Key, param.Value)
                Next
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(result)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error executing stored procedure: " & procedureName & " - " & ex.Message)
            Throw
        Finally
            Cerrar_Conexion()
        End Try
        Return result
    End Function
End Module
