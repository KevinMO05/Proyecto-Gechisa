<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu_Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu_Main))
        panelTitulo = New Panel()
        btnSalir = New Button()
        lb_Tittle = New Label()
        panelBusqueda = New Panel()
        PictureBox3 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        btnVendedor = New Button()
        btnAdmin = New Button()
        btnGerente = New Button()
        panelTitulo.SuspendLayout()
        panelBusqueda.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' panelTitulo
        ' 
        panelTitulo.BackColor = Color.Gold
        panelTitulo.Controls.Add(btnSalir)
        panelTitulo.Controls.Add(lb_Tittle)
        panelTitulo.Location = New Point(0, -1)
        panelTitulo.Name = "panelTitulo"
        panelTitulo.Size = New Size(684, 79)
        panelTitulo.TabIndex = 0
        ' 
        ' btnSalir
        ' 
        btnSalir.FlatAppearance.BorderSize = 0
        btnSalir.FlatStyle = FlatStyle.Flat
        btnSalir.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSalir.Location = New Point(626, 3)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(55, 74)
        btnSalir.TabIndex = 1
        btnSalir.Text = "X"
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' lb_Tittle
        ' 
        lb_Tittle.AutoSize = True
        lb_Tittle.Font = New Font("Consolas", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lb_Tittle.Location = New Point(29, 18)
        lb_Tittle.Name = "lb_Tittle"
        lb_Tittle.Size = New Size(127, 34)
        lb_Tittle.TabIndex = 0
        lb_Tittle.Text = "GECHISA"
        ' 
        ' panelBusqueda
        ' 
        panelBusqueda.BackColor = Color.White
        panelBusqueda.Controls.Add(PictureBox3)
        panelBusqueda.Controls.Add(PictureBox2)
        panelBusqueda.Controls.Add(PictureBox1)
        panelBusqueda.Controls.Add(btnVendedor)
        panelBusqueda.Controls.Add(btnAdmin)
        panelBusqueda.Controls.Add(btnGerente)
        panelBusqueda.Location = New Point(3, 78)
        panelBusqueda.Name = "panelBusqueda"
        panelBusqueda.Size = New Size(681, 422)
        panelBusqueda.TabIndex = 1
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(194, 244)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(69, 68)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 6
        PictureBox3.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.InitialImage = CType(resources.GetObject("PictureBox2.InitialImage"), Image)
        PictureBox2.Location = New Point(194, 67)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(69, 62)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 5
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.ErrorImage = Nothing
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(194, 146)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(69, 76)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 4
        PictureBox1.TabStop = False
        ' 
        ' btnVendedor
        ' 
        btnVendedor.Font = New Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnVendedor.Location = New Point(300, 244)
        btnVendedor.Name = "btnVendedor"
        btnVendedor.Size = New Size(160, 68)
        btnVendedor.TabIndex = 2
        btnVendedor.Text = "Vendedor"
        btnVendedor.UseVisualStyleBackColor = True
        ' 
        ' btnAdmin
        ' 
        btnAdmin.Font = New Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAdmin.Location = New Point(297, 154)
        btnAdmin.Name = "btnAdmin"
        btnAdmin.Size = New Size(160, 68)
        btnAdmin.TabIndex = 1
        btnAdmin.Text = "Administrador"
        btnAdmin.UseVisualStyleBackColor = True
        ' 
        ' btnGerente
        ' 
        btnGerente.Font = New Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnGerente.Location = New Point(297, 61)
        btnGerente.Name = "btnGerente"
        btnGerente.Size = New Size(163, 68)
        btnGerente.TabIndex = 0
        btnGerente.Text = "Gerente"
        btnGerente.UseVisualStyleBackColor = True
        ' 
        ' Menu_Main
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(683, 500)
        Controls.Add(panelBusqueda)
        Controls.Add(panelTitulo)
        FormBorderStyle = FormBorderStyle.None
        Name = "Menu_Main"
        Text = "Menu_Main"
        panelTitulo.ResumeLayout(False)
        panelTitulo.PerformLayout()
        panelBusqueda.ResumeLayout(False)
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents panelTitulo As Panel
    Friend WithEvents lb_Tittle As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents panelBusqueda As Panel
    Friend WithEvents btnAdmin As Button
    Friend WithEvents btnGerente As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnVendedor As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
End Class
