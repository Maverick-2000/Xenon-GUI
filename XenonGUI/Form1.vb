'------------------
'This is the Login Form
'Textbox1 means Email input
'Textbox2 means Password input
'MetroButton1 means Login button
'Label3 means Forgot Password link
'Label5 means Registration link
'sender As Object means parameter that contains the reference to the control/object that raised the event
'e As Event means e contains the event data
'------------------
Public Class Form1 'Class from 1
    Public Value As String 'Value variable as public so it can be used anywhere

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Subroutine for form load
        TextBox1.Select() 'when login form loads textbox1 (email) should be selected
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click 'subroutine when login button is clicked
        Try 'Try to login
            Dim proc As Process = New Process 'make a new process object called proc
            proc.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
            proc.StartInfo.Arguments = "login.py -u " + TextBox1.Text + " -p " + TextBox2.Text 'call the script login.py and pass the parameters
            proc.StartInfo.UseShellExecute = False 'required for redirect.
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
            proc.StartInfo.CreateNoWindow = True 'dont create a window while the script executes
            proc.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
            proc.Start() 'start the process i.e. the script (login.py)
            AddHandler proc.OutputDataReceived, AddressOf proccess_OutputDataReceived 'redirect the output from the script to variable Value
            proc.BeginOutputReadLine() 'start reading the redirected output
            proc.WaitForExit() 'wait for the script to complete execution
            If Value = "Login Success" Then 'check for string Login Success
                MsgBox(Value) 'Display the same as a message box
                Try 'Try to download
                    'check for uploads.txt in firebase (i.e. the meta data) if it exists downlolad it 
                    Dim download As Process = New Process 'make a new process object called download
                    download.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
                    download.StartInfo.Arguments = "download.py -u " + TextBox1.Text + " -p " + TextBox2.Text + " -f uploads.txt" 'call the script download.py and pass the parameters
                    download.StartInfo.UseShellExecute = False 'required for redirect.
                    download.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                    download.StartInfo.CreateNoWindow = True 'dont create a window while the script executes
                    download.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                    download.Start() 'start the process i.e. the script (download.py)
                    AddHandler download.OutputDataReceived, AddressOf proccess_OutputDataReceived 'redirect the output from the script to variable Value
                    download.BeginOutputReadLine() 'start reading the redirected output
                    download.WaitForExit() 'wait for the script to complete execution
                    If Value = "Done" Then 'check for string Done i.e uploads.txt exists in firebase
                        Form2.Show() 'Show Main Form i.e Form2
                        Me.Hide() ' hide Login Form
                    Else 'uploads.txt doesnt exist in firebase
                        MsgBox("Welcome") 'consider the user to be a new user since uploads.txt doesnt exist in firebase
                        Form2.Show() 'Show Main Form i.e Form2
                        Me.Hide() 'hide Login Form
                    End If
                Catch ex As Exception
                    MsgBox("Unknown Error") 'show message if exception occurs while exceuting download.py
                End Try
            Else
                MsgBox(Value) 'show script output if login fails (i.e invalid username/password)
            End If
        Catch ex As Exception
            MsgBox("Unknown Error") 'show message if exception occurs while exceuting login.py
        End Try
    End Sub
    Public Sub proccess_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs) 'subroutine for storing the redirected values from the script
        On Error Resume Next 'just continue in case of an error
        If e.Data = "" Then 'if the value from the script is blank then do nothing
        Else
            Value = e.Data 'value from the script is stored in the variable Value
        End If
    End Sub
    Private Sub Label5_Click_1(sender As Object, e As EventArgs) Handles Label5.Click 'subroutine when Registration link is clicked
        Me.Hide() 'hide Login Form
        Form4.Show() 'Show registration form i.e Form4
    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click 'subroutine when Forgot Password link is clicked
        If String.IsNullOrEmpty(TextBox1.Text) Then 'Check if Email input is empty
            MsgBox("Please enter email") ' if empty show this message
        Else
            Try 'try to execute forgot password script
                Dim forgot As Process = New Process 'make a new process object called forgot
                forgot.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
                forgot.StartInfo.Arguments = "forgot.py -u " + TextBox1.Text 'call the script forgot.py and pass the parameters
                forgot.StartInfo.UseShellExecute = False 'required for redirect.
                forgot.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                forgot.StartInfo.CreateNoWindow = True 'dont create a window while the script executes
                forgot.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                forgot.Start() 'start the process i.e. the script (forgot.py)
                AddHandler forgot.OutputDataReceived, AddressOf proccess_OutputDataReceived 'redirect the output from the script to variable Value
                forgot.BeginOutputReadLine() 'start reading the redirected output
                forgot.WaitForExit() 'wait for the script to complete execution
                If Value = "Password reset link sent" Then 'check for string Password reset link sent
                    MsgBox(Value) 'display the message i.e Password reset link sent
                Else 'script execution failed
                    MsgBox("Error") 'display error 
                End If
            Catch ex As Exception
                MsgBox("Unknown Error") 'show message if exception occurs while exceuting forgot.py
            End Try
        End If
    End Sub
End Class
