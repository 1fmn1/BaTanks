Imports System.Runtime.InteropServices
Public Class FrmvsMain
    Dim Num As Integer, _
    TimerScore As Integer, Colorback1 As Long, Colorback2 As Long, lngColor As Long, _
    BoxTimer As Integer, MoveMode As Boolean, meX As Single, meY As Single, _
    mrand As Integer, miNutes As Long, seConds As Long, rBlPath(0 To 10) As Boolean, _
    lBlPath(0 To 10) As Boolean, uBlPath(0 To 10) As Boolean, dBlPath(0 To 10) As Boolean, _
    sprRoadHelp As Sprite, intSleep As Long, sprColor As New Sprite(95, 422), sprStart(2) As Sprite
    Dim T1 As Double, T2 As Double, T3 As Double, DT As Single, Grp As Graphics, Starting As Boolean, Ending As Boolean, Winner As Integer
    Dim hDC As HandleRef
    Dim hDC2 As HandleRef
    Dim picX As Integer, picY As Integer, MousePressed As Boolean, AltEditorView As Boolean
    Private sprEndMenu As Sprite, FPS1 As Integer
    Private sprWinner As New Sprite(Application.StartupPath & "\Графика\Winner.btj")
    Dim a1 As System.Threading.Thread, EMapChanged As Boolean
    Private Ping1 As Double, Ping2 As Double, Ping As Integer, bitmap1 As New System.Drawing.Bitmap(My.Resources._1), _
        bitmap2 As New System.Drawing.Bitmap(My.Resources._2), bitmap3 As New System.Drawing.Bitmap(My.Resources._3)
    Public Sub UpdateList(text As String)
        If ListBox1.InvokeRequired Then
            ListBox1.Invoke(New Delegat(AddressOf UpdateList), "Kek")
        Else
            ListBox1.Items.Add(text)
            ListBox1.Refresh()
        End If
    End Sub
    Public Sub Loading()
        'AddHandler ourAudio.Ending, AddressOf Me.Close
        'Console.SetOut(rtfWriter)
        'rtfWriter.OutputBox = RTB1
        sprStart(0) = New Sprite(bitmap3)
        sprStart(1) = New Sprite(bitmap2)
        sprStart(2) = New Sprite(bitmap1)
        BTMusic = False
        'FileListBox1.SelectedIndex = 0
        'RC$ = vbCrLf & "Console Version 0.1"
        'rtbChat1.SelStart = Len(rtbChat1.Text)
        ''rtbChat1.SelLength = 0
        ''rtbChat1.SelText = RC$
        ''rtbChat1.SelStart = Len(rtbChat1.Text) - Len(RC$)
        ''rtbChat1.SelLength = Len(RC$)
        ''rtbChat1.SelColor = vbYellow
        'RunAudio(App.Path & "\sounds\backmelody2.mp3", 1)
        Texture_Init()
        Try
            Kill("tempmap.btm")
        Catch e As Exception
        End Try
        Running = False
        BTEditing = False
        LeftKey(0) = &H25
        RightKey(0) = &H27
        DownKey(0) = &H28
        UpKey(0) = &H26
        Firekey(0) = &H11
        LeftKey(1) = &H41
        RightKey(1) = &H44
        DownKey(1) = &H53
        UpKey(1) = &H57
        Firekey(1) = Keys.Space
        Randomize()
        Sound = 0
        Me.Text = "BaТанчики приветствуют тебя!!!"
        picRoad.ClientSize = New System.Drawing.Size(640, 640)
        '-----------------------------mnuInitialize
        Sound = 1
        Back1.Stop()
        Back2.Stop()
        'For i = 0 To 3
        '    IsJoy(i) = -1
        '    ctrlHello1.GetControls(i, UpKey(i), RightKey(i), DownKey(i), LeftKey(i), Firekey(i), IsJoy(i))
        'Next
        'MinKoef = 2
        CtrlHello1.Visible = False
        CtrlOption1.Visible = False
        CtrlColor1.Visible = False
        CtrlEditor1.Visible = False
        myTank = 0
        AutosOnMap = -1
        Me.Visible = True
    End Sub
    Private Sub UpdateRoad()
        If myTank < 0 Or myTank > 3 Then myTank = 0
        ChangeX = (Tank(myTank).X - SprBackBuffer.Width / 2)
        ChangeY = (Tank(myTank).Y - SprBackBuffer.Height / 2)
        If ChangeX < 0 Then
            ChangeX = 0
        End If
        If ChangeY < 0 Then
            ChangeY = 0
        End If
        If ChangeX > MapSizeX * 40 - SprBackBuffer.Width Then
            If MapSizeX * 40 - SprBackBuffer.Width > 0 Then
                ChangeX = (MapSizeX * 40 - SprBackBuffer.Width)
            Else
                ChangeX = (MapSizeX * 40 - SprBackBuffer.Width) / 2
            End If
        End If
        If ChangeY > MapSizeY * 40 - SprBackBuffer.Height Then
            If MapSizeX * 40 - SprBackBuffer.Height > 0 Then
                ChangeY = MapSizeY * 40 - SprBackBuffer.Height
            Else
                ChangeY = (MapSizeY * 40 - SprBackBuffer.Height) / 2
            End If
        End If
    End Sub
    'Private Sub Moving_Panzer()
    '    'Dim JOYPOS As JOYINFO, strPack As String
    '    'Tank(0).isComp = True
    '    '            For i = 0 To AutosOnMap
    '    '                If Tank(i).isComp = True Then
    '    '                    Tank(i).BTIntellect()
    '    '                    GoTo Moveend
    '    '            End If
    '    '            If Gamer(i).FKey = True And Gamer(i).FBlocked = False Then
    '    '                Tank(i).Fire()
    '    '                Gamer(i).FBlocked = True
    '    '            End If
    '    '            Tank(i).Move(Gamer(i).UKey, Gamer(i).DKey, Gamer(i).LKey, Gamer(i).RKey)
    '    '                'If IsJoy(i) = -1 Then
    '    '                '                If Gamer(i).LKey Then
    '    '                '                    Tank(i).Move(3)
    '    '                '                    GoTo metka5
    '    '                '                End If
    '    '                '                If Gamer(i).RKey Then
    '    '                '                    Tank(i).Move(1)
    '    '                '                    GoTo metka5
    '    '                '                End If
    '    '                '                If Gamer(i).UKey Then
    '    '                '                    Tank(i).Move(0)
    '    '                '                    GoTo metka5
    '    '                '                End If
    '    '                '                If Gamer(i).DKey Then
    '    '                '                    Tank(i).Move(2)
    '    '                '                    GoTo metka5
    '    '                '                End If
    '    '                'metka5:
    '    '                '                If Gamer(i).FKey And Gamer(i).FBlocked = False Then
    '    '                '                    Tank(i).Fire()
    '    '                '                    'Gamer(i).FKey = False
    '    '                '                    Gamer(i).FBlocked = True
    '    '                '                End If
    '    '                '                Else 'Äæîéñòèê!!!!! ===================================================
    '    '                '                    joyGetpos(IsJoy(i), JOYPOS)
    '    '                '                    If JOYPOS.wXpos = 255 Then
    '    '                '                        Tank(i).Move(3)
    '    '                '                        GoTo metka6
    '    '                '                    End If
    '    '                '                    If JOYPOS.wXpos = 65274 Then
    '    '                '                        Tank(i).Move(1)
    '    '                '                        GoTo metka6
    '    '                '                    End If
    '    '                '                    If JOYPOS.wYpos = 255 Then
    '    '                '                        Tank(i).Move(0)
    '    '                '                        GoTo metka6
    '    '                '                    End If
    '    '                '                    If JOYPOS.wYpos = 65274 Then
    '    '                '                        Tank(i).Move(2)
    '    '                '                        GoTo metka6
    '    '                '                    End If
    '    '                'metka6:
    '    '                '                    If JOYPOS.wButtons <> 0 Then
    '    '                '                        Tank(i).Fire()
    '    '                '                    End If
    '    '                'End If
    '    'Moveend:
    '    '            Next i
    '        '        Else
    '        '            strPack = Chr(0) & "4" & Abs(Gamer(0).LKey) & Abs(Gamer(0).RKey) & Abs(Gamer(0).UKey) & _
    '        '            Abs(Gamer(0).DKey) & Abs(Gamer(0).FKey) & Chr(1)
    '        '            If sock.State = sckConnected Then
    '        '                sock.SendData strPack
    '        '            End If
    '        '          If GetAsyncKeyState(LeftKey(0)) Then
    '        '            Tank(myTank).Move (3)
    '        '            GoTo metka5
    '        '          End If
    '        '          If GetAsyncKeyState(RightKey(0)) Then
    '        '            Tank(myTank).Move (1)
    '        '            GoTo metka5
    '        '          End If
    '        '          If GetAsyncKeyState(UpKey(0)) Then
    '        '            Tank(myTank).Move (0)
    '        '            GoTo metka5
    '        '          End If
    '        '          If GetAsyncKeyState(DownKey(0)) Then
    '        '            Tank(myTank).Move (2)
    '        '            GoTo metka5
    '        '          End If
    '        '          If GetAsyncKeyState(FireKey(0)) Then
    '        '            Tank(myTank).Fire
    '        '          End If
    'End Sub

    Private Sub FrmvsMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            If a1.IsAlive = True Then
                a1.Abort()
            End If
        Catch
        End Try
        End
    End Sub

    Private Sub FrmvsMain_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Grp = Me.CreateGraphics
        hDC2 = New HandleRef(Grp, Grp.GetHdc)
    End Sub

    Private Sub FrmvsMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If Running = True Then
            If LANgame And isHost = False Then
                Select Case e.KeyCode
                    Case UpKey(0)
                        Gamer(myTank).UKey = True
                    Case RightKey(0)
                        Gamer(myTank).RKey = True
                    Case DownKey(0)
                        Gamer(myTank).DKey = True
                    Case LeftKey(0)
                        Gamer(myTank).LKey = True
                    Case Firekey(0)
                        Gamer(myTank).FKey = True
                End Select
                If e.KeyCode = Keys.Escape Then
                    MenuStrip1.Visible = Not MenuStrip1.Visible
                End If
            Else
                If e.KeyCode = Keys.Escape Then
                    MenuStrip1.Visible = Not MenuStrip1.Visible
                End If
                For i = 0 To 3
                    Select Case e.KeyCode
                        Case UpKey(i)
                            Gamer(i).UKey = True
                        Case RightKey(i)
                            Gamer(i).RKey = True
                        Case DownKey(i)
                            Gamer(i).DKey = True
                        Case LeftKey(i)
                            Gamer(i).LKey = True
                        Case Firekey(i)
                            Gamer(i).FKey = True
                    End Select
                Next i
                Exit Sub
            End If
        End If
        If BTEditing = True Then
            Select Case e.KeyCode
                Case Keys.Q
                    CtrlEditor1.SelectItem(1)
                Case Keys.W
                    CtrlEditor1.SelectItem(2)
                Case Keys.E
                    CtrlEditor1.SelectItem(3)
                Case Keys.R
                    CtrlEditor1.SelectItem(4)
                Case Keys.T
                    CtrlEditor1.SelectItem(5)
                Case Keys.Y
                    CtrlEditor1.SelectItem(6)
                Case Keys.U
                    CtrlEditor1.SelectItem(7)
                Case Keys.Oemtilde
                    BackStyle = 0
                    CtrlEditor1.Changed(0, picX + ChangeX, picY + ChangeY)
                    Texture_Init(True)
                Case Keys.D1
                    BackStyle = 1
                    CtrlEditor1.Changed(1, picX + ChangeX, picY + ChangeY)
                    Texture_Init(True)
                Case Keys.D2
                    BackStyle = 2
                    CtrlEditor1.Changed(2, picX + ChangeX, picY + ChangeY)
                    Texture_Init(True)
                Case Keys.D3
                    BackStyle = 3
                    CtrlEditor1.Changed(3, picX + ChangeX, picY + ChangeY)
                    Texture_Init(True)
                Case Keys.D4
                    BackStyle = 4
                    CtrlEditor1.Changed(4, picX + ChangeX, picY + ChangeY)
                    Texture_Init(True)
                Case Keys.D5
                    BackStyle = 5
                    CtrlEditor1.Changed(5, picX + ChangeX, picY + ChangeY)
                    Texture_Init(True)
                Case Keys.D6
                    BackStyle = 6
                    CtrlEditor1.Changed(6, picX + ChangeX, picY + ChangeY)
                    Texture_Init(True)
                Case Keys.D7
                    BackStyle = 7
                    CtrlEditor1.Changed(7, picX + ChangeX, picY + ChangeY)
                    Texture_Init(True)
                Case Keys.D8
                    BackStyle = 8
                    CtrlEditor1.Changed(8, picX + ChangeX, picY + ChangeY)
                    Texture_Init(True)
                Case Keys.D9
                    BackStyle = 9
                    CtrlEditor1.Changed(9, picX + ChangeX, picY + ChangeY)
                    Texture_Init(True)
                Case Keys.D0
                    BackStyle = 10
                    CtrlEditor1.Changed(10, picX + ChangeX, picY + ChangeY)
                    Texture_Init(True)
                Case Keys.OemMinus
                    BackStyle = 11
                    CtrlEditor1.Changed(11, picX + ChangeX, picY + ChangeY)
                    Texture_Init(True)
                Case Keys.Oemplus
                    Try
                        Dim lolka As Integer
                        lolka = SprGLoad.Height
                        BackStyle = -1
                    Catch ex As Exception
                        BackStyle = 12
                    End Try
                    CtrlEditor1.Changed(-1, picX + ChangeX, picY + ChangeY)
                    Texture_Init(True)
                Case Keys.ControlKey
                    AltEditorView = True
            End Select
        End If
    End Sub

    Private Sub FrmvsMain_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If Running = True Then
            If LANgame And isHost = False Then
                Select Case e.KeyCode
                    Case UpKey(0)
                        Gamer(myTank).UKey = False
                    Case RightKey(0)
                        Gamer(myTank).RKey = False
                    Case DownKey(0)
                        Gamer(myTank).DKey = False
                    Case LeftKey(0)
                        Gamer(myTank).LKey = False
                    Case Firekey(0)
                        Gamer(myTank).FKey = False
                        Gamer(myTank).FBlocked = False
                End Select
            Else
                For i = 0 To 3
                    Select Case e.KeyCode
                        Case UpKey(i)
                            Gamer(i).UKey = False
                        Case RightKey(i)
                            Gamer(i).RKey = False
                        Case DownKey(i)
                            Gamer(i).DKey = False
                        Case LeftKey(i)
                            Gamer(i).LKey = False
                        Case Firekey(i)
                            Gamer(i).FKey = False
                            Gamer(i).FBlocked = False
                    End Select
                Next i
            End If
        End If
        If e.KeyCode = Keys.ControlKey And BTEditing = True Then
            AltEditorView = False
        End If
    End Sub

    Private Sub FrmvsMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Loading()
