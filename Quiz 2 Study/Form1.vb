Imports System.Net.Http.Headers

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        ' While Product <= 100'
        'product = product * 3'
        'End While'
        'Do Until Product > 100'
        'Product = Product * 3'
        'Loop '
    End Sub

    '============================================================================================================================================'
    '=================================================================Calculate Power============================================================'

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim exponent As Integer = TextBox1.Text
        Dim result As Integer
        result = 2
        result ^= exponent
        TextBox2.Text = "resutl = 2" & vbCrLf & "result = result ^" & exponent & ":" & result
    End Sub

    '============================================================================================================================================'
    '============================================Average Grade==================================================================================='

    '====place grade in listbox ====='
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox3.Text <> String.Empty Then
            ListBox1.Items.Add(TextBox3.Text)
            TextBox3.Clear()
        End If
        TextBox3.Focus()
    End Sub

    '====Calculate Average========='
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim total As Integer
        Dim gradeCounter As Integer
        Dim grade As Integer
        Dim average As Double
        total = 0
        gradeCounter = 0 'to loop through'
        Do While gradeCounter < ListBox1.Items.Count
            grade = ListBox1.Items(gradeCounter)
            total += grade 'add grade to total'
            gradeCounter += 1
        Loop
        If gradeCounter <> 0 Then
            average = total / ListBox1.Items.Count
            TextBox4.Text = vbCrLf & "Total of" & gradeCounter & "grades is" & total & vbCrLf & "class average is " & String.Format("{0:F}", average) 'formatting float point, 0 = average, f = 2 decimal places, f3 = 3 decimal places'
        Else
            TextBox4.Text = "no grades were entered"
        End If
        'display'

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ListBox1.Items.Clear()
        TextBox4.Text = String.Empty
        TextBox3.Focus()

    End Sub
    '============================================================================================================================================'
    '==========================================Licensing Exam Analysis App======================================================================='
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'add grade to listbox '
        If ListBox2.Items.Count < 10 Then
            ListBox2.Items.Add(TextBox6.Text)
            TextBox6.Clear()
            TextBox6.Focus()
        End If
        'prevent or not user from entering more reults'
        If ListBox2.Items.Count = 10 Then
            Button7.Enabled = False 'disable submit button'
            TextBox6.Enabled = True 'enable results textbox'
            Button6.Enabled = True 'Enable analyze button'
        End If

    End Sub

    '===Analyze results==='
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim passes As Integer = 0 'number of passes'
        Dim failures As Integer = 0 'number of failures'
        Dim student As Integer = 0 'student counter'
        Dim res As String 'one exam result'

        'process 10 students using counter-controlled loop'
        Do While student < 10
            res = ListBox2.Items(student) 'get a result'
            If res = "P" Then
                passes += 1 'increment number of passes'
            Else
                failures += 1 'increment number of failures'
            End If
            student += 1 'increment student counter'
        Loop

        '=== display exam results ==='
        TextBox5.Text = vbCrLf & "Passed: " & passes & vbCrLf & "Failed: " & failures & vbCrLf
        '=== raise tuition if more than 8 students passed ==='
        If passes > 8 Then
            TextBox5.Text = vbCrLf & "bonus to instructor!"
        End If
    End Sub


    '===clear button==='
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ListBox2.Items.Clear() 'remove all items'
        TextBox5.Text = String.Empty 'clears the text'
        Button6.Enabled = True 'enable submit button'
        Button7.Enabled = False 'disable analyze button'
        TextBox6.Focus() 'select result box'
    End Sub

    '===for loop==='
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        For counter As Integer = 2 To 15 Step 2
            TextBox7.Text = counter & " "
            counter += 2
        Next
    End Sub

    '============================================================================================================================================'
    '==========================================Interest Calculator APP==========================================================================='

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'store prinipal ans interest rate'
        Dim principal As Decimal = Val(TextBox8.Text)
        Dim rate As Decimal = Val(TextBox9.Text)
        'display output header'
        ListBox3.Items.Add("year" & vbTab & "Amount on Deposit")
        Dim amount As Decimal 'amount on deposit after each year'
        'calculte amount and add to listbox'
        For YearCounter As Integer = 1 To NumericUpDown1.Value
            amount = principal * ((1 + rate / 100) ^ YearCounter)
            ListBox3.Items.Add(YearCounter & vbTab & String.Format("{0:C}", amount)) 'C is for currency'

        Next


    End Sub
    'clear lisbox when principal changes'
    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        ListBox3.Items.Clear()
    End Sub


    'clear listbox when rate changes'
    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        ListBox3.Items.Clear()
    End Sub
    'clear listbox when number of years changes'
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        ListBox3.Items.Clear()
    End Sub


    '============================================================================================================================================'
    '===============================================Square of Characters APP ===================================================================='
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        'get fill character and side length'
        Dim fillchar As String = TextBox10.Text
        Dim sidelength As Integer = NumericUpDown2.Value

        'control row displayed'
        For row As Integer = 1 To sidelength
            'control column displayed'
            For column As Integer = 1 To sidelength
                TextBox11.AppendText(fillchar & " ")
            Next column
            TextBox11.AppendText(vbCrLf)
        Next row

    End Sub

    'clear output textbox when fill character is changed by user'
    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        TextBox11.Clear()
    End Sub

    'clear output textbox when sidelength is changed by user'
    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        TextBox11.Clear()
    End Sub


    '============================================================================================================================================'
    '=======================================Dental Payment Calculator============================================================================'
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        'if not name entered or  no checkbox checked dispalye message'
        If (TextBox12.Text = String.Empty) OrElse (Not CheckBox1.Checked AndAlso Not CheckBox2.Checked AndAlso Not CheckBox3.Checked) Then
            'Label16.Text = String.Empty' 'clear total cost label'
            'display an error messeage in dialog'
            MessageBox.Show("Please enter a name and check at least one item", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else 'add prices'
            Dim totalamount As Decimal = 0
            'if patient had a cleaning'
            If CheckBox1.Checked Then
                totalamount += Val(Label12.Text)
            End If
            'if patient had a cavity filled'
            If CheckBox2.Checked Then
                totalamount += Val(Label13.Text)
            End If
            'if patient had an xray taken'
            If CheckBox3.Checked Then
                totalamount += Val(Label14.Text)
            End If

            'Display the total'
            Label16.Text = String.Format("{0:C}", totalamount)
        End If
    End Sub
    '============================================================================================================================================'

End Class
