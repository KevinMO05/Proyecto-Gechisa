Public Class frmRegistrarRuta

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

    ' Al cargar el formulario
    Private Sub frmRegistrarRuta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub

    ' Al buscar
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ' Buscar la ciudad
        Dim controller As New ControllerGerent()
        Try
            DataRutas.DataSource = controller.SearchRoute(txtBuscar.Text)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        DataRutas.EnableHeadersVisualStyles = False
        Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle
        estilo.BackColor = Color.White
        estilo.ForeColor = Color.Black
        estilo.Font = New Font("Consolas", 10, FontStyle.Regular Or FontStyle.Bold)
        DataRutas.ColumnHeadersDefaultCellStyle = estilo
    End Sub

    ' Botones

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        PanelDatos.Visible = True
        ' Cargar ciudades a los combos con GetCities guardando un dictionary con Integer para el id y String para el nombre
        Dim controller As New ControllerGerent()
        Try
            cities = controller.GetCities()
            ' Llenar los combos
            cbo_CiudadOrigen.Items.Clear()
            cbo_CiudadDestino.Items.Clear()
            For Each city As KeyValuePair(Of Integer, String) In cities
                cbo_CiudadOrigen.Items.Add(city.Value)
                cbo_CiudadDestino.Items.Add(city.Value)
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
        Dim price = txtPrecio.Text

        If (price = "") Then
            MessageBox.Show("Ingrese el precio")
            Return
        End If

        Dim controller As New ControllerGerent()
        Dim idOrigen = ""
        Dim idDestino = ""


        ' Obtener el id de la ciudad de origen
        For Each city As KeyValuePair(Of Integer, String) In cities
            If city.Value = cbo_CiudadOrigen.Text Then
                idOrigen = city.Key
                Exit For
            End If
        Next

        ' Obtener el id de la ciudad de destino
        For Each city As KeyValuePair(Of Integer, String) In cities
            If city.Value = cbo_CiudadDestino.Text Then
                idDestino = city.Key
                Exit For
            End If
        Next

        If (idOrigen = "" Or idDestino = "") Then
            MessageBox.Show("Por favor, seleccione una opción válida para todos los campos.")
            Return
        End If

        ' Registrar la ruta
        Try
            controller.RegisterRoute(idOrigen, idDestino, price)
            MessageBox.Show("Ruta registrada")
            cargarDatos()
            PanelDatos.Visible = False
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub

    ' Cargar datos
    Private Sub cargarDatos()
        Dim controller As New ControllerGerent()
        Try
            DataRutas.DataSource = controller.ShowRoutes()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        DataRutas.EnableHeadersVisualStyles = False
        Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle
        estilo.BackColor = Color.White
        estilo.ForeColor = Color.Black
        estilo.Font = New Font("Consolas", 10, FontStyle.Regular Or FontStyle.Bold)
        DataRutas.ColumnHeadersDefaultCellStyle = estilo
    End Sub

    ' Eliminar
    Private Sub DataRutas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataRutas.CellContentClick

        If e.ColumnIndex = DataRutas.Columns.Item("Eliminar").Index Then
            Dim controller As New ControllerGerent()
            Dim id As Integer = DataRutas.Rows(e.RowIndex).Cells(1).Value
            Try
                If controller.DeleteRoute(id) Then
                    MessageBox.Show("Ruta eliminada")
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
        cargarDatos()

    End Sub

End Class