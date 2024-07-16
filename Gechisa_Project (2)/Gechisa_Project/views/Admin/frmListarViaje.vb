Public Class frmListarViaje

    Dim ex, ey As Integer
    Dim Arrastre As Boolean

    Private Sub pnlHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelTitulo.MouseDown
        ex = e.X
        ey = e.Y
        Arrastre = True
    End Sub

    Private Sub pnlHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelTitulo.MouseMove
        If Arrastre Then
            Me.Location = Me.PointToScreen(New Point(Menu_Main.MousePosition.X - Me.Location.X - ex, Menu_Main.MousePosition.Y - Me.Location.Y - ey))
        End If
    End Sub

    Private Sub pnlHeader_MouseUp(sender As Object, e As MouseEventArgs) Handles panelTitulo.MouseUp
        Arrastre = False
    End Sub

    ' Al cargar el formulario
    Private Sub frmListarViaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        ' Mensaje de confirmación para cerrar sesión
        Dim result As Integer = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            Return
        End If

        ' Limpiar la sesión y mostrar el formulario de inicio de sesión
        Session.GetInstance().Logout()
        Menu_Main.Show()
        Me.Close()
    End Sub

    Private Sub btnCrearViaje_Click(sender As Object, e As EventArgs) Handles btnCrearViaje.Click
        frmCrearViaje.Show()
        Me.Close()
    End Sub

    Private Function cargarDatos()
        Dim controller As New ControllerAdmin()
        Try
            DataViajes.DataSource = controller.ShowTrips()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        DataViajes.EnableHeadersVisualStyles = False
        Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle
        estilo.BackColor = Color.White
        estilo.ForeColor = Color.Black
        estilo.Font = New Font("Consolas", 10, FontStyle.Regular Or FontStyle.Bold)
        DataViajes.ColumnHeadersDefaultCellStyle = estilo
        Return True
    End Function

    ' Registrar salida y llegada
    Private Sub DataViajes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataViajes.CellContentClick

        If e.ColumnIndex = DataViajes.Columns.Item("RegistrarSalida").Index Then
            Dim controller As New ControllerAdmin()
            Dim id As Integer = DataViajes.Rows(e.RowIndex).Cells(2).Value
            Try
                If controller.StartTrip(id) Then
                    MessageBox.Show("Salida registrada")
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
        If e.ColumnIndex = DataViajes.Columns.Item("RegistrarLlegada").Index Then
            Dim controller As New ControllerAdmin()
            Dim id As Integer = DataViajes.Rows(e.RowIndex).Cells(2).Value
            Try
                If controller.FinishTrip(id) Then
                    MessageBox.Show("Llegada registrada")
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
        cargarDatos()
    End Sub
End Class