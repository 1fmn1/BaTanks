Public Class clsShot
    Public X As Single, Y As Single, Angle As Single, Initialized As Boolean
    Private Index As Long, Speed As Single, CurrFrame As Single, sprhelp As New Sprite(15, 15)
    'local variable(s) to hold property value(s)
    Private mvarisMoving As Boolean, mvarisExploding As Boolean  'local copy

    Public Property isMoving As Boolean
    'used when assigning a value to the property, on the left side of an assignment.
    'Syntax: X.isMoving = 5
        Set(vData As Boolean)
            If vData = mvarisMoving Then Exit Property
            If vData Then PlayMusEff(2)
            mvarisMoving = vData
        End Set
        Get
            isMoving = mvarisMoving
        End Get
    End Property

    Public Property isExploding As Boolean
        'used when assigning a value to the property, on the left side of an assignment.
        'Syntax: X.isMoving = 5
        Get
            isExploding = mvarisExploding
        End Get
        Set(vData As Boolean)
            If vData = mvarisExploding Then Exit Property
            If vData Then PlayMusEff(4)
            'If vData = False Then Initialized = False
            mvarisExploding = vData
        End Set
    End Property

    Public Sub Draw(DT, MeSpeed)
        If mvarisMoving = True Then
            If X - ChangeX > -40 And Y - ChangeY > -40 And X - ChangeX < SprBackBuffer.Width + 40 And Y - ChangeY < SprBackBuffer.Height + 40 Then
                SprBackBuffer.Draw(sprhelp, X - 7 - ChangeX, Y - 7 - ChangeY, Op.AlphaBlend)
            End If
        End If
        If mvarisExploding Then
            CurrFrame = CurrFrame + DT * MeSpeed
            If X - ChangeX > -40 And Y - ChangeY > -40 And X - ChangeX < SprBackBuffer.Width + 40 And Y - ChangeY < SprBackBuffer.Height + 40 Then
                Anim_Exp.DrawTo(SprBackBuffer, X - ChangeX, Y - ChangeY, CurrFrame)
            End If
            If CurrFrame > Anim_Exp.SprCnt - 1 Then
                mvarisExploding = False
                Initialized = False
                CurrFrame = 0
            End If
        End If
    End Sub

    Public Sub Init(PIndex As Integer, Px As Long, Py As Long, Angl As Double)
        Initialized = True
        Angle = Angl
        Index = PIndex
        Speed = ShotSpeed
        X = Px + 20
        Y = Py + 20
        mvarisExploding = False
        mvarisMoving = True
        sprhelp.ClearBuffer(ARGB(0, 255, 255, 255)) '
        sprhelp.DrawRotate(SprShot(0), 8, 8, 8, 8, -Angle, False)
        sprhelp.AddColorKey(ARGB(0, 255, 255, 255))
    End Sub

    Public Sub Move()
        Dim pixel As Integer, oldX As Long, oldY As Long, i As Integer
        If mvarisMoving = False Then Exit Sub
        oldX = X
        oldY = Y
        X = X + ShotSpeed * Math.Sin(Angle)
        Y = Y - ShotSpeed * Math.Cos(Angle)
        If Y < 0 Or X < 0 Or Y > MapSizeY * 40 Or X > MapSizeX * 40 Then mvarisMoving = False : Exit Sub
        pixel = SprFrm.GetPixel(X, Y)
        Select Case pixel
            Case vbGreen
                mvarisMoving = False
                mvarisExploding = True
                PlayMusEff(4)
                Exit Sub
                'Case vbMagenta
                '    mvarisMoving = False
                '    mvarisExploding = True
                '    PlayMusEff(4)
                '    'PlayMusEff(4) //SN: хз зачем повтор
                '    Exit Sub
            Case vbYellow
                For p = 1 To ScoreBoxesOnMap
                    If (X >= WoodenBox(p).X And X <= (WoodenBox(p).X + 40)) And
                       (Y >= WoodenBox(p).Y And Y <= (WoodenBox(p).Y + 40)) Then
                        'mvarisExploding = True
                        WoodenBox(p).Explode()
                        mvarisMoving = False
                        mvarisExploding = True
                        Exit Sub
                    End If
                Next p
        End Select
        pixel = SprDynamicFrm.GetPixel(X, Y)
        For i = 0 To AutosOnMap
            If i = Index Then Continue For
            If Tank(i).isDead = True Then Continue For
            If X > Tank(i).X + 5 And X < Tank(i).X + 35 Then
                If Y > Tank(i).Y + 5 And Y < Tank(i).Y + 35 Then
                    mvarisMoving = False
                    If Tank(i).isShielded Then
                        'mvarisExploding = True
                        If CurrentShotsA > ShotLimit Then
                            CurrentShotsA = 0
                        End If

                        Angle -= Math.PI

                        If Angle < 0 Then Angle = 2 * Math.PI - Angle
                        If Angle > 2 * Math.PI Then Angle = 2 * Math.PI - Angle
                        Shot(CurrentShotsA).Init(i, X - 15, Y - 15, Angle)
                        CurrentShotsA += 1
                        Exit Sub
                    End If
                    mvarisExploding = True
                    Tank(i).Demolish()
                    Tank(Index).Kills += 1
                    Exit Sub
                End If
            End If
        Next i
        If pixel = 0 Then
            Exit Sub
        ElseIf pixel = vbMagenta Then
            mvarisMoving = False
            mvarisExploding = True
            PlayMusEff(4)
            Exit Sub
        Else
            'For i = 0 To AutosOnMap
            '    If i = Index Then Continue For

            '    If pixel = ARGB(0, 255, 0, i) Then
            '        mvarisMoving = False
            '        If Tank(i).isShielded Then
            '            'mvarisExploding = True
            '            If CurrentShotsA > ShotLimit Then
            '                CurrentShotsA = 0
            '            End If

            '            Angle -= Math.PI

            '            If Angle < 0 Then Angle = 2 * Math.PI - Angle
            '            If Angle > 2 * Math.PI Then Angle = 2 * Math.PI - Angle
            '            Shot(CurrentShotsA).Init(i, X - 15, Y - 15, Angle)
            '            CurrentShotsA += 1
            '            Exit Sub
            '        End If
            '        Tank(i).Demolish()
            '        Tank(Index).Kills += 1
            '        Exit Sub
            '    End If
            '    'If pixel = ARGB(0, 255, 128, i) Then
            '    '    mvarisMoving = False
            '    '    If Tank(i).isShielded Then
            '    '        mvarisExploding = True
            '    '        Exit Sub
            '    '    End If
            '    ' If Math.Abs(Angle - Tank(i).Angle) < 1 Or (Math.Abs(Angle - Tank(i).Angle) < Math.PI + 1 And Math.Abs(Angle - Tank(i).Angle) > Math.PI - 1) Then
            '    'If CurrentShotsA > ShotLimit Then
            '    '    CurrentShotsA = 0
            '    'End If

            '    'Angle = Tank(i).Angle - Angle

            '    'If Angle < 0 Then Angle = 2 * 3.14 - Angle
            '    'If Angle > 2 * 3.14 Then Angle = 2 * 3.14 - Angle
            '    'Shot(CurrentShotsA).Init(i, X - 15, Y - 15, Angle)
            '    'CurrentShotsA = CurrentShotsA + 1
            '    'Exit Sub
            '    'Tank(i).Demolish()
            '    'Tank(Index).Kills = Tank(Index).Kills + 1
            '    'Exit Sub
            '    'End If
            '    'End If
            'Next
        End If
    End Sub

    Public Sub Dispose()
        mvarisMoving = False
    End Sub

    Public Sub New()
        MyBase.New()
    End Sub
End Class
