Public Class frmOpciones

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

    Private Sub frmOpciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        frmRegistrarAdmin.Show()
        Me.Close()
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
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

    Private Sub btnVendedor_Click(sender As Object, e As EventArgs) Handles btnVendedor.Click
        frmRegistrarVendedor.Show()
        Me.Close()

    End Sub

    Private Sub btnConductor_Click(sender As Object, e As EventArgs) Handles btnConductor.Click
        frmRegistrarConductor.Show()
        Me.Close()

    End Sub

    Private Sub btnbus_Click(sender As Object, e As EventArgs) Handles btnbus.Click
        frmRegistrarBus.Show()
        Me.Close()

    End Sub

    Private Sub btnCiudad_Click(sender As Object, e As EventArgs) Handles btnCiudad.Click
        frmRegistrarCiudad.Show()
        Me.Close()

    End Sub

    Private Sub btnRuta_Click(sender As Object, e As EventArgs) Handles btnRuta.Click
        frmRegistrarRuta.Show()
        Me.Close()

    End Sub
End Class