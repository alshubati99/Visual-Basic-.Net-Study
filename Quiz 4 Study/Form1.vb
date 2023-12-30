Imports System.Data.SqlClient
Public Class Form1
    Dim CN As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DC\OneDrive\Documents\database1.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN.Open()
    End Sub

    '**********Display Function**************'
    Sub Display()
        Dim Query As String = "Select * from myTable"
        Dim Command As New SqlCommand(Query, CN)
        Dim DTab As New DataTable
        Dim SDAdap As New SqlDataAdapter(Command)
        SDAdap.Fill(DTab)

        DataGridView1.DataSource = DTab
        DataGridView1.Refresh()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Display()
    End Sub
    'If Cell is Double Clicked Textboxes will show data'
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells("id").Value
        TextBox2.Text = DataGridView1.CurrentRow.Cells("brand").Value
        TextBox3.Text = DataGridView1.CurrentRow.Cells("model").Value
        ComboBox1.Text = DataGridView1.CurrentRow.Cells("year").Value
        NumericUpDown1.Text = DataGridView1.CurrentRow.Cells("stock").Value
    End Sub

    '***Update Button*****'
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Query As String
        Query = "UPDATE myTable SET brand ='" & TextBox2.Text & "', model = '" & TextBox3.Text & "', year = '" & ComboBox1.Text & "', stock = '" & NumericUpDown1.Value & "' WHERE id = '" & TextBox1.Text & "' "
        Dim Command As New SqlCommand(Query, CN)
        Command.ExecuteNonQuery()

        Display()
    End Sub



    '******Insert************'
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Query As String
        Query = "INSERT INTO myTable VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "','" & NumericUpDown1.Value & "')"
        Dim Command As New SqlCommand(Query, CN)
        Command.ExecuteNonQuery()
        Display()
    End Sub
    '****Delete********'
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Query As String
        Query = "DELETE FROM myTable WHERE Id = '" & TextBox1.Text & "'"
        Dim Command As New SqlCommand(Query, CN)
        Command.ExecuteNonQuery()
        Display()

    End Sub

    '****Exit******'
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CN.Close()
        Application.Exit()

    End Sub

    '***Search by Brand*****'
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Query As String = "SELECT * FROM myTable WHERE brand = '" & TextBox4.Text & "'"
        Dim Command As New SqlCommand(Query, CN)
        Dim DTab As New DataTable
        Dim SDAdap As New SqlDataAdapter()
        SDAdap.Fill(DTab)

        DataGridView1.DataSource = DTab
        DataGridView1.Refresh()


    End Sub

    '****Search by ID*****'
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim Query As String
        Query = "select * from myTable where id = '" & TextBox5.Text & "'"
        Dim Command As New SqlCommand(Query, CN)
        Dim SDR As SqlDataReader = Command.ExecuteReader()
        TextBox6.Clear()

        If SDR.Read() Then
            TextBox6.AppendText("Id = " & SDR.Item("Id").ToString() & vbCrLf)
            TextBox6.AppendText("Brand = " & SDR.Item("brand").ToString() & vbCrLf)
            TextBox6.AppendText("Model = " & SDR.Item("model").ToString() & vbCrLf)
            TextBox6.AppendText("Year = " & SDR.Item("year").ToString() & vbCrLf)
            TextBox6.AppendText("Stocks = " & SDR.Item("stock").ToString() & vbCrLf)
        Else
            MessageBox.Show("No record Found!", "Warning")

        End If

        SDR.Close()
    End Sub
End Class
