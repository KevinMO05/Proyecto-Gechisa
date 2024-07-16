Public Class frmRegistrarBus


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


    ' Al cargar
    Private Sub frmRegistrarBus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub

    ' Al buscar
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ' Buscar la ciudad
        Dim controller As New ControllerGerent()
        Try
            DataBus.DataSource = controller.SearchBus(txtBuscar.Text)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        DataBus.EnableHeadersVisualStyles = False
        Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle
        estilo.BackColor = Color.White
        estilo.ForeColor = Color.Black
        estilo.Font = New Font("Consolas", 10, FontStyle.Regular Or FontStyle.Bold)
        DataBus.ColumnHeadersDefaultCellStyle = estilo
    End Sub

    ' Botones

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
        Dim busId = txtPlaca.Text
        Dim brand = txtModelo.Text
        Dim model = txtMarca.Text
        Dim seats_count = txtAsientos.Text

        If (seats_count = "") Then
            MessageBox.Show("Por favor, ingrese la cantidad de asientos")
            Return
        End If

        Dim controller As New ControllerGerent

        Try
            controller.RegisterBus(busId, brand, model, seats_count)
            MessageBox.Show("Bus registrado correctamente")
            PanelDatos.Visible = False
            txtPlaca.Text = ""
            txtModelo.Text = ""
            txtMarca.Text = ""
            txtAsientos.Text = ""
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        cargarDatos()
    End Sub

    ' Funciones
    Private Function cargarDatos()
        Dim controller As New ControllerGerent
        DataBus.DataSource = controller.ShowBuses()
    End Function

    ' Eliminar
    Private Sub DataBus_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataBus.CellContentClick

        If e.ColumnIndex = DataBus.Columns.Item("Eliminar").Index Then
            Dim controller As New ControllerGerent
            Dim busId = DataBus.Rows(e.RowIndex).Cells(1).Value
            Try
                controller.DeleteBus(busId)
                MessageBox.Show("Bus eliminado correctamente")
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try

            cargarDatos()

        End If

    End Sub
End Class