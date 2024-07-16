Public Class frmRegistrarCiudad
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
    Private Sub frmRegistrarCiudad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub

    ' Al buscar
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ' Buscar la ciudad
        Dim controller As New ControllerGerent()
        Try
            DataCities.DataSource = controller.SearchCity(txtBuscar.Text)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        DataCities.EnableHeadersVisualStyles = False
        Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle
        estilo.BackColor = Color.White
        estilo.ForeColor = Color.Black
        estilo.Font = New Font("Consolas", 10, FontStyle.Regular Or FontStyle.Bold)
        DataCities.ColumnHeadersDefaultCellStyle = estilo
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

        Dim cityName = txtCiudad.Text
        Dim controller As New ControllerGerent

        Try
            If controller.RegisterCity(cityName) Then
                ' Registro exitoso
                MessageBox.Show("Ciudad registrada exitosamente.")
                PanelDatos.Visible = False
                txtCiudad.Text = ""
            Else
                ' Mostrar mensaje de error
                MessageBox.Show("Error: No se pudo registrar la ciudad.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        ' Actualizar la lista de ciudades
        cargarDatos()
    End Sub

    ' Funciones
    Private Function cargarDatos()
        Dim controller As New ControllerGerent()
        Try
            DataCities.DataSource = controller.ShowCities()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            Return False
        End Try

        DataCities.EnableHeadersVisualStyles = False
        Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle
        estilo.BackColor = Color.White
        estilo.ForeColor = Color.Black
        estilo.Font = New Font("Consolas", 10, FontStyle.Regular Or FontStyle.Bold)
        DataCities.ColumnHeadersDefaultCellStyle = estilo
    End Function

    ' Eliminar
    Private Sub DataCities_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataCities.CellContentClick
        If e.ColumnIndex = DataCities.Columns.Item("Eliminar").Index Then
            Dim controller As New ControllerGerent()
            Dim id As Integer = DataCities.CurrentRow.Cells(1).Value
            Dim city As String = DataCities.CurrentRow.Cells(2).Value

            Dim result As Integer = MessageBox.Show("¿Está seguro de eliminar la ciudad " & city & "?", "Eliminar", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Try
                    If controller.DeleteCity(id) Then
                        MessageBox.Show("Ciudad eliminada exitosamente.")
                    Else
                        MessageBox.Show("Error: No se pudo eliminar la ciudad.")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End If

            cargarDatos()
        End If
    End Sub
End Class