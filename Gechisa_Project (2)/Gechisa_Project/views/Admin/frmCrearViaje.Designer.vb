<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCrearViaje
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnRegresar = New Button()
        lb_Tittle = New Label()
        panelTitulo = New Panel()
        PanelDatos = New Panel()
        dtp_FechaHora = New DateTimePicker()
        cboConductor = New ComboBox()
        Label5 = New Label()
        Label6 = New Label()
        cbo_Bus = New ComboBox()
        cbo_CiudadDestino = New ComboBox()
        cbo_CiudadOrigen = New ComboBox()
        btnRegistrar = New Button()
        Label9 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        panelTitulo.SuspendLayout()
        PanelDatos.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnRegresar
        ' 
        btnRegresar.FlatAppearance.BorderSize = 0
        btnRegresar.FlatStyle = FlatStyle.Flat
        btnRegresar.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRegresar.Location = New Point(626, 3)
        btnRegresar.Name = "btnRegresar"
        btnRegresar.Size = New Size(55, 48)
        btnRegresar.TabIndex = 1
        btnRegresar.Text = "X"
        btnRegresar.UseVisualStyleBackColor = True
        ' 
        ' lb_Tittle
        ' 
        lb_Tittle.AutoSize = True
        lb_Tittle.Font = New Font("Consolas", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lb_Tittle.Location = New Point(29, 12)
        lb_Tittle.Name = "lb_Tittle"
        lb_Tittle.Size = New Size(127, 34)
        lb_Tittle.TabIndex = 0
        lb_Tittle.Text = "GECHISA"
        ' 
        ' panelTitulo
        ' 
        panelTitulo.BackColor = Color.Gold
        panelTitulo.Controls.Add(btnRegresar)
        panelTitulo.Controls.Add(lb_Tittle)
        panelTitulo.Location = New Point(0, 0)
        panelTitulo.Name = "panelTitulo"
        panelTitulo.Size = New Size(684, 58)
        panelTitulo.TabIndex = 2
        ' 
        ' PanelDatos
        ' 
        PanelDatos.BackColor = Color.White
        PanelDatos.Controls.Add(dtp_FechaHora)
        PanelDatos.Controls.Add(cboConductor)
        PanelDatos.Controls.Add(Label5)
        PanelDatos.Controls.Add(Label6)
        PanelDatos.Controls.Add(cbo_Bus)
        PanelDatos.Controls.Add(cbo_CiudadDestino)
        PanelDatos.Controls.Add(cbo_CiudadOrigen)
        PanelDatos.Controls.Add(btnRegistrar)
        PanelDatos.Controls.Add(Label9)
        PanelDatos.Controls.Add(Label3)
        PanelDatos.Controls.Add(Label2)
        PanelDatos.Controls.Add(Label1)
        PanelDatos.Location = New Point(0, 58)
        PanelDatos.Name = "PanelDatos"
        PanelDatos.Size = New Size(684, 443)
        PanelDatos.TabIndex = 2
        ' 
        ' dtp_FechaHora
        ' 
        dtp_FechaHora.Format = DateTimePickerFormat.Time
        dtp_FechaHora.Location = New Point(406, 179)
        dtp_FechaHora.Name = "dtp_FechaHora"
        dtp_FechaHora.Size = New Size(177, 25)
        dtp_FechaHora.TabIndex = 30
        dtp_FechaHora.Value = New Date(2024, 7, 1, 18, 49, 9, 0)
        ' 
        ' cboConductor
        ' 
        cboConductor.FormattingEnabled = True
        cboConductor.Location = New Point(406, 101)
        cboConductor.Name = "cboConductor"
        cboConductor.Size = New Size(177, 25)
        cboConductor.TabIndex = 27
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(406, 154)
        Label5.Name = "Label5"
        Label5.Size = New Size(162, 19)
        Label5.TabIndex = 25
        Label5.Text = "Fecha programada:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(406, 76)
        Label6.Name = "Label6"
        Label6.Size = New Size(99, 19)
        Label6.TabIndex = 24
        Label6.Text = "Conductor:"
        ' 
        ' cbo_Bus
        ' 
        cbo_Bus.FormattingEnabled = True
        cbo_Bus.Location = New Point(139, 245)
        cbo_Bus.Name = "cbo_Bus"
        cbo_Bus.Size = New Size(177, 25)
        cbo_Bus.TabIndex = 23
        ' 
        ' cbo_CiudadDestino
        ' 
        cbo_CiudadDestino.FormattingEnabled = True
        cbo_CiudadDestino.Location = New Point(139, 179)
        cbo_CiudadDestino.Name = "cbo_CiudadDestino"
        cbo_CiudadDestino.Size = New Size(177, 25)
        cbo_CiudadDestino.TabIndex = 22
        ' 
        ' cbo_CiudadOrigen
        ' 
        cbo_CiudadOrigen.FormattingEnabled = True
        cbo_CiudadOrigen.Location = New Point(139, 101)
        cbo_CiudadOrigen.Name = "cbo_CiudadOrigen"
        cbo_CiudadOrigen.Size = New Size(177, 25)
        cbo_CiudadOrigen.TabIndex = 21
        ' 
        ' btnRegistrar
        ' 
        btnRegistrar.BackColor = Color.DodgerBlue
        btnRegistrar.Cursor = Cursors.Hand
        btnRegistrar.FlatAppearance.BorderSize = 0
        btnRegistrar.FlatStyle = FlatStyle.Flat
        btnRegistrar.Font = New Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegistrar.ForeColor = Color.White
        btnRegistrar.Location = New Point(313, 322)
        btnRegistrar.Name = "btnRegistrar"
        btnRegistrar.Size = New Size(110, 45)
        btnRegistrar.TabIndex = 18
        btnRegistrar.Text = "Registrar"
        btnRegistrar.UseVisualStyleBackColor = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(281, 23)
        Label9.Name = "Label9"
        Label9.Size = New Size(142, 24)
        Label9.TabIndex = 17
        Label9.Text = "Crear Viaje"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(139, 220)
        Label3.Name = "Label3"
        Label3.Size = New Size(162, 19)
        Label3.TabIndex = 4
        Label3.Text = "Bus: (- Asientos)"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(139, 154)
        Label2.Name = "Label2"
        Label2.Size = New Size(144, 19)
        Label2.TabIndex = 2
        Label2.Text = "Ciudad Destino:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(139, 76)
        Label1.Name = "Label1"
        Label1.Size = New Size(135, 19)
        Label1.TabIndex = 0
        Label1.Text = "Ciudad Origen:"
        ' 
        ' frmCrearViaje
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(685, 501)
        Controls.Add(PanelDatos)
        Controls.Add(panelTitulo)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmCrearViaje"
        Text = "frmRegistrarAdmin"
        panelTitulo.ResumeLayout(False)
        panelTitulo.PerformLayout()
        PanelDatos.ResumeLayout(False)
        PanelDatos.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnRegresar As Button
    Friend WithEvents lb_Tittle As Label
    Friend WithEvents panelTitulo As Panel
    Friend WithEvents PanelDatos As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents cboConductor As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbo_CiudadDestino As ComboBox
    Friend WithEvents cbo_CiudadOrigen As ComboBox
    Friend WithEvents cbo_Bus As ComboBox
    Friend WithEvents dtp_FechaHora As DateTimePicker
End Class
