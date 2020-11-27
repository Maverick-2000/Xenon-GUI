'This is the Password for encryption/decryption form (Form 3)
'------------------
'Password means Password input
'Button1 means Confirm button
'sender As Object means parameter that contains the reference to the control/object that raised the event
'e As Event means e contains the event data
'------------------
Public Class Form3 'Class Form 3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'subroutine when confirm button is clicked
        Me.Hide() 'hide Password for encryption/decryption form
    End Sub

End Class