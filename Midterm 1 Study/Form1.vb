
Public Class Form1

    '===================================================================Passing Arrays============================================================================================='
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        Dim Array1() As Integer = {1, 2, 3, 4, 5}
        TextBox1.AppendText("Effects of passing and entire array by reference:" & vbCrLf & "the values of the origional array are: " & vbCrLf)
        'Display original elements of the array'
        For i = 0 To Array1.GetUpperBound(0)
            TextBox1.AppendText(vbTab & Array1(i))
        Next

        'Array is passed by reference'
        ModifyArray(Array1)
        TextBox1.AppendText(vbCrLf & "the values of the modified array are: " & vbCrLf)
        'Display modified elements of array1'
        For m = 0 To Array1.GetUpperBound(0)
            TextBox1.AppendText(vbTab & Array1(m))
        Next
        TextBox1.AppendText(vbCrLf & vbCrLf & "Effects of passing an array element by value: " & vbCrLf & "array1(3) before ModifyElementByVal: " & Array1(3) & vbCrLf)

        'Array element passed by value'
        ModifyElementByVal(Array1(3))
        TextBox1.AppendText("array1(3) after ModifyElementByVal: " & Array1(3) & vbCrLf)
        TextBox1.AppendText(vbCrLf & "Effects of passing an array element by reference: " & vbCrLf & "array1(3) before modifyElementsByRef: " & Array1(3) & vbCrLf)
        'array element passed by reference'
        ModifyElementByRef(Array1(3))
        TextBox1.AppendText("array1(3) after ModifyElementByRef: " & Array1(3) & vbCrLf)


    End Sub

    'method modifies array, it recieves (note ByVale)'
    Sub ModifyArray(ByVal arrayParameter() As Integer)
        For j = 0 To arrayParameter.GetUpperBound(0)
            arrayParameter(j) *= 2 'double the array elements'
        Next
    End Sub

    'method  modifies integer passed to it by value'
    Sub ModifyElementByVal(ByVal element As Integer)
        TextBox1.AppendText("value recieved in MovifyElementByVal: " & element & vbCrLf)
        element *= 2 'double array element'
        TextBox1.AppendText("value calculated in ModifyElementbyVal: " & element & vbCrLf)
    End Sub

    'method modifies integer passed  to it by reference'
    Sub ModifyElementByRef(ByRef element As Integer)
        TextBox1.AppendText("value recieved in MovifyElementByRef: " & element & vbCrLf)
        element *= 2 'double array element'
        TextBox1.AppendText("value calculated in ModifyElementbyRef: " & element & vbCrLf)
    End Sub

    '================================================================================================================================================================================'
    '=================================================================================Find Smallest=================================================================================='

    Dim gradesArray(9) As Integer 'create 10 elements array'
    Dim randomNumber As New Random()

    'create random generated numbers'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        smallestTextBox.Text = String.Empty 'clear textbox'
        'create 10 random numbers and append to output'
        For rand = 0 To gradesArray.GetUpperBound(0)
            gradesArray(rand) = randomNumber.Next(100)
            ListBox1.Items.Add(gradesArray(rand))
        Next

        Button2.Enabled = True 'enable find smallest button'
    End Sub
    'finds smallest randomly generated numbers'
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim lowGrade As Integer = 100 'starts with maximum grade'
        'user for each to find minimum grade'
        For Each grade In gradesArray
            If grade < lowGrade Then
                lowGrade = grade 'so far, current grade is the lowest'
            End If
        Next
        smallestTextBox.Text = Convert.ToString(lowGrade)

        Button2.Enabled = False 'disaple smallest button'
    End Sub

    '/// by default array method Sort sorts arryas elements into ASCENDing order////'

    '============================================================================================================================================================================='
    '===============================================================================Sort Array===================================================================================='
    Dim intArray(9) As Integer
    Dim randomNumber2 As New Random()

    'generate numbers randomly'
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        originalListBox.Items.Clear()
        sortedListBox.Items.Clear()

        'create 10 random numbers and add to original listbox'
        For ele = 0 To intArray.GetUpperBound(0)
            intArray(ele) = randomNumber2.Next(1000)
            originalListBox.Items.Add(intArray(ele))
        Next

        Button4.Enabled = True 'enable sort button'
    End Sub

    'Sort randomly generated numbers'
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Array.Sort(intArray) 'sort array'
        'display sorted numbers in listbox'
        For sortnum = 0 To intArray.GetUpperBound(0)
            sortedListBox.Items.Add(intArray(sortnum))
        Next
        Button4.Enabled = False
    End Sub

    '==============================================================================================================================================================================='
    '==========================================================================Linear Search Test==================================================================================='
    Dim searchData(19) As Integer 'create 20 elements array'
    Dim randomNumber3 As New Random()

    'create random data'
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        For num = 0 To searchData.GetUpperBound(0)
            searchData(num) = randomNumber3.Next(1000)
        Next
        'display the array elements in listbox'
        searchListBox3.Items.Add("Index" & vbTab & "Value")
        For i = 0 To searchData.GetUpperBound(0)
            searchListBox3.Items.Add(i & vbTab & searchData(i))
        Next
        searchTextBox2.Clear()
        Button6.Enabled = True 'enable search button'
    End Sub


    'search array for a search key'
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'if search textbox is empty display message'
        If searchTextBox2.Text = String.Empty Then
            MessageBox.Show(" you must enter number to search for", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub 'terminates the method call immediately'
        End If

        Dim searchKey As Integer = Convert.ToInt32(searchTextBox2.Text)
        Dim index As Integer = -1 'stores index of found value '
        'linear iteration through array: '
        For i = 0 To searchData.GetUpperBound(0)
            If searchData(i) = searchKey Then
                index = i
                Exit For 'terminiate loop because value is found'
            End If
        Next

        If index >= 0 Then
            resultTextBox3.Text = "Found Value in index " & index
        Else
            resultTextBox3.Text = "Value Not found "
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Array.Sort(searchData)
        Dim searchKey As Integer = Convert.ToInt32(searchTextBox2.Text)
        Dim index As Integer = Array.BinarySearch(searchData, searchKey)
        If index Then
            resultTextBox3.Text = "Found Value in index " & index
        Else
            resultTextBox3.Text = "Value Not found "
        End If
    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter, GroupBox8.Enter, GroupBox9.Enter
        Dim Values(,) As Integer = {{1, 2, 3}, {4, 5, 6}}
        'output elements of the vlues array'
        For row = 0 To Values.GetUpperBound(0)
            For column = 0 To Values.GetUpperBound(1)
                rectangularTextBox2.AppendText(Values(row, column) & vbTab)
            Next
            rectangularTextBox2.AppendText(vbCrLf)
        Next
    End Sub

    '========================================================================================================================================================================================'
    '=====================================================================Grade Report======================================================================================================='
    Dim grades(9, 2) As Integer 'stores 10 students, 3 tests'
    Dim studentCount As Integer = 0 'number of student inter'

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter
        GradeListBox2.Items.Add(vbTab & vbTab & "Test1" & vbTab & "Test2" & vbTab & "Test3" & vbTab & "Average")

    End Sub
    'process one students grade'
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'retrieve students grades'
        grades(studentCount, 0) = Convert.ToInt32(TextBox2.Text)
        grades(studentCount, 1) = Convert.ToInt32(TextBox3.Text)
        grades(studentCount, 2) = Convert.ToInt32(TextBox4.Text)

        'create a string containing student's grades and average'
        Dim output As String = "Student" & studentCount & vbTab
        'append each test grade to the output'
        For column = 0 To grades.GetUpperBound(1)
            'if the letter radiobutton is checked'
            If RadioButton2.Checked = True Then
                'append letter grade to output'
                output &= vbTab & LetterGrade(grades(studentCount, column))
            Else
                'append number grade to output'
                output &= vbTab & grades(studentCount, column)
            End If
        Next
        'append students test average to the output'
        output &= vbTab & CalculateStudentAverage(studentCount)

        'add output to list box'
        GradeListBox2.Items.Add(output)
        'update number of students entered'
        studentCount += 1
        'display class average'
        Label11.Text = CalculateClassAverage()
        'display current grade distribution'
        DisplayBarChart()

        'clear input textboxes and focus on first textbox'
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox2.Focus()
        'limit number of students'
        If studentCount = grades.GetUpperBound(0) + 1 Then
            GroupBox6.Enabled = False 'disable groupbox controls'
        End If
    End Sub

    'handles numberic and letter radiobuttons'
    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        'if there are grades to display, call DisplayClassGrades'
        If studentCount > 0 Then
            DisplayClassGrades()
        End If

    End Sub


    'claculates students test average'
    Function CalculateStudentAverage(row As Integer) As String
        Dim gradeTotal As Integer = 0 'student total grade'
        'sum the grades for the student'
        For column = 0 To grades.GetUpperBound(1)
            gradeTotal += grades(row, column)
        Next
        Dim studentAverage As String = String.Empty 'output string'
        'calculate student's test average:'
        If RadioButton2.Checked = True Then
            studentAverage = LetterGrade(gradeTotal / (grades.GetUpperBound(1) + 1))
        Else
            studentAverage = String.Format("{0:F}", (gradeTotal / (grades.GetUpperBound(1) + 1)))
        End If
        Return studentAverage
    End Function

    'calculates the class average test'
    Function CalculateClassAverage() As String
        Dim classTotal As Integer = 0
        'loop through all rows that currently contain grades'
        For row = 0 To studentCount - 1
            'loop through all columns'
            For column = 0 To grades.GetUpperBound(1)
                classTotal += grades(row, column) 'add grades to total'
            Next
        Next
        Dim classAverage As String = String.Empty
        'if the letter radiobutton is checked return letter grade'
        If RadioButton2.Checked = True Then
            classAverage = LetterGrade(classTotal / (studentCount * (grades.GetUpperBound(1) + 1)))
        Else 'return numberic grade'
            classAverage = String.Format("{0:F}", (classTotal / (studentCount * (grades.GetUpperBound(1) + 1))))
        End If
        Return classAverage
    End Function

    'LetterGrade Method'
    Function LetterGrade(grade As Double) As String
        Dim output As String 'letter grade to return'
        'determin correct letter grade'
        Select Case grade
            Case Is >= 90
                output = "A"
            Case Is >= 80
                output = "B"
            Case Is >= 70
                output = "C"
            Case Is >= 60
                output = "D"
            Case Else
                output = "F"
        End Select
        Return output 'returns letter grade'
    End Function

    'method DisplayClassGrades'
    Sub DisplayClassGrades()
        GradeListBox2.Items.Clear()
        'add header to listbox'
        GradeListBox2.Items.Add(vbTab & vbTab & "Test1" & vbTab & "Test2" & vbTab & "Test3" & vbTab & "Average")
        'loop through all rows'
        For row = 0 To studentCount - 1
            Dim output As String = "student" & row & vbTab
            'loop through all columns'
            For column = 0 To grades.GetUpperBound(1)
                If RadioButton2.Checked = True Then
                    'add letter grade to output string'
                    output &= vbTab & LetterGrade(grades(row, column))
                Else
                    'add number grade to output string'
                    output &= vbTab & (grades(row, column))
                End If
            Next
            'add students average to output'
            output &= vbTab & CalculateStudentAverage(row)
            'add output to listbox'
            GradeListBox2.Items.Add(output)
        Next
        'update class average'
        Label11.Text = CalculateClassAverage()

    End Sub

    'Method DisplayBarChart'
    Sub DisplayBarChart()
        ListBox2.Items.Clear()
        'stores frequency of grades in each range of 10 grades'
        Dim frequency(10) As Integer
        'for each grade, increment the appropriate frequence'
        For row = 0 To studentCount - 1
            For column = 0 To grades.GetUpperBound(1)
                frequency(grades(row, column) \ 10) += 1
            Next
        Next

        'for each grade frequency, display bar of asterisks'
        For count = 0 To frequency.GetUpperBound(0)
            Dim bar As String 'stores all label and bar'
            'create bar label'
            If count = 10 Then
                bar = String.Format("{0,5:D}: ", 100)
            Else
                bar = String.Format("{0, 2:D2}-{1,2:D2}: ", count * 10, count * 10 + 9)
            End If

            'append bar of astrikes'
            For stars = 1 To frequency(count)
                bar &= ("*")
            Next

            'display bar'
            ListBox2.Items.Add(bar)
        Next
    End Sub
    '==================================================================================================================================================================================='
    '====================================================================================Resize Array==================================================================================='
    Private Sub GroupBox8_Enter(sender As Object, e As EventArgs) Handles GroupBox8.Enter

        'create and initialize tow 5 elements arrays'
        Dim values11() As Integer = {1, 2, 3, 4, 5}
        Dim values22() As Integer = {1, 2, 3, 4, 5}
        'display array length and the elements in the array'
        redimTextBox5.AppendText("The original array has " & vbCrLf & values11.Length & "elements: " & vbCrLf)
        DisplayArray(values11)
        'change the size of the array without preserve keyword'
        ReDim values11(6)
        'display new array length and elemtns in the array'
        redimTextBox5.AppendText("New array(without Preserve) has " & vbCrLf & values11.Length & "elements: " & vbCrLf)
        DisplayArray(values11)

        'change the size of the array without preserve keyword'
        ReDim Preserve values22(6)
        'display new array length and elemtns in the array'
        redimTextBox5.AppendText("New array(with Preserve) has " & vbCrLf & values22.Length & "elements: " & vbCrLf)
        DisplayArray(values22)
    End Sub

    'Display array elements: '
    Sub DisplayArray(array() As Integer)
        For Each number In array
            redimTextBox5.AppendText(number & " ")
        Next
        redimTextBox5.AppendText(vbCrLf)
    End Sub

    '==================================================================================================================================================================================='
End Class
