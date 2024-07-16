Public Class frmRegistrarConductor

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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        PanelDatos.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        frmOpciones.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        PanelDatos.Visible = False
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim controller As New ControllerGerent()
        Dim cboCiudad As Integer = 0
        Dim dni = txtDni.Text
        Dim nombre = txtNombre.Text
        Dim apellido = txtApellido.Text
        Dim correo = txtCorreo.Text
        Dim direccion = txtDireccion.Text
        Dim telefono = txtCelular.Text
        Dim brevete = txtBrevete.Text



        ' Registrar Conductor
        Try
            controller.RegisterDriver(dni, nombre, apellido, correo, direccion,
                                                telefono, brevete)
            MessageBox.Show("Conductor registrado")
            cargarDatos()
            PanelDatos.Visible = False
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub cargarDatos()
        Dim controller As New ControllerGerent()
        Try
            DataConductor.DataSource = controller.ShowDrivers()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        DataConductor.EnableHeadersVisualStyles = False
        Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle
        estilo.BackColor = Color.White
        estilo.ForeColor = Color.Black
        estilo.Font = New Font("Consolas", 10, FontStyle.Regular Or FontStyle.Bold)
        DataConductor.ColumnHeadersDefaultCellStyle = estilo
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ' Buscar el conductor
        Dim controller As New ControllerGerent()
        Try
            DataConductor.DataSource = controller.SearchDriver(txtBuscar.Text)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        DataConductor.EnableHeadersVisualStyles = False
        Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle
        estilo.BackColor = Color.White
        estilo.ForeColor = Color.Black
        estilo.Font = New Font("Consolas", 10, FontStyle.Regular Or FontStyle.Bold)
        DataConductor.ColumnHeadersDefaultCellStyle = estilo
    End Sub

    Private Sub frmRegistrarConductor_Load(sender As Object, e As EventArgs) Handles Me.Load
        cargarDatos()

    End Sub
End Class