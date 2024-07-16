Public Class frmLoginAdmin


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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_Usuario.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txt_Contraseña.TextChanged
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Menu_Main.Show()
        Me.Close()


    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim dni As String = txt_Usuario.Text
        Dim password As String = txt_Contraseña.Text
        Dim controller As New ControllerAdmin()

        Try
            If controller.LoginAdministrator(dni, password) Then
                ' Inicio de sesión exitoso
                Dim session As Session = Session.GetInstance()
                MessageBox.Show("Inicio de sesión exitoso. Bienvenido, " & session.FirstName & "!")
                frmListarViaje.Show()
                Me.Close()
            Else
                ' Mostrar mensaje de error
                MessageBox.Show("Error: No se pudo iniciar sesión.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Class
