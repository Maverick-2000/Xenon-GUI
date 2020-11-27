'This is the Registration Form (Form 4)
'------------------
'Textbox1 means Email input
'Textbox2 means Password input
'Textbox3 means Password input confirmation
'MetroButton1 means Register button
'sender As Object means parameter that contains the reference to the control/object that raised the event
'e As Event means e contains the event data
'------------------
Public Class Form4
    Public Value As String 'Value variable as public so it can be used anywhere
    Public Sub proccess_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs) 'subroutine for storing the redirected values from the script
        On Error Resume Next 'just continue in case of an error
        If e.Data = "" Then 'if the value from the script is blank then do nothing
        Else
            Value = e.Data 'value from the script is stored in the variable Value
        End If
    End Sub
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click 'subroutine when register button is clicked
        If String.IsNullOrEmpty(TextBox2.Text) Or String.IsNullOrEmpty(TextBox3.Text) Or String.IsNullOrEmpty(TextBox1.Text) Then 'check if email input (i.e Textbox1) or password input (i.e Textbox2) or password confirmation (i.e Textbox3) is empty
            MsgBox("Please fill all the fields") 'Display this message if empty 
        ElseIf TextBox2.Text = TextBox3.Text Then 'if password input (i.e Textbox2) and password confirmation input (i.e Textbox3) is equal then start the registration process
            Try 'try to register
                'start registration
                Dim reg As Process = New Process 'make a new process object called reg
                reg.StartInfo.FileName = "C:\Python37\python.exe" 'Default Python Installation
                reg.StartInfo.Arguments = "register.py -u " + TextBox1.Text + " -p " + TextBox2.Text 'call the script register.py and pass the parameters
                reg.StartInfo.UseShellExecute = False 'required for redirect.
                reg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
                reg.StartInfo.CreateNoWindow = True 'dont create a window while the script executes
                reg.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                reg.Start() 'start the process i.e. the script (register.py)
                AddHandler reg.OutputDataReceived, AddressOf proccess_OutputDataReceived 'redirect the output from the script to variable Value
                reg.BeginOutputReadLine() 'start reading the redirected output
                reg.WaitForExit() 'wait for the script to complete execution
                If Value = "Registration success" Then 'check for string Registration success
                    MsgBox(Value) 'Display the same as a message box
                    Form1.Show() 'Show Login form (i.e Form1)
                    Me.Hide() 'hide registration form
                Else
                    MsgBox("Error") 'Script returned something other than Registration success
                End If
            Catch ex As Exception
                'Do nothing if exception occurs
            End Try

        Else 'if password input (i.e Textbox2) and password confirmation input (i.e Textbox3) are not equal
            MsgBox("Passwords dont match") 'display the message
        End If
    End Sub
    Private Sub Form4_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing 'subroutine when form is closed
        Try 'try to close Form1 (i.e login form) 
            Form1.Close()
        Catch ex As Exception
            'Do nothing if exception occurs
        End Try
    End Sub
End Class