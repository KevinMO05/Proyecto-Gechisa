<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentaBoletos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentaBoletos))
        btnRegresar = New Button()
        lb_Tittle = New Label()
        panelTitulo = New Panel()
        panelContenido = New Panel()
        btnActualizar = New Button()
        cbo_CiudadOrigen = New ComboBox()
        Label8 = New Label()
        btnRegistrarCliente = New Button()
        DataViajesBoletos = New DataGridView()
        cbo_CiudadDestino = New ComboBox()
        Label7 = New Label()
        Label6 = New Label()
        txtTelefono = New TextBox()
        Label5 = New Label()
        txtDireccion = New TextBox()
        Label4 = New Label()
        txtCorreo = New TextBox()
        Label3 = New Label()
        txtApellido = New TextBox()
        Label2 = New Label()
        txtNombre = New TextBox()
        btnBuscarCliente = New PictureBox()
        Label1 = New Label()
        txtDni = New TextBox()
        VenderBoleto = New DataGridViewImageColumn()
        panelTitulo.SuspendLayout()
        panelContenido.SuspendLayout()
        CType(DataViajesBoletos, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnBuscarCliente, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnRegresar
        ' 
        btnRegresar.FlatAppearance.BorderSize = 0
        btnRegresar.FlatStyle = FlatStyle.Flat
        btnRegresar.Font = New Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegresar.Location = New Point(952, 1)
        btnRegresar.Name = "btnRegresar"
        btnRegresar.Size = New Size(55, 63)
        btnRegresar.TabIndex = 1
        btnRegresar.Text = "X"
        btnRegresar.UseVisualStyleBackColor = True
        ' 
        ' lb_Tittle
        ' 
        lb_Tittle.AutoSize = True
        lb_Tittle.Font = New Font("Consolas", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lb_Tittle.Location = New Point(29, 11)
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
        panelTitulo.Size = New Size(1007, 65)
        panelTitulo.TabIndex = 1
        ' 
        ' panelContenido
        ' 
        panelContenido.BackColor = Color.White
        panelContenido.Controls.Add(btnActualizar)
        panelContenido.Controls.Add(cbo_CiudadOrigen)
        panelContenido.Controls.Add(Label8)
        panelContenido.Controls.Add(btnRegistrarCliente)
        panelContenido.Controls.Add(DataViajesBoletos)
        panelContenido.Controls.Add(cbo_CiudadDestino)
        panelContenido.Controls.Add(Label7)
        panelContenido.Controls.Add(Label6)
        panelContenido.Controls.Add(txtTelefono)
        panelContenido.Controls.Add(Label5)
        panelContenido.Controls.Add(txtDireccion)
        panelContenido.Controls.Add(Label4)
        panelContenido.Controls.Add(txtCorreo)
        panelContenido.Controls.Add(Label3)
        panelContenido.Controls.Add(txtApellido)
        panelContenido.Controls.Add(Label2)
        panelContenido.Controls.Add(txtNombre)
        panelContenido.Controls.Add(btnBuscarCliente)
        panelContenido.Controls.Add(Label1)
        panelContenido.Controls.Add(txtDni)
        panelContenido.Location = New Point(2, 65)
        panelContenido.Name = "panelContenido"
        panelContenido.Size = New Size(1006, 500)
        panelContenido.TabIndex = 2
        ' 
        ' btnActualizar
        ' 
        btnActualizar.BackColor = Color.Azure
        btnActualizar.FlatAppearance.BorderSize = 0
        btnActualizar.FlatStyle = FlatStyle.Flat
        btnActualizar.Font = New Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnActualizar.Location = New Point(865, 46)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(102, 41)
        btnActualizar.TabIndex = 24
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = False
        ' 
        ' cbo_CiudadOrigen
        ' 
        cbo_CiudadOrigen.FormattingEnabled = True
        cbo_CiudadOrigen.Location = New Point(305, 62)
        cbo_CiudadOrigen.Name = "cbo_CiudadOrigen"
        cbo_CiudadOrigen.Size = New Size(203, 25)
        cbo_CiudadOrigen.TabIndex = 23
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(305, 26)
        Label8.Name = "Label8"
        Label8.Size = New Size(72, 19)
        Label8.TabIndex = 22
        Label8.Text = "Origen:"
        ' 
        ' btnRegistrarCliente
        ' 
        btnRegistrarCliente.BackColor = Color.DodgerBlue
        btnRegistrarCliente.FlatAppearance.BorderSize = 0
        btnRegistrarCliente.FlatStyle = FlatStyle.Flat
        btnRegistrarCliente.Font = New Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegistrarCliente.Location = New Point(32, 423)
        btnRegistrarCliente.Name = "btnRegistrarCliente"
        btnRegistrarCliente.Size = New Size(178, 41)
        btnRegistrarCliente.TabIndex = 16
        btnRegistrarCliente.Text = "Registrar Cliente"
        btnRegistrarCliente.UseVisualStyleBackColor = False
        ' 
        ' DataViajesBoletos
        ' 
        DataViajesBoletos.BackgroundColor = SystemColors.ActiveCaptionText
        DataViajesBoletos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataViajesBoletos.Columns.AddRange(New DataGridViewColumn() {VenderBoleto})
        DataViajesBoletos.Location = New Point(294, 111)
        DataViajesBoletos.Name = "DataViajesBoletos"
        DataViajesBoletos.Size = New Size(673, 353)
        DataViajesBoletos.TabIndex = 15
        ' 
        ' cbo_CiudadDestino
        ' 
        cbo_CiudadDestino.FormattingEnabled = True
        cbo_CiudadDestino.Location = New Point(555, 61)
        cbo_CiudadDestino.Name = "cbo_CiudadDestino"
        cbo_CiudadDestino.Size = New Size(221, 25)
        cbo_CiudadDestino.TabIndex = 14
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Consolas", 11.25F)
        Label7.Location = New Point(555, 26)
        Label7.Name = "Label7"
        Label7.Size = New Size(72, 18)
        Label7.TabIndex = 13
        Label7.Text = "Destino:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Consolas", 11.25F)
        Label6.Location = New Point(28, 350)
        Label6.Name = "Label6"
        Label6.Size = New Size(80, 18)
        Label6.TabIndex = 11
        Label6.Text = "Teléfono:"
        ' 
        ' txtTelefono
        ' 
        txtTelefono.Location = New Point(28, 373)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(182, 25)
        txtTelefono.TabIndex = 12
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Consolas", 11.25F)
        Label5.Location = New Point(28, 286)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 18)
        Label5.TabIndex = 9
        Label5.Text = "Direccion:"
        ' 
        ' txtDireccion
        ' 
        txtDireccion.Location = New Point(28, 308)
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(182, 25)
        txtDireccion.TabIndex = 10
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Consolas", 11.25F)
        Label4.Location = New Point(28, 220)
        Label4.Name = "Label4"
        Label4.Size = New Size(64, 18)
        Label4.TabIndex = 7
        Label4.Text = "Correo:"
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Location = New Point(28, 243)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(182, 25)
        txtCorreo.TabIndex = 8
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Consolas", 11.25F)
        Label3.Location = New Point(28, 154)
        Label3.Name = "Label3"
        Label3.Size = New Size(80, 18)
        Label3.TabIndex = 5
        Label3.Text = "Apellido:"
        ' 
        ' txtApellido
        ' 
        txtApellido.Location = New Point(28, 177)
        txtApellido.Name = "txtApellido"
        txtApellido.Size = New Size(182, 25)
        txtApellido.TabIndex = 6
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Consolas", 11.25F)
        Label2.Location = New Point(28, 88)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 18)
        Label2.TabIndex = 3
        Label2.Text = "Nombre:"
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(28, 111)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(182, 25)
        txtNombre.TabIndex = 4
        ' 
        ' btnBuscarCliente
        ' 
        btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), Image)
        btnBuscarCliente.Location = New Point(216, 51)
        btnBuscarCliente.Name = "btnBuscarCliente"
        btnBuscarCliente.Size = New Size(26, 24)
        btnBuscarCliente.SizeMode = PictureBoxSizeMode.Zoom
        btnBuscarCliente.TabIndex = 2
        btnBuscarCliente.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Consolas", 11.25F)
        Label1.Location = New Point(28, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(40, 18)
        Label1.TabIndex = 0
        Label1.Text = "Dni:"
        ' 
        ' txtDni
        ' 
        txtDni.Location = New Point(28, 50)
        txtDni.Name = "txtDni"
        txtDni.Size = New Size(182, 25)
        txtDni.TabIndex = 1
        ' 
        ' VenderBoleto
        ' 
        VenderBoleto.HeaderText = "Vender"
        VenderBoleto.Image = CType(resources.GetObject("VenderBoleto.Image"), Image)
        VenderBoleto.ImageLayout = DataGridViewImageCellLayout.Zoom
        VenderBoleto.Name = "VenderBoleto"
        ' 
        ' frmVentaBoletos
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1008, 564)
        Controls.Add(panelContenido)
        Controls.Add(panelTitulo)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmVentaBoletos"
        Text = "frmVentaBoletos"
        panelTitulo.ResumeLayout(False)
        panelTitulo.PerformLayout()
        panelContenido.ResumeLayout(False)
        panelContenido.PerformLayout()
        CType(DataViajesBoletos, ComponentModel.ISupportInitialize).EndInit()
        CType(btnBuscarCliente, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnRegresar As Button
    Friend WithEvents lb_Tittle As Label
    Friend WithEvents panelTitulo As Panel
    Friend WithEvents panelContenido As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtApellido As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents btnBuscarCliente As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDni As TextBox
    Friend WithEvents cbo_CiudadDestino As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents DataViajesBoletos As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents cbo_CiudadOrigen As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnRegistrarCliente As Button
    Friend WithEvents btnActualizar As Button
    Friend WithEvents VenderBoleto As DataGridViewImageColumn
End Class
