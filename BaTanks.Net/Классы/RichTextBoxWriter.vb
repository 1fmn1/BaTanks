Imports System.IO
Public Class RichTextBoxWriter
    Inherits StreamWriter
    Public Sub New()
            MyBase.New("BaTanks.log", FileMode.Create)
            Me.AutoFlush = True
    End Sub
    Public OutputBox As RichTextBox
    Public Overrides Sub WriteLine(value As String)
        _Write(value + Environment.NewLine)
    End Sub
    Public Overloads Sub WriteLine(format As String, arg As ParamArrayAttribute)
        _Write(String.Format(format, arg) + Environment.NewLine)
    End Sub

    Public Overloads Sub WriteLine()
        _Write(Environment.NewLine)
    End Sub

    Public Overrides Sub Write(value As String)
        _Write(value)
    End Sub

    Public Overloads Sub Write(format As String, arg As ParamArrayAttribute)
        _Write(String.Format(format, arg))
    End Sub
    Delegate Sub f(text As String)

    Private Sub _Write(text As String)

        If Not (OutputBox.IsDisposed) Then

            If (OutputBox.InvokeRequired) Then
                '' Не ждем завершение UI операции.
                OutputBox.BeginInvoke(New f(AddressOf fdf), text)
            Else
                fdf(text)
            End If
            If Not (String.IsNullOrEmpty(text)) Then
                MyBase.Write(String.Format("[{0:yyyy.MM.dd HH:mm:ss.ffff}] {1}", DateTime.Now, text))
            End If
        End If
    End Sub
    Sub fdf(text As String)
        OutputBox.AppendText(text)
        OutputBox.ScrollToCaret()
    End Sub
End Class
