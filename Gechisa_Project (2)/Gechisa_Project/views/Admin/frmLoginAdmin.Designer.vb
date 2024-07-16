<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLoginAdmin

    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoginAdmin))
        panelTitulo = New Panel()
        btnRegresar = New Button()
        lb_Tittle = New Label()
        panelBusqueda = New Panel()
        btnLogin = New Button()
        txt_Contraseña = New TextBox()
        txt_Usuario = New TextBox()
        lbContraseña = New Label()
        lbUsuario = New Label()
        PictureBox1 = New PictureBox()
        panelTitulo.SuspendLayout()
        panelBusqueda.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' panelTitulo
        ' 
        panelTitulo.BackColor = Color.Gold
        panelTitulo.Controls.Add(btnRegresar)
        panelTitulo.Controls.Add(lb_Tittle)
        panelTitulo.Location = New Point(0, 0)
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
        panelBusqueda.Controls.Add(btnLogin)
        panelBusqueda.Controls.Add(txt_Contraseña)
        panelBusqueda.Controls.Add(txt_Usuario)
        panelBusqueda.Controls.Add(lbContraseña)
        panelBusqueda.Controls.Add(lbUsuario)
        panelBusqueda.Controls.Add(PictureBox1)
        panelBusqueda.Location = New Point(0, 79)
        panelBusqueda.Name = "panelBusqueda"
        panelBusqueda.Size = New Size(684, 422)
        panelBusqueda.TabIndex = 3
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.DodgerBlue
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogin.Location = New Point(270, 311)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(144, 39)
        btnLogin.TabIndex = 5
        btnLogin.Text = "Iniciar Sesión"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' txt_Contraseña
        ' 
        txt_Contraseña.Font = New Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txt_Contraseña.Location = New Point(199, 247)
        txt_Contraseña.Multiline = True
        txt_Contraseña.Name = "txt_Contraseña"
        txt_Contraseña.Size = New Size(293, 36)
        txt_Contraseña.TabIndex = 4
        ' 
        ' txt_Usuario
        ' 
        txt_Usuario.Font = New Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txt_Usuario.Location = New Point(199, 169)
        txt_Usuario.Multiline = True
        txt_Usuario.Name = "txt_Usuario"
        txt_Usuario.Size = New Size(293, 36)
        txt_Usuario.TabIndex = 3
        ' 
        ' lbContraseña
        ' 
        lbContraseña.AutoSize = True
        lbContraseña.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbContraseña.Location = New Point(199, 222)
        lbContraseña.Name = "lbContraseña"
        lbContraseña.Size = New Size(99, 19)
        lbContraseña.TabIndex = 2
        lbContraseña.Text = "Contraseña"
        ' 
        ' lbUsuario
        ' 
        lbUsuario.AutoSize = True
        lbUsuario.Font = New Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbUsuario.Location = New Point(199, 144)
        lbUsuario.Name = "lbUsuario"
        lbUsuario.Size = New Size(72, 19)
        lbUsuario.TabIndex = 1
        lbUsuario.Text = "Usuario"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(308, 37)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(58, 63)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' frmLoginAdmin
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(683, 502)
        Controls.Add(panelTitulo)
        Controls.Add(panelBusqueda)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmLoginAdmin"
        Text = "Form1"
        panelTitulo.ResumeLayout(False)
        panelTitulo.PerformLayout()
        panelBusqueda.ResumeLayout(False)
        panelBusqueda.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents panelTitulo As Panel
    Friend WithEvents btnRegresar As Button
    Friend WithEvents lb_Tittle As Label
    Friend WithEvents panelBusqueda As Panel
    Friend WithEvents lbUsuario As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txt_Usuario As TextBox
    Friend WithEvents lbContraseña As Label
    Friend WithEvents txt_Contraseña As TextBox
    Friend WithEvents btnLogin As Button

End Class