Beginning:
        'picRoad.Visible = False
        Me.ClientSize = New System.Drawing.Size(994, 706)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        Me.Text = "0"
        CtrlHello1.RefreshList()
        RunAudio(2)
        For i = 0 To AutosOnMap
            Track(i).DemolTrack()
        Next
        ''''''''''''''''''''''''''''''''''''''''''''RunAudio(Application.StartupPath & "\sounds\BackMelody2.mp3", 1)
        picRoad.Enabled = True
        Me.Refresh()
        CtrlHello1_ListBoxClick()
        picRoad.Enabled = True
        CtrlHello1.Visible = True
        CtrlHello1.Enabled = True
        CtrlColor1.Visible = True
        CtrlColor1.Enabled = True
        MenuStrip1.Visible = True
        picRoad.Visible = True
        Button1.Visible = True
        Timer3.Enabled = True
        MenuStrip1.Visible = True
        sprEndMenu = New Sprite(Application.StartupPath & "\Графика\EndingMenu.btj")
        '================= Main menu loop =======================================
        Do
            System.Threading.Thread.Sleep(80)
            Application.DoEvents()
            ChangedMapPreview()
            If LANgame And isHost Then
                ListBox1.Items.Clear()
                Dim enumerator As IDictionaryEnumerator = clientsList.GetEnumerator()
                While enumerator.MoveNext()
                    ListBox1.Items.Add(enumerator.Key)
                End While
                'Running = True
            End If
        Loop While Running = False And BTEditing = False
        If BTEditing = True Then GoTo BTEditor
        '=====================================================================
        picRoad.Enabled = False
        Me.Text = "0"
        GroupBox1.Visible = False
        Panel1.Visible = False
        CtrlHello1.Visible = False
        CtrlHello1.Enabled = False
        CtrlColor1.Visible = False
        CtrlColor1.Enabled = False
        MenuStrip1.Visible = False
        Button1.Select()
        Button1.Visible = False
        PathFile = CtrlHello1.MapPath
        ReadMapNew()
        Application.DoEvents()
        RunAudio(0)
        For i = 0 To 3
            '    ctrlHello1.SetControls(i, UpKey(i), RightKey(i), DownKey(i), LeftKey(i), Firekey(i), IsJoy(i))
        Next
        T1 = GetTickCount
        T3 = T1
        Starting = True
        PlayMusEff(13)
        For i = 0 To MaxBonuses
            Bonus(i).isOnField = False
        Next i
        GMode = CtrlHello1.GameMode
        FragLimit = CtrlHello1.GetFragLimit
        TimeLimit = CtrlHello1.GetTimeLimit
        miNutes = TimeLimit
        seConds = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.ClientSize = New System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        Me.Location = New System.Drawing.Point(0, 0)
        picRoad.Visible = False
        Me.Text = "0"
        Do While Starting = True
            T2 = GetTickCount
            DT = (T2 - T1)
            T1 = T2
            Application.DoEvents()
            SprBackBuffer.ClearBuffer(vbBlack)
            UpdateRoad()
            DrawRoad(0)
            DrawStart(DT)
            SprBackBuffer.PaintToDevice(hDC2)
        Loop
        'Me.Select()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = False
        RunAudio(1)
        Back_Draw(SprDynamicFrm)
        a1 = New System.Threading.Thread(AddressOf Render)
        'a1.Start()
        'GoTo labelSpeed
        'If chkFast.Value = 1 Then GoTo labelSpeed
        '============================== Game loop =================================================

        While Running
            Application.DoEvents()
            UpdateRoad()
            T1 = T2
            DrawRoad(DT)
            'System.Threading.Thread.Sleep(10)
            SprBackBuffer.PaintToDevice(hDC2)
            'sprtestBack = New Sprite(SprBackBuffer, , 320, 320)
            'sprtestBack.PaintToDevice(hDC)
            'SprDynamicFrm.PaintToDevice(hDC2)
            'SprFrm.PaintToDevice(hDC2)
            'Back_Draw(SprDynamicFrm)
            T2 = GetTickCount
            DT = (T2 - T1) / 500
            FPS = FPS + 1
        End While
        Timer1.Enabled = False
        Timer2.Enabled = False
        MenuStrip1.Visible = True
        RunAudio(0)
        Do While Ending = True
            'sprFinalMenu.ClearBuffer(vbWhite)
            'sprFinalMenu.Draw(SprMenu(0), 0, 0, Op.Paint)
            Application.DoEvents()
            DrawRoad(0)
            DrawEnd()
            'sprFinalMenu.PaintToDevice(hDC2)
            SprBackBuffer.PaintToDevice(hDC2)
        Loop
