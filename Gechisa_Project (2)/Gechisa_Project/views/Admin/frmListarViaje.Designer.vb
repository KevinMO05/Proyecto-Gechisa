<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListarViaje
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListarViaje))
        btnRegresar = New Button()
        panelTitulo = New Panel()
        btnCrearViaje = New Button()
        lb_Tittle = New Label()
        Panel1 = New Panel()
        DataViajes = New DataGridView()
        RegistrarSalida = New DataGridViewImageColumn()
        RegistrarLlegada = New DataGridViewImageColumn()
        panelTitulo.SuspendLayout()
        Panel1.SuspendLayout()
        CType(DataViajes, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnRegresar
        ' 
        btnRegresar.FlatAppearance.BorderSize = 0
        btnRegresar.FlatStyle = FlatStyle.Flat
        btnRegresar.Font = New Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegresar.Location = New Point(741, 3)
        btnRegresar.Name = "btnRegresar"
        btnRegresar.Size = New Size(55, 74)
        btnRegresar.TabIndex = 1
        btnRegresar.Text = "X"
        btnRegresar.UseVisualStyleBackColor = True
        ' 
        ' panelTitulo
        ' 
        panelTitulo.BackColor = Color.Gold
        panelTitulo.Controls.Add(btnCrearViaje)
        panelTitulo.Controls.Add(btnRegresar)
        panelTitulo.Controls.Add(lb_Tittle)
        panelTitulo.Location = New Point(0, 0)
        panelTitulo.Name = "panelTitulo"
        panelTitulo.Size = New Size(803, 79)
        panelTitulo.TabIndex = 1
        ' 
        ' btnCrearViaje
        ' 
        btnCrearViaje.BackColor = Color.DodgerBlue
        btnCrearViaje.Cursor = Cursors.Hand
        btnCrearViaje.FlatStyle = FlatStyle.Flat
        btnCrearViaje.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCrearViaje.Location = New Point(603, 18)
        btnCrearViaje.Name = "btnCrearViaje"
        btnCrearViaje.Size = New Size(120, 42)
        btnCrearViaje.TabIndex = 2
        btnCrearViaje.Text = "Crear Viaje"
        btnCrearViaje.UseVisualStyleBackColor = False
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
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(DataViajes)
        Panel1.Location = New Point(0, 80)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(803, 432)
        Panel1.TabIndex = 2
        ' 
        ' DataViajes
        ' 
        DataViajes.BackgroundColor = Color.White
        DataViajes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataViajes.Columns.AddRange(New DataGridViewColumn() {RegistrarSalida, RegistrarLlegada})
        DataViajes.Location = New Point(12, 17)
        DataViajes.Name = "DataViajes"
        DataViajes.Size = New Size(776, 399)
        DataViajes.TabIndex = 0
        ' 
        ' RegistrarSalida
        ' 
        RegistrarSalida.HeaderText = "RSalida"
        RegistrarSalida.Image = CType(resources.GetObject("RegistrarSalida.Image"), Image)
        RegistrarSalida.Name = "RegistrarSalida"
        ' 
        ' RegistrarLlegada
        ' 
        RegistrarLlegada.HeaderText = "RLlegada"
        RegistrarLlegada.Image = CType(resources.GetObject("RegistrarLlegada.Image"), Image)
        RegistrarLlegada.Name = "RegistrarLlegada"
        ' 
        ' frmListarViaje
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 510)
        Controls.Add(Panel1)
        Controls.Add(panelTitulo)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmListarViaje"
        Text = "frmCrearViaje"
        panelTitulo.ResumeLayout(False)
        panelTitulo.PerformLayout()
        Panel1.ResumeLayout(False)
        CType(DataViajes, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnRegresar As Button
    Friend WithEvents panelTitulo As Panel
    Friend WithEvents btnCrearViaje As Button
    Friend WithEvents lb_Tittle As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataViajes As DataGridView
    Friend WithEvents RegistrarSalida As DataGridViewImageColumn
    Friend WithEvents RegistrarLlegada As DataGridViewImageColumn
End Class
