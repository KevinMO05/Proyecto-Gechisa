Public Class frmCrearViaje

    Dim destinationCities As Dictionary(Of Integer, String)
    Dim buses As Dictionary(Of String, String)
    Dim drivers As Dictionary(Of String, String)

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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
        PanelDatos.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        frmListarViaje.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        PanelDatos.Visible = False
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        Dim controller As New ControllerAdmin()
        Try
            Dim destinationCityID = ""
            Dim busID = ""
            Dim driverID = ""
            Dim departureDateTime

            ' Obtiene el ID de la ciudad de destino
            For Each city As KeyValuePair(Of Integer, String) In destinationCities
                If city.Value = cbo_CiudadDestino.SelectedItem Then
                    destinationCityID = city.Key
                    Exit For
                End If
            Next

            ' Obtiene el ID del bus
            For Each bus As KeyValuePair(Of String, String) In buses
                If bus.Value = cbo_Bus.SelectedItem Then
                    busID = bus.Key
                    Exit For
                End If
            Next
            ' Obtiene el ID del conductor
            For Each driver As KeyValuePair(Of String, String) In drivers
                If driver.Value = cboConductor.SelectedItem Then
                    driverID = driver.Key
                    Exit For
                End If
            Next
            ' Obtiene la fecha y hora de salida
            departureDateTime = dtp_FechaHora.Value

            If (destinationCityID = "" Or busID = "" Or driverID = "") Then
                MessageBox.Show("Por favor, seleccione una opción válida para todos los campos.")
                Return
            End If

            ' Ejecuta CreateTrip con los datos obtenidos
            If controller.CreateTrip(destinationCityID, busID, driverID, departureDateTime) Then
                MessageBox.Show("Viaje creado exitosamente.")
            Else
                MessageBox.Show("No se pudo crear el viaje.")
            End If

            frmListarViaje.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub

    Private Sub frmCrearViaje_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim controller As New ControllerAdmin()
        Try
            dtp_FechaHora.Value = DateTime.Now
            ' Ejecuta GetTripCreationOptions y guarda el resultado en una variable
            Dim result As Tuple(Of Dictionary(Of Integer, String), Dictionary(Of String, String), Dictionary(Of String, String)) = controller.GetTripCreationOptions()

            destinationCities = result.Item1
            buses = result.Item2
            drivers = result.Item3

            ' Establece el comboBox Origen CON SOLO LA OPCIÓN DEL CITY DE LA SESIÓN ACTUAL
            cbo_CiudadOrigen.Items.Clear()
            cbo_CiudadOrigen.Items.Add(Session.GetInstance().CityName)
            cbo_CiudadOrigen.SelectedIndex = 0

            ' Llena los ComboBox de con los datos obtenidos
            cbo_CiudadDestino.Items.Clear()
            For Each city As KeyValuePair(Of Integer, String) In destinationCities
                cbo_CiudadDestino.Items.Add(city.Value)
            Next
            cbo_Bus.Items.Clear()
            For Each bus As KeyValuePair(Of String, String) In buses
                cbo_Bus.Items.Add(bus.Value)
            Next
            cboConductor.Items.Clear()
            For Each driver As KeyValuePair(Of String, String) In drivers
                cboConductor.Items.Add(driver.Value)
            Next
        Catch ex As Exception
        End Try
    End Sub
End Class