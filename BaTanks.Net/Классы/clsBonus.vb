Public Class clsBonus
    Public X As Long, Y As Long, WhatIsThis As Integer, isExploding As Boolean
    Private mvarisOnField As Boolean
    Public Property isOnField As Boolean
        Get
            isOnField = mvarisOnField
        End Get
        Set(ByVal vData As Boolean)
            If vData = mvarisOnField Then Exit Property
            If vData = False Then PlayMusEff(5)
            mvarisOnField = vData
        End Set
    End Property
    Public Sub Update()
        'On Error Resume Next
        Dim BonusRand As Integer, clorlol As Long, clorlol1 As Long
        Static BonusTime As Long
        If mvarisOnField = True Then
            BonusTime += 1
            If BonusTime > BonusLife Then mvarisOnField = False : BonusTime = 0
            Exit Sub
        End If
        If LANgame And isHost = False Then Exit Sub

        'ReDraw:
        If Int(Rnd * 100) < 100 - BonusRandom Then Exit Sub
        X = Int(Rnd * (MapSizeX * 40 - 70))
        Y = Int(Rnd * (MapSizeY * 40 - 70))
        clorlol = SprFrm.GetPixel((X + 20), (Y + 20))
        clorlol1 = SprDynamicFrm.GetPixel((X + 20), (Y + 20))
        If clorlol <> vbBlack Or clorlol1 <> vbBlack Then Exit Sub
        BonusRand = Int(Rnd() * 100)
        If BonusRand <= ChanceShot Then
            WhatIsThis = 0
        ElseIf BonusRand >= ChanceShot + ChanceShield + ChanceSpeed Then
            WhatIsThis = 3
        ElseIf BonusRand < ChanceShot + ChanceShield And BonusRand > ChanceShot Then
            WhatIsThis = 1
        ElseIf BonusRand < 100 - ChanceEdges And BonusRand >= ChanceShot + ChanceShield Then
            WhatIsThis = 2
        End If
        BonusTime = 0
        isOnField = True
        isExploding = True
    End Sub
    Public Sub Draw(DT As Single)
        Static CurFrame As Single
        If mvarisOnField Then
            SprBackBuffer.Draw(sprBonus(WhatIsThis), X - ChangeX, Y - ChangeY)
        End If
        If isExploding Then
            CurFrame = CurFrame + DT * 16
            Anim_Bonus.DrawTo(SprBackBuffer, X + 15 - ChangeX, Y + 15 - ChangeY, CurFrame)
            If CurFrame > Anim_Bonus.SprCnt - 1 Then
                isExploding = False
                CurFrame = 0
            End If
        End If
    End Sub
    Public Sub New()
        MyBase.New()
    End Sub
End Class
