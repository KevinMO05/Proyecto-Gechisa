﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRegistrarAdmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistrarAdmin))
        btnRegresar = New Button()
        lb_Tittle = New Label()
        panelTitulo = New Panel()
        panelBusqueda = New Panel()
        txtBuscar = New TextBox()
        buttonBuscar = New PictureBox()
        PanelContenido = New Panel()
        DataAdmins = New DataGridView()
        PanelLateral = New Panel()
        btnNuevo = New PictureBox()
        PanelDatos = New Panel()
        btnCancelar = New Button()
        btnRegistrar = New Button()
        Label9 = New Label()
        Select_ciudad = New ComboBox()
        txtContraseña = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        txtCelular = New TextBox()
        Label6 = New Label()
        txtDireccion = New TextBox()
        Label5 = New Label()
        txtCorreo = New TextBox()
        Label4 = New Label()
        txtApellido = New TextBox()
        Label3 = New Label()
        txtNombre = New TextBox()
        Label2 = New Label()
        txtDni = New TextBox()
        Label1 = New Label()
        panelTitulo.SuspendLayout()
        panelBusqueda.SuspendLayout()
        CType(buttonBuscar, ComponentModel.ISupportInitialize).BeginInit()
        PanelContenido.SuspendLayout()
        CType(DataAdmins, ComponentModel.ISupportInitialize).BeginInit()
        PanelLateral.SuspendLayout()
        CType(btnNuevo, ComponentModel.ISupportInitialize).BeginInit()
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
        btnRegresar.Size = New Size(55, 42)
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
        panelTitulo.Size = New Size(684, 51)
        panelTitulo.TabIndex = 2
        ' 
        ' panelBusqueda
        ' 
        panelBusqueda.BackColor = Color.White
        panelBusqueda.Controls.Add(txtBuscar)
        panelBusqueda.Controls.Add(buttonBuscar)
        panelBusqueda.Location = New Point(0, 51)
        panelBusqueda.Name = "panelBusqueda"
        panelBusqueda.Size = New Size(684, 39)
        panelBusqueda.TabIndex = 3
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(161, 8)
        txtBuscar.Multiline = True
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(363, 23)
        txtBuscar.TabIndex = 2
        ' 
        ' buttonBuscar
        ' 
        buttonBuscar.ErrorImage = CType(resources.GetObject("buttonBuscar.ErrorImage"), Image)
        buttonBuscar.Image = CType(resources.GetObject("buttonBuscar.Image"), Image)
        buttonBuscar.Location = New Point(537, 6)
        buttonBuscar.Name = "buttonBuscar"
        buttonBuscar.Size = New Size(26, 30)
        buttonBuscar.SizeMode = PictureBoxSizeMode.Zoom
        buttonBuscar.TabIndex = 0
        buttonBuscar.TabStop = False
        ' 
        ' PanelContenido
        ' 
        PanelContenido.BackColor = Color.White
        PanelContenido.Controls.Add(DataAdmins)
        PanelContenido.Controls.Add(PanelLateral)
        PanelContenido.Location = New Point(0, 88)
        PanelContenido.Name = "PanelContenido"
        PanelContenido.Size = New Size(684, 354)
        PanelContenido.TabIndex = 4
        ' 
        ' DataAdmins
        ' 
        DataAdmins.AllowUserToAddRows = False
        DataAdmins.AllowUserToDeleteRows = False
        DataAdmins.AllowUserToResizeColumns = False
        DataAdmins.BackgroundColor = Color.White
        DataAdmins.BorderStyle = BorderStyle.None
        DataAdmins.CellBorderStyle = DataGridViewCellBorderStyle.None
        DataAdmins.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataAdmins.EnableHeadersVisualStyles = False
        DataAdmins.Location = New Point(12, 18)
        DataAdmins.Name = "DataAdmins"
        DataAdmins.RowHeadersVisible = False
        DataAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataAdmins.Size = New Size(551, 324)
        DataAdmins.TabIndex = 1
        ' 
        ' PanelLateral
        ' 
        PanelLateral.Controls.Add(btnNuevo)
        PanelLateral.Location = New Point(577, 0)
        PanelLateral.Name = "PanelLateral"
        PanelLateral.Size = New Size(107, 354)
        PanelLateral.TabIndex = 0
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), Image)
        btnNuevo.Location = New Point(13, 145)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(83, 68)
        btnNuevo.SizeMode = PictureBoxSizeMode.Zoom
        btnNuevo.TabIndex = 0
        btnNuevo.TabStop = False
        ' 
        ' PanelDatos
        ' 
        PanelDatos.BackColor = Color.White
        PanelDatos.Controls.Add(btnCancelar)
        PanelDatos.Controls.Add(btnRegistrar)
        PanelDatos.Controls.Add(Label9)
        PanelDatos.Controls.Add(Select_ciudad)
        PanelDatos.Controls.Add(txtContraseña)
        PanelDatos.Controls.Add(Label8)
        PanelDatos.Controls.Add(Label7)
        PanelDatos.Controls.Add(txtCelular)
        PanelDatos.Controls.Add(Label6)
        PanelDatos.Controls.Add(txtDireccion)
        PanelDatos.Controls.Add(Label5)
        PanelDatos.Controls.Add(txtCorreo)
        PanelDatos.Controls.Add(Label4)
        PanelDatos.Controls.Add(txtApellido)
        PanelDatos.Controls.Add(Label3)
        PanelDatos.Controls.Add(txtNombre)
        PanelDatos.Controls.Add(Label2)
        PanelDatos.Controls.Add(txtDni)
        PanelDatos.Controls.Add(Label1)
        PanelDatos.Location = New Point(0, 51)
        PanelDatos.Name = "PanelDatos"
        PanelDatos.Size = New Size(684, 391)
        PanelDatos.TabIndex = 2
        PanelDatos.Visible = False
        ' 
        ' btnCancelar
        ' 
        btnCancelar.BackColor = Color.FromArgb(CByte(194), CByte(54), CByte(22))
        btnCancelar.Cursor = Cursors.Hand
        btnCancelar.FlatAppearance.BorderSize = 0
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.Font = New Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancelar.ForeColor = Color.White
        btnCancelar.Location = New Point(406, 285)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(110, 40)
        btnCancelar.TabIndex = 20
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = False
        ' 
        ' btnRegistrar
        ' 
        btnRegistrar.BackColor = Color.DodgerBlue
        btnRegistrar.Cursor = Cursors.Hand
        btnRegistrar.FlatAppearance.BorderSize = 0
        btnRegistrar.FlatStyle = FlatStyle.Flat
        btnRegistrar.Font = New Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegistrar.ForeColor = Color.White
        btnRegistrar.Location = New Point(214, 285)
        btnRegistrar.Name = "btnRegistrar"
        btnRegistrar.Size = New Size(110, 40)
        btnRegistrar.TabIndex = 18
        btnRegistrar.Text = "Guardar"
        btnRegistrar.UseVisualStyleBackColor = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(230, 18)
        Label9.Name = "Label9"
        Label9.Size = New Size(286, 24)
        Label9.TabIndex = 17
        Label9.Text = "Registrar Administrador"
        ' 
        ' Select_ciudad
        ' 
        Select_ciudad.FormattingEnabled = True
        Select_ciudad.Location = New Point(438, 159)
        Select_ciudad.Name = "Select_ciudad"
        Select_ciudad.Size = New Size(223, 23)
        Select_ciudad.TabIndex = 16
        ' 
        ' txtContraseña
        ' 
        txtContraseña.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtContraseña.Location = New Point(456, 204)
        txtContraseña.Name = "txtContraseña"
        txtContraseña.Size = New Size(205, 26)
        txtContraseña.TabIndex = 15
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(351, 204)
        Label8.Name = "Label8"
        Label8.Size = New Size(108, 19)
        Label8.TabIndex = 14
        Label8.Text = "Contraseña:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(351, 159)
        Label7.Name = "Label7"
        Label7.Size = New Size(72, 19)
        Label7.TabIndex = 12
        Label7.Text = "Ciudad:"
        ' 
        ' txtCelular
        ' 
        txtCelular.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCelular.Location = New Point(438, 117)
        txtCelular.Name = "txtCelular"
        txtCelular.Size = New Size(223, 26)
        txtCelular.TabIndex = 11
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(351, 117)
        Label6.Name = "Label6"
        Label6.Size = New Size(81, 19)
        Label6.TabIndex = 10
        Label6.Text = "Celular:"
        ' 
        ' txtDireccion
        ' 
        txtDireccion.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtDireccion.Location = New Point(456, 73)
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(205, 26)
        txtDireccion.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(351, 76)
        Label5.Name = "Label5"
        Label5.Size = New Size(99, 19)
        Label5.TabIndex = 8
        Label5.Text = "Direccion:"
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCorreo.Location = New Point(132, 201)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(153, 26)
        txtCorreo.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(54, 201)
        Label4.Name = "Label4"
        Label4.Size = New Size(72, 19)
        Label4.TabIndex = 6
        Label4.Text = "Correo:"
        ' 
        ' txtApellido
        ' 
        txtApellido.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtApellido.Location = New Point(150, 156)
        txtApellido.Name = "txtApellido"
        txtApellido.Size = New Size(135, 26)
        txtApellido.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(54, 159)
        Label3.Name = "Label3"
        Label3.Size = New Size(90, 19)
        Label3.TabIndex = 4
        Label3.Text = "Apellido:"
        ' 
        ' txtNombre
        ' 
        txtNombre.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtNombre.Location = New Point(123, 114)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(162, 26)
        txtNombre.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(54, 117)
        Label2.Name = "Label2"
        Label2.Size = New Size(72, 19)
        Label2.TabIndex = 2
        Label2.Text = "Nombre:"
        ' 
        ' txtDni
        ' 
        txtDni.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtDni.Location = New Point(114, 73)
        txtDni.Name = "txtDni"
        txtDni.Size = New Size(171, 26)
        txtDni.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(54, 76)
        Label1.Name = "Label1"
        Label1.Size = New Size(54, 19)
        Label1.TabIndex = 0
        Label1.Text = "Dni: "
        ' 
        ' frmRegistrarAdmin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(685, 442)
        Controls.Add(PanelDatos)
        Controls.Add(PanelContenido)
        Controls.Add(panelTitulo)
        Controls.Add(panelBusqueda)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmRegistrarAdmin"
        Text = "frmRegistrarAdmin"
        panelTitulo.ResumeLayout(False)
        panelTitulo.PerformLayout()
        panelBusqueda.ResumeLayout(False)
        panelBusqueda.PerformLayout()
        CType(buttonBuscar, ComponentModel.ISupportInitialize).EndInit()
        PanelContenido.ResumeLayout(False)
        CType(DataAdmins, ComponentModel.ISupportInitialize).EndInit()
        PanelLateral.ResumeLayout(False)
        CType(btnNuevo, ComponentModel.ISupportInitialize).EndInit()
        PanelDatos.ResumeLayout(False)
        PanelDatos.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnRegresar As Button
    Friend WithEvents lb_Tittle As Label
    Friend WithEvents panelTitulo As Panel
    Friend WithEvents panelBusqueda As Panel
    Friend WithEvents buttonBuscar As PictureBox
    Friend WithEvents PanelContenido As Panel
    Friend WithEvents PanelLateral As Panel
    Friend WithEvents btnNuevo As PictureBox
    Friend WithEvents DataAdmins As DataGridView
    Friend WithEvents PanelDatos As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDni As TextBox
    Friend WithEvents txtContraseña As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCelular As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtApellido As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Select_ciudad As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents txtBuscar As TextBox
End Class
