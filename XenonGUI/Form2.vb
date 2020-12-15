'This is the Main Form (Form 2)
'------------------
'Textbox1 means file to upload input
'Textbox2 means upload console
'Textbox3 means help console
'Textbox4 means about console
'Textbox5 means management console
'MetroButton1 means Browse button
'MetroButton2 means Upload button
'MetroButton3 means Download button
'MetroButton4 means Refresh Lists button
'MetroButton5 means Delete button
'ListBox1 means Files on Cloud list
'ListBox2 means Files on Host list
'sender As Object means parameter that contains the reference to the control/object that raised the event
'e As Event means e contains the event data
'------------------
Imports System.IO 'import System.IO namespace (set of signs that are used to identify and refer to objects of various kinds)
'mainly used for system operations such as delete,rename etc...
Public Class Form2 'Class Form 2 
    Public Value As String 'Value variable as public so it can be used anywhere
    Dim Newline As String = System.Environment.NewLine 'Assign new line property to the variable Newline (whenever this variable is included a new line is created)
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click 'subroutine when browse button is clicked
        Dim selfile As String 'string variable called selfile for storing selected file path 
        OpenFileDialog1.Title = "Select files" 'set open file dialog pop up title
        OpenFileDialog1.ShowDialog() 'Show the open file dialog for browsing files
        selfile = OpenFileDialog1.FileName 'Store the selected file in selfile
        TextBox1.Text = selfile 'Assign selfile value file to upload input (i.e Textbox1) 
        TextBox2.Text = "Selected File: " + TextBox1.Text 'Set upload console (i.e Textbox2 ) value to display selected file
    End Sub
    Public Sub proccess_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs) 'subroutine for storing the redirected values from the script
        On Error Resume Next 'just continue in case of an error
        If e.Data = "" Then 'if the value from the script is blank then do nothing
        Else
            Value = e.Data 'value from the script is stored in the variable Value
        End If
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Subroutine for form load
        Try 'try to load items to Files on Cloud list (i.e ListBox1) and Files on Host list (i.e ListBox2)

            Dim fileNames = My.Computer.FileSystem.GetFiles("Downloads", FileIO.SearchOption.SearchTopLevelOnly) 'Call the function GetFiles in order to get the list of files present in Downloads folder
            ListBox2.Items.Clear() 'Clear Files on Host list (i.e ListBox2)
            For Each fileName As String In fileNames 'For loop for getting each file name
                Dim result As String = Path.GetFileName(fileName) 'Store the file name in result
                ListBox2.Items.Add(result) 'Add result to Files on Host list (i.e ListBox2)
            Next
            Dim r As IO.StreamReader 'Define r (object) as new Stream reader (for reading from text file)
            r = New IO.StreamReader("uploads.txt") 'read from uploads.txt
            While (r.Peek() >= 1) 'while loop the peak method checks whether the end of the file has reached (when end is reached it returns -1)
                ListBox1.Items.Add(r.ReadLine) 'Add each line to the Files on Cloud list (i.e ListBox1)
            End While
            r.Close() 'Close stream reader to flush all the buffers
        Catch ex As Exception
            'Do nothing in case of exception
        End Try


    End Sub



    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click 'subroutine when upload button is clicked
        Form3.ShowDialog() 'Show Password for encryption/decryption form (i.e Form3) as dialog
        'Start encryption
        TextBox2.Text += Newline + "Encrypting...." 'Set upload console (i.e Textbox2 ) value to a newline and then display Encrypting 
        Dim proc As Process = New Process 'make a new process object called proc
        proc.StartInfo.FileName = "python.exe" 'Default Python Installation
        proc.StartInfo.Arguments = "AesCrypt.py -f " + Chr(34) + TextBox1.Text + Chr(34) + " -p " + Form3.Password.Text + " -e" 'call the script AesCrypt.py and pass the parameters
        proc.StartInfo.UseShellExecute = False 'required for redirect.
        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
        proc.StartInfo.CreateNoWindow = True 'dont create a window while the script executes
        proc.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
        proc.Start() 'start the process i.e. the script (AesCrypt.py)
        AddHandler proc.OutputDataReceived, AddressOf proccess_OutputDataReceived 'redirect the output from the script to variable Value
        proc.BeginOutputReadLine() 'start reading the redirected output
        proc.WaitForExit() 'wait for the script to complete execution
        'Start Upload
        Dim filetoupload As String 'String variable called filetoupload to store the path of the file to upload 
        filetoupload = Value 'Assign value returned by the script to filetoupload (Here the value returned is the encrypted file)
        proc.StartInfo.Arguments = "upload.py -u " + Form1.TextBox1.Text + " -p " + Form1.TextBox2.Text + " -f" + Chr(34) + filetoupload + Chr(34) 'call the script upload.py and pass the parameters
        TextBox2.Text += Newline + "Starting Upload..." 'Set upload console (i.e Textbox2 ) value to a newline and then display Starting Upload...
        proc.Start() 'start the process i.e. the script (upload.py)
        AddHandler proc.OutputDataReceived, AddressOf proccess_OutputDataReceived 'redirect the output from the script to variable Value
        proc.WaitForExit() 'wait for the script to complete execution
        TextBox2.Text += Newline + "Updating Metadata.." 'Set upload console (i.e Textbox2 ) value to a newline and then display Updating Metadata..
        Try 'Try to update uploads.txt (i.e metadata) in firebase
            Dim meta As Process = New Process 'make a new process object called meta
            meta.StartInfo.FileName = "python.exe" 'Default Python Installation
            meta.StartInfo.Arguments = "upload.py -u " + Form1.TextBox1.Text + " -p " + Form1.TextBox2.Text + " -f uploads.txt" 'call the script upload.py and pass the parameters
            meta.StartInfo.UseShellExecute = False 'required for redirect.
            meta.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
            meta.StartInfo.CreateNoWindow = True 'dont create a window while the script executes
            meta.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
            meta.Start() 'start the process i.e. the script (upload.py)
            AddHandler meta.OutputDataReceived, AddressOf proccess_OutputDataReceived 'redirect the output from the script to variable Value
            meta.BeginOutputReadLine() 'start reading the redirected output
            meta.WaitForExit() 'wait for the script to complete execution
            MsgBox("Success") 'After execution display Success
            TextBox2.Text += Newline + "Upload success!" 'Set upload console (i.e Textbox2 ) value to a newline and then display Upload success!
            My.Computer.FileSystem.DeleteFile(filetoupload) 'Delete encrypted file after upload
        Catch ex As Exception
            MsgBox("Error") 'show message if exception occurs while exceuting upload.py
        End Try


    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing 'subroutine when form is closed
        Try 'try to close Form1 (i.e login form) and delete uploads.txt (i.e metadata)
            Form1.Close() 'close Form1 (i.e Login form)
            My.Computer.FileSystem.DeleteFile("uploads.txt") 'Delete uploads.txt (i.e metadata)
        Catch ex As Exception
            'Do nothing if exception occurs
        End Try

    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click 'subroutine when download button is clicked
        Dim filetodownload As String 'String variable called filetodownload to store the path of the file to download 
        filetodownload = ListBox1.SelectedItem 'set file to download as selected item on files on cloud list (i.e Listbox1)

        If filetodownload = "" Then 'if nothing is selected from files on cloud list (i.e listBox1) then show message
            MsgBox("Please Select a file")
        Else
            TextBox5.Text += Newline + "Selected File: " + filetodownload 'Set management console (i.e Textbox5 ) value to a newline and then display the file to download
            Try 'Try to download
                'Start Download
                Dim download As Process = New Process 'make a new process object called download
                download.StartInfo.FileName = "python.exe" 'Default Python Installation
                download.StartInfo.Arguments = "download.py -u " + Form1.TextBox1.Text + " -p " + Form1.TextBox2.Text + " -f " + Chr(34) + filetodownload + Chr(34) 'call the script download.py and pass the parameters
                download.StartInfo.UseShellExecute = False 'required for redirect.
                download.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                download.StartInfo.CreateNoWindow = True 'dont create a window while the script executes
                download.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                download.Start() 'start the process i.e. the script (download.py)
                AddHandler download.OutputDataReceived, AddressOf proccess_OutputDataReceived 'redirect the output from the script to variable Value
                download.BeginOutputReadLine() 'start reading the redirected output
                download.WaitForExit() 'wait for the script to complete execution
                TextBox5.Text += Newline + "Starting Download...." 'Set management console (i.e Textbox5 ) value to a newline and then display Starting Download
                TextBox5.Text += Newline + "Please wait.." 'Set management console (i.e Textbox5 ) value to a newline and then display Please wait
                If Value = "Done" Then 'check for string Done i.e download completed 
                    MsgBox("Success") 'display the corresponding message
                    TextBox5.Text += Newline + "Download Success" 'Set management console (i.e Textbox5 ) value to a newline and then display Download Success
                    'Start Decryption
                    TextBox5.Text += Newline + "Starting Decryption..." 'Set management console (i.e Textbox5 ) value to a newline and then display Download Success
                    Try
                        Form3.Password.Text = "" 'Clear text for Password for encryption/decryption form (i.e Form3) 
                        Form3.ShowDialog() 'Show Password for encryption/decryption form (i.e Form3) as dialog
                        Dim decrypt As Process = New Process 'make a new process object called decrypt
                        decrypt.StartInfo.FileName = "python.exe" 'Default Python Installation
                        decrypt.StartInfo.Arguments = "AesCrypt.py -f " + Chr(34) + "Downloads\" + filetodownload + Chr(34) + " -p " + Form3.Password.Text + " -d" 'call the script AesCrypt.py and pass the parameters
                        decrypt.StartInfo.UseShellExecute = False 'required for redirect.
                        decrypt.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                        decrypt.StartInfo.CreateNoWindow = True 'dont create a window while the script executes
                        decrypt.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                        decrypt.Start() 'start the process i.e. the script (AesCrypt.py)
                        AddHandler decrypt.OutputDataReceived, AddressOf proccess_OutputDataReceived 'redirect the output from the script to variable Value
                        decrypt.BeginOutputReadLine() 'start reading the redirected output
                        decrypt.WaitForExit() 'wait for the script to complete execution
                        If Value = "Decrypted" Then 'check for string Decrypted
                            MsgBox("Decrypted Successfully") 'Display message 
                            TextBox5.Text += Newline + "Decryption Successful!" 'Set management console (i.e Textbox5 ) value to a newline and then display Decryption Successful!
                            Process.Start("explorer.exe", "Downloads") 'start Windows Explorer and open downloads folder
                            Dim selfdestructfile As String 'String variable called selfdestructfile to store the path of downloaded .aes file

                            selfdestructfile = "Downloads\" + filetodownload 'store the path of the downloaded .aes file

                            My.Computer.FileSystem.DeleteFile(selfdestructfile) 'delete the downloaded .aes file as its useless
                        Else
                            MsgBox("Invalid Pass") 'Display if password incorrect
                        End If
                    Catch ex As Exception
                        'Do nothing if exception occurs
                    End Try
                End If
            Catch ex As Exception
                MsgBox("Error") 'show message if exception occurs while exceuting download.py
            End Try
        End If
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click 'subroutine when delete button is clicked
        Dim filetodelete As String 'String variable called filetodelete to store the path of the file to delete on firebase 
        filetodelete = ListBox1.SelectedItem 'set file to delete as selected item on files on cloud list (i.e Listbox1)
        If filetodelete = "" Then 'if nothing is selected from files on cloud list (i.e listBox1) then show message
            MsgBox("Please Select a file")
        Else
            TextBox5.Text += Newline + "Selected File: " + filetodelete 'Set management console (i.e Textbox5 ) value to a newline and then display the file to delete
            Try 'try to delete
                'start delete
                Dim delete As Process = New Process 'make a new process object called delete
                delete.StartInfo.FileName = "python.exe" 'Default Python Installation
                delete.StartInfo.Arguments = "delete.py -u " + Form1.TextBox1.Text + " -p " + Form1.TextBox2.Text + " -f " + Chr(34) + filetodelete + Chr(34) 'call the script delete.py and pass the parameters
                delete.StartInfo.UseShellExecute = False 'required for redirect.
                delete.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                delete.StartInfo.CreateNoWindow = True 'dont create a window while the script executes
                delete.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                delete.Start() 'start the process i.e. the script (delete.py)
                AddHandler delete.OutputDataReceived, AddressOf proccess_OutputDataReceived 'redirect the output from the script to variable Value
                delete.BeginOutputReadLine() 'start reading the redirected output
                delete.WaitForExit() 'wait for the script to complete execution
                If Value = "Deleted" Then 'check for string Deleted
                    TextBox5.Text += Newline + "Deletion successful" 'Set management console (i.e Textbox5 ) value to a newline and then display Deletion successful
                    MsgBox("Deleted successfully") 'Display message 
                    Try
                        Me.Cursor = Cursors.WaitCursor
                        'update metadata (i.e uploads.txt) in firebase
                        TextBox5.Text += Newline + "Updating metadata..." 'Set management console (i.e Textbox5 ) value to a newline and then display Updating metadata
                        Dim meta As Process = New Process 'make a new process object called meta
                        meta.StartInfo.FileName = "python.exe" 'Default Python Installation
                        meta.StartInfo.Arguments = "upload.py -u " + Form1.TextBox1.Text + " -p " + Form1.TextBox2.Text + " -f uploads.txt" 'call the script upload.py and pass the parameters
                        meta.StartInfo.UseShellExecute = False 'required for redirect.
                        meta.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                        meta.StartInfo.CreateNoWindow = True 'dont create a window while the script executes
                        meta.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                        meta.Start() 'start the process i.e. the script (upload.py)
                        AddHandler meta.OutputDataReceived, AddressOf proccess_OutputDataReceived 'redirect the output from the script to variable Value
                        meta.BeginOutputReadLine() 'start reading the redirected output
                        meta.WaitForExit() 'wait for the script to complete execution
                        ListBox1.Items.Clear() 'clear Files on Cloud list (i.e Listbox1)
                        Dim r As IO.StreamReader 'Define r (object) as new Stream reader (for reading from text file)
                        r = New IO.StreamReader("uploads.txt") 'read from uploads.txt
                        While (r.Peek() >= 1) 'while loop the peak method checks whether the end of the file has reached (when end is reached it returns -1)
                            ListBox1.Items.Add(r.ReadLine) 'Add each line to the Files on Cloud list (i.e ListBox1)
                        End While
                        r.Close() 'Close stream reader to flush all the buffers
                        Me.Cursor = Cursors.Default
                        TextBox5.Text += Newline + "Metadata update complete..."
                    Catch ex As Exception
                        MsgBox("Error") 'Display message upon exception
                        Me.Cursor = Cursors.Default
                    End Try
                Else
                    MsgBox("File not found") 'if script returns error
                    Me.Cursor = Cursors.Default
                End If
                'Do nothing if exception occurs
            Catch ex As Exception
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click 'subroutine when refresh button is clicked
        TextBox5.Text += Newline + "Refresh...."  'Set management console (i.e Textbox5 ) value to a newline and then display the file to Refresh....
        Try 'try to refresh Files on Cloud (i.e ListBox1)
            ListBox1.Items.Clear() 'Clear Files on Cloud list (i.e ListBox1)
            Dim r As IO.StreamReader 'Define r (object) as new Stream reader (for reading from text file)
            r = New IO.StreamReader("uploads.txt") 'read from uploads.txt
            While (r.Peek() >= 1) 'while loop the peak method checks whether the end of the file has reached (when end is reached it returns -1)
                ListBox1.Items.Add(r.ReadLine) 'Add each line to the Files on Cloud list (i.e ListBox1)
            End While
            r.Close() 'Close stream reader to flush all the buffers
        Catch ex As Exception
            MsgBox("Meta Data Missing") 'display message if exception occurs
        End Try
        Try 'try to refresh Files on Host (i.e ListBox2)

            Dim fileNames = My.Computer.FileSystem.GetFiles("Downloads", FileIO.SearchOption.SearchTopLevelOnly) 'Call the function GetFiles in order to get the list of files present in Downloads folder
            ListBox2.Items.Clear() 'Clear Files on Host list (i.e ListBox2)
            For Each fileName As String In fileNames 'For loop for getting each file name
                Dim result As String = Path.GetFileName(fileName) 'Store the file name in result
                ListBox2.Items.Add(result) 'Add result to Files on Host list (i.e ListBox2)
            Next
        Catch ex As Exception
            'Do nothing if exception occurs
        End Try
        MsgBox("Refreshed") 'Display message 
    End Sub




End Class