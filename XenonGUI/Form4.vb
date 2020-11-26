Public Class Form4
    Public Value As String
    Public Sub proccess_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        On Error Resume Next
        If e.Data = "" Then
        Else
            Value = e.Data
        End If
    End Sub
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If String.IsNullOrEmpty(TextBox2.Text) Or String.IsNullOrEmpty(TextBox3.Text) Or String.IsNullOrEmpty(TextBox1.Text) Then
            MsgBox("Please fill all the fields")
        ElseIf TextBox2.Text = TextBox3.Text Then
            Try
                Dim reg As Process = New Process
                reg.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
                reg.StartInfo.Arguments = "register.py -u " + TextBox1.Text + " -p " + TextBox2.Text
                reg.StartInfo.UseShellExecute = False 'required for redirect.
                reg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                reg.StartInfo.CreateNoWindow = True
                reg.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                reg.Start()
                AddHandler reg.OutputDataReceived, AddressOf proccess_OutputDataReceived
                reg.BeginOutputReadLine()
                reg.WaitForExit()

                If Value = "Registration success" Then
                    MsgBox(Value)
                    Form1.Show()
                    Me.Hide()
                Else
                    MsgBox("Error")
                End If
            Catch ex As Exception
            End Try

        Else
            MsgBox("Passwords dont match")
        End If
    End Sub
    Private Sub Form4_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Form1.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class