Imports System.Net

Public Class Account
    Private balanceValue As Decimal
    Public Sub New(Optional initialBalance As Decimal = 0D)
        If initialBalance < 0D Then
            Throw New ArgumentOutOfRangeException("initial balance must be greater than or equal to 0")
        End If
        balanceValue = initialBalance 'initialize balancevalue'
    End Sub
    'deposit money to account'
    Public Sub Deposit(depositAmount As Decimal)
        If depositAmount <= 0D Then
            Throw New ArgumentOutOfRangeException("Deposit amount must be positive")
        End If
        balanceValue += depositAmount
    End Sub

    'withdraw money from the account'
    Public Sub Withdraw(withdrawalAmount As Decimal)
        If withdrawalAmount > balanceValue Then
            Throw New ArgumentOutOfRangeException("withdrawal amount ust be positive")
        End If
        balanceValue -= withdrawalAmount
    End Sub

    'Return current balance'
    Public ReadOnly Property Balance As Decimal
        Get 'to retrieve the variables value'
            Return balanceValue
        End Get
    End Property
    'set to modify the variables value'
End Class
