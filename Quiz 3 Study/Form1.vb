Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    '******************************************CHECK CHARACTER TYPE*************************************'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim input As Char = Convert.ToChar(TextBox1.Text)
        TextBox1.Focus()
        Dim result As String = TextBox2.Text
        result &= "is digit:" & Char.IsDigit(input) & vbCrLf
        result &= "is char:" & Char.IsLetter(input) & vbCrLf
        result &= "is Symbol:" & Char.IsSymbol(input) & vbCrLf
        result &= "is Punctuation:" & Char.IsPunctuation(input) & vbCrLf
        TextBox2.Text = result

    End Sub

    '***************************************************************************************************'
    '******************************************COMPARE STRINGS******************************************'
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim string1 As String = "hello"
        Dim string2 As String = "good bye"
        Dim string3 As String = "Happy Birthday"
        Dim string4 As String = "happy birthday"

        TextBox3.Text = ("string1=" & Chr(34) & string1 & Chr(34) & vbCrLf &
            "string2=" & Chr(34) & string2 & Chr(34) & vbCrLf &
            "string3=" & Chr(34) & string3 & Chr(34) & vbCrLf &
            "string4=" & Chr(34) & string4 & Chr(34) & vbCrLf)

        If string1.Equals("hello") Then
            TextBox3.AppendText(vbCrLf & "string1 equals" & Chr(34) & "hello" & Chr(34) & vbCrLf)
        Else
            TextBox3.AppendText("string1 doesn't equal" & Chr(34) & "hello" & Chr(34) & vbCrLf)
        End If

        If string1 = "hello" Then
            TextBox3.AppendText("string1 equals" & Chr(34) & "hello" & Chr(34) & vbCrLf)
        Else
            TextBox3.AppendText("string1 doesn't equal" & Chr(34) & "hello" & Chr(34) & vbCrLf)
        End If

        If String.Equals(string3, string4) Then
            TextBox3.AppendText(vbCrLf & "string3 equals string4" & vbCrLf)
        Else
            TextBox3.AppendText("string3 doesn't equal string4" & vbCrLf)
        End If

        TextBox3.AppendText(vbCrLf & "string1.compareTo(string2) is " & string1.CompareTo(string2) & vbCrLf &
                            "string2.compareTo(string1) is " & string2.CompareTo(string1) & vbCrLf &
                            "string1.compareTo(string1) is " & string1.CompareTo(string1) & vbCrLf &
                            "string3.compareTo(string4) is " & string3.CompareTo(string4) & vbCrLf &
                            "string4.compareTo(string3) is " & string4.CompareTo(string3) & vbCrLf)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim strings As String() = {"started", "starting", "ended", "ending"}
        For Each element In strings
            If element.StartsWith("st") Then
                TextBox4.AppendText(Chr(34) & element & Chr(34) & "starts with" & Chr(34) & "st" & Chr(34) & vbCrLf)
            End If
        Next

        For Each element In strings
            If element.EndsWith("ed") Then
                TextBox4.AppendText(vbCrLf & Chr(34) & element & Chr(34) & "ends with" & Chr(34) & "ed" & Chr(34) & vbCrLf)
            End If
        Next
    End Sub


    '***************************************************************************************************'
    '******************************************DECLARE STRINGS******************************************'
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim characterarray() As Char = {"b"c, "i"c, "r"c, "t"c, "h"c, " "c, "d"c, "a"c, "y"c}
        Dim original As String = "welcome to vb"
        Dim string1 As String = original
        Dim string2 As New String(characterarray)
        Dim string3 As New String(characterarray, 6, 3)
        Dim string4 As New String("c"c, 5)

        TextBox5.Text = ("string1=" & Chr(34) & string1 & Chr(34) & vbCrLf &
            "string2=" & Chr(34) & string2 & Chr(34) & vbCrLf &
            "string3=" & Chr(34) & string3 & Chr(34) & vbCrLf &
            "string4=" & Chr(34) & string4 & Chr(34) & vbCrLf)
    End Sub

    '***************************************************************************************************'
    '******************************************PREPROCESS TEXT******************************************'

    ' Function to remove punctuation marks
    Private Function RemovePunctuation(ByVal inputText As String) As String
        Dim punctuationChars As Char() = {","c, "."c, "!"c, "?"c, ";"c, ":"c, "'"c, """"c, "("c, ")"c, "["c, "]"c, "{"c, "}"c, "-"c}
        Return New String(inputText.Where(Function(c) Not punctuationChars.Contains(c)).ToArray())
    End Function

    ' Function to remove extra spaces and change to lower case
    Private Function PreprocessText(ByVal inputText As String) As String
        ' Removing punctuation
        Dim textWithoutPunctuation As String = RemovePunctuation(inputText)
        ' Removing extra spaces and changing to lower case
        Dim words As String() = textWithoutPunctuation.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
        Dim processedText As String = String.Join(" ", words.Select(Function(w) w.ToLower()))
        Return processedText
    End Function

    ' Function to remove stop words
    Private Function RemoveStopWords(ByVal inputText As String) As String
        Dim stopWords As String() = {"in", "on", "at", "is", "was"} ' Add more as needed
        Dim words As String() = inputText.Split(" "c)
        Dim resultWords As List(Of String) = New List(Of String)()

        For Each word As String In words
            If Not stopWords.Contains(word) Then
                resultWords.Add(word)
            End If
        Next

        Return String.Join(" ", resultWords)
    End Function
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim Input As String = TextBox7.Text

        ' Preprocess the text
        Dim processedText As String = PreprocessText(Input)

        ' Remove stop words
        Dim result As String = RemoveStopWords(processedText)

        ' Display the processed text in the output textbox
        TextBox6.Text = result


    End Sub

    '*******************************************************************************************************'
    '******************************************REGULAR EXPRESSIONS******************************************'
    Private Function FindEmptyTextBoxes() As IEnumerable(Of TextBox)
        Dim emptyBoxes As IEnumerable(Of TextBox) = Me.Controls.OfType(Of TextBox)().Where(Function(tb) String.IsNullOrEmpty(tb.Text))
        Return emptyBoxes
    End Function
    Private Function ValidateInput(ByVal input As String, ByVal pattern As String, ByVal errorMessage As String) As Boolean
        Dim regex As New Regex(pattern)
        Return regex.IsMatch(input)
    End Function
    Private Sub Button10_Click(sender As Object, e As EventArgs)
        Dim emptyBoxes As IEnumerable(Of TextBox) = FindEmptyTextBoxes()
        Dim employees =
            From control In Controls
            Where TypeOf control Is TextBox
            Let box As TextBox = CType(control, TextBox)
            Where String.IsNullOrEmpty(box.Text)
            Order By box.TabIndex
            Select box

        If emptyBoxes.Any() Then
            MessageBox.Show("Please fill in missing info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            emptyBoxes.First().Focus()
        Else
            Select Case False
                Case ValidateInput(TextBox9.Text, "^[A-Z][a-zA-Z]*$", "Invalid Last Name")
                    TextBox9.Focus()
                Case ValidateInput(TextBox10.Text, "^[A-Z][a-zA-Z]*$", "Invalid first Name")
                    TextBox10.Focus()
                Case ValidateInput(TextBox11.Text, "^[0-9]+\s+([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$", "Invalid address")
                    TextBox11.Focus()
                Case ValidateInput(TextBox12.Text, "^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$", "Invalid city")
                    TextBox12.Focus()
                Case ValidateInput(TextBox13.Text, "^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$", "Invalid state")
                    TextBox13.Focus()
                Case ValidateInput(TextBox14.Text, "^\d{5}$", "Invalid zip code")
                    TextBox14.Focus()
                Case ValidateInput(TextBox15.Text, "^[1-9]\d{2}-[1-9]\d{2}-\d{4}$", "Invalid phone number")
                    TextBox15.Focus()
                Case Else
                    Me.Hide()
                    MessageBox.Show("thank you", "information correct", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Application.Exit()
            End Select
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim teststring1 As String = "this sentence ends in 5 stars *****"
        Dim teststring2 As String = "1,2,3,4,5,6,7,8"
        Dim testregex1 As New Regex("\d")
        Dim output As String = String.Empty

        TextBox8.AppendText("first test string: " & teststring1)
        teststring1 = Regex.Replace(teststring1, "\*", "^")
        TextBox8.AppendText(vbCrLf & "^ substituted for *: " & teststring1)
        teststring1 = Regex.Replace(teststring1, "stars", "carets")
        TextBox8.AppendText(vbCrLf & """carets"" substituted for ""stars"":" & teststring1)
        TextBox8.AppendText(vbCrLf & "Every word replaced by ""word"": " & Regex.Replace(teststring1, "\w+", "word"))

        TextBox8.AppendText(vbCrLf & vbCrLf & "second test string: " & teststring2 & vbCrLf)
        TextBox8.AppendText("replace first 3 digits by ""digit"": " & testregex1.Replace(teststring2, "digit", 3) & vbCrLf)
        TextBox8.AppendText("string split at commas[")
        Dim result As String() = Regex.Split(teststring2, ",\s")
        For Each resultstring In result
            output &= """" & resultstring & ""","
        Next

        TextBox8.AppendText(output.Substring(0, output.Length - 2) & "]" & vbCrLf)
    End Sub

    '*******************************************************************************************************'
    '******************************************SEARCH STRINGS***********************************************'
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click, Button11.Click, Button13.Click, Button15.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click, Button14.Click
        Dim input As String = TextBox17.Text
        Dim search As String = TextBox18.Text

        If RadioButton1.Checked Then
            Dim index As Integer = input.IndexOf(search)
            If index <> -1 Then
                TextBox16.Text = "Found at index " & index & " from the left."
            Else
                TextBox16.Text = "Not found in the text."
            End If
        ElseIf RadioButton2.Checked Then
            Dim index As Integer = input.LastIndexOf(search)
            If index <> -1 Then
                TextBox16.Text = "Found at index " & index & " from the right."
            Else
                TextBox16.Text = "Not found in the text."
            End If
        Else
            MessageBox.Show("Please select search direction.")
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim letters As String = "abcdefghijklmabcdefghijklm"
        Dim searchletters As Char() = {"c"c, "a"c, "$"c}

        TextBox19.AppendText("first 'c' is located at index " & letters.IndexOf("c"c) & vbCrLf)
        TextBox19.AppendText("first 'a' starting at 1 is located at index " & letters.IndexOf("a"c, 1) & vbCrLf)
        TextBox19.AppendText("first '$' in the 5 position starting at 3" & "is located at index " & letters.IndexOf("$"c, 3, 5) & vbCrLf)
    End Sub


    '*******************************************************************************************************'
    '******************************************LINQ*********************************************************'

    Dim values() As Integer = {2, 9, 5, 0, 3, 7, 1, 4, 8, 6}
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        TextBox21.AppendText(String.Format("original array:{0}", vbCrLf))
        For Each element In values
            TextBox21.AppendText("  " & element)
        Next

        Dim filtered =
            From value In values
            Where (value > 4)
            Select value
        TextBox21.AppendText(String.Format("{0}{0} array values greater than 4: {0}", vbCrLf))
        For Each element In filtered
            TextBox21.AppendText("  " & element)
        Next

        Dim sorted =
            From value In values
            Order By value
            Select value
        TextBox21.AppendText(String.Format("{0}{0}original array, sorted: {0}", vbCrLf))
        For Each element In sorted
            TextBox21.AppendText("  " & element)
        Next

        Dim sortfilteredresults =
            From value In filtered
            Order By value Descending
            Select value
        TextBox21.AppendText(String.Format("{0}{0}values greater than 4, decending order(chained):{0}", vbCrLf))
        For Each element In sortfilteredresults
            TextBox21.AppendText("  " & element)
        Next

        Dim sortandfilter =
            From value In values
            Where value > 4
            Order By value Descending
            Select value
        TextBox21.AppendText(String.Format("{0}{0}values greater than 4, decending order (one query): {0}", vbCrLf))
        For Each element In sortandfilter
            TextBox21.AppendText("  " & element)
        Next

    End Sub

    '*************************************************************************************************************'
    '******************************************LINQ RADIO*********************************************************'
    Dim RN As New Random
    Dim array(100) As Integer
    Sub sayrandom(ByRef ar() As Integer)
        Dim i As Integer = 0
        For i = 0 To 99
            ar(i) = RN.Next(0, 9)
        Next
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim val As Integer = TextBox24.Text
        Dim results0 As IEnumerable
        sayrandom(array)
        If RadioButton4.Checked And CheckBox1.Checked Then
            results0 = From elem In array
                       Where elem > val
                       Order By elem Ascending
                       Select elem

        ElseIf RadioButton4.Checked And CheckBox2.Checked Then
            results0 = From elem In array
                       Where elem < val
                       Order By elem Ascending
                       Select elem

        ElseIf RadioButton3.Checked And CheckBox1.Checked Then
            results0 = From elem In array
                       Where elem > val
                       Order By elem Descending
                       Select elem

        ElseIf RadioButton3.Checked And CheckBox2.Checked Then
            results0 = From elem In array
                       Where elem < val
                       Order By elem Descending
                       Select elem
        End If
        TextBox24.Clear()
        For Each item In results0
            TextBox22.AppendText(item & vbCrLf)
        Next
    End Sub
    '****************************************************************************************************************'
    '******************************************LINQ EMPLOYEE*********************************************************'
    Dim company() As EMPLOYEE = {New EMPLOYEE("Ali", "veli", 5000),
        New EMPLOYEE("john", "red", 8000),
        New EMPLOYEE("mike", "tyson", 10000),
        New EMPLOYEE("Ali", "mohammed", 20000)}
    Sub display(ByVal x As IEnumerable)
        TextBox20.Clear()
        For Each elem In x
            TextBox20.AppendText(elem.ToString() & vbCrLf)
        Next
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim res1 = From items In company
                   Select items.Surname
                   Distinct
        display(res1)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim res2 = From items In company
                   Where items.monthlysalary > 6000
                   Select items.Firstname, items.Surname
        If res2.Count > 0 Then
            display(res2)
        Else
            TextBox20.Text = "nothing"
        End If

    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim res3 = From items In company
                   Select items
        display(res3)

    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim filter = From items In company
                     Where (items.monthlysalary >= Val(TextBox23.Text) And
                         items.monthlysalary <= Val(TextBox25.Text))
                     Order By items.monthlysalary Descending
                     Select items

        display(filter)
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim colors() As String = {"aqua", "rust", "yellow", "red", "blue", "orange"}
        Dim startwith =
            From color In colors
            Where (color.StartsWith("r"))
            Order By color
            Select color.ToUpper()

        For Each item In startwith
            TextBox20.AppendText(item & "  ")
        Next
        TextBox20.AppendText(vbCrLf)

        colors(4) = "ruby"
        colors(5) = "rose"

        For Each item In startwith
            TextBox20.AppendText(item & "  ")
        Next

    End Sub
End Class
