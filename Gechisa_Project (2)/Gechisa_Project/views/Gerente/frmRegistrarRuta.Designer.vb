<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRegistrarRuta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistrarRuta))
        btnRegresar = New Button()
        lb_Tittle = New Label()
        panelTitulo = New Panel()
        panelBusqueda = New Panel()
        txtBuscar = New TextBox()
        buttonBuscar = New PictureBox()
        PanelContenido = New Panel()
        DataRutas = New DataGridView()
        Eliminar = New DataGridViewImageColumn()
        PanelLateral = New Panel()
        btnNuevo = New PictureBox()
        PanelDatos = New Panel()
        cbo_CiudadDestino = New ComboBox()
        cbo_CiudadOrigen = New ComboBox()
        btnCancelar = New Button()
        btnRegistrar = New Button()
        Label9 = New Label()
        txtPrecio = New TextBox()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        panelTitulo.SuspendLayout()
        panelBusqueda.SuspendLayout()
        CType(buttonBuscar, ComponentModel.ISupportInitialize).BeginInit()
        PanelContenido.SuspendLayout()
        CType(DataRutas, ComponentModel.ISupportInitialize).BeginInit()
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
        ' panelBusqueda
        ' 
        panelBusqueda.BackColor = Color.White
        panelBusqueda.Controls.Add(txtBuscar)
        panelBusqueda.Controls.Add(buttonBuscar)
        panelBusqueda.Location = New Point(0, 58)
        panelBusqueda.Name = "panelBusqueda"
        panelBusqueda.Size = New Size(684, 44)
        panelBusqueda.TabIndex = 3
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(161, 9)
        txtBuscar.Multiline = True
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(363, 26)
        txtBuscar.TabIndex = 2
        ' 
        ' buttonBuscar
        ' 
        buttonBuscar.ErrorImage = CType(resources.GetObject("buttonBuscar.ErrorImage"), Image)
        buttonBuscar.Image = CType(resources.GetObject("buttonBuscar.Image"), Image)
        buttonBuscar.Location = New Point(537, 7)
        buttonBuscar.Name = "buttonBuscar"
        buttonBuscar.Size = New Size(26, 34)
        buttonBuscar.SizeMode = PictureBoxSizeMode.Zoom
        buttonBuscar.TabIndex = 0
        buttonBuscar.TabStop = False
        ' 
        ' PanelContenido
        ' 
        PanelContenido.BackColor = Color.White
        PanelContenido.Controls.Add(DataRutas)
        PanelContenido.Controls.Add(PanelLateral)
        PanelContenido.Location = New Point(0, 100)
        PanelContenido.Name = "PanelContenido"
        PanelContenido.Size = New Size(684, 401)
        PanelContenido.TabIndex = 4
        ' 
        ' DataRutas
        ' 
        DataRutas.AllowUserToAddRows = False
        DataRutas.AllowUserToDeleteRows = False
        DataRutas.AllowUserToResizeColumns = False
        DataRutas.BackgroundColor = Color.White
        DataRutas.BorderStyle = BorderStyle.None
        DataRutas.CellBorderStyle = DataGridViewCellBorderStyle.None
        DataRutas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataRutas.Columns.AddRange(New DataGridViewColumn() {Eliminar})
        DataRutas.EnableHeadersVisualStyles = False
        DataRutas.Location = New Point(12, 20)
        DataRutas.Name = "DataRutas"
        DataRutas.RowHeadersVisible = False
        DataRutas.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataRutas.Size = New Size(551, 367)
        DataRutas.TabIndex = 1
        ' 
        ' Eliminar
        ' 
        Eliminar.HeaderText = ""
        Eliminar.Image = CType(resources.GetObject("Eliminar.Image"), Image)
        Eliminar.Name = "Eliminar"
        ' 
        ' PanelLateral
        ' 
        PanelLateral.Controls.Add(btnNuevo)
        PanelLateral.Location = New Point(577, 0)
        PanelLateral.Name = "PanelLateral"
        PanelLateral.Size = New Size(107, 401)
        PanelLateral.TabIndex = 0
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), Image)
        btnNuevo.Location = New Point(13, 164)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(83, 77)
        btnNuevo.SizeMode = PictureBoxSizeMode.Zoom
        btnNuevo.TabIndex = 0
        btnNuevo.TabStop = False
        ' 
        ' PanelDatos
        ' 
        PanelDatos.BackColor = Color.White
        PanelDatos.Controls.Add(cbo_CiudadDestino)
        PanelDatos.Controls.Add(cbo_CiudadOrigen)
        PanelDatos.Controls.Add(btnCancelar)
        PanelDatos.Controls.Add(btnRegistrar)
        PanelDatos.Controls.Add(Label9)
        PanelDatos.Controls.Add(txtPrecio)
        PanelDatos.Controls.Add(Label3)
        PanelDatos.Controls.Add(Label2)
        PanelDatos.Controls.Add(Label1)
        PanelDatos.Location = New Point(0, 58)
        PanelDatos.Name = "PanelDatos"
        PanelDatos.Size = New Size(684, 443)
        PanelDatos.TabIndex = 2
        PanelDatos.Visible = False
        ' 
        ' cbo_CiudadDestino
        ' 
        cbo_CiudadDestino.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cbo_CiudadDestino.AutoCompleteSource = AutoCompleteSource.ListItems
        cbo_CiudadDestino.FormattingEnabled = True
        cbo_CiudadDestino.Location = New Point(248, 176)
        cbo_CiudadDestino.Name = "cbo_CiudadDestino"
        cbo_CiudadDestino.Size = New Size(223, 25)
        cbo_CiudadDestino.TabIndex = 22
        ' 
        ' cbo_CiudadOrigen
        ' 
        cbo_CiudadOrigen.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cbo_CiudadOrigen.AutoCompleteSource = AutoCompleteSource.ListItems
        cbo_CiudadOrigen.FormattingEnabled = True
        cbo_CiudadOrigen.Location = New Point(251, 104)
        cbo_CiudadOrigen.Name = "cbo_CiudadOrigen"
        cbo_CiudadOrigen.Size = New Size(220, 25)
        cbo_CiudadOrigen.TabIndex = 21
        ' 
        ' btnCancelar
        ' 
        btnCancelar.BackColor = Color.FromArgb(CByte(194), CByte(54), CByte(22))
        btnCancelar.Cursor = Cursors.Hand
        btnCancelar.FlatAppearance.BorderSize = 0
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.Font = New Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancelar.ForeColor = Color.White
        btnCancelar.Location = New Point(416, 323)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(110, 45)
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
        btnRegistrar.Location = New Point(208, 323)
        btnRegistrar.Name = "btnRegistrar"
        btnRegistrar.Size = New Size(110, 45)
        btnRegistrar.TabIndex = 18
        btnRegistrar.Text = "Guardar"
        btnRegistrar.UseVisualStyleBackColor = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(259, 20)
        Label9.Name = "Label9"
        Label9.Size = New Size(178, 24)
        Label9.TabIndex = 17
        Label9.Text = "Registrar Ruta"
        ' 
        ' txtPrecio
        ' 
        txtPrecio.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPrecio.Location = New Point(248, 243)
        txtPrecio.Name = "txtPrecio"
        txtPrecio.Size = New Size(223, 26)
        txtPrecio.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(248, 216)
        Label3.Name = "Label3"
        Label3.Size = New Size(72, 19)
        Label3.TabIndex = 4
        Label3.Text = "Precio:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(248, 150)
        Label2.Name = "Label2"
        Label2.Size = New Size(144, 19)
        Label2.TabIndex = 2
        Label2.Text = "Ciudad destino:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(248, 76)
        Label1.Name = "Label1"
        Label1.Size = New Size(135, 19)
        Label1.TabIndex = 0
        Label1.Text = "Ciudad origen:"
        ' 
        ' frmRegistrarRuta
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(685, 501)
        Controls.Add(PanelDatos)
        Controls.Add(PanelContenido)
        Controls.Add(panelTitulo)
        Controls.Add(panelBusqueda)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmRegistrarRuta"
        Text = "frmRegistrarAdmin"
        panelTitulo.ResumeLayout(False)
        panelTitulo.PerformLayout()
        panelBusqueda.ResumeLayout(False)
        panelBusqueda.PerformLayout()
        CType(buttonBuscar, ComponentModel.ISupportInitialize).EndInit()
        PanelContenido.ResumeLayout(False)
        CType(DataRutas, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DataRutas As DataGridView
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
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Select_ciudad As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents cbo_CiudadDestino As ComboBox
    Friend WithEvents cbo_CiudadOrigen As ComboBox
    Friend WithEvents Eliminar As DataGridViewImageColumn
End Class
