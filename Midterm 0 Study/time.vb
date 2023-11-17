Public Class time
    'declare variables for hour, minute and second'
    Private hourValue As Integer
    Private minuteValue As Integer
    Private secondValue As Integer

    'time constructor with hour, minute, second as optional param'
    Public Sub New(Optional h As Integer = 12, Optional m As Integer = 0, Optional s As Integer = 0)
        SetTime(h, m, s) 'call settime'
    End Sub

    'time constructor: another time object supplied'
    Public Sub New(t As time)
        SetTime(t.hourValue, t.minuteValue, t.secondValue)
    End Sub

    'set new time vlue using universal time, check validity of data'
    Public Sub SetTime(h As Integer, m As Integer, s As Integer)
        'set accessors to validate hour, minute, second'
        Hour = h
        Minute = m
        Second = s
    End Sub

    'property Hour'
    Public Property Hour() As Integer
        Get 'return hourValue'
            Return hourValue
        End Get
        Set(value As Integer) 'set hourValue'
            If (value >= 0 AndAlso value < 24) Then 'in range 0-23'
                hourValue = value 'value is valid'
            Else 'invalid hour'
                Throw New ArgumentOutOfRangeException("hour must be 0-23")
            End If

        End Set
    End Property

    'property Minute'
    Public Property Minute() As Integer
        Get
            Return minuteValue
        End Get
        Set(value As Integer) 'set minuteValue'
            If (value >= 0 AndAlso value < 60) Then 'in range 0-59'
                minuteValue = value 'value is valid'
            Else 'value invlid'
                Throw New ArgumentOutOfRangeException("minute must be 0-59")
            End If
        End Set
    End Property

    'property Second'
    Public Property Second() As Integer
        Get
            Return secondValue
        End Get
        Set(value As Integer) 'set second value'
            If (value >= 0 AndAlso value < 60) Then 'in range 0-59'
                secondValue = value
            Else
                Throw New ArgumentOutOfRangeException("second must be 0-59")
            End If
        End Set
    End Property

    'return time as string in universal time 24=hour clock format'
    Public Function ToUniversalString() As String
        Return String.Format("{0}:{1:D2}:{2:D2}", Hour, Minute, Second)
    End Function

    'return time as string in standard time 12 hour clock format'
    Public Overrides Function ToString() As String
        Dim suffix As String 'am or pm'
        Dim standardHour As String 'standard hour in range 1-12'
        'determine wether the 12 hour clock suffix is am or pm'
        If Hour < 12 Then
            suffix = "AM"
        Else
            suffix = "PM"
        End If
        'convert hour from universal time format to standard time format'
        If (Hour = 12 OrElse Hour = 0) Then
            standardHour = 12 'noon or midnight'
        Else
            standardHour = Hour Mod 12 '1 through 11 am or pm'
        End If

        Return String.Format("{0}:{1:D2}:{2:D2} {3}", standardHour, Minute, Second, suffix)
    End Function



End Class
