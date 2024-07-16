Public Class Session
    Private Shared _instance As Session
    Public Property UserID As String
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Email As String
    Public Property Phone As String
    Public Property CityID As String
    Public Property CityName As String

    Private Sub New()
        ' Constructor privado para prevenir instanciación externa.
    End Sub

    Public Shared Function GetInstance() As Session
        If _instance Is Nothing Then
            _instance = New Session()
        End If
        Return _instance
    End Function

    Public Sub Logout()
        UserID = Nothing
        FirstName = Nothing
        LastName = Nothing
        Email = Nothing
        Phone = Nothing
        CityID = Nothing
        CityName = Nothing
    End Sub
End Class
