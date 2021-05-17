Public Class clsAnimation
    Dim spr() As Sprite
    'Dim SprCnt1 As Long
    Dim AddX As Long, AddY As Long
    Dim Phase As Single
    Public SprCnt As Long
    Friend Sub DrawRot(ByVal Dest As Sprite, ByVal dx As Long, ByVal dy As Long, ByVal Phase As Single, Optional ByVal Angl As Double = 0)
        On Error Resume Next
        Dim sprRot As Sprite
        sprRot = New Sprite(50, 50)
        sprRot.ClearBuffer(ARGB(0, 255, 255, 255))
        sprRot.DrawRotate(spr(Phase), 20, 20, 25, 25, -Angl, False)
        sprRot.AddColorKey(ARGB(0, 255, 255, 255))
        Dest.Draw(sprRot, dx - 5, dy - 5, Op.AlphaBlend)

    End Sub
    Friend Sub DrawTo(Dest As Sprite, ByVal dx As Long, ByVal dy As Long, ByVal Phase As Single, Optional ByVal Op As SR2D.Op = 0)
        On Error Resume Next
        Dest.Draw(spr(Phase), dx + AddX, dy + AddY, Op)
    End Sub

    Public Sub New(ByVal CntX As Long, ByVal CntY As Long, ByVal Width As Integer, ByVal Height As Integer, ByVal CenterX As Long, ByVal CenterY As Long, fName As String, Optional MinKoef As Double = 1, Optional CCKey As Long = vbBlack)
        MyBase.New()
        Dim SprTemp11 As Sprite
        Dim sprTemp1111 As Sprite
        Dim i As Long
        For i = 0 To SprCnt - 1
            spr(i) = Nothing
        Next i
        SprTemp11 = New Sprite(fName) '//SN: Можно без SprTemp11 вроде, хз зачем он...
        'SprTemp11.AddColorKey (ARGB(0, 0, 0, 0))
        sprTemp1111 = New Sprite(SprTemp11, , CInt(Width * MinKoef * CntX), CInt(Height * MinKoef * CntY), CCKey)
        SprCnt = CntX * CntY
        AddX = -CenterX * MinKoef
        AddY = -CenterY * MinKoef
        ReDim spr(SprCnt - 1)
        For i = 0 To SprCnt - 1
            spr(i) = New Sprite(CInt(Width * MinKoef), CInt(Height * MinKoef), Op.AlphaBlend)
            spr(i).Draw(sprTemp1111, -(i Mod CntX) * Width * MinKoef, -(i \ CntX) * Height * MinKoef, Op.Paint)
        Next i
    End Sub

    Private Sub Finalise()
        Dim i As Long

        For i = 0 To SprCnt - 1
            spr(i) = Nothing
        Next i
    End Sub

    Public Sub ChangeColor(OldColor As Long, NewColor As Long)
        Dim sprHelp As Sprite, i As Integer
        For i = 0 To SprCnt - 1
            'OldColor = ARGB(255, 0, 255, 0)
            'NewColor = ARGB(255, 255, 255, 0)
            sprHelp = New Sprite(spr(i), Op.Paint)
            sprHelp.AddColorKey(OldColor)
            sprHelp.MaskClearBuffer(sprHelp, 0, 0, NewColor, ARGB(128, 0, 0, 0), True)
            spr(i) = New Sprite(sprHelp, Transform.FlipX)
        Next
    End Sub
End Class
