Public Class frmVentaBoletos
    Dim ex, ey As Integer
    Dim Arrastre As Boolean
    Dim estadoVender As Boolean
    Dim cities As Dictionary(Of Integer, String)
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

    ' Al cargar, establecer combobox de ciudades
    Private Sub frmVentaBoletos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClienteEncontrado()
        estadoVender = False
        Dim controller As New ControllerVendedor()
        Try
            cities = controller.GetDestinationCities()
            cbo_CiudadOrigen.Items.Clear()
            cbo_CiudadOrigen.Items.Add(Session.GetInstance().CityName)
            cbo_CiudadOrigen.SelectedIndex = 0

            cbo_CiudadDestino.Items.Clear()
            For Each city As KeyValuePair(Of Integer, String) In cities
                cbo_CiudadDestino.Items.Add(city.Value)
            Next
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
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

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        ' Buscar cliente por DNI, si hay error entonces ClienteNoEncontrado
        Dim controller As New ControllerVendedor()
        Try
            Dim cliente As DataRow = controller.SearchClient(txtDni.Text).Rows(0)
            txtNombre.Text = cliente("first_name")
            txtApellido.Text = cliente("last_name")
            txtTelefono.Text = cliente("phone")
            txtCorreo.Text = cliente("email")
            txtDireccion.Text = cliente("address")
            ClienteEncontrado()
        Catch ex As Exception
            If ex.Message.ToString = "1" Then
                MessageBox.Show("Cliente no encontrado")
                ClienteNoEncontrado()
            Else
                MessageBox.Show(ex.Message)
            End If
        End Try
    End Sub

    Private Function ClienteNoEncontrado() As Boolean
        ' Activa todos los txt y el btnRegistrarCliente, además desactiva el btnVenderBoleto
        txtNombre.Enabled = True
        txtApellido.Enabled = True
        txtDni.Enabled = True
        txtTelefono.Enabled = True
        txtCorreo.Enabled = True
        txtDireccion.Enabled = True

        btnRegistrarCliente.Enabled = True
        estadoVender = False
        Return True
    End Function

    Private Function ClienteEncontrado() As Boolean
        ' Desactiva todos los txt y el btnRegistrarCliente, además activa el btnVenderBoleto
        txtNombre.Enabled = False
        txtApellido.Enabled = False
        txtTelefono.Enabled = False
        txtCorreo.Enabled = False
        txtDireccion.Enabled = False

        btnRegistrarCliente.Enabled = False
        estadoVender = True
        Return True
    End Function

    'Funcion limpiarCampos
    Private Sub LimpiarCampos()
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtDni.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
        txtDireccion.Text = ""
    End Sub

    Private Sub cbo_CiudadDestino_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbo_CiudadDestino.SelectedValueChanged
        actualizarViajes()
    End Sub

    Private Sub btnRegistrarCliente_Click(sender As Object, e As EventArgs) Handles btnRegistrarCliente.Click
        ' Registrar cliente con los datos ingresados
        Dim controller As New ControllerVendedor()
        Try
            controller.RegisterClient(txtDni.Text, txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtDireccion.Text, txtTelefono.Text)
            MessageBox.Show("Cliente registrado")
            ClienteEncontrado()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Vender boleto
    Private Sub DataViajesBoletos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataViajesBoletos.CellContentClick

        If e.ColumnIndex = DataViajesBoletos.Columns.Item("VenderBoleto").Index Then
            If estadoVender = False Then
                MessageBox.Show("Primero debe tener un cliente válido")
                Return
            End If

            Dim controller As New ControllerVendedor()
            Dim dni As String = txtDni.Text
            Dim id As Integer = DataViajesBoletos.Rows(e.RowIndex).Cells(1).Value
            Try
                If controller.SellTicket(dni, id) Then
                    MessageBox.Show("Boleto Registrado")
                    actualizarViajes()
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Function actualizarViajes()
        ' Al cambiar el destino, obtener los viajes disponibles
        Dim controller As New ControllerVendedor()
        Try
            Dim destinationCityID As Integer
            For Each city As KeyValuePair(Of Integer, String) In cities
                If city.Value = cbo_CiudadDestino.Text Then
                    destinationCityID = city.Key
                    Exit For
                End If
            Next
            Dim trips As DataTable = controller.GetTripsByRoute(destinationCityID)
            DataViajesBoletos.DataSource = trips
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        Return True
    End Function

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        actualizarViajes()
    End Sub
End Class