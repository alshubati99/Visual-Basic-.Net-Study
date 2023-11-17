Imports DevExpress.XtraExport.Xls

Public Class Form1

    '==============================================================Account Project=========================================================================='
    Private account As New Account() 'create account object'
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        TextBox2.Text = String.Format("{0:C}", account.Balance)
    End Sub

    '=============Deposit=============='
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'get deposit ammount'
            Dim depositAmount As Decimal = Convert.ToDecimal(TextBox1.Text)
            'make deposit'
            account.Deposit(depositAmount)
            TextBox2.Text = String.Format("{0:C}", account.Balance)

        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show("Deposit amount must be positive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        TextBox1.Clear()
        TextBox1.Focus()
    End Sub

    '============Withdraw==============='
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            'get withdrawal amount'
            Dim withdrawalAmount As Decimal = Convert.ToDecimal(TextBox1.Text)
            account.Withdraw(withdrawalAmount) 'make the withdrawal'
            TextBox2.Text = String.Format("{0:C}", account.Balance)
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show("Withdrawal amount must be positive and less than or equal to balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        TextBox1.Clear()
        TextBox1.Focus()
    End Sub
    '=========================================================================================================================================================='
    '=======================================================Time Set Project==================================================================================='
    Dim time As New time() 'construct time with zero argument'
    'add second button'
    Private Sub incrementButton4_Click(sender As Object, e As EventArgs) Handles incrementButton4.Click
        time.Second = (time.Second + 1) Mod 60 'add 1 to second'
        'add one minute if 60 seconds have passed'
        If time.Second = 0 Then
            time.Minute = (time.Minute + 1) Mod 60 'add 1 minute'
            'add one hour if 60 minutes have passed'
            If time.Minute = 0 Then
                time.Hour = (time.Hour + 1) Mod 24 'add 1 hour'
            End If
        End If
        UpdateDisplay() 'update the texboxes and output labels'
    End Sub

    'set time based on textbox values'
    Private Sub timeButton3_Click(sender As Object, e As EventArgs) Handles timeButton3.Click
        'ensure that hour, minute, and second are in range'
        Try
            If setHourTextBox3.Text <> String.Empty Then
                time.Hour = Convert.ToInt32(setHourTextBox3.Text)
            End If
            If setMinuteTextBox4.Text <> String.Empty Then
                time.Minute = Convert.ToInt32(setMinuteTextBox4.Text)
            End If
            If setSecondTextBox5.Text <> String.Empty Then
                time.Second = Convert.ToInt32(setSecondTextBox5.Text)
            End If
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show("the hour, minute or seconds were out of range", "Out of Range", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        UpdateDisplay()
    End Sub

    'update time display'
    Private Sub UpdateDisplay()
        setHourTextBox3.Text = Convert.ToString(time.Hour)
        setMinuteTextBox4.Text = Convert.ToString(time.Minute)
        setSecondTextBox5.Text = Convert.ToString(time.Second)
        outputLabel6.Text = ("Hour: " & time.Hour & "; Minute: " & time.Minute & "; Second: " & time.Second)
        outputLabel7.Text = ("Standard time is: " & time.ToString() & vbCrLf & "Universal time is : " & time.ToUniversalString())
    End Sub

    '========================================================================================================================================================'
    '========================================================================================================================================================'

    'Declaring array: '
    Dim c(11) As Integer
    Dim c1(0 To 11) As Integer
    Dim c2() As Integer = {1, 2, 3, 4}

    '=========================================================================================================================================================='
    '======================================================Display Array======================================================================================='
    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter
        'GetUpperBound: returns index of last element'
        Dim array1() As Integer = {32, 27, 86, 99}
        'allocate array2 based on length of array 1'
        Dim array2(array1.GetUpperBound(0)) As Integer
        'set values in array2 by calculations'
        For i = 0 To array2.GetUpperBound(0)
            array2(i) = 2 + 2 * i 'generate 2, 4, 6 ...10'
        Next
        outputTextBox.AppendText("index " & vbTab & "Array1 " & vbTab & "Array2" & vbCrLf)
        'display values for both arrays side by side'
        For i = 0 To array1.GetUpperBound(0)
            outputTextBox.AppendText(i & vbTab & array1(i) & vbTab & array2(i) & vbCrLf)
        Next
    End Sub
    '=========================================================Sum Elements of Arrays========================================================================='

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter
        Dim values() As Integer = {55, 88, 99, 99, 99, 22, 110, 199, 100}
        Dim Total As Integer = 0
        'sum the array element values'
        For element = 0 To values.GetUpperBound(0)
            Total += values(element)
        Next
        SumTextBox.Text = Convert.ToString(Total)
    End Sub

    '=========================================================================================================================================================='
    '=============================================================Student Poll=================================================================================='
    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter
        'student response arrray'
        Dim responses() As Integer = {1, 2, 3, 5, 3, 4, 5, 4, 3, 3, 2, 9, 3, 4, 5}
        'response frequency array'
        Dim Ffrequency1(5) As Integer
        'count frequencies: '
        For answer = 0 To responses.GetUpperBound(0)
            Try
                Ffrequency1(responses(answer)) += 1
            Catch ex As IndexOutOfRangeException
                MessageBox.Show(String.Format("{0}{1}responses({2}) = {3}", ex.Message, vbCrLf, answer, responses(answer)), "IndexOutOfRangeException", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Next
        outputTextBoxpoll.AppendText("Rating" & vbTab & "Frequency" & vbCrLf)
        'display output, ignore elemtns of 0 frequency'
        For rating = 1 To Ffrequency1.GetUpperBound(0)
            outputTextBoxpoll.AppendText(rating & vbTab & Ffrequency1(rating) & vbCrLf)
        Next
    End Sub
    '================================================================================================================================================================'
    '=============================================================Die-Rolling App with Array of Counters============================================================='
    Dim randomObject As New Random()
    Dim frequency(6) As Integer 'create 7 element array'
    'display result of twelve rolls'
    Private Sub displayButton3_Click(sender As Object, e As EventArgs) Handles displayButton3.Click
        DisplayDie(PictureBox1)
        DisplayDie(PictureBox2)
        DisplayDie(PictureBox3)
        DisplayDie(PictureBox4)
        DisplayDie(PictureBox5)
        DisplayDie(PictureBox6)
        DisplayDie(PictureBox13)
        DisplayDie(PictureBox14)
        DisplayDie(PictureBox15)
        DisplayDie(PictureBox16)
        DisplayDie(PictureBox17)
        DisplayDie(PictureBox18)

        Dim total2 As Double = 0
        'total the die faces (used in percentage calculations):'
        For die = 1 To frequency.GetUpperBound(0)
            total2 += frequency(die)
        Next

        'display frequencies of faces'
        displayTextBox3.Text = "Faces " & vbTab & "Freqency" & vbTab & "Percent" & vbCrLf

        'output frequency values ignore 0'
        For m = 1 To frequency.GetUpperBound(0)
            displayTextBox3.Text &= m & vbTab & frequency(m) & vbTab & String.Format("{0:P2}", frequency(m) / total2) & vbCrLf
        Next

    End Sub
    'display a single die image'
    Sub DisplayDie(diePictureBox As PictureBox)
        Dim face As Integer = randomObject.Next(1, 7)
        Dim pictureResource = My.Resources.ResourceManager.GetObject(String.Format("die{0}", face))

        'convert picture resource to image type and load into picturebox'
        diePictureBox.Image = CType(pictureResource, Image)
        frequency(face) += 1 'increment appropriate frequency counter'

    End Sub

    '=========================================================================================================================================================='
    '=================================================================================Flag Quiz================================================================'
    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter
        Dim countries() As String = {"Australia", "Brazil", "China", "Italy", "Russia", "South Africa", "Spain", "United States"}
        Dim randomObject As New Random()

        ComboBox1.DataSource = countries
        DisplayFlag() 'displayes first flag in picturebox
    End Sub

    'boolean array tracks which flags have been displayed'

    Dim countries() As String = {"Australia", "Brazil", "China", "Itally", "Russia", "South Africa", "Spain", "United States"}
    Dim count As Integer = 1 'number of flags shown'
    Dim country As String 'current flags country'
    Dim used(countries.GetUpperBound(0)) As Boolean 'all false by default'
    Private Sub submitButton_Click(sender As Object, e As EventArgs) Handles submitButton.Click
        'verify user's answers'
        If ComboBox1.Text = country Then
            MessageBox.Show("Correct! ", "Correct Answer")
        Else
            MessageBox.Show("The correct answer is " & country, "Incorrect Answer")
        End If

        'Inform user if quiz is over'
        If count >= countries.Length Then 'quiz is over'
            ComboBox1.Enabled = False
            submitButton.Enabled = False
        Else 'quiz is not over'
            DisplayFlag()
            ComboBox1.SelectedIndex = 0 'select first combobox entry'
            count += 1
        End If
    End Sub

    'return unused random number'
    Function GetUniqueRandomNumber() As Integer
        Dim randomNumber As Integer
        Do 'generate random numbers untill unused flag is found'
            randomNumber = randomObject.Next(0, used.Length)
        Loop Until used(randomNumber) = False
        used(randomNumber) = True 'indicate that flag has been used'
        Return randomNumber 'return index for new flag'
    End Function
    'display random flag in picturebox'
    Sub DisplayFlag()
        Dim randomNumber As Integer = GetUniqueRandomNumber()
        country = countries(randomNumber) 'get country name'
        'get image resource, remove spaces from country name'
        Dim pictureResource = My.Resources.ResourceManager.GetObject(country.Replace(" ", ""))
        flagPictureBox.Image = CType(pictureResource, Image) 'display flag'

    End Sub


    '=========================================================================================================================================================='
End Class
