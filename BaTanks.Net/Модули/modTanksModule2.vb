Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Net.NetworkInformation

Module modTanksModule2
    Dim arg1 As String, arg2 As String, _
        arg3 As String
    Public SprGLoad As Sprite
    Private SprHelpObject As Sprite, SprGRoad As Sprite, massPict() As Byte, sprObject(0 To 4) As Sprite
    Public Sub ReadMapNew()
        Dim FILL As Integer, TileLength As Integer, BackLength As Integer, Tile() As Byte, Back() As Byte
        'For m = 0 To 3
        'Tank(m).isDead = True
        'Next
        FrmvsMain.CtrlOption1.Reset()
        'FrmvsMain.getOptions()
        AutosOnMap = -1
        ChangeX = 0
        ChangeY = 0
        ScoreBoxesOnMap = 0
        ScoreWallsOnMap = 0
        ScoreSWallsOnMap = 0
        ScoreWaterOnMap = 0
        ScoreSWaterOnMap = 0
        ScoreBlocksOnMap = 0
        ScoreBushesOnMap = 0
        SimpleMap = True
        'For i = 0 To AutosOnMap
        'Tank(i) = New clsTank
        'Track(i) = New clsTrack
        'Tank(i).isshooting = False
        ' Next
        Try
            Using sr As StreamReader = New StreamReader(PathFile)
                Dim line As String
                Do
                    line = sr.ReadLine()
                    arg1 = Mid(line, 1, InStr(line, " ") - 1)
                    line = Trim(Mid(line, InStr(line, " ")))
                    arg2 = Mid(line, 1, InStr(line, " ") - 1)
                    arg3 = Mid(line, InStr(line, " "))
                    Select Case Trim(LCase(arg1))
                        Case "mapsize"
                            MapSizeX = Trim(arg2)
                            MapSizeY = Trim(arg3)
                        Case "btmap"
                            AuthorName = Trim(arg3)
                        Case "bteditorversion"
                        Case "simplemap"
                            SimpleMap = CBool(Trim(arg3))
                            'MapV = Trim(arg3)
                        Case "maxshots"
                            MaxShots1 = Trim(arg3)
                        Case "backstyle"
                            BackStyle = Trim(arg3)
                        Case "respshields"
                            RespShields = Trim(arg3)
                        Case "bonusshields"
                            BonusShields = Trim(arg3)
                        Case "respspeed"
                            RespSpeed = Trim(arg3)
                        Case "maxspeed"
                            MaxSpeed = Trim(arg3)
                        Case "maxbonuses"
                            MaxBonuses = Trim(arg3)
                        Case "bonusrandom"
                            BonusRandom = Trim(arg3)
                        Case "resptime"
                            RespTime = Trim(arg3)
                        Case "shotspeed"
                            ShotSpeed = Trim(arg3)
                        Case "bonuslife"
                            BonusLife = Trim(arg3)
                        Case "chanceshot"
                            ChanceShot = Trim(arg3)
                        Case "chanceshield"
                            ChanceShield = Trim(arg3)
                        Case "chancespeed"
                            ChanceSpeed = Trim(arg3)
                        Case "chanceedges"
                            ChanceEdges = Trim(arg3)
                        Case "tank"
                            AutosOnMap = AutosOnMap + 1
                            Select Case AutosOnMap
                                Case 0
                                    Tank(AutosOnMap).isComp = FrmvsMain.Танк1ToolStripMenuItem.Checked
                                Case 1
                                    Tank(AutosOnMap).isComp = FrmvsMain.Танк2ToolStripMenuItem.Checked
                                Case 2
                                    Tank(AutosOnMap).isComp = FrmvsMain.Танк3ToolStripMenuItem.Checked
                                Case 3
                                    Tank(AutosOnMap).isComp = FrmvsMain.Танк4ToolStripMenuItem.Checked
                            End Select
                            Tank(AutosOnMap).InitA(Int(arg2), Int(arg3), (AutosOnMap))
                            Track(AutosOnMap).InitTrack(AutosOnMap)
                        Case "b"
                            ScoreBoxesOnMap = ScoreBoxesOnMap + 1
                            WoodenBox(ScoreBoxesOnMap) = New clsBox
                            WoodenBox(ScoreBoxesOnMap).X = Int(arg2)
                            WoodenBox(ScoreBoxesOnMap).Y = Int(arg3)
                        Case "bl"
                            ScoreBlocksOnMap = ScoreBlocksOnMap + 1
                            Block(ScoreBlocksOnMap) = New clsBlock
                            Block(ScoreBlocksOnMap).Init(Int(arg2), Int(arg3), 40, 40)
                        Case "w"
                            ScoreWaterOnMap = ScoreWaterOnMap + 1
                            Water(ScoreWaterOnMap).X = Int(arg2)
                            Water(ScoreWaterOnMap).Y = Int(arg3)
                        Case "sw"
                            ScoreSWaterOnMap = ScoreSWaterOnMap + 1
                            SWater(ScoreSWaterOnMap).X = Int(arg2)
                            SWater(ScoreSWaterOnMap).Y = Int(arg3)
                        Case "wl"
                            ScoreWallsOnMap = ScoreWallsOnMap + 1
                            Wall(ScoreWallsOnMap).X = Int(arg2)
                            Wall(ScoreWallsOnMap).Y = Int(arg3)
                        Case "swl"
                            ScoreSWallsOnMap = ScoreSWallsOnMap + 1
                            SWall(ScoreSWallsOnMap).X = Int(arg2)
                            SWall(ScoreSWallsOnMap).Y = Int(arg3)
                        Case "bu"
                            ScoreBushesOnMap = ScoreBushesOnMap + 1
                            Bush(ScoreBushesOnMap).X = Int(arg2)
                            Bush(ScoreBushesOnMap).Y = Int(arg3)
                        Case "rboxtime"
                            RBoxTimer = Trim(arg3)
                        Case "tile"
                            TileLength = Trim(arg3)
                        Case "back"
                            BackLength = Trim(arg3)
                        Case "end"
                            FILL = Trim(arg3)
                    End Select
                Loop Until line Is Nothing
            End Using
        Catch ex As Exception
        End Try
        'If RBoxTimer <= 0 Then RBoxTimer = 1
        'If BonusLife <= 0 Then BonusLife = 15
        'If BlockLife <= 0 Then BlockLife = 30
        '    WoodenBox(m).isOnField = True
        'Next m
        'Exit Sub
        If SimpleMap = False Then
            Dim fs As New FileStream(PathFile, FileMode.Open, FileAccess.Read)
            Dim r As New BinaryReader(fs)
            ReDim Tile(0 To TileLength - 1)
            ReDim Back(0 To BackLength - 1)
            fs.Position = fs.Length - TileLength - BackLength
            Tile = r.ReadBytes(TileLength)
            Back = r.ReadBytes(BackLength)
            fs.Close()
            Try
                Kill("Tile.png")
                Kill("Back.png")
            Catch
            End Try
            Dim fw As New FileStream("Tile.png", FileMode.CreateNew)
            Dim w As New BinaryWriter(fw)
            For i = 0 To TileLength - 1
                w.Write(Tile(i))
            Next
            fw.Close()
            fw = New FileStream("Back.png", FileMode.CreateNew)
            w = New BinaryWriter(fw)
            For i = 0 To BackLength - 1
                w.Write(Back(i))
            Next
            fw.Close()
            sprBigTexture = New Sprite(Application.StartupPath & "\Tile.png")
            SprFrm = New Sprite(Application.StartupPath & "\Back.png")
            Kill("Tile.png")
            Kill("Back.png")
        End If
        If BackStyle = -1 Then
            Dim fs As New FileStream(PathFile, FileMode.Open, FileAccess.Read)
            ' Create the writer for data.
            Dim r As New BinaryReader(fs)
            '      Open PathFile For Binary As #d
            'fs.Position = fs.Length - 332856
            ReDim massPict(0 To FILL - 1)
            fs.Position = fs.Length - FILL
            massPict = r.ReadBytes(FILL)
            fs.Close()
            Try
                Kill("Temppic.png")
            Catch
            End Try
            Dim fw As New FileStream("Temppic.png", FileMode.CreateNew)
            ' Create the writer for data.
            Dim w As New BinaryWriter(fw)
            'ReDim massPict(0 To FILL - 1)
            For i = 0 To FILL - 1
                w.Write(massPict(i))
            Next
            fw.Close()
            SprGLoad = New Sprite(Application.StartupPath & "\Temppic.png")
            Kill(Application.StartupPath & "\Temppic.png")
        End If
        For m = 0 To MaxBonuses
            Bonus(m) = New clsBonus
        Next
        For m = 0 To ShotLimit
            Shot(m) = New clsShot
        Next
        Texture_Init(True)
        Back_Init()
        If RBoxTimer <= 0 Then RBoxTimer = 1
        If BonusLife <= 0 Then BonusLife = 15
        If BlockLife <= 0 Then BlockLife = 30
        For m = 1 To ScoreBoxesOnMap
            WoodenBox(m).isOnField = True
        Next m
        FrmvsMain.CtrlEditor1.Changed(BackStyle, MapSizeX, MapSizeY)
        FrmvsMain.setOptions()
        '        Exit Function
        'ololo:
        '        Close d
        'If Err.Number = 32755 Then Exit Function
        'MsgBox("Карта повреждена. Возможно ее версия не соответствует версии BaTaнчиков.", vbOKOnly, "ВаТанчики")
    End Sub
    Public Sub Texture_Init(Optional Reinit As Boolean = False, Optional GameMode As Byte = 0)
        Dim SprTestB As Sprite, SprTestC As Sprite, SprTestD As Sprite, _
        SprTestG As Sprite, SprTestE As Sprite
        If Reinit = True Then
            GoTo re1
        End If
        'Из файлов в тестовые спрайты
        SprMenu(0) = New Sprite(Application.StartupPath & "\Графика\StatusMenu3.btj")
        SprTestE = New Sprite(Application.StartupPath & "\Графика\Numbers1.btj")
        SprTestC = New Sprite(Application.StartupPath & "\Графика\Shot.btj")
        SprShield = New Sprite(Application.StartupPath & "\Графика\Shield.btj")
        SprTestB = New Sprite(Application.StartupPath & "\Графика\Bonus.btj")
        SprTestD = New Sprite(Application.StartupPath & "\Графика\Tracks2.btj")
        SprTestG = New Sprite(Application.StartupPath & "\Графика\Edges1.btj")
        SprGRoad = New Sprite(Application.StartupPath & "\Графика\BackStyleAkasia.btj")
        sprMenuBonus = New Sprite(Application.StartupPath & "\Графика\MenuBonus.png")
        'Анимации
        'Anim_Exp = New clsAnimation(5, 5, 96, 96, 48, 48, Application.StartupPath & "\Графика\exp1.btj", 0.5)
        Anim_ExpBox = New clsAnimation(6, 5, 174, 174, 87, 87, Application.StartupPath & "\Графика\explo1.btj", 0.25)
        Anim_Exp = New clsAnimation(8, 8, 60, 60, 30, 30, Application.StartupPath & "\Графика\explosion.btj")
        Anim_Resp = New clsAnimation(10, 10, 50, 50, 25, 25, Application.StartupPath & "\Графика\animTankresp.png")
        Anim_Kill = New clsAnimation(5, 3, 96, 96, 48, 48, Application.StartupPath & "\Графика\exp3.btj", 0.8)
        'Anim_Bonus = New clsAnimation(1, 5, 32, 32, 0, 0, Application.StartupPath & "\Графика\lightning.btj")
        Anim_Bonus = New clsAnimation(7, 7, 100, 100, 50, 50, Application.StartupPath & "\Графика\animbonus.png")
        Anim_ShotAnim = New clsAnimation(5, 4, 20, 20, 0, 0, Application.StartupPath & "\Графика\ShotAnim.btj")
        For i = 0 To 10
            Tank(i) = New clsTankNew
            Track(i) = New clsTrack
            Anim_Tank(i) = New clsAnimation(1, 3, 40, 40, 0, 0, Application.StartupPath & "\Графика\Танки.btj", , ARGB(0, 128, 0, 0))
            Tank(i).InitA(-40, -40, (i))
        Next i
        'Маска для тестовый спрайтов
        SprTestC.AddColorKey(ARGB(0, 255, 255, 255))
        SprShield.AddColorKey(ARGB(0, 255, 255, 255))
        SprTestB.AddColorKey(ARGB(0, 255, 255, 255))
        SprTestB.AddColorKey(ARGB(0, 255, 255, 255))
        'Загружаем рабочие спрайты
        For i = 0 To 9
            sprNumber(i) = New Sprite(38, 28, Op.AlphaBlend)
            sprNumber(i).Draw(SprTestE, -38 * i, 0, Op.AlphaBlend)
            sprNumber(i).AddColorKey(ARGB(0, 0, 0, 0))
        Next
        'Следы
        sprTrack(0) = New Sprite(SprTestD, , , , ARGB(0, 255, 255, 255))
        sprTrack(1) = New Sprite(SprTestD, Transform.RotCCW, 0, 0, ARGB(0, 255, 255, 255))
        sprTrack(2) = New Sprite(SprTestD, , , , ARGB(0, 255, 255, 255))
        sprTrack(3) = New Sprite(SprTestD, Transform.RotCCW, 0, 0, ARGB(0, 255, 255, 255))
        'Таран
        SprEdges(0) = New Sprite(SprTestG, , , , ARGB(0, 255, 255, 255))
        SprEdges(1) = New Sprite(SprTestG, Transform.FlipX, , , ARGB(0, 255, 255, 255))
        SprEdges(2) = New Sprite(SprTestG, Transform.RotCCW, , , ARGB(0, 255, 255, 255))
        SprEdges(3) = New Sprite(SprEdges(2), Transform.FlipY, , , ARGB(0, 255, 255, 255))
        SprEdges(5) = New Sprite(SprEdges(2), Transform.RotCCW, , , ARGB(0, 255, 255, 255))
        SprEdges(4) = New Sprite(SprEdges(5), Transform.FlipX, , , ARGB(0, 255, 255, 255))
        SprEdges(6) = New Sprite(SprEdges(4), Transform.RotCCW, , , ARGB(0, 255, 255, 255))
        SprEdges(7) = New Sprite(SprEdges(6), Transform.FlipY, , , ARGB(0, 255, 255, 255))
        'Пули и бонусы
        For i = 0 To 3
            sprBonus(i) = New Sprite(30, 30, Op.AlphaBlend)
            sprBonus(i).Draw(SprTestB, -i * 30, 0, Op.Paint)
            SprShot(i) = New Sprite(15, 15, Op.AlphaBlend)
            SprShot(i).Draw(SprTestC, -i * 15, 0, Op.Paint)
        Next i
        'For i = 0 To 3
        'Anim_Edges(i).Load_Exp 4, 1, 30, 30, 0, 0, Application.ExecutablePath & "\Графика\Edges" & i & ".btj"
        'Next i
        'Инициализация бэкбуффера
        SprBackBuffer = New Sprite(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        sprFinalMenu = New Sprite(994, 706)
        Exit Sub
re1:
        'Текстурные спрайты
        SprBackBuffer.ClearBuffer(vbBlack)
        For i = 0 To 5
            sprTexture(i) = New Sprite(40, 40, Op.AlphaBlend)
        Next i
        For i = 6 To 7
            sprTexture(i) = New Sprite(20, 20, Op.AlphaBlend)
        Next
        If BackStyle = -1 Then
            For i = 0 To 5
                sprTexture(i).Draw(SprGLoad, 0, -40 * i, Op.Paint)
            Next i
            sprTexture(6).Draw(SprGLoad, 0, -240, Op.Paint)
            sprTexture(7).Draw(SprGLoad, -20, -240, Op.Paint)
        Else
            For i = 0 To 5
                sprTexture(i).Draw(SprGRoad, -((BackStyle) * 40), -40 * i, Op.Paint)
            Next i
            sprTexture(6).Draw(SprGRoad, -((BackStyle) * 40), -240, Op.Paint)
            sprTexture(7).Draw(SprGRoad, -((BackStyle) * 40) - 20, -240, Op.Paint)
        End If
        For i = 1 To 7
            sprTexture(i).AddColorKey(ARGB(0, 255, 255, 255))
        Next i
        If SimpleMap Then
            sprBigTexture = Nothing
            sprBigTexture = New Sprite(MapSizeX * 40, MapSizeY * 40)
            sprBigTexture.TileDraw(sprTexture(0), 0, 0, sprBigTexture.Width, sprBigTexture.Height, 0, 0)
            For m = 1 To ScoreWaterOnMap
                sprBigTexture.Draw(sprTexture(2), Water(m).X, Water(m).Y, Op.AlphaBlend)
            Next m
            For m = 1 To ScoreSWaterOnMap
                sprBigTexture.Draw(sprTexture(7), SWater(m).X, SWater(m).Y, Op.AlphaBlend)
            Next m
            For m = 1 To ScoreWallsOnMap
                sprBigTexture.Draw(sprTexture(1), Wall(m).X, Wall(m).Y, Op.AlphaBlend)
            Next m
            For m = 1 To ScoreSWallsOnMap
                sprBigTexture.Draw(sprTexture(6), SWall(m).X, SWall(m).Y, Op.AlphaBlend)
            Next m
        End If
        If Tank(0).MyColor = Tank(2).MyColor And Tank(1).MyColor = Tank(3).MyColor Then
            Tank(0).MyColor = ARGB(255, 255, 0, 0)
            Tank(1).MyColor = ARGB(255, 255, 255, 0)
            Tank(2).MyColor = ARGB(255, 255, 0, 255)
            Tank(3).MyColor = ARGB(255, 0, 255, 0)
        End If
        '====================
    End Sub
    Public Sub Back_Init()
        For i = 0 To 2
            sprObject(i) = New Sprite(40, 40)
        Next
        sprObject(3) = New Sprite(20, 20)
        sprObject(4) = New Sprite(20, 20)
        sprObject(0).ClearBuffer(vbGreen)
        sprObject(1).ClearBuffer(vbBlue)
        sprObject(2).ClearBuffer(ARGB(0, 255, 255, 0))
        sprObject(3).ClearBuffer(vbGreen)
        sprObject(4).ClearBuffer(vbBlue)
        If BTEditing = True Then
            SprDynamicFrm = Nothing
            SprDynamicFrm = New Sprite(MapSizeX * 40, MapSizeY * 40)
            SprDynamicFrm.ClearBuffer(vbBlack)
            If SimpleMap = True Then
                SprDynamicFrm = Nothing
                SprDynamicFrm = New Sprite(MapSizeX * 40, MapSizeY * 40)
                SprDynamicFrm.ClearBuffer(vbBlack)
                For i = 1 To ScoreWallsOnMap
                    SprDynamicFrm.Draw(sprObject(0), Wall(i).X, Wall(i).Y, Op.Paint)
                Next
                For i = 1 To ScoreSWallsOnMap
                    SprDynamicFrm.Draw(sprObject(3), SWall(i).X, SWall(i).Y, Op.Paint)
                Next
                For i = 1 To ScoreWaterOnMap
                    SprDynamicFrm.Draw(sprObject(1), Water(i).X, Water(i).Y, Op.Paint)
                Next
                For i = 1 To ScoreSWaterOnMap
                    SprDynamicFrm.Draw(sprObject(4), SWater(i).X, SWater(i).Y, Op.Paint)
                Next
                'SprDynamicFrm.ClearBuffer(vbBlack)
                'Блоки
                For m = 1 To ScoreBlocksOnMap
                    Block(m).BackDraw(SprDynamicFrm)
                Next
                'Стенки, вода.
                'Destr.Draw(SprHelpObject, 0, 0, Op.Add)
                'Ящики
                For m = 1 To ScoreBoxesOnMap
                    SprDynamicFrm.ClearRect((WoodenBox(m).X), (WoodenBox(m).X + 40), WoodenBox(m).Y, (WoodenBox(m).Y + 40), ARGB(0, 255, 255, 0))
                Next m
            Else
                For m = 1 To ScoreBlocksOnMap
                    Block(m).BackDraw(SprDynamicFrm)
                Next
                For m = 1 To ScoreBoxesOnMap
                    SprDynamicFrm.ClearRect((WoodenBox(m).X), (WoodenBox(m).X + 40), WoodenBox(m).Y, (WoodenBox(m).Y + 40), ARGB(0, 255, 255, 0))
                Next m
            End If
        Else

            'SprFrm.ClearBuffer(ARGB(0, 0, 255, 0))
            'SprFrm.ClearRect(40, (MapSizeX - 1) * 40, 40, (MapSizeY - 1) * 40, vbBlack)
            'SprHelpObject.AddColorKey vbBlack
            If SimpleMap = True Then
                SprFrm = Nothing
                SprFrm = New Sprite(MapSizeX * 40, MapSizeY * 40)
                SprFrm.ClearBuffer(vbBlack)
                For i = 1 To ScoreWallsOnMap
                    SprFrm.Draw(sprObject(0), Wall(i).X, Wall(i).Y, Op.Paint)
                Next
                For i = 1 To ScoreSWallsOnMap
                    SprFrm.Draw(sprObject(3), SWall(i).X, SWall(i).Y, Op.Paint)
                Next
                For i = 1 To ScoreWaterOnMap
                    SprFrm.Draw(sprObject(1), Water(i).X, Water(i).Y, Op.Paint)
                Next
                For i = 1 To ScoreSWaterOnMap
                    SprFrm.Draw(sprObject(4), SWater(i).X, SWater(i).Y, Op.Paint)
                Next
                'SprFrm.ClearBuffer(vbBlack)
                'Блоки
                'For m = 1 To ScoreBlocksOnMap
                '    Block(m).BackDraw(SprFrm)
                'Next
                'Стенки, вода.
                'Destr.Draw(SprHelpObject, 0, 0, Op.Add)
                'Ящики
                For m = 1 To ScoreBoxesOnMap
                    SprFrm.ClearRect((WoodenBox(m).X), (WoodenBox(m).X + 40), WoodenBox(m).Y, (WoodenBox(m).Y + 40), ARGB(0, 255, 255, 0))
                Next m
            Else
                For m = 1 To ScoreBlocksOnMap
                    Block(m).BackDraw(SprFrm)
                Next
                For m = 1 To ScoreBoxesOnMap
                    SprFrm.ClearRect((WoodenBox(m).X), (WoodenBox(m).X + 40), WoodenBox(m).Y, (WoodenBox(m).Y + 40), ARGB(0, 255, 255, 0))
                Next m
            End If
            SprDynamicFrm = New Sprite(MapSizeX * 40, MapSizeY * 40)
            End If
    End Sub

    Public Sub Back_Draw(Destr As Sprite)
        If BTEditing = True Then
            Destr.ClearBuffer(vbBlack)
            'SprFrm.ClearRect(40, (MapSizeX - 1) * 40, 40, (MapSizeY - 1) * 40, vbBlack)
            'Стенки, вода.
            For i = 1 To ScoreWallsOnMap
                Destr.Draw(sprObject(0), Wall(i).X, Wall(i).Y, Op.Paint)
            Next
            For i = 1 To ScoreWaterOnMap
                Destr.Draw(sprObject(1), Water(i).X, Water(i).Y, Op.Paint)
            Next
            For i = 1 To ScoreSWallsOnMap
                Destr.ClearRect(SWall(i).X, SWall(i).X + 20, SWall(i).Y, SWall(i).Y + 20, ARGB(0, 0, 255, 1))
            Next
            For i = 1 To ScoreSWaterOnMap
                Destr.ClearRect(SWater(i).X, SWater(i).X + 20, SWater(i).Y, SWater(i).Y + 20, ARGB(0, 0, 1, 255))
            Next
            'Блоки
            For m = 1 To ScoreBlocksOnMap
                Block(m).BackDraw(Destr)
            Next
            'Ящики
            For m = 1 To ScoreBoxesOnMap
                Destr.ClearRect((WoodenBox(m).X), (WoodenBox(m).X + 40), WoodenBox(m).Y, (WoodenBox(m).Y + 40), ARGB(0, 255, 255, 0))
            Next m
            For m = 1 To ScoreBushesOnMap
                Destr.ClearRect((Bush(m).X), (Bush(m).X + 40), Bush(m).Y, (Bush(m).Y + 40), RGB(128, 128, 128))
            Next m
            'Танки
            For i = 0 To AutosOnMap
                Destr.ClearRect(Tank(i).X, Tank(i).X + 40, Tank(i).Y, Tank(i).Y + 40, ARGB(0, 255, 0, i))
            Next
        Else
            Destr.ClearBuffer(vbBlack)
            'Блоки
            For m = 1 To ScoreBlocksOnMap
                Block(m).BackDraw(Destr)
            Next
            'Стенки, вода.
            'Destr.Draw(SprHelpObject, 0, 0, Op.Add)
            'Ящики
            'Танки
            For i = 0 To AutosOnMap
                Tank(i).BackDraw(Destr)
            Next
        End If
    End Sub
    Public Function MakeNumber(Num As Integer) As Sprite
        Dim strHelp As String, sprNumHelp As Sprite
        strHelp = Num
        sprNumHelp = New Sprite(30 * Len(strHelp), 28)
        'sprNumHelp.Init(30 * Len(strHelp), 28)
        For i = 1 To Len(strHelp)
            sprNumHelp.Draw(sprNumber(Mid(strHelp, i, 1)), (i - 1) * 30, 0)
        Next i
        MakeNumber = New Sprite(sprNumHelp, , 15 * Len(strHelp), 15)
        'MakeNumber.LoadFromSprite(sprNumHelp, , 15 * Len(strHelp), 15)
    End Function
    Public Sub WriteMapNew()
        Dim Fil As Integer, Tile() As Byte, Back() As Byte
        Try
            Using sr As StreamWriter = New StreamWriter(FrmvsMain.SD1.FileName)
                sr.WriteLine("BTMap by " & AuthorName)
                sr.WriteLine("BTEditorVersion = " & EditorV)
                sr.WriteLine("MapSize " & MapSizeX & " " & MapSizeY)
                sr.WriteLine("SimpleMap = " & SimpleMap)
                If BackStyle = 12 Then
                    BackStyle = 1
                End If
                sr.WriteLine("BackStyle = " & BackStyle)
                sr.WriteLine("MaxShots = " & MaxShots1)
                sr.WriteLine("RespShields = " & RespShields)
                sr.WriteLine("BonusShields = " & BonusShields)
                sr.WriteLine("RespSpeed = " & RespSpeed)
                sr.WriteLine("MaxSpeed = " & MaxSpeed)
                sr.WriteLine("BonusRandom = " & BonusRandom)
                sr.WriteLine("ChanceShot = " & ChanceShot)
                sr.WriteLine("ChanceShield = " & ChanceShield)
                sr.WriteLine("ChanceSpeed = " & ChanceSpeed)
                sr.WriteLine("ChanceEdges = " & ChanceEdges)
                sr.WriteLine("RespTime = " & RespTime)
                sr.WriteLine("ShotSpeed = " & ShotSpeed)
                sr.WriteLine("MaxBonuses = " & MaxBonuses)
                sr.WriteLine("RBoxTime = " & RBoxTimer)
                sr.WriteLine("BonusLife = " & BonusLife)
                sr.WriteLine("BlockLife = " & BlockLife)
                    For i = 0 To AutosOnMap
                        sr.WriteLine("Tank " & Tank(i).X & " " & Tank(i).Y)
                    Next
                    For i = 1 To ScoreWaterOnMap
                        sr.WriteLine("W " & Water(i).X & " " & Water(i).Y)
                    Next i
                    For i = 1 To ScoreSWaterOnMap
                        sr.WriteLine("SW " & SWater(i).X & " " & SWater(i).Y)
                    Next i
                    For i = 1 To ScoreBoxesOnMap
                        sr.WriteLine("B " & WoodenBox(i).X & " " & WoodenBox(i).Y)
                    Next i
                    For i = 1 To ScoreWallsOnMap
                        sr.WriteLine("WL " & Wall(i).X & " " & Wall(i).Y)
                    Next i
                    For i = 1 To ScoreSWallsOnMap
                        sr.WriteLine("SWL " & SWall(i).X & " " & SWall(i).Y)
                    Next i
                    For i = 1 To ScoreBlocksOnMap
                        sr.WriteLine("BL " & Block(i).X & " " & Block(i).Y)
                    Next i
                    For i = 1 To ScoreBushesOnMap
                        sr.WriteLine("BU " & Bush(i).X & " " & Bush(i).Y)
                Next i
                If BackStyle = -1 Then
                    Fil = massPict.Length
                End If
                If SimpleMap = False Then
                    sprBigTexture.SaveToFile(Application.StartupPath & "\Tile.png", System.Drawing.Imaging.ImageFormat.Png)
                    Dim fs1 As New FileStream(Application.StartupPath & "\Tile.png", FileMode.Open)
                    Dim fs1Reader As New BinaryReader(fs1)
                    sr.WriteLine("Tile = " & fs1.Length)
                    ReDim Tile(0 To fs1.Length - 1)
                    Tile = fs1Reader.ReadBytes(fs1.Length)
                    fs1.Close()
                    SprFrm.SaveToFile(Application.StartupPath & "\back.png", System.Drawing.Imaging.ImageFormat.Png)
                    fs1 = New FileStream(Application.StartupPath & "\back.png", FileMode.Open)
                    sr.WriteLine("Back = " & fs1.Length)
                    fs1Reader = New BinaryReader(fs1)
                    ReDim Back(0 To fs1.Length - 1)
                    Back = fs1Reader.ReadBytes(fs1.Length)
                    fs1.Close()
                    Kill("Tile.png")
                    Kill("Back.png")
                End If
                sr.WriteLine("END = " & Fil)
                sr.Close()
            End Using
            If SimpleMap = False Then
                Dim fs1 As New FileStream(FrmvsMain.SD1.FileName, FileMode.Append)
                Dim w1 As New BinaryWriter(fs1)
                For i = 0 To Tile.Length - 1
                    w1.Write(Tile(i))
                Next
                For i = 0 To Back.Length - 1
                    w1.Write(Back(i))
                Next
                fs1.Close()
            End If
            If BackStyle = -1 Then
                Dim fs As New FileStream(FrmvsMain.SD1.FileName, FileMode.Append)
                Dim w As New BinaryWriter(fs)
                For i = 0 To Fil - 1
                    w.Write(massPict(i))
                Next
                fs.Close()
            End If
        Catch e As Exception
            MsgBox(e.Message)
        End Try
    End Sub
    Public Sub LoadTextureToEditor()
        FrmvsMain.OD1.InitialDirectory = Application.StartupPath
        If FrmvsMain.OD1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        SprGLoad = New Sprite(FrmvsMain.OD1.FileName)
        Dim fs As New FileStream(FrmvsMain.OD1.FileName, FileMode.Open)
        Dim r As New BinaryReader(fs)
        ReDim massPict(0 To fs.Length - 1)
        massPict = r.ReadBytes(fs.Length)
        BackStyle = -1
        Texture_Init(True)
        FrmvsMain.CtrlEditor1.Changed(-1, MapSizeX, MapSizeY)
    End Sub
End Module
