Public Class frmRegistrarAdmin

    Dim cities As Dictionary(Of Integer, String)
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

    ' Carga Inicial
    Private Sub frmRegistrarAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()

    End Sub

    ' Botones

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        PanelDatos.Visible = True

        Dim controller As New ControllerGerent()
        Try
            cities = controller.GetCities()
            ' Llenar los combos
            Select_ciudad.Items.Clear()
            For Each city As KeyValuePair(Of Integer, String) In cities
                Select_ciudad.Items.Add(city.Value)
            Next
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try


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
        Dim ciudad = Select_ciudad.Text
        Dim contraseña = txtContraseña.Text

        ' Obtener el id de la ciudad 
        For Each city As KeyValuePair(Of Integer, String) In cities
            If city.Value = ciudad Then
                cboCiudad = city.Key
                Exit For
            End If
        Next

        ' Registrar Administrador
        Try
            controller.RegisterAdministrator(dni, nombre, apellido, correo, direccion,
                                                telefono, contraseña, cboCiudad)
            MessageBox.Show("Admininstrador registrado")
            cargarDatos()
            PanelDatos.Visible = False
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub cargarDatos()
        Dim controller As New ControllerGerent()
        Try
            DataAdmins.DataSource = controller.ShowAdministrators()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        DataAdmins.EnableHeadersVisualStyles = False
        Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle
        estilo.BackColor = Color.White
        estilo.ForeColor = Color.Black
        estilo.Font = New Font("Consolas", 10, FontStyle.Regular Or FontStyle.Bold)
        DataAdmins.ColumnHeadersDefaultCellStyle = estilo
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ' Buscar el admin
        Dim controller As New ControllerGerent()
        Try
            DataAdmins.DataSource = controller.SearchAdministrator(txtBuscar.Text)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        DataAdmins.EnableHeadersVisualStyles = False
        Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle
        estilo.BackColor = Color.White
        estilo.ForeColor = Color.Black
        estilo.Font = New Font("Consolas", 10, FontStyle.Regular Or FontStyle.Bold)
        DataAdmins.ColumnHeadersDefaultCellStyle = estilo
    End Sub
End Class