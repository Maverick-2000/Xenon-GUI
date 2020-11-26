<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetroButton1
        '
        Me.MetroButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MetroButton1.Location = New System.Drawing.Point(366, 262)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(142, 23)
        Me.MetroButton1.TabIndex = 43
        Me.MetroButton1.Text = "Register"
        Me.MetroButton1.UseSelectable = True
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Consolas", 11.25!)
        Me.TextBox3.Location = New System.Drawing.Point(297, 215)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.TextBox3.Size = New System.Drawing.Size(277, 25)
        Me.TextBox3.TabIndex = 42
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(294, 188)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(118, 19)
        Me.MetroLabel3.TabIndex = 41
        Me.MetroLabel3.Text = "Confirm Password:"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Consolas", 11.25!)
        Me.TextBox2.Location = New System.Drawing.Point(297, 152)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.TextBox2.Size = New System.Drawing.Size(277, 25)
        Me.TextBox2.TabIndex = 40
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Consolas", 11.25!)
        Me.TextBox1.Location = New System.Drawing.Point(297, 86)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(277, 25)
        Me.TextBox1.TabIndex = 39
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(295, 125)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(66, 19)
        Me.MetroLabel2.TabIndex = 38
        Me.MetroLabel2.Text = "Password:"
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(294, 63)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(44, 19)
        Me.MetroLabel1.TabIndex = 37
        Me.MetroLabel1.Text = "Email:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.XenonGUI.My.Resources.Resources.pngwave
        Me.PictureBox1.Location = New System.Drawing.Point(33, 90)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(230, 182)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 36
        Me.PictureBox1.TabStop = False
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 341)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form4"
        Me.Resizable = False
        Me.Style = MetroFramework.MetroColorStyle.Magenta
        Me.Text = "Xenon"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents PictureBox1 As PictureBox
End Class
