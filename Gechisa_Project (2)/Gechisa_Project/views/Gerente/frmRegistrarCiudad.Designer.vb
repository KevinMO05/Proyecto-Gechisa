<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRegistrarCiudad

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistrarCiudad))
        btnRegresar = New Button()
        lb_Tittle = New Label()
        panelTitulo = New Panel()
        panelBusqueda = New Panel()
        txtBuscar = New TextBox()
        buttonBuscar = New PictureBox()
        PanelContenido = New Panel()
        DataCities = New DataGridView()
        Eliminar = New DataGridViewImageColumn()
        PanelLateral = New Panel()
        btnNuevo = New PictureBox()
        PanelDatos = New Panel()
        btnCancelar = New Button()
        btnRegistrar = New Button()
        lbl_TituloRegistro = New Label()
        txtCiudad = New TextBox()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        panelTitulo.SuspendLayout()
        panelBusqueda.SuspendLayout()
        CType(buttonBuscar, ComponentModel.ISupportInitialize).BeginInit()
        PanelContenido.SuspendLayout()
        CType(DataCities, ComponentModel.ISupportInitialize).BeginInit()
        PanelLateral.SuspendLayout()
        CType(btnNuevo, ComponentModel.ISupportInitialize).BeginInit()
        PanelDatos.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
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
        PanelContenido.Controls.Add(DataCities)
        PanelContenido.Controls.Add(PanelLateral)
        PanelContenido.Location = New Point(0, 100)
        PanelContenido.Name = "PanelContenido"
        PanelContenido.Size = New Size(684, 401)
        PanelContenido.TabIndex = 4
        ' 
        ' DataCities
        ' 
        DataCities.AllowUserToAddRows = False
        DataCities.AllowUserToDeleteRows = False
        DataCities.AllowUserToResizeColumns = False
        DataCities.BackgroundColor = Color.White
        DataCities.BorderStyle = BorderStyle.None
        DataCities.CellBorderStyle = DataGridViewCellBorderStyle.None
        DataCities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataCities.Columns.AddRange(New DataGridViewColumn() {Eliminar})
        DataCities.EnableHeadersVisualStyles = False
        DataCities.Location = New Point(12, 20)
        DataCities.Name = "DataCities"
        DataCities.RowHeadersVisible = False
        DataCities.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataCities.Size = New Size(551, 367)
        DataCities.TabIndex = 1
        ' 
        ' Eliminar
        ' 
        Eliminar.HeaderText = ""
        Eliminar.Image = CType(resources.GetObject("Eliminar.Image"), Image)
        Eliminar.ImageLayout = DataGridViewImageCellLayout.Zoom
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
        PanelDatos.Controls.Add(btnCancelar)
        PanelDatos.Controls.Add(btnRegistrar)
        PanelDatos.Controls.Add(lbl_TituloRegistro)
        PanelDatos.Controls.Add(txtCiudad)
        PanelDatos.Controls.Add(Label1)
        PanelDatos.Controls.Add(PictureBox1)
        PanelDatos.Location = New Point(0, 57)
        PanelDatos.Name = "PanelDatos"
        PanelDatos.Size = New Size(684, 444)
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
        btnCancelar.Location = New Point(382, 308)
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
        btnRegistrar.Location = New Point(173, 308)
        btnRegistrar.Name = "btnRegistrar"
        btnRegistrar.Size = New Size(110, 45)
        btnRegistrar.TabIndex = 18
        btnRegistrar.Text = "Guardar"
        btnRegistrar.UseVisualStyleBackColor = False
        ' 
        ' lbl_TituloRegistro
        ' 
        lbl_TituloRegistro.AutoSize = True
        lbl_TituloRegistro.Font = New Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_TituloRegistro.Location = New Point(231, 39)
        lbl_TituloRegistro.Name = "lbl_TituloRegistro"
        lbl_TituloRegistro.Size = New Size(202, 24)
        lbl_TituloRegistro.TabIndex = 17
        lbl_TituloRegistro.Text = "Registrar Ciudad"
        ' 
        ' txtCiudad
        ' 
        txtCiudad.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCiudad.Location = New Point(205, 145)
        txtCiudad.Name = "txtCiudad"
        txtCiudad.Size = New Size(256, 26)
        txtCiudad.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(205, 120)
        Label1.Name = "Label1"
        Label1.Size = New Size(162, 19)
        Label1.TabIndex = 0
        Label1.Text = "Nombre de ciudad:"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(0, 181)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(708, 475)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 21
        PictureBox1.TabStop = False
        ' 
        ' frmRegistrarCiudad
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(685, 501)
        Controls.Add(PanelDatos)
        Controls.Add(PanelContenido)
        Controls.Add(panelTitulo)
        Controls.Add(panelBusqueda)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmRegistrarCiudad"
        Text = "frmRegistrarAdmin"
        panelTitulo.ResumeLayout(False)
        panelTitulo.PerformLayout()
        panelBusqueda.ResumeLayout(False)
        panelBusqueda.PerformLayout()
        CType(buttonBuscar, ComponentModel.ISupportInitialize).EndInit()
        PanelContenido.ResumeLayout(False)
        CType(DataCities, ComponentModel.ISupportInitialize).EndInit()
        PanelLateral.ResumeLayout(False)
        CType(btnNuevo, ComponentModel.ISupportInitialize).EndInit()
        PanelDatos.ResumeLayout(False)
        PanelDatos.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DataCities As DataGridView
    Friend WithEvents PanelDatos As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCiudad As TextBox
    Friend WithEvents lbl_TituloRegistro As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Eliminar As DataGridViewImageColumn
End Class
