Public Class Form1

    'When clicking on lable it changes to this text'
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Label1.Text = "VB is Fun"
    End Sub

    '===============================================Addition Program================================================================='
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim num1 As Integer = TextBox1.Text
        Dim num2 As Integer = TextBox2.Text
        Dim total As Integer
        total = num1 + num2
        TextBox3.Text = "sum is " & total & vbCrLf
        'to clear textbox:' 
        'TextBox3.Clear()'
        'To make total to exponent 2'
        ' Dim exponent As Integer = TextBox1.Text'
        'total ^= exponent'
        'TextBox3.Text = "result" & total & vbCrLf & "result ^= " & exponent & ": " & total & vbCrLf'


    End Sub
    '============================================================================================================================================'
    '=====================================================to compare numbers in textboxes:========================================================='
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim num1 As Integer = TextBox1.Text
        Dim num2 As Integer = TextBox2.Text
        If num1 = num2 Then
            TextBox3.AppendText(num1 & "=" & num2 & vbCrLf)
        End If
        If num1 <> num2 Then
            TextBox3.AppendText(num1 & "<>" & num2 & vbCrLf)
        End If
        If num1 < num2 Then
            TextBox3.AppendText(num1 & "<" & num2 & vbCrLf)
        End If
        If num1 > num2 Then
            TextBox3.AppendText(num1 & ">" & num2 & vbCrLf)
        End If
        If num1 <= num2 Then
            TextBox3.AppendText(num1 & "<=" & num2 & vbCrLf)
        End If
        If num1 >= num2 Then
            TextBox3.AppendText(num1 & ">=" & num2 & vbCrLf)
        End If
    End Sub
    '============================================================================================================================================'
    '==========================================================Letter Grade======================================================================'
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim num3 As Integer = TextBox4.Text
        If num3 >= 90 Then
            TextBox5.Text = "A"
        ElseIf num3 >= 80 Then
            TextBox5.Text = "B"
        ElseIf num3 >= 70 Then
            TextBox5.Text = "C"
        ElseIf num3 >= 60 Then
            TextBox5.Text = "D"
        Else
            TextBox5.Text = "F"
        End If

    End Sub
    '============================================================================================================================================'
    '==================================================== Grades Average ========================================================================'
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Grade As Integer = TextBox6.Text
        ListBox1.Items.Add(Grade)
        TextBox6.Clear()
        TextBox6.Focus()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim totalgrade As Integer
        Dim gradeCounter As Integer
        Dim Grade As Integer
        Dim Average As Double
        totalgrade = 0
        gradeCounter = 0
        Do While gradeCounter < ListBox1.Items.Count
            Grade = ListBox1.Items(gradeCounter)
            totalgrade += Grade
            gradeCounter += 1
        Loop
        'Termination phase'
        If gradeCounter <> 0 Then
            Average = totalgrade / ListBox1.Items.Count
            TextBox7.Text = "Total of the " & gradeCounter & "grads is " & totalgrade & vbCrLf & "average is" & String.Format("{0:F}", Average)
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

    End Sub
    '============================================================================================================================================'
End Class
