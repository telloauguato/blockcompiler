<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.act = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.actCheck = New System.Windows.Forms.CheckBox()
        Me.editInfo = New System.Windows.Forms.Button()
        Me.saida = New System.Windows.Forms.Label()
        Me.path = New System.Windows.Forms.Label()
        Me.monitora = New System.Windows.Forms.TextBox()
        Me.compliler = New System.Windows.Forms.Button()
        Me.ver = New System.Windows.Forms.Button()
        Me.compilador = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'act
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Arquivo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Saída:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ver)
        Me.GroupBox1.Controls.Add(Me.compliler)
        Me.GroupBox1.Controls.Add(Me.actCheck)
        Me.GroupBox1.Controls.Add(Me.editInfo)
        Me.GroupBox1.Controls.Add(Me.saida)
        Me.GroupBox1.Controls.Add(Me.path)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(511, 113)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informações"
        '
        'actCheck
        '
        Me.actCheck.AutoSize = True
        Me.actCheck.Location = New System.Drawing.Point(7, 84)
        Me.actCheck.Name = "actCheck"
        Me.actCheck.Size = New System.Drawing.Size(125, 17)
        Me.actCheck.TabIndex = 9
        Me.actCheck.Text = "Ativar monitoramento"
        Me.actCheck.UseVisualStyleBackColor = True
        '
        'editInfo
        '
        Me.editInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.editInfo.Location = New System.Drawing.Point(430, 84)
        Me.editInfo.Name = "editInfo"
        Me.editInfo.Size = New System.Drawing.Size(75, 23)
        Me.editInfo.TabIndex = 8
        Me.editInfo.Text = "Editar"
        Me.editInfo.UseVisualStyleBackColor = True
        '
        'saida
        '
        Me.saida.AutoSize = True
        Me.saida.Location = New System.Drawing.Point(70, 52)
        Me.saida.Name = "saida"
        Me.saida.Size = New System.Drawing.Size(0, 13)
        Me.saida.TabIndex = 7
        '
        'path
        '
        Me.path.AutoSize = True
        Me.path.Location = New System.Drawing.Point(70, 26)
        Me.path.Name = "path"
        Me.path.Size = New System.Drawing.Size(0, 13)
        Me.path.TabIndex = 6
        '
        'monitora
        '
        Me.monitora.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.monitora.BackColor = System.Drawing.Color.Black
        Me.monitora.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.monitora.ForeColor = System.Drawing.SystemColors.Window
        Me.monitora.Location = New System.Drawing.Point(12, 132)
        Me.monitora.Multiline = True
        Me.monitora.Name = "monitora"
        Me.monitora.ReadOnly = True
        Me.monitora.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.monitora.Size = New System.Drawing.Size(511, 279)
        Me.monitora.TabIndex = 7
        '
        'compliler
        '
        Me.compliler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.compliler.Location = New System.Drawing.Point(349, 84)
        Me.compliler.Name = "compliler"
        Me.compliler.Size = New System.Drawing.Size(75, 23)
        Me.compliler.TabIndex = 10
        Me.compliler.Text = "Compilar"
        Me.compliler.UseVisualStyleBackColor = True
        '
        'ver
        '
        Me.ver.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ver.Location = New System.Drawing.Point(268, 84)
        Me.ver.Name = "ver"
        Me.ver.Size = New System.Drawing.Size(75, 23)
        Me.ver.TabIndex = 11
        Me.ver.Text = "Pasta"
        Me.ver.UseVisualStyleBackColor = True
        '
        'compilador
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 423)
        Me.Controls.Add(Me.monitora)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "_Block Compiler"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents act As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents editInfo As Button
    Friend WithEvents saida As Label
    Friend WithEvents path As Label
    Friend WithEvents actCheck As CheckBox
    Friend WithEvents monitora As TextBox
    Friend WithEvents ver As Button
    Friend WithEvents compliler As Button
    Friend WithEvents compilador As Timer
End Class
