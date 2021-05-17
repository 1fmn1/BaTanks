Public Class clsBox
    Public X As Long, Y As Long, isOnField As Boolean, isExploding As Boolean, isRespawning As Boolean
    Private startX As Long, startY As Long, RespTimer As Integer, CurFrame As Single, CurrFrame As Single

    Public Sub Explode()
        isOnField = False
        SprFrm.ClearRect(X, X + 40, Y, Y + 40, vbBlack)
        RespTimer = RBoxTimer
        isExploding = True
        PlayMusEff(4)
    End Sub
    Private Sub Create()
        isOnField = True
        SprFrm.ClearRect(X, X + 40, Y, Y + 40, vbYellow)
        For p = 0 To AutosOnMap
            If (Tank(p).X + 30 >= X + 5 And Tank(p).X <= X + 35) And
                (Tank(p).Y + 30 >= Y + 5 And Tank(p).Y <= Y + 35) Then
                'If (Tank(p).X >= X + 5 And Tank(p).X <= (X + 35)) Or (Tank(p).X + 30 >= X + 5 And Tank(p).X + 30 <= X + 35) Then
                '    If (Tank(p).Y >= Y + 5 And Tank(p).Y <= (Y + 35)) Or (Tank(p).Y + 30 >= Y + 5 And Tank(p).Y + 30 <= (Y + 35)) Then
                Tank(p).Demolish()
                Tank(p).Kills -= 1
            End If
            'End If
        Next
    End Sub
    Public Sub Update()
        If isOnField = False Then
            If RespTimer <= 0 Then
                isRespawning = True
            End If
            RespTimer -= 1
        End If
    End Sub
    Public Sub Draw(DT As Single, MeSpeed As Single)
        If isOnField = True Then
            If X - ChangeX > -40 And Y - ChangeY > -40 And X - ChangeX < SprBackBuffer.Width + 40 And Y - ChangeY < SprBackBuffer.Height + 40 Then
                SprBackBuffer.Draw(sprTexture(3), X - ChangeX, Y - ChangeY, Op.AlphaBlend)
            End If
        End If
        If isRespawning = True Then
            CurrFrame = CurrFrame + DT * MeSpeed
            If X - ChangeX > -40 And Y - ChangeY > -40 And X - ChangeX < SprBackBuffer.Width + 40 And Y - ChangeY < SprBackBuffer.Height + 40 Then
                Anim_ExpBox.DrawTo(SprBackBuffer, X - ChangeX + 20, Y - ChangeY + 20, CurrFrame)
            End If
            If CurrFrame > Anim_ExpBox.SprCnt - 1 Then
                Create()
                isRespawning = False
                CurrFrame = 0
            End If
        End If
        If isExploding = True Then
            CurFrame = CurFrame + DT * 15
            If X - ChangeX > -40 And Y - ChangeY > -40 And X - ChangeX < SprBackBuffer.Width + 40 And Y - ChangeY < SprBackBuffer.Height + 40 Then
                Anim_Exp.DrawTo(SprBackBuffer, X - ChangeX + 20, Y - ChangeY + 20, CurFrame)
            End If
            If CurFrame > Anim_ExpBox.SprCnt - 1 Then
                isExploding = False
                CurFrame = 0
            End If
        End If
    End Sub
    Public Sub New()
        MyBase.New()
    End Sub
End Class
