Public Class clsTankNew
    Private Tcolour As Long, RespX As Long, RespY As Long, RespAnim As Boolean, KillAnim As Boolean
    '====================================================================
    Private Ind As Integer, lolcolor As Long, RespawnTime As Long, _
   ShotDelay As Boolean, SprHelpS As Sprite
    '====================================================================
    Public isShielded As Boolean, isComp As Boolean, _
    Speed As Long, Ammo As Long, ShieldTime As Long, hasEdges As Boolean, Angle As Single = 0
    Private mvarKills As Integer, mvarDeaths As Integer, mvarisDead As Boolean, mvarX As Single, mvarY As Single, mvarMyColor As Long, isShooting As Boolean, BackSprite As New Sprite(40, 40), BackSprite2 As New Sprite(40, 40)
    Private Structure UserData1
        Dim UKey As Boolean
        Dim RKey As Boolean
        Dim DKey As Boolean
        Dim LKey As Boolean
        Dim FKey As Boolean
        Dim FBlocked As Boolean
    End Structure
    Public Property Deaths As Integer
        Get
            Deaths = mvarDeaths
        End Get
        Set(ByVal vData As Integer)
            If vData - mvarDeaths <= 1 And vData >= 0 Then
                mvarDeaths = Deaths
            End If
        End Set
    End Property
    Public Property MyColor As Long
        Get
            MyColor = mvarMyColor
        End Get
        Set(ByVal vData As Long)
            Anim_Tank(Ind).ChangeColor(mvarMyColor, vData)
            mvarMyColor = vData
        End Set
    End Property
    Public Property X As Single
        Get
            X = mvarX
        End Get
        Set(ByVal vData As Single)
            If vData <> mvarX Then
                mvarX = vData
                'Track(Ind).UpdateTrack()
            End If
        End Set
    End Property
    Public Property Y As Single
        Get
            Y = mvarY
        End Get
        Set(ByVal vData As Single)
            If vData <> mvarY Then
                mvarY = vData
                'Track(Ind).UpdateTrack()
            End If
        End Set
    End Property
    Public Property Kills As Integer
        Get
            Kills = mvarKills
        End Get
        Set(ByVal vData As Integer)
            If vData - mvarKills <= 1 And vData >= 0 Then
                mvarKills = vData
            End If
        End Set
    End Property
    Public Property isDead() As Boolean
        Get
            isDead = mvarisDead
        End Get
        Set(ByVal vData As Boolean)
            'If vData <> mvarisDead Then
            'If vData Then
            'PlayMusEff(1)
            'KillAnim = True
            mvarisDead = vData
            'Else
            'RespAnim = True
            'mvarisDead = False
            'End If
            'End If
        End Set
    End Property
    '====================================================================
    Public Sub InitA(Optional ByVal RespawnX As Long = 40, _
    Optional ByVal RespawnY As Long = 40, Optional Index As Integer = 0)
        'sprDisplay.Init 140, 140, Op.AlphaBlend
        SprHelpS = New Sprite(34, 34, Op.AlphaBlend)
        'MyColor = ARGB(255, 255, 255, 0)
        'If Index = 0 Then
        'MyColor = ARGB(255, 255, 0, 0)
        'Anim_Tank(Index).ChangeColor(MyOldColor, MyColor)
        'Anim_Tank(Index).ChangeColor(MyOldColor, MyColor)
        'Else
        'Anim_Tank(Index).ChangeColor(MyOldColor, MyColor)
        'End If
        mvarX = RespawnX
        mvarY = RespawnY
        Angle = 0
        Speed = RespSpeed
        Ammo = MaxShots1
        KillAnim = False
        RespAnim = False
        mvarisDead = False
        isShielded = False
        hasEdges = False
        mvarKills = 0
        mvarDeaths = 0
        Ind = Index
        RespX = RespawnX
        RespY = RespawnY
        lolcolor = ARGB(0, 255, 0, Ind)
        Anim_Tank(0).DrawRot(BackSprite, 0, 0, 0, 0)
        BackSprite.MaskClearBuffer(BackSprite, 0, 0, ARGB(0, 255, 0, Ind), ARGB(128, 0, 0, 0), False)
        BackSprite2.MaskClearBuffer(BackSprite, 0, 0, 0, ARGB(128, 0, 0, 0), False)
        'BackSprite.ClearRect(6, 13, 4, 39, ARGB(0, 255, 128, Ind))
        'BackSprite.ClearRect(28, 35, 4, 39, ARGB(0, 255, 128, Ind))
    End Sub

    Public Overridable Sub DrawA(DT As Single)
        Static CurFrame As Single, CurrFrame As Single, CurrrFrame As Single, CurFrameAuto As Single, ShotFrame As Single
        ''''''''''''''''''KillAnim'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If KillAnim Then
            CurrrFrame = CurrrFrame + DT * 8
            If mvarX - ChangeX > -40 And mvarY - ChangeY > -40 _
            And mvarX - ChangeX < SprBackBuffer.Width + 40 And mvarY - ChangeY < SprBackBuffer.Height + 40 Then
                Anim_Kill.DrawTo(SprBackBuffer, mvarX - ChangeX + 20, mvarY - ChangeY + 20, CurrrFrame)
                If CurrrFrame > Anim_Kill.SprCnt - 1 Then
                    CurrrFrame = 0
                    KillAnim = False
                End If
            End If
        End If
        ''''''''''''''''''RespAnim'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If RespAnim Then
            CurrFrame = CurrFrame + DT * 16
            If RespX - ChangeX > -40 And RespY - ChangeY > -40 _
            And RespX - ChangeX < SprBackBuffer.Width + 40 And RespY - ChangeY < SprBackBuffer.Height + 40 Then
                Anim_Resp.DrawTo(SprBackBuffer, RespX - ChangeX + 20, RespY - ChangeY + 20, CurrFrame)
            End If
            If CurrFrame > Anim_Resp.SprCnt - 1 Then
                CurrFrame = 0
                Respawn()
                RespAnim = False
            End If
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If mvarisDead Then Exit Sub
        If Gamer(Ind).DKey Or Gamer(Ind).UKey Or Gamer(Ind).RKey Or Gamer(Ind).LKey Or isComp = True Then
            CurFrameAuto = CurFrameAuto + DT * Speed * 2
        End If
        If CurFrameAuto > Anim_Tank(Ind).SprCnt - 0.5 Then
            CurFrameAuto = 0
        End If
        ''''''''''''''''''ShotAnim'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If isShooting = True Then
            ShotFrame = ShotFrame + DT * 32
            If mvarX - ChangeX > -40 And mvarY - ChangeY > -40 _
            And mvarX - ChangeX < SprBackBuffer.Width + 40 And mvarY - ChangeY < SprBackBuffer.Height + 40 Then
                Select Case Angle
                    Case 0
                        Anim_ShotAnim.DrawRot(SprBackBuffer, mvarX - ChangeX + 10, mvarY - ChangeY - 20, ShotFrame, 0)
                    Case 1
                        Anim_ShotAnim.DrawRot(SprBackBuffer, mvarX - ChangeX + 40, mvarY - ChangeY + 10, ShotFrame, Math.PI / 2)
                    Case 2
                        Anim_ShotAnim.DrawRot(SprBackBuffer, mvarX - ChangeX + 10, mvarY - ChangeY + 40, ShotFrame, Math.PI)
                    Case 3
                        Anim_ShotAnim.DrawRot(SprBackBuffer, mvarX - ChangeX - 20, mvarY - ChangeY + 10, ShotFrame, Math.PI / 2 + Math.PI)
                End Select
            End If
            If ShotFrame > Anim_ShotAnim.SprCnt - 1 Then
                ShotFrame = 0
                isShooting = False
            End If
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If mvarX - ChangeX < -40 And mvarY - ChangeY < -40 _
            And mvarX - ChangeX > SprBackBuffer.Width + 40 And mvarY - ChangeY > SprBackBuffer.Height + 40 Then Exit Sub
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Anim_Tank(Ind).DrawRot(SprBackBuffer, mvarX - ChangeX, mvarY - ChangeY, CurFrameAuto, Angle)
        ''''''''''''''''''''''''ShieldAnim'''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If isShielded Then
            CurFrame += DT * 2
            If CurFrame >= Math.PI Then CurFrame = 0
            SprHelpS.ClearBuffer(ARGB(0, 255, 255, 255))
            SprHelpS.DrawRotate(SprShield, 17, 17, 17, 17, CurFrame)
            SprHelpS.AddColorKey(ARGB(0, 0, 0, 0))
            SprBackBuffer.Draw(SprHelpS, mvarX + 3 - ChangeX, mvarY + 3 - ChangeY, Op.DefaultOp)
        End If
        ''''''''''''''''''''''''EdgesAnim'''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If hasEdges Then
            Select Case Angle
                Case 0
                    SprBackBuffer.Draw(SprEdges(0), mvarX + 3 - ChangeX, mvarY - 8 - ChangeY, Op.DefaultOp)
                    SprBackBuffer.Draw(SprEdges(1), mvarX + 25 - ChangeX, mvarY - 8 - ChangeY, Op.DefaultOp)
                Case 1
                    SprBackBuffer.Draw(SprEdges(2), mvarX + 36 - ChangeX, mvarY + 3 - ChangeY, Op.DefaultOp)
                    SprBackBuffer.Draw(SprEdges(3), mvarX + 36 - ChangeX, mvarY + 25 - ChangeY, Op.DefaultOp)
                Case 2
                    SprBackBuffer.Draw(SprEdges(4), mvarX + 3 - ChangeX, mvarY + 36 - ChangeY, Op.DefaultOp)
                    SprBackBuffer.Draw(SprEdges(5), mvarX + 25 - ChangeX, mvarY + 36 - ChangeY, Op.DefaultOp)
                Case 3
                    SprBackBuffer.Draw(SprEdges(6), mvarX - 8 - ChangeX, mvarY + 3 - ChangeY, Op.DefaultOp)
                    SprBackBuffer.Draw(SprEdges(7), mvarX - 8 - ChangeX, mvarY + 25 - ChangeY, Op.DefaultOp)
            End Select
        End If
    End Sub

    Public Sub Respawn(Optional ByVal RespawnX As Long = 0, Optional ByVal RespawnY As Long = 0)
        If RespawnX <> 0 And RespawnY <> 0 Then
            mvarX = RespawnX
            mvarY = RespawnY
        Else
            mvarX = RespX
            mvarY = RespY
        End If
        Angle = 0
        Speed = RespSpeed
        Ammo = MaxShots1
        SprDynamicFrm.DrawRotate(BackSprite, 20, 20, mvarX + 20, mvarY + 20, -Angle)
        mvarisDead = False
        isShielded = True
        ShieldTime = BonusShields
    End Sub

    Public Sub Demolish()
        PlayMusEff(1)
        KillAnim = True
        mvarisDead = True
        hasEdges = False
        isShooting = False
        RespawnTime = RespTime
        'SprDynamicFrm.DrawRotate(BackSprite2, 20, 20, mvarX + 20, mvarY + 20, -Angle)
        mvarDeaths = mvarDeaths + 1
    End Sub

    Public Overridable Sub Move(ByVal Upkey As Boolean, ByVal DownKey As Boolean, _
                                Leftkey As Boolean, RightKey As Boolean)
        If Upkey = False And DownKey = False And Leftkey = False And RightKey = False Then Exit Sub
        Dim Colorback1 As Long, Colorback2 As Long, ColorBack3 As Long, ColorBack4 As Long, MySpeedX As Single, MySpeedY As Single, p As Long, m As Long, intX As Single, intY As Single

        If mvarisDead = True Then Exit Sub
        If LANgame = False Or (LANgame And isHost) Then
            'Status = Storona
            'SprFrm.DrawRotate(BackSprite2, 20, 20, mvarX + 20, mvarY + 20, -Angle)
            MySpeedX = Speed * Math.Sin(Angle)
            MySpeedY = -Speed * Math.Cos(Angle)
            intX = 20 * Math.Sin(Angle)
            intY = 20 * Math.Cos(Angle)

            If Upkey = True Then
                Colorback1 = SprFrm.GetPixel(mvarX + 20 + intX + 0.7 * intY + MySpeedX \ 2, mvarY + 20 - intY + 0.7 * intX + MySpeedY \ 2)
                Colorback2 = SprFrm.GetPixel(mvarX + 20 + intX - 0.7 * intY + MySpeedX \ 2, mvarY + 20 - intY - 0.7 * intX + MySpeedY \ 2)
                ColorBack3 = SprDynamicFrm.GetPixel(mvarX + 20 + intX + 0.7 * intY + MySpeedX \ 2, mvarY + 20 - intY + 0.7 * intX + MySpeedY \ 2)
                ColorBack4 = SprDynamicFrm.GetPixel(mvarX + 20 + intX - 0.7 * intY + MySpeedX \ 2, mvarY + 20 - intY - 0.7 * intX + MySpeedY \ 2)
                For i = 0 To AutosOnMap
                    If i = Ind Then Continue For
                    If Tank(i).isDead = True Then Continue For
                    If mvarX + 20 + intX + 0.7 * intY + MySpeedX \ 2 > Tank(i).X + 5 And _
                        mvarX + 20 + intX + 0.7 * intY + MySpeedX \ 2 < Tank(i).X + 35 Then
                        If mvarY + 20 - intY + 0.7 * intX + MySpeedY \ 2 > Tank(i).Y + 5 And _
                            mvarY + 20 - intY + 0.7 * intX + MySpeedY \ 2 < Tank(i).Y + 35 Then
                            Exit Sub
                        End If
                    ElseIf mvarX + 20 + intX - 0.7 * intY + MySpeedX \ 2 > Tank(i).X + 5 And _
                        mvarX + 20 + intX - 0.7 * intY + MySpeedX \ 2 < Tank(i).X + 35 Then
                        If mvarY + 20 - intY - 0.7 * intX + MySpeedY \ 2 > Tank(i).Y + 5 And _
                            mvarY + 20 - intY - 0.7 * intX + MySpeedY \ 2 < Tank(i).Y + 35 Then
                            Exit Sub
                        End If
                    End If
                Next i
            ElseIf DownKey = True Then
                Colorback1 = SprFrm.GetPixel(mvarX + 20 - intX - 0.7 * intY - MySpeedX \ 2, mvarY + 20 + intY - 0.7 * intX - MySpeedY \ 2)
                Colorback2 = SprFrm.GetPixel(mvarX + 20 - intX + 0.7 * intY - MySpeedX \ 2, mvarY + 20 + intY + 0.7 * intX - MySpeedY \ 2)
                ColorBack3 = SprDynamicFrm.GetPixel(mvarX + 20 - intX - 0.7 * intY - MySpeedX \ 2, mvarY + 20 + intY - 0.7 * intX - MySpeedY \ 2)
                ColorBack4 = SprDynamicFrm.GetPixel(mvarX + 20 - intX + 0.7 * intY - MySpeedX \ 2, mvarY + 20 + intY + 0.7 * intX - MySpeedY \ 2)
                For i = 0 To AutosOnMap
                    If i = Ind Then Continue For
                    If Tank(i).isDead = True Then Continue For
                    If mvarX + 20 - intX - 0.7 * intY - MySpeedX \ 2 > Tank(i).X + 5 And _
                        mvarX + 20 - intX - 0.7 * intY - MySpeedX \ 2 < Tank(i).X + 35 Then
                        If mvarY + 20 + intY - 0.7 * intX - MySpeedY \ 2 > Tank(i).Y + 5 And _
                            mvarY + 20 + intY - 0.7 * intX - MySpeedY \ 2 < Tank(i).Y + 35 Then
                            Exit Sub
                        End If
                    ElseIf mvarX + 20 - intX + 0.7 * intY - MySpeedX \ 2 > Tank(i).X + 5 And _
                        mvarX + 20 - intX + 0.7 * intY - MySpeedX \ 2 < Tank(i).X + 35 Then
                        If mvarY + 20 + intY + 0.7 * intX - MySpeedY \ 2 > Tank(i).Y + 5 And _
                            mvarY + 20 + intY + 0.7 * intX - MySpeedY \ 2 < Tank(i).Y + 35 Then
                            Exit Sub
                        End If
                    End If
                Next i
            ElseIf RightKey = True Then
                Colorback1 = SprFrm.GetPixel(mvarX + 20 + intX + 0.7 * intY, mvarY + 20 - intY + 0.7 * intX)
                ColorBack3 = SprDynamicFrm.GetPixel(mvarX + 20 + intX + 0.7 * intY, mvarY + 20 - intY + 0.7 * intX)
                For i = 0 To AutosOnMap
                    If i = Ind Then Continue For
                    If Tank(i).isDead = True Then Continue For
                    If mvarX + 20 + intX + 0.7 * intY > Tank(i).X + 5 And _
                        mvarX + 20 + intX + 0.7 * intY < Tank(i).X + 35 Then
                        If mvarY + 20 - intY + 0.7 * intX > Tank(i).Y + 5 And _
                           mvarY + 20 - intY + 0.7 * intX < Tank(i).Y + 35 Then
                            Exit Sub
                        End If
                    End If
                Next i
            ElseIf Leftkey = True Then
                Colorback2 = SprFrm.GetPixel(mvarX + 20 + intX - 0.7 * intY, mvarY + 20 - intY - 0.7 * intX)
                ColorBack4 = SprDynamicFrm.GetPixel(mvarX + 20 + intX - 0.7 * intY, mvarY + 20 - intY - 0.7 * intX)
                For i = 0 To AutosOnMap
                    If i = Ind Then Continue For
                    If Tank(i).isDead = True Then Continue For
                    If mvarX + 20 + intX - 0.7 * intY > Tank(i).X + 5 And _
                       mvarX + 20 + intX - 0.7 * intY < Tank(i).X + 35 Then
                        If mvarY + 20 - intY - 0.7 * intX > Tank(i).Y + 5 And _
                           mvarY + 20 - intY - 0.7 * intX < Tank(i).Y + 35 Then
                            Exit Sub
                        End If
                    End If
                Next i
            End If

            If ColorBack3 = vbMagenta Or ColorBack4 = vbMagenta Then
                For p = 1 To ScoreBlocksOnMap
                    If (X + 7 >= Block(p).X And X + 7 <= (Block(p).X + 40)) Or (X + 33 >= Block(p).X And X + 33 <= Block(p).X + 40) Then
                        If (Y + 7 >= Block(p).Y And Y + 7 <= (Block(p).Y + 40)) Or (Y + 33 >= Block(p).Y And Y + 33 <= (Block(p).Y + 40)) Then
                            Block(p).Move(Angle, Speed)
                            Exit Sub
                        End If
                    End If
                Next p
            End If
            If Colorback1 = vbBlue Or Colorback2 = vbBlue Or (Colorback1 = vbYellow And Colorback2 = vbYellow) _
                    Or (Colorback1 = vbGreen And Colorback2 = vbGreen) Then Exit Sub
            If ((Colorback1 = vbGreen Or Colorback1 = vbYellow) And Colorback2 = 0 And Upkey = True) Then
                If Angle > 0 And Angle < Math.PI / 2 Then MySpeedX = 0
                If Angle > Math.PI / 2 And Angle < Math.PI Then MySpeedY = 0
                If Angle > Math.PI And Angle < Math.PI * 1.5 Then MySpeedX = 0
                If Angle > Math.PI * 1.5 And Angle < Math.PI * 2 Then MySpeedY = 0
            End If
            If (Colorback1 = 0 And (Colorback2 = vbGreen Or Colorback2 = vbYellow) And Upkey = True) Then
                If Angle > 0 And Angle < Math.PI / 2 Then MySpeedY = 0
                If Angle > Math.PI / 2 And Angle < Math.PI Then MySpeedX = 0
                If Angle > Math.PI And Angle < Math.PI * 1.5 Then MySpeedY = 0
                If Angle > Math.PI * 1.5 And Angle < Math.PI * 2 Then MySpeedX = 0
            End If
            If ((Colorback1 = vbGreen Or Colorback1 = vbYellow) And Colorback2 = 0 And DownKey = True) Then
                If Angle > 0 And Angle < Math.PI / 2 Then MySpeedX = 0
                If Angle > Math.PI / 2 And Angle < Math.PI Then MySpeedY = 0
                If Angle > Math.PI And Angle < Math.PI * 1.5 Then MySpeedX = 0
                If Angle > Math.PI * 1.5 And Angle < Math.PI * 2 Then MySpeedY = 0
            End If
            If (Colorback1 = 0 And (Colorback2 = vbGreen Or Colorback2 = vbYellow) And DownKey = True) Then
                If Angle > 0 And Angle < Math.PI / 2 Then MySpeedY = 0
                If Angle > Math.PI / 2 And Angle < Math.PI Then MySpeedX = 0
                If Angle > Math.PI And Angle < Math.PI * 1.5 Then MySpeedY = 0
                If Angle > Math.PI * 1.5 And Angle < Math.PI * 2 Then MySpeedX = 0
            End If
            'If hasEdges Then
            '    For i = 0 To AutosOnMap
            '        If ColorBack3 = ARGB(0, 255, 0, i) Or ColorBack4 = ARGB(0, 255, 0, i) Then
            '            If Tank(i).isShielded = True Then Exit Sub
            '            Kills += 1
            '            Tank(i).Demolish()
            '        End If
            '    Next i
            'Else
            '    For i = 0 To AutosOnMap
            '        If ColorBack3 = ARGB(0, 255, 0, i) Or ColorBack4 = ARGB(0, 255, 0, i) Then Exit Sub
            '    Next
            'End If
            'SprDynamicFrm.DrawRotate(BackSprite2, 20, 20, mvarX + 20, mvarY + 20, -Angle)
            If RightKey = True Then
                Angle += 0.01 * Speed
                If Angle >= Math.PI * 2 Then 'Выравнивает вверх на отлично
                    Angle = 0
                End If
            End If
            If Leftkey = True Then
                Angle -= 0.01 * Speed
                If Angle < 0 Then
                    Angle = Math.PI * 2 - Angle
                End If
            End If
            If Upkey = True Then
                mvarX += MySpeedX
                mvarY += MySpeedY
            ElseIf DownKey = True Then
                mvarX -= MySpeedX
                mvarY -= MySpeedY
            End If
            'SprDynamicFrm.DrawRotate(BackSprite, 20, 20, mvarX + 20, mvarY + 20, -Angle)
            If mvarY < 0 Then mvarY = 0
            If mvarX < 0 Then mvarX = 0
            If mvarY > (MapSizeY - 1) * 40 Then mvarY = (MapSizeY - 1) * 40
            If mvarX > (MapSizeX - 1) * 40 Then mvarX = (MapSizeX - 1) * 40
        End If
        Track(Ind).UpdateTrack()
        For m = 0 To MaxBonuses - 1
            If Bonus(m).isOnField Then
                If ((mvarY + 30 >= Bonus(m).Y) And _
                    (mvarY + 30 <= Bonus(m).Y + 30)) Or _
                    ((mvarY >= Bonus(m).Y) And _
                    (mvarY <= Bonus(m).Y + 30)) Then
                    If ((mvarX + 30 >= Bonus(m).X) And _
                          (mvarX + 30 <= Bonus(m).X + 30)) Or _
                          ((mvarX >= Bonus(m).X) And _
                          (mvarX <= Bonus(m).X + 30)) Then
                        Bonus(m).isOnField = False
                        Select Case Bonus(m).WhatIsThis
                            Case 0
                                Ammo = MaxShots1
                            Case 1
                                isShielded = True
                                ShieldTime = BonusShields
                            Case 2
                                Speed += 1
                                If Speed > MaxSpeed Then
                                    Speed = MaxSpeed
                                End If
                            Case 3
                                hasEdges = True
                        End Select
                    End If
                End If
            End If
        Next m
    End Sub

    Public Sub Fire()
        On Error Resume Next
        If mvarisDead Or Ammo = 0 Then Exit Sub
        If isComp And ShotDelay Then Exit Sub
        If LANgame And isHost And ShotDelay And Ind > 0 Then Exit Sub
        PlayMusEff(2)
        ShotDelay = True
        isShooting = True
        Ammo -= 1
        If CurrentShotsA > ShotLimit Then
            CurrentShotsA = 0
        End If
        Shot(CurrentShotsA).Init(Ind, mvarX, mvarY, Angle)
        CurrentShotsA = CurrentShotsA + 1
    End Sub

    Friend Sub BackDraw(Dest As Sprite)
        If mvarisDead = True Then Exit Sub
        'BackSprite.ClearBuffer(vbBlack)
        'Anim_Tank(0).DrawRot(BackSprite, 0, 0, 0, Angle)
        'BackSprite.MaskClearBuffer(BackSprite, 0, 0, lolcolor, ARGB(128, 0, 0, 0))
        'Dest.DrawRotate(BackSprite, 20, 20, mvarX + 20, mvarY + 20, -Angle)
    End Sub
    Public Sub Update()
        On Error Resume Next
        If isShielded = True Then
            ShieldTime = ShieldTime - 1
            If ShieldTime <= 0 Then
                isShielded = False
            End If
        End If
        If mvarisDead = True Then
            RespawnTime -= 1
            If RespawnTime <= 0 Then
                RespAnim = True
            End If
        End If
        ShotDelay = False
        'DrawDisplay()
    End Sub
    Public Sub DrawDisplay()
        'Select Case Ind
        '    Case 0
        '        sprFinalMenu.Draw(MakeNumber(Ammo), 90, 110, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(ShieldTime), 90, 145, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(Speed), 90, 180, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(mvarKills), 90, 215, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(mvarDeaths), 90, 250, Op.Add)
        '    Case 2
        '        sprFinalMenu.Draw(MakeNumber(Ammo), 90, 430, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(ShieldTime), 90, 465, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(Speed), 90, 500, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(mvarKills), 90, 535, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(mvarDeaths), 90, 570, Op.Add)
        '    Case 1
        '        sprFinalMenu.Draw(MakeNumber(Ammo), 890, 110, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(ShieldTime), 890, 145, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(Speed), 890, 180, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(mvarKills), 890, 215, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(mvarDeaths), 890, 250, Op.Add)
        '    Case 3
        '        sprFinalMenu.Draw(MakeNumber(Ammo), 890, 430, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(ShieldTime), 890, 465, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(Speed), 890, 500, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(mvarKills), 890, 535, Op.Add)
        '        sprFinalMenu.Draw(MakeNumber(mvarDeaths), 890, 570, Op.Add)
        'End Select
        Select Case Ind
            Case 0
                SprBackBuffer.Draw(sprMenuBonus, 5, 23, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(Ammo), 50, 30, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(ShieldTime), 50, 64, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(Speed), 50, 98, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(mvarKills), 50, 132, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(mvarDeaths), 50, 166, Op.AlphaBlend)
            Case 2
                SprBackBuffer.Draw(sprMenuBonus, 5, SprBackBuffer.Height - 187, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(Ammo), 50, SprBackBuffer.Height - 180, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(ShieldTime), 50, SprBackBuffer.Height - 146, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(Speed), 50, SprBackBuffer.Height - 112, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(mvarKills), 50, SprBackBuffer.Height - 78, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(mvarDeaths), 50, SprBackBuffer.Height - 44, Op.AlphaBlend)
            Case 1
                SprBackBuffer.Draw(sprMenuBonus, SprBackBuffer.Width - 85, 23, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(Ammo), SprBackBuffer.Width - 40, 30, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(ShieldTime), SprBackBuffer.Width - 40, 64, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(Speed), SprBackBuffer.Width - 40, 98, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(mvarKills), SprBackBuffer.Width - 40, 132, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(mvarDeaths), SprBackBuffer.Width - 40, 166, Op.AlphaBlend)
            Case 3
                SprBackBuffer.Draw(sprMenuBonus, SprBackBuffer.Width - 85, SprBackBuffer.Height - 187, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(Ammo), SprBackBuffer.Width - 40, SprBackBuffer.Height - 180, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(ShieldTime), SprBackBuffer.Width - 40, SprBackBuffer.Height - 146, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(Speed), SprBackBuffer.Width - 40, SprBackBuffer.Height - 112, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(mvarKills), SprBackBuffer.Width - 40, SprBackBuffer.Height - 78, Op.AlphaBlend)
                SprBackBuffer.Draw(MakeNumber(mvarDeaths), SprBackBuffer.Width - 40, SprBackBuffer.Height - 44, Op.AlphaBlend)
        End Select
    End Sub
    Public Sub BTIntellect()
        Dim Colorback1 As Long, Colorback2 As Long, Colorback3 As Long, Colorback4 As Long, m As Long, Slychai As Single
        Dim SpeedX As Single, SpeedY As Single, intX As Single, intY As Single
        Static Status As Integer
        Slychai = Rnd() * 10
        If Slychai > 9.8 Then Status = Int(Rnd() * 4)
        Select Case Status
            Case 0
                Angle = 0
            Case 1
                Angle = Math.PI / 2
            Case 2
                Angle = Math.PI
            Case 3
                Angle = Math.PI / 2 + Math.PI
        End Select
        If mvarisDead = True Then Exit Sub
        SpeedX = Speed * Math.Sin(Angle)
        SpeedY = -Speed * Math.Cos(Angle)
        intX = 20 * Math.Sin(Angle)
        intY = 20 * Math.Cos(Angle)
        Colorback1 = SprFrm.GetPixel(mvarX + 20 + intX + 0.7 * intY + SpeedX \ 2, mvarY + 20 - intY + 0.7 * intX + SpeedY \ 2)
        Colorback2 = SprFrm.GetPixel(mvarX + 20 + intX - 0.7 * intY + SpeedX \ 2, mvarY + 20 - intY - 0.7 * intX + SpeedY \ 2)
        Colorback3 = SprDynamicFrm.GetPixel(mvarX + 20 + intX + 0.7 * intY + SpeedX \ 2, mvarY + 20 - intY + 0.7 * intX + SpeedY \ 2)
        Colorback4 = SprDynamicFrm.GetPixel(mvarX + 20 + intX - 0.7 * intY + SpeedX \ 2, mvarY + 20 - intY - 0.7 * intX + SpeedY \ 2)

        If Colorback1 = vbBlack And Colorback2 = vbBlack And Colorback3 = vbBlack And Colorback4 = vbBlack Then GoTo Bmetka2
        If Colorback3 = vbMagenta Or Colorback4 = vbMagenta Then
            ' For p = 1 To ScoreBlocksOnMap
            'If (X + 7 >= Block(p).X And X + 7 <= (Block(p).X + 40)) Or (X + 33 >= Block(p).X And X + 33 <= Block(p).X + 40) Then
            'If (Y + 7 >= Block(p).Y And Y + 7 <= (Block(p).Y + 40)) Or (Y + 33 >= Block(p).Y And Y + 33 <= (Block(p).Y + 40)) Then
            'Block(p).Move(Angle, Speed)
            'Status = Int(Rnd() * 4)
            'Block(p).Move(Status, Speed)
            Exit Sub
            'End If
            'End If
            'Next p
        End If
        If Colorback1 = vbYellow Or Colorback2 = vbYellow Then
            If Ammo = 0 Or ShotDelay = True Then
                Status = Int(Rnd() * 4)
                Exit Sub
            Else
                Fire()
            End If
        End If
        If Colorback1 = vbBlue Or Colorback2 = vbBlue _
          Or Colorback1 = vbGreen Or Colorback2 = vbGreen Then
            Status = Int(Rnd() * 4)
            Exit Sub
        End If
        If hasEdges Then
            For i = 0 To AutosOnMap
                If Colorback3 = ARGB(0, 255, 0, i) Or Colorback4 = ARGB(0, 255, 0, i) Then
                    If Tank(i).isShielded = True Then Exit Sub
                    Kills += 1
                    Tank(i).Demolish()
                End If
            Next i
        Else
            For i = 0 To AutosOnMap
                If Colorback3 = ARGB(0, 255, 0, i) Or Colorback4 = ARGB(0, 255, 0, i) Then
                    Status = Int(Rnd() * 4)
                    Exit Sub
                End If
            Next
        End If
