Imports System.IO
Public Class Form2
    Public Value As String
    Dim Newline As String = System.Environment.NewLine
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Dim selfile As String
        OpenFileDialog1.Title = "Select files"
        OpenFileDialog1.ShowDialog()
        selfile = OpenFileDialog1.FileName
        TextBox1.Text = selfile
        TextBox2.Text = "Selected File: " + TextBox1.Text
    End Sub
    Public Sub proccess_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        On Error Resume Next
        If e.Data = "" Then
        Else
            Value = e.Data
        End If
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim fileNames = My.Computer.FileSystem.GetFiles("Downloads", FileIO.SearchOption.SearchTopLevelOnly)
            ListBox2.Items.Clear()
            For Each fileName As String In fileNames
                Dim result As String = Path.GetFileName(fileName)
                ListBox2.Items.Add(result)
            Next
            Dim r As IO.StreamReader
            r = New IO.StreamReader("uploads.txt")
            While (r.Peek() >= 1)
                ListBox1.Items.Add(r.ReadLine)
            End While
            r.Close()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown 'form shown Event
        ' Me.Visible = False
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub InfluenceTheme1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Form3.ShowDialog()
        TextBox2.Text += Newline + "Encrypting...."
        'python AesCrypt.py -f "E:\New folder (2)\lorem ipsum.txt" -p maver0182 -e 
        Dim proc As Process = New Process
        proc.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
        proc.StartInfo.Arguments = "AesCrypt.py -f " + Chr(34) + TextBox1.Text + Chr(34) + " -p " + Form3.Password.Text + " -e"
        'TextBox2.Text = "AesCrypt.py -f " + Chr(34) + TextBox1.Text + Chr(34) + " -p " + Form3.Password.Text + " -e"
        proc.StartInfo.UseShellExecute = False 'required for redirect.
        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
        proc.Start()
        AddHandler proc.OutputDataReceived, AddressOf proccess_OutputDataReceived
        proc.BeginOutputReadLine()
        proc.WaitForExit()
        Dim filetoupload As String
        filetoupload = Value
        'python upload.py -u maver0182@gmail.com -p maver0182 -f "E:\New folder (2)\lorem ipsum.txt" 
        'proc.StartInfo.Arguments = "upload.py -u " + Chr(34) + TextBox1.Text + Chr(34) + " -p " + Form3.Password.Text + " -e"
        proc.StartInfo.Arguments = "upload.py -u " + Form1.TextBox1.Text + " -p " + Form1.TextBox2.Text + " -f" + Chr(34) + filetoupload + Chr(34)
        TextBox2.Text += Newline + "Starting Upload..."

        proc.Start()
        AddHandler proc.OutputDataReceived, AddressOf proccess_OutputDataReceived

        proc.WaitForExit()
        TextBox2.Text += Newline + "Updating Metadata.."
        Try
            Dim meta As Process = New Process
            meta.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
            meta.StartInfo.Arguments = "upload.py -u " + Form1.TextBox1.Text + " -p " + Form1.TextBox2.Text + " -f uploads.txt"
            meta.StartInfo.UseShellExecute = False 'required for redirect.
            meta.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
            meta.StartInfo.CreateNoWindow = True
            meta.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
            meta.Start()
            AddHandler meta.OutputDataReceived, AddressOf proccess_OutputDataReceived
            meta.BeginOutputReadLine()
            meta.WaitForExit()
            MsgBox("Success")
            TextBox2.Text += Newline + "Upload success!"
            My.Computer.FileSystem.DeleteFile(filetoupload)
        Catch ex As Exception
            MsgBox("Error")
        End Try


    End Sub

    Private Sub CarbonFiberTheme1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Form1.Close()
            My.Computer.FileSystem.DeleteFile("uploads.txt")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Dim filetodownload As String
        filetodownload = ListBox1.SelectedItem

        If filetodownload = "" Then
            MsgBox("Please Select a file")
        Else
            TextBox5.Text += Newline + "Selected File: " + filetodownload
            Try
                Dim download As Process = New Process
                download.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
                download.StartInfo.Arguments = "download.py -u " + Form1.TextBox1.Text + " -p " + Form1.TextBox2.Text + " -f " + Chr(34) + filetodownload + Chr(34)
                download.StartInfo.UseShellExecute = False 'required for redirect.
                download.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                download.StartInfo.CreateNoWindow = True
                download.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                download.Start()
                AddHandler download.OutputDataReceived, AddressOf proccess_OutputDataReceived
                download.BeginOutputReadLine()
                download.WaitForExit()
                TextBox5.Text += Newline + "Starting Download...."
                TextBox5.Text += Newline + "Please wait.."
                If Value = "Done" Then
                    MsgBox("Success")
                    TextBox5.Text += Newline + "Download Success"
                    TextBox5.Text += Newline + "Starting Decryption..."
                    Try
                        Form3.Password.Text = ""
                        Form3.ShowDialog()
                        Dim decrypt As Process = New Process
                        decrypt.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
                        decrypt.StartInfo.Arguments = "AesCrypt.py -f " + Chr(34) + "Downloads\" + filetodownload + Chr(34) + " -p " + Form3.Password.Text + " -d"
                        'TextBox2.Text = "AesCrypt.py -f " + Chr(34) + TextBox1.Text + Chr(34) + " -p " + Form3.Password.Text + " -e"
                        decrypt.StartInfo.UseShellExecute = False 'required for redirect.
                        decrypt.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                        decrypt.StartInfo.CreateNoWindow = True
                        decrypt.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                        decrypt.Start()
                        AddHandler decrypt.OutputDataReceived, AddressOf proccess_OutputDataReceived
                        decrypt.BeginOutputReadLine()
                        decrypt.WaitForExit()
                        If Value = "Decrypted" Then
                            MsgBox("Decrypted Successfully")
                            TextBox5.Text += Newline + "Decryption Successful!"
                            Process.Start("explorer.exe", "Downloads")
                            Dim selfdestructfile As String

                            selfdestructfile = "Downloads\" + filetodownload

                            My.Computer.FileSystem.DeleteFile(selfdestructfile)
                        Else
                            MsgBox("Invalid Pass")
                        End If
                    Catch ex As Exception

                    End Try
                End If
            Catch ex As Exception
                MsgBox("Error")
            End Try
        End If
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        Dim filetodelete As String
        filetodelete = ListBox1.SelectedItem
        If filetodelete = "" Then
            MsgBox("Please Select a file")
        Else
            TextBox5.Text += Newline + "Selected File: " + filetodelete
            Try
                Dim delete As Process = New Process
                delete.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
                delete.StartInfo.Arguments = "delete.py -u " + Form1.TextBox1.Text + " -p " + Form1.TextBox2.Text + " -f " + Chr(34) + filetodelete + Chr(34)
                delete.StartInfo.UseShellExecute = False 'required for redirect.
                delete.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                delete.StartInfo.CreateNoWindow = True
                delete.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                delete.Start()
                AddHandler delete.OutputDataReceived, AddressOf proccess_OutputDataReceived
                delete.BeginOutputReadLine()
                delete.WaitForExit()
                If Value = "Deleted" Then
                    TextBox5.Text += Newline + "Deletion successful"
                    MsgBox("Deleted successfully")
                    Try
                        TextBox5.Text += Newline + "Updating metadata..."
                        Dim meta As Process = New Process
                        meta.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
                        meta.StartInfo.Arguments = "upload.py -u " + Form1.TextBox1.Text + " -p " + Form1.TextBox2.Text + " -f uploads.txt"
                        meta.StartInfo.UseShellExecute = False 'required for redirect.
                        meta.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                        meta.StartInfo.CreateNoWindow = True
                        meta.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                        meta.Start()
                        AddHandler meta.OutputDataReceived, AddressOf proccess_OutputDataReceived
                        meta.BeginOutputReadLine()
                        meta.WaitForExit()
                        ListBox1.Items.Clear()
                        Dim r As IO.StreamReader
                        r = New IO.StreamReader("uploads.txt")
                        While (r.Peek() >= 1)
                            ListBox1.Items.Add(r.ReadLine)
                        End While
                        r.Close()
                    Catch ex As Exception
                        MsgBox("Error")
                    End Try
                Else
                    MsgBox("File not found")
                End If

            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        TextBox5.Text += Newline + "Refresh...."
        Try
            ListBox1.Items.Clear()
            Dim r As IO.StreamReader
            r = New IO.StreamReader("uploads.txt")
            While (r.Peek() >= 1)
                ListBox1.Items.Add(r.ReadLine)
            End While
            r.Close()
        Catch ex As Exception
            MsgBox("Meta Data Missing")
        End Try
        Try

            Dim fileNames = My.Computer.FileSystem.GetFiles("Downloads", FileIO.SearchOption.SearchTopLevelOnly)
            ListBox2.Items.Clear()
            For Each fileName As String In fileNames
                Dim result As String = Path.GetFileName(fileName)
                ListBox2.Items.Add(result)
            Next
        Catch ex As Exception

        End Try
        MsgBox("Refreshed")
    End Sub




End Class