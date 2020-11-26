Imports System.Diagnostics
Public Class Form1
    Public Value As String


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Select()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            Dim proc As Process = New Process
            proc.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
            proc.StartInfo.Arguments = "login.py -u " + TextBox1.Text + " -p " + TextBox2.Text
            proc.StartInfo.UseShellExecute = False 'required for redirect.
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
            proc.StartInfo.CreateNoWindow = True
            proc.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
            proc.Start()
            AddHandler proc.OutputDataReceived, AddressOf proccess_OutputDataReceived
            proc.BeginOutputReadLine()
            proc.WaitForExit()
            If Value = "Login Success" Then
                MsgBox(Value)




                Try
                    Dim download As Process = New Process
                    download.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
                    download.StartInfo.Arguments = "download.py -u " + TextBox1.Text + " -p " + TextBox2.Text + " -f uploads.txt"
                    download.StartInfo.UseShellExecute = False 'required for redirect.
                    download.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                    download.StartInfo.CreateNoWindow = True
                    download.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                    download.Start()
                    AddHandler download.OutputDataReceived, AddressOf proccess_OutputDataReceived
                    download.BeginOutputReadLine()
                    download.WaitForExit()
                    If Value = "Done" Then
                        Form2.Show()
                        Me.Hide()
                    Else
                        MsgBox("Welcome")
                        Form2.Show()
                        Me.Hide()
                    End If
                Catch ex As Exception
                    MsgBox("Unknown Error")
                End Try
            Else
                MsgBox(Value)
            End If
        Catch ex As Exception
            MsgBox("Unknown Error")
        End Try
    End Sub
    Public Sub proccess_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        On Error Resume Next
        If e.Data = "" Then
        Else
            Value = e.Data
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CarbonFiberTheme1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label5_Click_1(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MsgBox("Please enter email")
        Else
            Try
                Dim forgot As Process = New Process
                forgot.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
                forgot.StartInfo.Arguments = "forgot.py -u " + TextBox1.Text
                forgot.StartInfo.UseShellExecute = False 'required for redirect.
                forgot.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                forgot.StartInfo.CreateNoWindow = True
                forgot.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                forgot.Start()
                AddHandler forgot.OutputDataReceived, AddressOf proccess_OutputDataReceived
                forgot.BeginOutputReadLine()
                forgot.WaitForExit()
                If Value = "Password reset link sent" Then
                    MsgBox(Value)
                Else
                    MsgBox("Error")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
