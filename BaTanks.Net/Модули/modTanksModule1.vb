Module modTanksModule1
    'Public Declare Function sndPlaySound Lib "winmm.dll" Alias "sndPlaySoundA" (ByVal lpszSoundName As String, ByVal uFlags As Long) As Long
    'Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Long) As Integer
    Public Declare Function joyGetpos Lib "winmm.dll" Alias "joyGetPos" (ByVal uJoyID As Long, pji As JOYINFO) As Long
    'Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Dim mp As New Media.SoundPlayer
    Public Structure JOYINFO
        Dim wXpos As Long
        Dim wYpos As Long
        Dim wZpos As Long
        Dim wButtons As Long
    End Structure
    Public Structure Mapobject_Data
        Dim X As Long
        Dim Y As Long
        Dim isOnField As Boolean
        Dim Status As Single
    End Structure
    Public Structure UserData
        Dim UKey As Boolean
        Dim RKey As Boolean
        Dim DKey As Boolean
        Dim LKey As Boolean
        Dim FKey As Boolean
        Dim FBlocked As Boolean
        Dim Nick As String
    End Structure

    Public Gamer(0 To 10) As UserData
    Public myTank As Single
    Public LANgame As Boolean
    Public CurrentShotsA As Integer
    Public Bonus(0 To 199) As clsBonus
    Public Shot(0 To 30) As clsShot
    Public Sound As Integer
    Public BTMusic As Boolean
    Public BTVol As Single
    Public BackStyle As Integer
    Public ScoreWaterOnMap As Long
    Public ScoreSWaterOnMap As Long
    Public ScoreBoxesOnMap As Long
    Public ScoreWallsOnMap As Long
    Public ScoreSWallsOnMap As Long
    Public ScoreBlocksOnMap As Long
    Public ScoreBushesOnMap As Long
    Public Water(30000) As Mapobject_Data
    Public WoodenBox(4000) As clsBox
    Public Wall(30000) As Mapobject_Data
    Public Block(4000) As clsBlock
    Public Bush(30000) As Mapobject_Data
    Public SWater(30000) As Mapobject_Data
    Public SWall(30000) As Mapobject_Data
    Public MapName As String
    Public AuthorName As String
    Public RespShields As Integer
    Public BonusShields As Integer
    Public MaxSpeed As Integer
    Public RespSpeed As Integer
    Public MaxShots1 As Integer
    Public BonusRandom As Integer
    Public EditorV As String = "4.1"
    Public RespTime As Integer
    Public MaxBonuses As Integer
    Public BonusLife As Integer
    Public BlockLife As Integer
    Public PathFile As String
    Public RBoxTimer As Integer
    Public DemoMode As Boolean
    Public UserTexture As String
    Public LoadedTexture As Boolean
    Public Running As Boolean
    Public FPS As Integer
    Public FragLimit As Long
    Public TimeLimit As Integer
    Public MapSizeX As Integer
    Public MapSizeY As Integer
    Public MinKoef As Byte
    Public maxKoef As Double
    Public ChangeX As Integer
    Public ChangeY As Integer
    Public AutosOnMap As Integer
    Public SprBackBuffer As Sprite
    Public SprFrm As Sprite
    Public SprDynamicFrm As Sprite
    Public sprTexture(0 To 7) As Sprite
    Public SprShield As Sprite
    Public sprBonus(0 To 3) As Sprite
    Public SprShot(0 To 3) As Sprite
    Public SprEdges(0 To 7) As Sprite
    Public Anim_Exp As clsAnimation
    Public Anim_Edges(0 To 10) As clsAnimation
    Public Anim_ExpBox As clsAnimation
    Public Anim_Bonus As clsAnimation
    Public Anim_Tank(0 To 10) As clsAnimation
    Public Anim_ShotAnim As clsAnimation
    Public Tank(0 To 10) As clsTankNew 'clsTank
    Public LeftKey(0 To 10) As Long
    Public RightKey(0 To 10) As Long
    Public DownKey(0 To 10) As Long
    Public UpKey(0 To 10) As Long
    Public Firekey(0 To 10) As Long
    Public IsJoy(0 To 10) As Long
    Public ShotSpeed As Integer
    Public sprTrack(0 To 10) As Sprite
    Public Track(0 To 10) As clsTrack
    Public Anim_Resp As clsAnimation
    Public Anim_Kill As clsAnimation
    Public SprMenu(0 To 10) As Sprite
    Public sprNumber(0 To 9) As Sprite
    Public sprFinalMenu As Sprite
    Public GMode As Integer
    Public RBlockTimer As Integer
    Public ChanceShot As Integer = 50
    Public ChanceShield As Integer = 25
    Public ChanceSpeed As Integer = 15
    Public ChanceEdges As Integer = 10
    Public BTEditing As Boolean
    Public SimpleMap As Boolean = True
    Public sprBigTexture As Sprite
    Public sprMenuBonus As Sprite
    Public isHost As Boolean
    'Public rtfWriter As New RichTextBoxWriter

    Public Const ShotLimit = 30
    Public Const BonusHeight = 30
    Public Const BonusWidth = 30
    Public Const Version = "3.15"
    Public Const vbGreen = -16711936
    Public Const vbRed = 16711680
    Public Const vbBlue = -16776961
    Public Const vbBlack = 0
    Public Const vbWhite = 16777215
    Public Const vbMagenta = 16711935
    Public Const vbCyan = 65535
    Public Const vbYellow = 16776960
    Public Sub PlayMusEff(EffNum As Integer)
        If Sound = 1 Then
            Select Case EffNum
                Case 0
                    mp.SoundLocation = Application.StartupPath & "\Sounds\Resp.wav"
                    mp.Play()
                Case 1
                    mp.SoundLocation = Application.StartupPath & "\Sounds\Expl.wav"
                    mp.Play()
                Case 2
                    mp.SoundLocation = Application.StartupPath & "\Sounds\FastShot.wav"
                    mp.Play()
                Case 3
                    mp.SoundLocation = Application.StartupPath & "\Sounds\kill.wav"
                    mp.Play()
                Case 4
                    mp.SoundLocation = Application.StartupPath & "\Sounds\explosion.wav"
                    mp.Play()
                Case 5
                    mp.SoundLocation = Application.StartupPath & "\Sounds\Prize.wav"
                    mp.Play()
                Case 6
                    mp.SoundLocation = Application.StartupPath & "\Sounds\kill.wav"
                    mp.Play()
                Case 10
                    mp.Stream = My.Resources.ResourceManager.GetStream("Fight")
                    mp.Play()
                Case 11
                    mp.Stream = My.Resources.ResourceManager.GetStream("W1")
                    mp.Play()
                Case 12
                    mp.Stream = My.Resources.ResourceManager.GetStream("W2")
                    mp.Play()
                Case 13
                    mp.Stream = My.Resources.ResourceManager.GetStream("W3")
                    mp.Play()
            End Select
        End If
    End Sub
End Module
