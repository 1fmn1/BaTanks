Public Class clsBlock
    Public X As Long, Y As Long, SpeedX As Long, SpeedY As Long, Counter As Long, startX As Long, _
startY As Long, isOnField As Boolean
    Public Width As Long, Height As Long
    Public Sub Init(sx As Long, sy As Long, W As Long, H As Long)
        startX = sx
        startY = sy
        Height = 40
        Width = 40
        Respawn()
        'isOnField = True
    End Sub
    Public Sub Update()
        Counter += 1
        If Counter > BlockLife Then Respawn()
    End Sub
    Public Sub Move(Angle As Double, Speed As Long)
        'Dim Colorback(3) As Long
        'Select Case Status
        '    Case 0
        '        Colorback(0) = SprFrm.GetPixel(X, (Y - Speed))
        '        Colorback(1) = SprFrm.GetPixel((X + Width - 1), (Y - Speed))
        '        Colorback(2) = SprDynamicFrm.GetPixel(X, (Y - Speed))
        '        Colorback(3) = SprDynamicFrm.GetPixel((X + Width - 1), (Y - Speed))
        '    Case 1
        '        Colorback(0) = SprFrm.GetPixel((X + Speed + Width), Y)
        '        Colorback(1) = SprFrm.GetPixel((X + Speed + Width), (Y + Height - 1))
        '        Colorback(2) = SprDynamicFrm.GetPixel((X + Speed + Width), Y)
        '        Colorback(3) = SprDynamicFrm.GetPixel((X + Speed + Width), (Y + Height - 1))
        '    Case 2
        '        Colorback(0) = SprFrm.GetPixel(X, (Y + Speed + Height))
        '        Colorback(1) = SprFrm.GetPixel((X + Width - 1), (Y + Speed + Height))
        '        Colorback(2) = SprDynamicFrm.GetPixel(X, (Y + Speed + Height))
        '        Colorback(3) = SprDynamicFrm.GetPixel((X + Width - 1), (Y + Speed + Height))
        '    Case 3
        '        Colorback(0) = SprFrm.GetPixel((X - Speed), Y)
        '        Colorback(1) = SprFrm.GetPixel((X - Speed), (Y + Height - 1))
        '        Colorback(2) = SprDynamicFrm.GetPixel(X, (Y + Speed + Height))
        '        Colorback(3) = SprDynamicFrm.GetPixel((X + Width - 1), (Y + Speed + Height))
        'End Select
        'For i = 0 To 3
        '    If (Colorback(i) <> vbBlack) Then Exit Sub
        'Next
        SprDynamicFrm.ClearRect(X, X + 40, Y, Y + 40, vbBlack)
        X += Speed * Math.Sin(Angle)
        Y -= Speed * Math.Cos(Angle)
        SprDynamicFrm.ClearRect(X, X + 40, Y, Y + 40, vbMagenta)
        Counter = 0
    End Sub
    Public Sub Draw()
        'If isOnField Then
        SprBackBuffer.Draw(sprTexture(4), X - ChangeX, Y - ChangeY, Op.AlphaBlend)
        'End If
    End Sub
    Friend Sub BackDraw(spr As Sprite)
        'If isOnField Then
        spr.ClearRect(X, X + 40, Y, Y + 40, vbMagenta)
        'End If
    End Sub
    Private Sub Respawn()
        SprDynamicFrm.ClearRect(X, X + 40, Y, Y + 40, vbBlack)
        X = startX
        Y = startY
        SprDynamicFrm.ClearRect(X, X + 40, Y, Y + 40, vbMagenta)
        Counter = 0
    End Sub
    Public Sub Destroy()
        isOnField = False
    End Sub
    Public Sub New()
        MyBase.New()
    End Sub

End Class
