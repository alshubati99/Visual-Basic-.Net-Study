Public Class EMPLOYEE
    Public Property Firstname As String
    Public Property Surname As String
    Private salary As Integer

    Public Sub New(ByVal first As String, ByVal last As String, ByVal sal As Integer)
        Firstname = first
        Surname = last
        salary = sal
    End Sub

    Public Property monthlysalary() As Integer
        Get
            Return salary
        End Get
        Set(value As Integer)
            salary = value
        End Set
    End Property

    'not in exam
    Public Overrides Function ToString() As String
        Return String.Format("{0,-10} {1,-10} {2,10}", Firstname, Surname, salary)
    End Function
End Class
