Public Class clsTrack
    Private Structure Track_Data
        Dim X As Long
        Dim Y As Long
        Dim isOnField As Long
        Dim Angle As Double
    End Structure
    Private Inde As Integer, TrCounter As Long, uTrack(0 To 99) As Track_Data
    Public Sub DrawTrack()
        Dim sprhelp As New Sprite(40, 40)
        For i = 0 To 99
            If uTrack(i).isOnField > 0 Then
                If uTrack(i).X - ChangeX < -40 And uTrack(i).Y - ChangeY < -40 _
                    And uTrack(i).X - ChangeX > SprBackBuffer.Width + 40 And _
                    uTrack(i).Y - ChangeY > SprBackBuffer.Height + 40 Then Continue For
                sprhelp.ClearBuffer(ARGB(0, 255, 255, 255))
                sprhelp.DrawRotate(sprTrack(0), 15, 15, 20, 20, -uTrack(i).Angle)
                SprBackBuffer.Draw(sprhelp, uTrack(i).X - 5 - ChangeX, uTrack(i).Y - 5 - ChangeY, Op.Mul)
            End If
        Next
    End Sub
    Public Sub InitTrack(Tindex As Integer)
        Inde = Tindex
        TrCounter = 0
    End Sub
    Public Sub UpdateTrack()
        Static counter As Integer
        If counter < 3 Then
            counter += 1
            Exit Sub
        End If
        counter = 0
        If TrCounter = 50 Then
            TrCounter = 0
        End If
        uTrack(TrCounter).X = Tank(Inde).X + 5
        uTrack(TrCounter).Y = Tank(Inde).Y + 5
        uTrack(TrCounter).isOnField = 100
        uTrack(TrCounter).Angle = Tank(Inde).Angle
        TrCounter += 1
    End Sub
    Public Sub TimeTrack()
        For i = 0 To 99
            If uTrack(i).isOnField > 0 Then
                uTrack(i).isOnField -= 1
            End If
        Next
    End Sub
    Public Sub DemolTrack()
        For i = 0 To 99
            uTrack(i).isOnField = False
        Next
    End Sub
    Public Sub New()
        MyBase.New()
    End Sub
End Class
