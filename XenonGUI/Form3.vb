'This is the Password for encryption/decryption form (Form 3)
'------------------
'Password means Password input
'Button1 means Confirm button
'sender As Object means parameter that contains the reference to the control/object that raised the event
'e As Event means e contains the event data
'------------------
Public Class Form3 'Class Form 3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'subroutine when confirm button is clicked
        If Not ValidPassword(Password.Text) Then 'if password is not valid
            MsgBox("The password should be atleast 8 characters long consisting atleast one digit,one lower case character and one upper case character.")
            Password.Clear()
        Else
            Me.Hide() 'hide Password for encryption/decryption form
        End If
    End Sub
    Function ValidPassword(myPassword As String) As Boolean 'function for checking password validity
        If myPassword.Length < 8 Then Return False
        If Not myPassword.Any(Function(c) Char.IsDigit(c)) Then Return False
        If Not myPassword.Any(Function(c) Char.IsLower(c)) Then Return False
        If Not myPassword.Any(Function(c) Char.IsUpper(c)) Then Return False
        Return True
    End Function
End Class