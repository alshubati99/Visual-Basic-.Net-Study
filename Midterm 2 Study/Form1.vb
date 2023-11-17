Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    '==================================================================Class Average===================================================================================='

    'Declar variables'
    Dim aCount As Integer
    Dim bCount As Integer
    Dim cCount As Integer
    Dim dCount As Integer
    Dim fCount As Integer
    Dim perfectScoreCount As Integer 'count of perfect score'

    'place a grade in listbox'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim grade As Integer = Val(TextBox1.Text)
        'add grades to end of grades listbos'
        ListBox1.Items.Add(grade)
        'clear textbox'
        TextBox1.Clear()
        'add one to appropriate counter for specified grade'
        Select Case grade
            Case 100
                perfectScoreCount += 1
            Case 90 To 99
                aCount += 1
            Case 80 To 89
                bCount += 1
            Case 70 To 79
                cCount += 1
            Case 60 To 69
                dCount += 1
            Case Else
                fCount += 1

        End Select
        TextBox1.Focus()
    End Sub

    'Calculate the class average based on grades given in listbox'
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim total As Integer = 0 'for adding grades'
        Dim gradeCounter As Integer = 0 'for loops'
        Dim grade As Integer 'input by user'
        Dim average As Double 'average of grades'

        'processing phase, while loop'
        Do While gradeCounter < ListBox1.Items.Count
            grade = ListBox1.Items(gradeCounter)
            total = total + grade
            gradeCounter += 1
        Loop
        'termination phase'
        If gradeCounter <> 0 Then
            average = total / gradeCounter 'average calculated'
            'display total and average with 2 digits of precision'
            TextBox2.Text &= "Total of the " & gradeCounter & "grades is " & total & vbCrLf & "class average is " & String.Format("{0:F}", average) & vbCrLf & vbCrLf

            'display summary of letter grades'
            TextBox2.Text &= "Letter grade summary: " & vbCrLf & "A: " & aCount & vbCrLf & "B: " & bCount & vbCrLf & "C: " & cCount & vbCrLf & "D: " & dCount & vbCrLf & "F: " & fCount & vbCrLf & "Perfect Score: " & perfectScoreCount
        Else
            TextBox2.Text = "No grades were entered"
        End If
    End Sub

    'clear grades And results'
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListBox1.Items.Clear()
        TextBox2.Text = String.Empty
    End Sub
    '==========================================================================================================================================================='

    '=================================================================Wage Calculator==========================================================================='
    Const Hours_Week As Integer = 168 'total hours in week'
    Const Hours_limit As Integer = 40

    'calculate and display the emplyees pay'
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim hoursWorked As Double = Val(TextBox3.Text)
        Dim hourlyWage As Decimal = Val(TextBox4.Text)

        'determine wether hourWorked is less than or equql to 168'
        If hoursWorked <= Hours_Week Then
            DisplayPay(hoursWorked, hourlyWage)
            Dim totalPay As Decimal = CalculatePay(hoursWorked, hourlyWage)
            TextBox5.Text = String.Format("{0:C}", totalpay)
        Else
            MessageBox.Show("hours worked must be less or equal to 168", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    'calculate the display wage  using ===SUB==='
    Sub DisplayPay(hours As Double, wages As Decimal)
        Dim earnings As Decimal 'stores total earnings'
        'determine wage ammount'
        If hours <= Hours_limit Then
            'earnings for regular wages'
            earnings = hours * wages
        Else
            'regular wages for first hourlimit hours'
            earnings = Hours_limit * wages
            'time and half for overtime'
            earnings += ((hours - Hours_limit) * (1.5 * wages))
        End If
        TextBox5.Text = String.Format("{0:C}", earnings)
    End Sub

    'calculate the wages using ===FUNCTION==='
    Function CalculatePay(hours As Double, wages As Decimal) As Decimal
        Dim earnings As Decimal 'stores total earnings'
        'determine wage ammount'
        If hours <= Hours_limit Then
            'earnings for regular wages'
            earnings = hours * wages
        Else
            'regular wages for first hourlimit hours'
            earnings = Hours_limit * wages
            'time and half for overtime'
            earnings += ((hours - Hours_limit) * (1.5 * wages))
        End If
        Return earnings
    End Function
    '==========================================================================================================================================================='

    '==============================================Passing Arguments - Reference/Value Passing ================================================================='
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'get user input and convert it to integer'
        Dim number1 As Integer = Convert.ToInt32(TextBox6.Text)
        'output'
        TextBox7.AppendText("Passing a value-type argument by VALUE:  " & vbCrLf)
        TextBox7.AppendText(String.Format("Before calling SquareByValue, number is {0}{1}", number1, vbCrLf))
        SquareByValue(number1) 'passes by value'
        TextBox7.AppendText(String.Format("After returning from SquareByValue, number is {0}{1}{1}", number1, vbCrLf))

        Dim number2 As Integer = Convert.ToInt32(TextBox6.Text)
        TextBox7.AppendText("Passing a value-type argument by REFERENCE:  " & vbCrLf)
        TextBox7.AppendText(String.Format("Before calling SquareByReference, number2 is {0}{1}", number2, vbCrLf))
        SquareByReference(number2) 'passes by value'
        TextBox7.AppendText(String.Format("After returning from SquareByReference, number is {0}{1}{1}", number2, vbCrLf))

        Dim number3 As Integer = Convert.ToInt32(TextBox6.Text)
        TextBox7.AppendText("Passing a value-type argument by REFERENCE but in PARANTHESE:  " & vbCrLf)
        TextBox7.AppendText(String.Format("Before calling SquareByReference using parantheses, number3 is {0}{1}", number3, vbCrLf))
        SquareByReference((number3)) 'passes by value'
        TextBox7.AppendText(String.Format("After returning from SquareByReference, number3 is {0}", number3, vbCrLf))

    End Sub

    'square number by value'
    Sub SquareByValue(ByVal number As Integer)
        TextBox7.AppendText(String.Format("After entering SquareByValue, number is {0}{1}", number, vbCrLf))
        number *= number
        TextBox7.AppendText(String.Format("Before Exiting SquareByValue, number is {0}{1}", number, vbCrLf))
    End Sub

    'square number by Reference'
    Sub SquareByReference(ByRef number As Integer)
        TextBox7.AppendText(String.Format("After entering SquareByReference, number is {0}{1}", number, vbCrLf))
        number *= number
        TextBox7.AppendText(String.Format("Before Exiting SquareByReference, number is {0}{1}", number, vbCrLf))
    End Sub

    '==========================================================================================================================================================='


    '====================================================================Fund Raiser============================================================================'
    Dim totalRaised As Decimal = 0 'store total of all donations'
    'Calculate and display donation amount and total donations'
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'get donation amount:'
        Dim donation As Decimal = Convert.ToDecimal(Val(TextBox8.Text))
        'obtain donation amount after operation costs deduction: '
        Dim afterCosts As Decimal = CalculateDonation(donation)
        'display amount of donation after costs: '
        TextBox9.Text = String.Format("{0:C}", afterCosts)
        'update total amount of donations recieved: '
        totalRaised += afterCosts
        'display total amound collected for charity: '
        TextBox10.Text = String.Format("{0:C}", totalRaised)
    End Sub

    'calculate donation amount after operatin expenses: '
    Function CalculateDonation(donateAmount As Decimal) As Decimal
        '17% of donation is used to cover operating costs: '
        Const COSTS As Decimal = 0.17D
        'calculate amount of donation after operating expenses: '
        Return donateAmount * (1D - COSTS)
    End Function
    'clear textboxts ':
    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        TextBox9.Text = String.Empty
    End Sub
    '==========================================================================================================================================================='


    '===============================================================Random Number Generator====================================================================='
    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter
        Dim randomObject As New Random()
        Dim randomNumber As Integer
        'generate 20 random numbers between 1 and 6: '
        For i = 1 To 20
            randomNumber = randomObject.Next(1, 7)
            TextBox11.AppendText(randomNumber & " ")
            If i Mod 5 = 0 Then 'is i multiple of 5'
                TextBox11.AppendText(vbCrLf) 'move to next line'
            End If
        Next
    End Sub
    '==========================================================================================================================================================='

    '=================================================================Method Overloading========================================================================'

    Private Sub GroupBox6_Enter(sender As Object, e As EventArgs) Handles GroupBox6.Enter
        'call overload square method and display results: '
        TextBox12.Text = "The square of integer 7 is " & Square(7) & vbCrLf & "The square of Double 7.5 is " & Square(7.5)
    End Sub
    'method Square takes integer and returns integer'
    Function Square(value As Integer) As Integer
        Return Convert.ToInt32(value ^ 2)
    End Function

    'method square takes Double and returns Double'
    Function Square(value As Double) As Double
        Return value ^ 2
    End Function
    '==========================================================================================================================================================='

End Class
