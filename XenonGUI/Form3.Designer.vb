<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits MetroFramework.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(313, 107)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Confirm"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Password
        '
        Me.Password.Font = New System.Drawing.Font("Consolas", 11.25!)
        Me.Password.Location = New System.Drawing.Point(23, 106)
        Me.Password.Name = "Password"
        Me.Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.Password.Size = New System.Drawing.Size(277, 25)
        Me.Password.TabIndex = 33
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(21, 79)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(66, 19)
        Me.MetroLabel2.TabIndex = 32
        Me.MetroLabel2.Text = "Password:"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 190)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Movable = False
        Me.Name = "Form3"
        Me.Resizable = False
        Me.Style = MetroFramework.MetroColorStyle.Magenta
        Me.Text = "Xenon"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Password As TextBox
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
End Class