BTEditor:
        Timer3.Enabled = False
        Me.Text = "Вы редактируете карту " & CtrlHello1.ListBox1.SelectedItem.ToString
        For i = 0 To AutosOnMap
            Tank(i).isDead = False
        Next
        Do While BTEditing = True
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            DrawEditor()
            SprBackBuffer.PaintToDevice(hDC)
        Loop
        GoTo Beginning
    End Sub
    Private Sub Render()
        'Dim sprtestBack As Sprite
        Do While Running = True
            T1 = T2
            DrawRoad(DT)
            'System.Threading.Thread.Sleep(10)
            'Back_Draw(SprFrm)
            SprBackBuffer.PaintToDevice(hDC)
            'sprtestBack = New Sprite(SprBackBuffer, , 320, 320)
            'sprtestBack.PaintToDevice(hDC)
            'SprDynamicFrm.PaintToDevice(hDC)
            'SprFrm.PaintToDevice(hDC)
            FPS1 = FPS1 + 1
            T2 = GetTickCount
            DT = (T2 - T1) / 500
        Loop
        a1.Abort()
    End Sub
    Private Sub DrawEditor()
        If SimpleMap Then
            SprBackBuffer.TileDraw(sprTexture(0), 0, 0, MapSizeX * 40, MapSizeY * 40, -ChangeX, -ChangeY, Op.Paint)
            For m = 1 To ScoreWaterOnMap
                If Water(m).X - ChangeX > -40 And Water(m).Y - ChangeY > -40 _
                And Water(m).X - ChangeX < picRoad.Width + 40 And Water(m).Y - ChangeY < picRoad.Height + 40 Then
                    SprBackBuffer.Draw(sprTexture(2), Water(m).X - ChangeX, Water(m).Y - ChangeY, Op.AlphaBlend)
                End If
            Next m
            For m = 1 To ScoreSWaterOnMap
                If SWater(m).X - ChangeX > -40 And SWater(m).Y - ChangeY > -40 _
                And SWater(m).X - ChangeX < picRoad.Width + 40 And SWater(m).Y - ChangeY < picRoad.Height + 40 Then
                    SprBackBuffer.Draw(sprTexture(7), SWater(m).X - ChangeX, SWater(m).Y - ChangeY, Op.AlphaBlend)
                End If
            Next m
            For m = 1 To ScoreWallsOnMap
                If Wall(m).X - ChangeX > -40 And Wall(m).Y - ChangeY > -40 _
                And Wall(m).X - ChangeX < picRoad.Width + 40 And Wall(m).Y - ChangeY < picRoad.Height + 40 Then
                    SprBackBuffer.Draw(sprTexture(1), Wall(m).X - ChangeX, Wall(m).Y - ChangeY, Op.AlphaBlend)
                End If
            Next m
            For m = 1 To ScoreSWallsOnMap
                If SWall(m).X - ChangeX > -40 And SWall(m).Y - ChangeY > -40 _
                And SWall(m).X - ChangeX < picRoad.Width + 40 And SWall(m).Y - ChangeY < picRoad.Height + 40 Then
                    SprBackBuffer.Draw(sprTexture(6), SWall(m).X - ChangeX, SWall(m).Y - ChangeY, Op.AlphaBlend)
                End If
            Next m
        Else
            SprBackBuffer.Draw(sprBigTexture, -ChangeX, -ChangeY, Op.Paint)
            If AltEditorView = True Then
                SprBackBuffer.Draw(SprFrm, -ChangeX, -ChangeY, Op.Paint)
            End If
        End If
            For m = 0 To AutosOnMap
                'If Tank(m).isDead = False Then
                Tank(m).DrawA(0)
                'End If
            Next
            For m = 1 To ScoreBoxesOnMap
                WoodenBox(m).Draw(0, 15)
            Next m
            For m = 1 To ScoreBlocksOnMap
                Block(m).Draw()
            Next m
            'For i = 0 To MapSizeX - 1
            '    For p = 0 To MapSizeY - 1
            '        If i * 40 - ChangeX > -40 And p * 40 - ChangeY > -40 And i * 40 - ChangeX < picRoad.Width + 40 And p * 40 - ChangeY < picRoad.Height + 40 Then
            '            If p = 0 Or p = MapSizeY - 1 Or i = 0 Or i = MapSizeX - 1 Then
            '                SprBackBuffer.Draw(sprTexture(1), (i * 40) - ChangeX, (p * 40) - ChangeY, Op.AlphaBlend)
            '            End If
            '        End If
            '    Next
            'Next
            For m = 1 To ScoreBushesOnMap
                If Bush(m).X - ChangeX > -40 And Bush(m).Y - ChangeY > -40 _
                And Bush(m).X - ChangeX < picRoad.Width + 40 And Bush(m).Y - ChangeY < picRoad.Height + 40 Then
                    SprBackBuffer.Draw(sprTexture(5), Bush(m).X - ChangeX, Bush(m).Y - ChangeY, Op.AlphaBlend)
                End If
            Next m
            Select Case CtrlEditor1.Item
                Case 0
                    SprBackBuffer.Draw(sprTexture(1), picX, picY, Op.AlphaBlend)
                Case 1
                    SprBackBuffer.Draw(sprTexture(2), picX, picY, Op.AlphaBlend)
                Case 2
                    SprBackBuffer.Draw(sprTexture(3), picX, picY, Op.AlphaBlend)
                Case 3
                    SprBackBuffer.Draw(sprTexture(4), picX, picY, Op.AlphaBlend)
                Case 9
                    SprBackBuffer.Draw(sprTexture(5), picX, picY, Op.AlphaBlend)
                Case 10
                    SprBackBuffer.Draw(sprTexture(6), picX, picY, Op.AlphaBlend)
                Case 11
                    SprBackBuffer.Draw(sprTexture(7), picX, picY, Op.AlphaBlend)
                Case 4
                SprBackBuffer.ClearRect(picX, picX + 15, picY, picY + 15, ARGB(0, 128, 128, 128))
            Case 5
                If AutosOnMap < 4 Then
                    Anim_Tank(AutosOnMap + 1).DrawRot(SprBackBuffer, picX, picY, 0, 0)
                End If
            Case 6
                SprBackBuffer.ClearRect(picX - CtrlEditor1.TrackBar1.Value * 5, picX, picY - CtrlEditor1.TrackBar1.Value * 5, picY, ARGB(0, 0, 0, 255))
            Case 7
                SprBackBuffer.ClearRect(picX - CtrlEditor1.TrackBar1.Value * 5, picX, picY - CtrlEditor1.TrackBar1.Value * 5, picY, ARGB(0, 0, 255, 0))
            Case 8
                SprBackBuffer.ClearRect(picX - CtrlEditor1.TrackBar1.Value * 5, picX, picY - CtrlEditor1.TrackBar1.Value * 5, picY, ARGB(0, 0, 0, 0))
        End Select
    End Sub
    Private Sub DrawStart(DT As Double)
        Dim sprHelpStart As Sprite
        Static countFrame As Double, counter As Integer
        countFrame = countFrame + DT * 2
        If countFrame > SprBackBuffer.Height - 40 Then
            countFrame = 0
            counter = counter + 1
            If counter = 2 Then
                PlayMusEff(11)
            End If
            If counter = 1 Then
                PlayMusEff(12)
            End If
            If counter > 2 Then
                Starting = False
                counter = 0
                PlayMusEff(10)
                Exit Sub
            End If
        End If
        'sprFinalMenu.ClearBuffer(vbWhite)
        'sprFinalMenu.Draw(SprMenu(0), 0, 0, Op.Paint)
        'sprFinalMenu.PaintToDevice(hDC2)
        'SprBackBuffer.ClearBuffer(vbBlack)
        sprHelpStart = New Sprite(sprStart(counter), , SprBackBuffer.Width - countFrame * SprBackBuffer.Width / SprBackBuffer.Height, SprBackBuffer.Height - countFrame, ARGB(0, 255, 255, 255))
        SprBackBuffer.Draw(sprHelpStart, countFrame / 2 * SprBackBuffer.Width / SprBackBuffer.Height, countFrame / 2)
    End Sub

    Private Sub DrawEnd()
        sprEndMenu.Draw(sprWinner, 40, 110 + Winner * 50, Op.AlphaBlend)
        For i = 0 To AutosOnMap
            Anim_Tank(i).DrawRot(sprEndMenu, 80, 130 + i * 50, 0)
            sprEndMenu.Draw(MakeNumber(Tank(i).Kills), 140, 140 + i * 50, Op.Max)
            sprEndMenu.Draw(MakeNumber(Tank(i).Deaths), 195, 140 + i * 50, Op.Max)
        Next
        SprBackBuffer.Draw(sprEndMenu, SprBackBuffer.Width \ 2 - sprEndMenu.Width \ 2, SprBackBuffer.Height \ 2 - sprEndMenu.Height \ 2, Op.Paint)
    End Sub
    Private Sub DrawRoad(DT As Single)
            SprBackBuffer.Draw(sprBigTexture, -ChangeX, -ChangeY, Op.Paint)
            For i = 0 To AutosOnMap
                Track(i).DrawTrack()
            Next i
            For i = 0 To ShotLimit
                Shot(i).Draw(DT, 16)
            Next
            For m = 0 To AutosOnMap
                Tank(m).DrawA(DT)
            Next m
            For i = 1 To ScoreBoxesOnMap
                WoodenBox(i).Draw(DT, 15)
            Next i
            For i = 1 To ScoreBlocksOnMap
                If Block(i).X - ChangeX < -40 And Block(i).Y - ChangeY < -40 _
                    And Block(i).X - ChangeX > SprBackBuffer.Width + 40 And _
                    Block(i).Y - ChangeY > SprBackBuffer.Height + 40 Then Continue For
                Block(i).Draw()
            Next i
            For i = 0 To MaxBonuses - 1
                If Bonus(i).X - ChangeX < -40 And Bonus(i).Y - ChangeY < -40 _
                    And Bonus(i).X - ChangeX > SprBackBuffer.Width + 40 And _
                    Bonus(i).Y - ChangeY > SprBackBuffer.Height + 40 Then Continue For
                Bonus(i).Draw(DT)
            Next
            For m = 1 To ScoreBushesOnMap
                If Bush(m).X - ChangeX > -40 And Bush(m).Y - ChangeY > -40 _
                And Bush(m).X - ChangeX < SprBackBuffer.Width + 40 And Bush(m).Y - ChangeY < SprBackBuffer.Height + 40 Then
                    SprBackBuffer.Draw(sprTexture(5), Bush(m).X - ChangeX, Bush(m).Y - ChangeY, Op.AlphaBlend)
                End If
            Next m
            If Running Then
                For i = 0 To AutosOnMap
                    Tank(i).DrawDisplay()
                Next
            SprBackBuffer.Draw(MakeNumber(Me.Text), SprBackBuffer.Width / 2 - 20, 30, Op.AlphaBlend)
            End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Text = FPS
        'DShowUpdate()
        For i = 0 To MaxBonuses - 1
            Bonus(i).Update()
        Next i
        If LANgame = False Or (LANgame And isHost) Then
            For i = 1 To ScoreBlocksOnMap
                Block(i).Update()
            Next i
            For m = 0 To AutosOnMap
                If GMode = 0 Then
                    Tank(m).Update()
                ElseIf GMode = 1 And Tank(m).Deaths < FragLimit Then
                    Tank(m).Update()
                End If
            Next m

            '================================================
            If TimeLimit > 0 Then
                If seConds <= 0 Then
                    If miNutes = 0 Then
                        If GMode = 1 Then
                            If Tank(0).Deaths <= Tank(1).Deaths And Tank(0).Deaths <= Tank(2).Deaths And Tank(0).Deaths <= Tank(3).Deaths Then
                                Winner = 0 : Ending = True : Running = False
                            ElseIf Tank(1).Deaths <= Tank(0).Deaths And Tank(1).Deaths <= Tank(2).Deaths And Tank(1).Deaths <= Tank(3).Deaths Then
                                Winner = 1 : Ending = True : Running = False
                            ElseIf Tank(2).Deaths <= Tank(1).Deaths And Tank(2).Deaths <= Tank(0).Deaths And Tank(2).Deaths <= Tank(3).Deaths Then
                                Winner = 2 : Ending = True : Running = False
                            ElseIf Tank(3).Deaths <= Tank(1).Deaths And Tank(3).Deaths <= Tank(0).Deaths And Tank(3).Deaths <= Tank(2).Deaths Then
                                Winner = 3 : Ending = True : Running = False
                            End If
                        ElseIf GMode = 0 Then
                            If Tank(0).Kills >= Tank(1).Kills And Tank(0).Kills >= Tank(2).Kills And Tank(0).Kills >= Tank(3).Kills Then
                                Winner = 0 : Ending = True : Running = False
                            ElseIf Tank(1).Kills >= Tank(0).Kills And Tank(1).Kills >= Tank(2).Kills And Tank(1).Kills >= Tank(3).Kills Then
                                Winner = 1 : Ending = True : Running = False
                            ElseIf Tank(2).Kills >= Tank(1).Kills And Tank(2).Kills >= Tank(0).Kills And Tank(2).Kills >= Tank(3).Kills Then
                                Winner = 2 : Ending = True : Running = False
                            ElseIf Tank(3).Kills >= Tank(1).Kills And Tank(3).Kills >= Tank(0).Kills And Tank(3).Kills >= Tank(2).Kills Then
                                Winner = 3 : Ending = True : Running = False
                            End If
                        End If
                        Ending = True
                        Running = False
                        Exit Sub
                    End If
                    miNutes = miNutes - 1
                    seConds = 59
                Else
                    seConds = seConds - 1
                End If
            End If
            For m = 1 To ScoreBoxesOnMap
                WoodenBox(m).Update()
            Next m
        End If
        sprFinalMenu.ClearBuffer(vbWhite)
        sprFinalMenu.Draw(SprMenu(0), 0, 0, Op.Paint)
        For i = 0 To AutosOnMap
            Tank(i).DrawDisplay()
        Next
        sprFinalMenu.Draw(MakeNumber(FragLimit), 920, 5, Op.Add)
        sprFinalMenu.Draw(MakeNumber(miNutes), 20, 5, Op.Add)
        sprFinalMenu.Draw(MakeNumber(seConds), 50, 5, Op.Add)
        'sprFinalMenu.PaintToDevice(hDC2)
        FPS = 0
        FPS1 = 0
        '================================================
        'Timer1.Enabled = True
    End Sub


    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim i As Integer
        If LANgame Then
            If isHost Then
                ' SendHost()
            Else
                SendClient()
                For i = 0 To AutosOnMap
                    Tank(i).Move(Gamer(i).UKey, Gamer(i).DKey, Gamer(i).LKey, Gamer(i).RKey)
                    Track(i).TimeTrack()
                Next i
                'Gamer(myTank).FBlocked = True
                Exit Sub
            End If
        End If
        For i = 0 To AutosOnMap
            If Tank(i).isComp = True Then
                Tank(i).BTIntellect()
                Continue For
            End If
            If Gamer(i).FKey = True And Gamer(i).FBlocked = False Then
                Tank(i).Fire()
                Gamer(i).FBlocked = True
            End If
            Tank(i).Move(Gamer(i).UKey, Gamer(i).DKey, Gamer(i).LKey, Gamer(i).RKey)
        Next i
        For i = 0 To AutosOnMap
            Track(i).TimeTrack()
        Next i
        For i = 0 To ShotLimit
            Shot(i).Move()
        Next
        '========================================================================================
        If GMode = 0 And FragLimit > 0 Then
            If Tank(0).Kills >= FragLimit Or Tank(1).Kills >= FragLimit Or Tank(2).Kills >= FragLimit Or Tank(3).Kills >= FragLimit Then
                For i = 0 To AutosOnMap
                    If Tank(i).Kills >= FragLimit Then
                        Winner = i
                    End If
                Next
                Ending = True
                Running = False
                Exit Sub
            End If
        ElseIf GMode = 1 And FragLimit > 0 Then
            If AutosOnMap = 3 Then
                If Tank(0).Deaths >= FragLimit And Tank(1).Deaths >= FragLimit And Tank(2).Deaths >= FragLimit Then
                    Winner = 3 : Ending = True : Running = False : Exit Sub
                ElseIf Tank(3).Deaths >= FragLimit And Tank(1).Deaths >= FragLimit And Tank(2).Deaths >= FragLimit Then
                    Winner = 0 : Ending = True : Running = False : Exit Sub
                ElseIf Tank(0).Deaths >= FragLimit And Tank(3).Deaths >= FragLimit And Tank(2).Deaths >= FragLimit Then
                    Winner = 1 : Ending = True : Running = False : Exit Sub
                ElseIf (Tank(0).Deaths >= FragLimit And Tank(1).Deaths >= FragLimit And Tank(3).Deaths >= FragLimit) Then
                    Winner = 2 : Ending = True : Running = False : Exit Sub
                End If
            ElseIf AutosOnMap = 2 Then
                If (Tank(0).Deaths >= FragLimit And Tank(1).Deaths >= FragLimit) Then
                    Winner = 2 : Ending = True : Running = False : Exit Sub
                ElseIf (Tank(1).Deaths >= FragLimit And Tank(2).Deaths >= FragLimit) Then
                    Winner = 0 : Ending = True : Running = False : Exit Sub
                ElseIf (Tank(2).Deaths >= FragLimit And Tank(0).Deaths >= FragLimit) Then
                    Winner = 1 : Ending = True : Running = False : Exit Sub
                End If
            ElseIf AutosOnMap = 1 Then
                If Tank(0).Deaths >= FragLimit Then
                    Winner = 1 : Ending = True : Running = False : Exit Sub
                ElseIf Tank(1).Deaths >= FragLimit Then
                    Winner = 0 : Ending = True : Running = False : Exit Sub
                End If
            End If
        End If
        If LANgame Then
            If isHost Then
                SendHost()
            End If
        End If
    End Sub

    Private Sub CtrlHello1_ListBoxClick() Handles CtrlHello1.ListBoxClick
        PathFile = CtrlHello1.MapPath
        ReadMapNew()
        ChangedMapPreview()
    End Sub
    Private Sub ChangedMapPreview()
        CtrlHello1.UpdateInfo(AuthorName, BackStyle, (MapSizeX & "x" & MapSizeY), RespShields, BonusShields, _
                                MaxShots1, RespTime, MaxBonuses, MaxSpeed, RespSpeed, ShotSpeed, BonusRandom)
        DrawRoad(0)
        SprBackBuffer.PaintToDevice(hDC)
    End Sub
    Private Sub CtrlHello1_MouseDown(sender As Object, e As MouseEventArgs) Handles CtrlHello1.MouseDown

    End Sub
    Private Sub CtrlHello1_Start() Handles CtrlHello1.Start
        Running = True
    End Sub

    Private Sub picRoad_HandleCreated(sender As Object, e As EventArgs) Handles picRoad.HandleCreated
        Grp = picRoad.CreateGraphics
        hDC = New HandleRef(Grp, Grp.GetHdc)
    End Sub
    Private Sub picRoad_MouseMove(sender As Object, e As MouseEventArgs) Handles picRoad.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picX = picX - e.X
            ChangeX = ChangeX + picX
            picX = e.X
            If ChangeX < 0 Then ChangeX = 0
            If ChangeX > (MapSizeX - 16) * 40 Then ChangeX = (MapSizeX - 16) * 40
            picY = picY - e.Y
            ChangeY = ChangeY + picY
            picY = e.Y
            If ChangeY < 0 Then ChangeY = 0
            If ChangeY > (MapSizeY - 16) * 40 Then ChangeY = (MapSizeY - 16) * 40
            'UpdateRoad()
            If BTEditing = False Then
                DrawRoad(0)
                SprBackBuffer.PaintToDevice(hDC)
            End If
        End If
        If BTEditing = True Then
            CtrlEditor1.Enabled = False
            CtrlOption1.Enabled = False
            picY = e.Y
            picX = e.X
            CtrlEditor1.UpdateXY(picX + ChangeX, picY + ChangeY, ScoreWallsOnMap, ScoreWaterOnMap, ScoreBoxesOnMap, _
                                 ScoreBlocksOnMap, ScoreBushesOnMap, ScoreSWallsOnMap, ScoreSWaterOnMap)
        End If
    End Sub
    Private Sub ВыходToolStripMenuItem1_click() Handles ВыходToolStripMenuItem1.Click
        Try
            If a1.IsAlive = True Then
                a1.Abort()
            End If
        Catch
        End Try
        End
    End Sub

    Private Sub ЗвукToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ЗвукToolStripMenuItem1.Click
        If Sound = 1 Then
            Sound = 0
            ЗвукToolStripMenuItem1.ForeColor = Color.Black
        Else
            Sound = 1
            ЗвукToolStripMenuItem1.ForeColor = Color.Red
        End If
    End Sub

    Private Sub МузыкаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles МузыкаToolStripMenuItem.Click
        If BTMusic = True Then
            Back1.Pause()
            Back2.Pause()
            BTMusic = False
            МузыкаToolStripMenuItem.ForeColor = Color.Black
        Else
            BTMusic = True
            МузыкаToolStripMenuItem.ForeColor = Color.Red
            If Running = True Then Back1.Play()
            If Running = False Then Back2.Play()
        End If
    End Sub

    Private Sub Танк1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Танк1ToolStripMenuItem.Click
        If Tank(0).isComp = False Then
            Tank(0).isComp = True
            Танк1ToolStripMenuItem.Checked = True
        Else

            Tank(0).isComp = False
            Танк1ToolStripMenuItem.Checked = False
        End If
    End Sub
    Private Sub Танк2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Танк2ToolStripMenuItem.Click
        If Tank(1).isComp = False Then
            Tank(1).isComp = True
            Танк2ToolStripMenuItem.Checked = True
        Else

            Tank(1).isComp = False
            Танк2ToolStripMenuItem.Checked = False
        End If
    End Sub
    Private Sub Танк3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Танк3ToolStripMenuItem.Click
        If Tank(2).isComp = False Then
            Tank(2).isComp = True
            Танк3ToolStripMenuItem.Checked = True
        Else

            Tank(2).isComp = False
            Танк3ToolStripMenuItem.Checked = False
        End If
    End Sub
    Private Sub Танк4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Танк4ToolStripMenuItem.Click
        If Tank(3).isComp = False Then
            Tank(3).isComp = True
            Танк4ToolStripMenuItem.Checked = True
        Else

            Tank(3).isComp = False
            Танк4ToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub mnuMain_Click(sender As Object, e As EventArgs) Handles mnuMain.Click
        Running = False
        Ending = False
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        sprColor.ClearBuffer(vbWhite)
        Static CurFrameAuto As Double
        CurFrameAuto = CurFrameAuto + 1
        If CurFrameAuto > Anim_Tank(0).SprCnt Then
            CurFrameAuto = 0.2
        End If
        For i = 0 To 3
            If CtrlColor1.ChValue = i Then
                Anim_Tank(i).DrawRot(sprColor, 17, 5 + i * 64, CurFrameAuto, 0)
            Else
                Anim_Tank(i).DrawRot(sprColor, 17, 5 + i * 64, 0, 0)
            End If
        Next
        sprColor.PaintToDevice(CtrlColor1.hDC3)
    End Sub

    Private Sub CtrlColor1_ColorChanged() Handles CtrlColor1.ColorChanged
        Tank(CtrlColor1.ChValue).MyColor = CtrlColor1.Color
    End Sub

    Private Sub picRoad_MouseDown(sender As Object, e As MouseEventArgs) Handles picRoad.MouseDown
        Dim Colback1 As Long, Colback2 As Long, Colback3 As Long, Colback4 As Long, SGrey As Long = vbBlack
        picX = e.X
        picY = e.Y
        If BTEditing = False Then Exit Sub
        If e.Button = Windows.Forms.MouseButtons.Left Then MousePressed = True : EMapChanged = True
        Do While MousePressed = True
            DrawEditor()
            Back_Draw(SprDynamicFrm)
            SprBackBuffer.PaintToDevice(hDC)
            Application.DoEvents()
            CtrlEditor1.UpdateXY(picX + ChangeX, picY + ChangeY, ScoreWallsOnMap, ScoreWaterOnMap, ScoreBoxesOnMap, _
                                 ScoreBlocksOnMap, ScoreBushesOnMap, ScoreSWallsOnMap, ScoreSWaterOnMap)
            If picX < 0 Or picY < 0 Or picX > MapSizeX * 40 Or picY > MapSizeY * 40 Then Continue Do
            Select Case CtrlEditor1.Item
                Case 6
                    SprFrm.ClearRect(picX - CtrlEditor1.TrackBar1.Value * 5, picX, picY - CtrlEditor1.TrackBar1.Value * 5, picY, ARGB(0, 0, 0, 255))
                Case 7
                    SprFrm.ClearRect(picX - CtrlEditor1.TrackBar1.Value * 5, picX, picY - CtrlEditor1.TrackBar1.Value * 5, picY, ARGB(0, 0, 255, 0))
                Case 8
                    SprFrm.ClearRect(picX - CtrlEditor1.TrackBar1.Value * 5, picX, picY - CtrlEditor1.TrackBar1.Value * 5, picY, ARGB(0, 0, 0, 0))
            End Select
            'If picX <= 40 Or picX > 600 Or picY <= 40 Or picY > 600 Then GoTo metka  
            If CtrlEditor1.CurAlign.Checked = True Then
                Colback1 = SprDynamicFrm.GetPixel((picX - 1 + ChangeX), (picY - 1 + ChangeY))
                If Colback1 <> vbBlack Then GoTo metka11
            Else
                Colback1 = SprDynamicFrm.GetPixel((picX + ChangeX), (picY + ChangeY))
                Colback2 = SprDynamicFrm.GetPixel((picX + 39 + ChangeX), (picY + 39 + ChangeY))
                Colback3 = SprDynamicFrm.GetPixel((picX + 39 + ChangeX), (picY + ChangeY))
                Colback4 = SprDynamicFrm.GetPixel((picX + ChangeX), (picY + 39 + ChangeY))
                If Colback1 <> vbBlack Or Colback2 <> vbBlack Or Colback3 <> vbBlack Or Colback4 <> vbBlack Then GoTo metka11
            End If
            '============================ Âîäè÷êà
            Select Case CtrlEditor1.Item
                Case 1
                    If SimpleMap = False Then Exit Sub
                    ScoreWaterOnMap = ScoreWaterOnMap + 1
                    'Water(ScoreWaterOnMap).ObjType = 1
                    Water(ScoreWaterOnMap).X = picX + ChangeX
                    Water(ScoreWaterOnMap).Y = picY + ChangeY
                    If CtrlEditor1.CurAlign.Checked = True Then
                        For i = 0 To MapSizeX - 1
                            If Water(ScoreWaterOnMap).X >= 40 * i And Water(ScoreWaterOnMap).X <= 40 + 40 * i Then
                                For p = 0 To MapSizeY - 1
                                    If Water(ScoreWaterOnMap).Y >= 40 * p And Water(ScoreWaterOnMap).Y <= 40 + 40 * p Then
                                        Water(ScoreWaterOnMap).X = 40 * i
                                        Water(ScoreWaterOnMap).Y = 40 * p
                                    End If
                                Next
                            End If
                        Next
                    End If
                Case 11
                    If SimpleMap = False Then Exit Sub
                    ScoreSWaterOnMap = ScoreSWaterOnMap + 1
                    'Water(ScoreWaterOnMap).ObjType = 1
                    SWater(ScoreSWaterOnMap).X = picX + ChangeX
                    SWater(ScoreSWaterOnMap).Y = picY + ChangeY
                    If CtrlEditor1.CurAlign.Checked = True Then
                        For i = 0 To (MapSizeX - 1) * 2 + 1
                            If SWater(ScoreSWaterOnMap).X >= 20 * i And SWater(ScoreSWaterOnMap).X <= 20 + 20 * i Then
                                For p = 0 To (MapSizeY - 1) * 2 + 1
                                    If SWater(ScoreSWaterOnMap).Y >= 20 * p And SWater(ScoreSWaterOnMap).Y <= 20 + 20 * p Then
                                        SWater(ScoreSWaterOnMap).X = 20 * i
                                        SWater(ScoreSWaterOnMap).Y = 20 * p
                                    End If
                                Next
                            End If
                        Next
                    End If
                    '============================ Êîðîáêè
                Case 2
                    ScoreBoxesOnMap = ScoreBoxesOnMap + 1
                    WoodenBox(ScoreBoxesOnMap) = New clsBox
                    WoodenBox(ScoreBoxesOnMap).isOnField = True
                    WoodenBox(ScoreBoxesOnMap).X = picX + ChangeX
                    WoodenBox(ScoreBoxesOnMap).Y = picY + ChangeY
                    If CtrlEditor1.CurAlign.Checked = True Then
                        For i = 0 To MapSizeX - 1
                            If WoodenBox(ScoreBoxesOnMap).X >= 40 * i And WoodenBox(ScoreBoxesOnMap).X <= 40 + 40 * i Then
                                For p = 0 To MapSizeY - 1
                                    If WoodenBox(ScoreBoxesOnMap).Y >= 40 * p And WoodenBox(ScoreBoxesOnMap).Y <= 40 + 40 * p Then
                                        WoodenBox(ScoreBoxesOnMap).X = 40 * i
                                        WoodenBox(ScoreBoxesOnMap).Y = 40 * p
                                    End If
                                Next
                            End If
                        Next
                    End If
                    '============================ Ñòåíêè
                Case 0
                    If SimpleMap = False Then Exit Sub
                    ScoreWallsOnMap = ScoreWallsOnMap + 1
                    Wall(ScoreWallsOnMap).X = picX + ChangeX
                    Wall(ScoreWallsOnMap).Y = picY + ChangeY
                    If CtrlEditor1.CurAlign.Checked = True Then
                        For i = 0 To MapSizeX - 1
                            If Wall(ScoreWallsOnMap).X >= 40 * i And Wall(ScoreWallsOnMap).X <= 40 + 40 * i Then
                                For p = 0 To MapSizeY - 1
                                    If Wall(ScoreWallsOnMap).Y >= 40 * p And Wall(ScoreWallsOnMap).Y <= 40 + 40 * p Then
                                        Wall(ScoreWallsOnMap).X = 40 * i
                                        Wall(ScoreWallsOnMap).Y = 40 * p
                                    End If
                                Next
                            End If
                        Next
                    End If
                Case 10
                    If SimpleMap = False Then Exit Sub
                    ScoreSWallsOnMap = ScoreSWallsOnMap + 1
                    SWall(ScoreSWallsOnMap).X = picX + ChangeX
                    SWall(ScoreSWallsOnMap).Y = picY + ChangeY
                    If CtrlEditor1.CurAlign.Checked = True Then
                        For i = 0 To (MapSizeX - 1) * 2 + 1
                            If SWall(ScoreSWallsOnMap).X >= 20 * i And SWall(ScoreSWallsOnMap).X <= 20 + 20 * i Then
                                For p = 0 To (MapSizeY - 1) * 2 + 1
                                    If SWall(ScoreSWallsOnMap).Y >= 20 * p And SWall(ScoreSWallsOnMap).Y <= 20 + 20 * p Then
                                        SWall(ScoreSWallsOnMap).X = 20 * i
                                        SWall(ScoreSWallsOnMap).Y = 20 * p
                                    End If
                                Next
                            End If
                        Next
                    End If
                    '============================ Áëîêè
                Case 3
                    ScoreBlocksOnMap = ScoreBlocksOnMap + 1
                    Block(ScoreBlocksOnMap) = New clsBlock
                    Block(ScoreBlocksOnMap).X = picX + ChangeX
                    Block(ScoreBlocksOnMap).Y = picY + ChangeY
                    If CtrlEditor1.CurAlign.Checked = True Then
                        For i = 0 To MapSizeX - 1
                            If Block(ScoreBlocksOnMap).X >= 40 * i And Block(ScoreBlocksOnMap).X <= 40 + 40 * i Then
                                For p = 0 To MapSizeY - 1
                                    If Block(ScoreBlocksOnMap).Y >= 40 * p And Block(ScoreBlocksOnMap).Y <= 40 + 40 * p Then
                                        Block(ScoreBlocksOnMap).X = 40 * i
                                        Block(ScoreBlocksOnMap).Y = 40 * p
                                    End If
                                Next
                            End If
                        Next
                    End If
                    '============================ Òàíêè
                Case 5
                    If AutosOnMap < 3 Then
                        AutosOnMap = AutosOnMap + 1
                    End If
                    'Tank(AutosOnMap).isDead = False
                    Tank(AutosOnMap).X = picX + ChangeX
                    Tank(AutosOnMap).Y = picY + ChangeY
                    Tank(AutosOnMap).Angle = 0
                    If CtrlEditor1.CurAlign.Checked = True Then
                        For i = 0 To MapSizeX - 1
                            If Tank(AutosOnMap).X >= 40 * i And Tank(AutosOnMap).X <= 40 + 40 * i Then
                                For p = 0 To MapSizeY - 1
                                    If Tank(AutosOnMap).Y >= 40 * p And Tank(AutosOnMap).Y <= 40 + 40 * p Then
                                        Tank(AutosOnMap).X = 40 * i
                                        Tank(AutosOnMap).Y = 40 * p
                                    End If
                                Next
                            End If
                        Next
                    End If
                    '======================== ðåçèíêà
            End Select