bmetka2:
        SprDynamicFrm.DrawRotate(BackSprite2, 20, 20, mvarX + 20, mvarY + 20, -Angle)
        Select Case Status
            Case 0
                mvarY = mvarY - Speed
            Case 1
                mvarX = mvarX + Speed
            Case 2
                mvarY = mvarY + Speed
            Case 3
                mvarX = mvarX - Speed
        End Select
        If mvarY < 0 Then mvarY = 0 : Status = Int(Rnd() * 4)
        If mvarX < 0 Then mvarX = 0 : Status = Int(Rnd() * 4)
        If mvarY > (MapSizeY - 1) * 40 Then mvarY = (MapSizeY - 1) * 40 : Status = Int(Rnd() * 4)
        If mvarX > (MapSizeX - 1) * 40 Then mvarX = (MapSizeX - 1) * 40 : Status = Int(Rnd() * 4)
        SprDynamicFrm.DrawRotate(BackSprite, 20, 20, mvarX + 20, mvarY + 20, -Angle)
        Track(Ind).UpdateTrack()
        For m = 0 To MaxBonuses - 1
            If Bonus(m).isOnField Then
                If ((mvarY + 30 >= Bonus(m).Y) And _
                    (mvarY + 30 <= Bonus(m).Y + 30)) Or _
                    ((mvarY >= Bonus(m).Y) And _
                    (mvarY <= Bonus(m).Y + 30)) Then
                    If ((mvarX + 30 >= Bonus(m).X) And _
                          (mvarX + 30 <= Bonus(m).X + 30)) Or _
                          ((mvarX >= Bonus(m).X) And _
                          (mvarX <= Bonus(m).X + 30)) Then
                        Bonus(m).isOnField = False
                        Select Case Bonus(m).WhatIsThis
                            Case 0
                                Ammo = MaxShots1
                            Case 1
                                isShielded = True
                                ShieldTime = BonusShields
                            Case 2
                                Speed = Speed + 1
                                If Speed > MaxSpeed Then
                                    Speed = MaxSpeed
                                End If
                            Case 3
                                hasEdges = True
                        End Select
                    End If
                End If
            End If
        Next m
        If Ammo = 0 Or ShotDelay = True Then Exit Sub
        Dim helpx As Integer, helpy As Integer
        For m = 0 To AutosOnMap
            If m = Ind Or Tank(m).isDead = True Then Continue For
            If Tank(m).Y + 25 > mvarY + 5 And Tank(m).Y + 5 < mvarY + 25 And Math.Abs(Tank(m).X - mvarX) < 550 Then
                If Tank(m).isShielded = True Or Ammo = 0 Or ShotDelay = True Then
                    If Angle = Math.PI / 2 Or Angle = Math.PI / 2 + Math.PI Then
                        Slychai = Rnd()
                        If Slychai > 0.5 Then
                            Angle = 0
                        Else
                            Angle = Math.PI
                        End If
                    End If
                    Exit Sub
                End If
                helpy = mvarY + 20
                If Tank(m).X <= mvarX Then
                    helpx = mvarX
                    Do While helpx > Tank(m).X + 20
                        helpx = helpx - 30
                        Colorback1 = SprFrm.GetPixel(helpx, helpy)
                        If Colorback1 = vbGreen Or Colorback1 = vbYellow Or Colorback1 = vbMagenta Then Continue For
                    Loop
                    Angle = Math.PI / 2 + Math.PI
                    Fire()
                Else
                    helpx = mvarX + 35
                    Do While helpx < Tank(m).X + 20
                        helpx = helpx + 30
                        Colorback1 = SprFrm.GetPixel(helpx, helpy)
                        If Colorback1 = vbGreen Or Colorback1 = vbYellow Or Colorback1 = vbMagenta Then Continue For
                    Loop
                    Angle = Math.PI / 2
                    Fire()
                End If
            ElseIf Tank(m).X + 25 > mvarX + 5 And Tank(m).X + 5 < mvarX + 25 And Math.Abs(Tank(m).Y - mvarY) < 550 Then
                If Tank(m).isShielded = True Or Ammo = 0 Or ShotDelay = True Then
                    If Angle = 0 Or Angle = Math.PI Then
                        Slychai = Rnd()
                        If Slychai > 0.5 Then
                            Angle = Math.PI / 2
                        Else
                            Angle = Math.PI / 2 + Math.PI
                        End If
                    End If
                    Exit Sub
                End If
                helpx = mvarX + 20
                If Tank(m).Y <= mvarY Then
                    helpy = mvarY
                    Do While helpy > Tank(m).Y + 20
                        helpy = helpy - 30
                        Colorback1 = SprFrm.GetPixel(helpx, helpy)
                        If Colorback1 = vbGreen Or Colorback1 = vbYellow Or Colorback1 = vbMagenta Then Continue For
                    Loop
                    Angle = 0
                    Fire()
                Else
                    helpy = mvarY + 35
                    Do While helpy < Tank(m).Y + 20
                        helpy = helpy + 30
                        Colorback1 = SprFrm.GetPixel(helpx, helpy)
                        If Colorback1 = vbGreen Or Colorback1 = vbYellow Or Colorback1 = vbMagenta Then Continue For
                    Loop
                    Angle = Math.PI
                    Fire()
                End If
            End If
        Next m
    End Sub

    Public Sub New()
        MyBase.New()
        mvarMyColor = ARGB(255, 255, 0, 0)
    End Sub
End Class
