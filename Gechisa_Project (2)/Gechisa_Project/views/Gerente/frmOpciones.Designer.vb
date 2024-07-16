<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpciones))
        lb_Tittle = New Label()
        panelTitulo = New Panel()
        btnRegresar = New Button()
        panelBusqueda = New Panel()
        PictureBox1 = New PictureBox()
        btnRuta = New Button()
        btnCiudad = New Button()
        btnbus = New Button()
        btnConductor = New Button()
        btnVendedor = New Button()
        btnAdmin = New Button()
        panelTitulo.SuspendLayout()
        panelBusqueda.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
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
        ' panelTitulo
        ' 
        panelTitulo.BackColor = Color.Gold
        panelTitulo.Controls.Add(btnRegresar)
        panelTitulo.Controls.Add(lb_Tittle)
        panelTitulo.Location = New Point(0, 1)
        panelTitulo.Name = "panelTitulo"
        panelTitulo.Size = New Size(684, 79)
        panelTitulo.TabIndex = 2
        ' 
        ' btnRegresar
        ' 
        btnRegresar.FlatAppearance.BorderSize = 0
        btnRegresar.FlatStyle = FlatStyle.Flat
        btnRegresar.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRegresar.Location = New Point(626, 3)
        btnRegresar.Name = "btnRegresar"
        btnRegresar.Size = New Size(55, 74)
        btnRegresar.TabIndex = 1
        btnRegresar.Text = "X"
        btnRegresar.UseVisualStyleBackColor = True
        ' 
        ' panelBusqueda
        ' 
        panelBusqueda.BackColor = Color.White
        panelBusqueda.Controls.Add(PictureBox1)
        panelBusqueda.Controls.Add(btnRuta)
        panelBusqueda.Controls.Add(btnCiudad)
        panelBusqueda.Controls.Add(btnbus)
        panelBusqueda.Controls.Add(btnConductor)
        panelBusqueda.Controls.Add(btnVendedor)
        panelBusqueda.Controls.Add(btnAdmin)
        panelBusqueda.Location = New Point(0, 80)
        panelBusqueda.Name = "panelBusqueda"
        panelBusqueda.Size = New Size(684, 430)
        panelBusqueda.TabIndex = 3
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(282, 142)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(130, 118)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 6
        PictureBox1.TabStop = False
        ' 
        ' btnRuta
        ' 
        btnRuta.BackColor = Color.DarkCyan
        btnRuta.FlatAppearance.BorderSize = 0
        btnRuta.FlatStyle = FlatStyle.Flat
        btnRuta.Font = New Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRuta.Location = New Point(375, 283)
        btnRuta.Name = "btnRuta"
        btnRuta.Size = New Size(309, 68)
        btnRuta.TabIndex = 5
        btnRuta.Text = "Registrar" & vbCrLf & " Ruta"
        btnRuta.UseVisualStyleBackColor = False
        ' 
        ' btnCiudad
        ' 
        btnCiudad.BackColor = Color.Khaki
        btnCiudad.FlatAppearance.BorderSize = 0
        btnCiudad.FlatStyle = FlatStyle.Flat
        btnCiudad.Font = New Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCiudad.Location = New Point(456, 169)
        btnCiudad.Name = "btnCiudad"
        btnCiudad.Size = New Size(228, 68)
        btnCiudad.TabIndex = 4
        btnCiudad.Text = "Registrar " & vbCrLf & "Ciudad"
        btnCiudad.UseVisualStyleBackColor = False
        ' 
        ' btnbus
        ' 
        btnbus.BackColor = Color.FromArgb(CByte(140), CByte(179), CByte(105))
        btnbus.FlatAppearance.BorderSize = 0
        btnbus.FlatStyle = FlatStyle.Flat
        btnbus.Font = New Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnbus.Location = New Point(375, 49)
        btnbus.Name = "btnbus"
        btnbus.Size = New Size(309, 68)
        btnbus.TabIndex = 3
        btnbus.Text = "Registrar " & vbCrLf & "Bus"
        btnbus.UseVisualStyleBackColor = False
        ' 
        ' btnConductor
        ' 
        btnConductor.BackColor = Color.LightCoral
        btnConductor.FlatAppearance.BorderSize = 0
        btnConductor.FlatStyle = FlatStyle.Flat
        btnConductor.Font = New Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnConductor.Location = New Point(0, 283)
        btnConductor.Name = "btnConductor"
        btnConductor.Size = New Size(309, 68)
        btnConductor.TabIndex = 2
        btnConductor.Text = "Registrar" & vbCrLf & "Conductor"
        btnConductor.UseVisualStyleBackColor = False
        ' 
        ' btnVendedor
        ' 
        btnVendedor.BackColor = Color.MediumSeaGreen
        btnVendedor.FlatAppearance.BorderSize = 0
        btnVendedor.FlatStyle = FlatStyle.Flat
        btnVendedor.Font = New Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnVendedor.Location = New Point(0, 169)
        btnVendedor.Name = "btnVendedor"
        btnVendedor.Size = New Size(228, 68)
        btnVendedor.TabIndex = 1
        btnVendedor.Text = "Registrar " & vbCrLf & "Vendedor"
        btnVendedor.UseVisualStyleBackColor = False
        ' 
        ' btnAdmin
        ' 
        btnAdmin.BackColor = Color.DodgerBlue
        btnAdmin.FlatAppearance.BorderSize = 0
        btnAdmin.FlatStyle = FlatStyle.Flat
        btnAdmin.Font = New Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAdmin.Location = New Point(0, 49)
        btnAdmin.Name = "btnAdmin"
        btnAdmin.Size = New Size(309, 68)
        btnAdmin.TabIndex = 0
        btnAdmin.Text = "Registrar " & vbCrLf & "Administrador"
        btnAdmin.UseVisualStyleBackColor = False
        ' 
        ' frmOpciones
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(685, 510)
        Controls.Add(panelTitulo)
        Controls.Add(panelBusqueda)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmOpciones"
        Text = "frmOpciones"
        panelTitulo.ResumeLayout(False)
        panelTitulo.PerformLayout()
        panelBusqueda.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lb_Tittle As Label
    Friend WithEvents panelTitulo As Panel
    Friend WithEvents btnRegresar As Button
    Friend WithEvents panelBusqueda As Panel
    Friend WithEvents btnConductor As Button
    Friend WithEvents btnVendedor As Button
    Friend WithEvents btnAdmin As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnRuta As Button
    Friend WithEvents btnCiudad As Button
    Friend WithEvents btnbus As Button
End Class