metka11:
            If CtrlEditor1.Item = 9 Then
                If Colback1 <> RGB(128, 128, 128) And Colback2 <> RGB(128, 128, 128) And Colback3 <> RGB(128, 128, 128) And Colback4 <> RGB(128, 128, 128) Then
                    ScoreBushesOnMap = ScoreBushesOnMap + 1
                    Bush(ScoreBushesOnMap).X = picX + ChangeX
                    Bush(ScoreBushesOnMap).Y = picY + ChangeY
                    If CtrlEditor1.CurAlign.Checked = True Then
                        For i = 0 To MapSizeX - 1
                            If Bush(ScoreBushesOnMap).X >= 40 * i And Bush(ScoreBushesOnMap).X <= 40 + 40 * i Then
                                For p = 0 To MapSizeY - 1
                                    If Bush(ScoreBushesOnMap).Y >= 40 * p And Bush(ScoreBushesOnMap).Y <= 40 + 40 * p Then
                                        Bush(ScoreBushesOnMap).X = 40 * i
                                        Bush(ScoreBushesOnMap).Y = 40 * p
                                    End If
                                Next
                            End If
                        Next
                    End If
                End If
            End If
            If CtrlEditor1.Item = 4 Then
                If Colback1 = vbBlue Then
                    For i = 1 To ScoreWaterOnMap
                        If picX >= Water(i).X + 1 - ChangeX And picX <= Water(i).X + 39 - ChangeX Then
                            If picY >= Water(i).Y + 1 - ChangeY And picY <= Water(i).Y + 39 - ChangeY Then
                                Water(i).X = Water(ScoreWaterOnMap).X
                                Water(i).Y = Water(ScoreWaterOnMap).Y
                                ScoreWaterOnMap = ScoreWaterOnMap - 1
                            End If
                        End If
                    Next i
                End If
                If Colback1 = ARGB(0, 0, 1, 255) Then
                    For i = 1 To ScoreSWaterOnMap
                        If picX >= SWater(i).X + 1 - ChangeX And picX <= SWater(i).X + 19 - ChangeX Then
                            If picY >= SWater(i).Y + 1 - ChangeY And picY <= SWater(i).Y + 19 - ChangeY Then
                                SWater(i).X = SWater(ScoreSWaterOnMap).X
                                SWater(i).Y = SWater(ScoreSWaterOnMap).Y
                                ScoreSWaterOnMap = ScoreSWaterOnMap - 1
                            End If
                        End If
                    Next i
                End If
                If Colback1 = vbGreen Then
                    For i = 1 To ScoreWallsOnMap
                        If picX >= Wall(i).X + 1 - ChangeX And picX <= Wall(i).X + 39 - ChangeX Then
                            If picY >= Wall(i).Y + 1 - ChangeY And picY <= Wall(i).Y + 39 - ChangeY Then
                                Wall(i).X = Wall(ScoreWallsOnMap).X
                                Wall(i).Y = Wall(ScoreWallsOnMap).Y
                                ScoreWallsOnMap = ScoreWallsOnMap - 1
                            End If
                        End If
                    Next i
                End If
                If Colback1 = ARGB(0, 0, 255, 1) Then
                    For i = 1 To ScoreSWallsOnMap
                        If picX >= SWall(i).X + 1 - ChangeX And picX <= SWall(i).X + 19 - ChangeX Then
                            If picY >= SWall(i).Y + 1 - ChangeY And picY <= SWall(i).Y + 19 - ChangeY Then
                                SWall(i).X = SWall(ScoreSWallsOnMap).X
                                SWall(i).Y = SWall(ScoreSWallsOnMap).Y
                                ScoreSWallsOnMap = ScoreSWallsOnMap - 1
                            End If
                        End If
                    Next i
                End If
                If Colback1 = RGB(128, 128, 128) Then
                    For i = 1 To ScoreBushesOnMap
                        If picX >= Bush(i).X + 1 - ChangeX And picX <= Bush(i).X + 39 - ChangeX Then
                            If picY >= Bush(i).Y + 1 - ChangeY And picY <= Bush(i).Y + 39 - ChangeY Then
                                Bush(i).X = Bush(ScoreBushesOnMap).X
                                Bush(i).Y = Bush(ScoreBushesOnMap).Y
                                ScoreBushesOnMap = ScoreBushesOnMap - 1
                            End If
                        End If
                    Next i
                End If
                If Colback1 = vbMagenta Then
                    For i = 1 To ScoreBlocksOnMap
                        If picX >= Block(i).X + 1 - ChangeX And picX <= Block(i).X + 39 - ChangeX Then
                            If picY >= Block(i).Y + 1 - ChangeY And picY <= Block(i).Y + 39 - ChangeY Then
                                Block(i).X = Block(ScoreBlocksOnMap).X
                                Block(i).Y = Block(ScoreBlocksOnMap).Y
                                ScoreBlocksOnMap = ScoreBlocksOnMap - 1
                            End If
                        End If
                    Next i
                End If
                If Colback1 = ARGB(0, 255, 255, 0) Then
                    For i = 1 To ScoreBoxesOnMap
                        If picX >= WoodenBox(i).X + 1 - ChangeX And picX <= WoodenBox(i).X + 39 - ChangeX Then
                            If picY >= WoodenBox(i).Y + 1 - ChangeY And picY <= WoodenBox(i).Y + 39 - ChangeY Then
                                WoodenBox(i).X = WoodenBox(ScoreBoxesOnMap).X
                                WoodenBox(i).Y = WoodenBox(ScoreBoxesOnMap).Y
                                WoodenBox(ScoreBoxesOnMap).isOnField = False
                                ScoreBoxesOnMap = ScoreBoxesOnMap - 1
                            End If
                        End If
                    Next i
                End If
                For i = 0 To AutosOnMap
                    If Colback1 = ARGB(0, 255, 0, i) Then
                        Tank(i).X = Tank(AutosOnMap).X
                        Tank(i).Y = Tank(AutosOnMap).Y
                        AutosOnMap = AutosOnMap - 1
                        'Tank(i).isDead = True
                    End If
                Next
            End If
            System.Threading.Thread.Sleep(20)
            Application.DoEvents()
        Loop
    End Sub

    Private Sub РедакторToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles РедакторToolStripMenuItem.Click
        If Running = True Or Ending = True Then Exit Sub
        ЗвукToolStripMenuItem1.Visible = False
        ВыходToolStripMenuItem1.Visible = False
        РедакторToolStripMenuItem.Visible = False
        ИИТанкиToolStripMenuItem.Visible = False
        mnuMain.Visible = False
        ФайлToolStripMenuItem.Visible = True
        ВаТанчикиToolStripMenuItem.Visible = True
        ЗагрузитьТекстуруToolStripMenuItem.Visible = True
        МакросыToolStripMenuItem.Visible = True
        CtrlOption1.Visible = True
        CtrlHello1.Visible = False
        CtrlColor1.Visible = False
        Button1.Visible = False
        CtrlEditor1.Visible = True
        'CtrlOption1.Reset()
        BTEditing = True
        Back_Init()
        'WriteMapNew()
    End Sub

    Private Sub ВаТанчикиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВаТанчикиToolStripMenuItem.Click
        If EMapChanged Then
            If MsgBox("При выходе из редактора все несохраненные данные будут потеряны. Продолжить?", vbOKCancel) = MsgBoxResult.Cancel Then Exit Sub
        End If
        ЗвукToolStripMenuItem1.Visible = True
        ВыходToolStripMenuItem1.Visible = True
        РедакторToolStripMenuItem.Visible = True
        ИИТанкиToolStripMenuItem.Visible = True
        mnuMain.Visible = True
        ВаТанчикиToolStripMenuItem.Visible = False
        ЗагрузитьТекстуруToolStripMenuItem.Visible = False
        ФайлToolStripMenuItem.Visible = False
        МакросыToolStripMenuItem.Visible = False
        CtrlOption1.Visible = False
        CtrlHello1.Visible = True
        CtrlColor1.Visible = True
        Button1.Visible = True
        CtrlEditor1.Visible = False
        BTEditing = False
    End Sub

    Private Sub picRoad_MouseUp(sender As Object, e As MouseEventArgs) Handles picRoad.MouseUp
        MousePressed = False
    End Sub


    Private Sub CtrlEditor1_BackStyleChanged() Handles CtrlEditor1.BackStyleChanged
        BackStyle = CtrlEditor1.Backstyle
        Texture_Init(True)
    End Sub

    Private Sub ЗагрузитьТекстуруToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЗагрузитьТекстуруToolStripMenuItem.Click
        OD1.Title = "Загрузить текстуру"
        OD1.Filter = "PNG-изображения|*.png|Все файлы|*.*"
        LoadTextureToEditor()
    End Sub

    Private Sub СохранитьКакToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СохранитьКакToolStripMenuItem.Click
        SD1.InitialDirectory = Application.StartupPath & "\Карты"
        If SD1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        getOptions()
        WriteMapNew()
        Dim teststring As String
        teststring = Mid(StrReverse(SD1.FileName), 5)
        teststring = Mid(teststring, 1, InStr(teststring, "\") - 1)
        Me.Text = "Вы редактируете карту " & StrReverse(teststring)
        EMapChanged = False
    End Sub

    Private Sub ОткрітьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОткрітьToolStripMenuItem.Click
        If EMapChanged Then
            If MsgBox("Все несохраненные данные будут потеряны. Продолжить?", vbOKCancel) = MsgBoxResult.Cancel Then Exit Sub
        End If
        OD1.Title = "Открыть карту"
        OD1.Filter = "Карта BaTanks|*.btm"
        If OD1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        PathFile = OD1.FileName
        ReadMapNew()
        Me.Text = "Вы редактируете карту " & Mid(OD1.SafeFileName, 1, Len(OD1.SafeFileName) - 4)
        EMapChanged = False
    End Sub

    Private Sub НоваяToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles НоваяToolStripMenuItem.Click
        If EMapChanged Then
            If MsgBox("Все несохраненные данные будут потеряны. Продолжить?", vbOKCancel) = MsgBoxResult.Cancel Then Exit Sub
        End If
        SimpleMap = True
        MapSizeX = 16
        MapSizeY = 16
        ChangeX = 0
        ChangeY = 0
        AutosOnMap = -1
        ScoreBlocksOnMap = 0
        ScoreBoxesOnMap = 0
        ScoreBushesOnMap = 0
        ScoreWallsOnMap = 0
        ScoreWaterOnMap = 0
        ScoreSWallsOnMap = 0
        ScoreSWaterOnMap = 0
        CtrlOption1.Reset()
        CtrlEditor1.UpdateXY(0, 0, 0, 0, 0, 0, 0, 0, 0)
        CtrlEditor1.Changed(0, 16, 16)
        Me.Text = "Вы редактируете новую карту"
        Back_Init()
        EMapChanged = False
    End Sub
    Public Sub getOptions()
        AuthorName = CtrlOption1.TextBox1.Text
        RespTime = CtrlOption1.ComboBox1.Text
        RBoxTimer = CtrlOption1.ComboBox2.Text
        BonusLife = CtrlOption1.ComboBox3.Text
        BlockLife = CtrlOption1.ComboBox4.Text
        RespSpeed = CtrlOption1.ComboBox5.Text
        MaxSpeed = CtrlOption1.ComboBox6.Text
        ShotSpeed = CtrlOption1.ComboBox7.Text
        MaxShots1 = CtrlOption1.ComboBox8.Text
        BonusRandom = CtrlOption1.ComboBox9.Text
        ChanceShot = CtrlOption1.ComboBox10.Text
        ChanceShield = CtrlOption1.ComboBox11.Text
        ChanceSpeed = CtrlOption1.ComboBox12.Text
        ChanceEdges = CtrlOption1.ComboBox13.Text
        MaxBonuses = CtrlOption1.ComboBox14.Text
        RespShields = CtrlOption1.ComboBox15.Text
        BonusShields = CtrlOption1.ComboBox16.Text
    End Sub
    Public Sub setOptions()
        CtrlOption1.TextBox1.Text = AuthorName
        CtrlOption1.ComboBox1.Text = RespTime
        CtrlOption1.ComboBox2.Text = RBoxTimer
        CtrlOption1.ComboBox3.Text = BonusLife
        CtrlOption1.ComboBox4.Text = BlockLife
        CtrlOption1.ComboBox5.Text = RespSpeed
        CtrlOption1.ComboBox6.Text = MaxSpeed
        CtrlOption1.ComboBox7.Text = ShotSpeed
        CtrlOption1.ComboBox8.Text = MaxShots1
        CtrlOption1.ComboBox9.Text = BonusRandom
        CtrlOption1.ComboBox10.Text = ChanceShot
        CtrlOption1.ComboBox11.Text = ChanceShield
        CtrlOption1.ComboBox12.Text = ChanceSpeed
        CtrlOption1.ComboBox13.Text = ChanceEdges
        CtrlOption1.ComboBox14.Text = MaxBonuses
        CtrlOption1.ComboBox15.Text = RespShields
        CtrlOption1.ComboBox16.Text = BonusShields
    End Sub

    Private Sub CtrlEditor1_MapSizeChangedX(sx As Integer) Handles CtrlEditor1.MapSizeChangedX
        If sx > 0 Then MapSizeX = sx
        Back_Init()
    End Sub

    Private Sub CtrlEditor1_MapSizeChangedY(sy As Integer) Handles CtrlEditor1.MapSizeChangedY
        If sy > 0 Then MapSizeY = sy
        Back_Init()
    End Sub

    Private Sub РамкаИзСтенокToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles РамкаИзСтенокToolStripMenuItem.CheckedChanged
        If РамкаИзСтенокToolStripMenuItem.Checked = True Then
            For i = 0 To MapSizeX - 1
                For p = 0 To MapSizeY - 1
                    If p = 0 Or p = MapSizeY - 1 Or i = 0 Or i = MapSizeX - 1 Then
                        If SprFrm.GetPixel((i * 40) + 20, (p * 40) + 20) = vbBlack Then
                            ScoreWallsOnMap = ScoreWallsOnMap + 1
                            Wall(ScoreWallsOnMap).X = 40 * i
                            Wall(ScoreWallsOnMap).Y = 40 * p
                        End If
                    End If
                Next
            Next
        Else
            For i = 0 To MapSizeX - 1
                For p = 0 To MapSizeY - 1
                    If p = 0 Or p = MapSizeY - 1 Or i = 0 Or i = MapSizeX - 1 Then
                            For m = 1 To ScoreWallsOnMap
                            If i * 40 = Wall(m).X And p * 40 = Wall(m).Y Then
                                Wall(m).X = Wall(ScoreWallsOnMap).X
                                Wall(m).Y = Wall(ScoreWallsOnMap).Y
                                ScoreWallsOnMap = ScoreWallsOnMap - 1
                            End If
                            Next m
                    End If
                Next p
            Next i
        End If
        Back_Init()
    End Sub

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    Private Sub FrmvsMain_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If BTEditing Then
            CtrlEditor1.Enabled = True
            CtrlOption1.Enabled = True
        End If
    End Sub

    Private Sub СохранітьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СохранітьToolStripMenuItem.Click
        If Me.Text Like "*новую карту*" Then СохранитьКакToolStripMenuItem_Click(sender, e) : Exit Sub
        SD1.FileName = Application.StartupPath & "\Карты\" & Mid(Me.Text, 23) & ".btm"
        getOptions()
        WriteMapNew()
        EMapChanged = False
    End Sub

    Private Sub СложнаяToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СложнаяToolStripMenuItem.Click
        If OD1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sprBigTexture = New Sprite(OD1.FileName)
        SimpleMap = False
    End Sub

    Private Sub СвернутьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СвернутьToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Running = True
        If LANgame And isHost Then
            myTank = 0
            SendStart()
        End If

        'Button1.Enabled = False
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        FrmvsMain_KeyDown(sender, e)
    End Sub

    Private Sub Button1_KeyUp(sender As Object, e As KeyEventArgs) Handles Button1.KeyUp
        FrmvsMain_KeyUp(sender, e)
    End Sub

    Private Sub СоздатьИгруToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СоздатьИгруToolStripMenuItem.Click
        GroupBox1.Visible = True
        ListBox1.Items.Add("LOL")
        Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf ServerMain)
        ctThread.Start()
    End Sub

    Private Sub ПодключитьсяToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПодключитьсяToolStripMenuItem.Click
        Panel1.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel1.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Connect_Clicked()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SendMap()
    End Sub
End Class
