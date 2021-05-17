'Imports QuartzTypeLib
Imports Microsoft.DirectX.AudioVideoPlayback
Module modDirectShow
    Public Back2 As New Audio(Application.StartupPath & "\sounds\backmelody2.mp3")
    Public Back1 As New Audio(Application.StartupPath & "\sounds\backmelody1.mp3")
    'Public SouExpTank
    'Public SouExpBox
    'Public SouPrize
    'Public SouShot
    'Public Player1 As FilgraphManager
    'Public Player1Position As IMediaPosition
    'Public Player1Audio As IBasicAudio
    'Public Sub RunAudio(fName As String, ByVal Volume As Single)
    '    'Dim meVol As Integer, state1 As Long, state2 As Long, state3 As Long
    '    ' If m_objMediaControl.GetState(10, state) Then
    '    ' End
    '    ' End If

    '    'Player1 = Nothing
    '    'Player1Position = Nothing
    '    'Player1Audio = Nothing
    '    Player1 = New FilgraphManager
    '    'Player1.Stop()
    '    Player1.RenderFile(fName)
    '    'Player1Position.
    '    Player1Position = Player1
    '    Player1Audio = Player1
    '    Player1Position.CurrentPosition = 1 'or any
    '    Player1.Run()
    '    Player1Position.Rate = 1 'between 0.5 and 2
    '    'valaue must be between 0.01 and 1
    '    Player1Audio.Volume = Math.Log(Volume) * 1000
    '    If BTMusic = False Then
    '        Player1.Pause()
    '    End If
    'End Sub
    'Public Sub DShowUpdate()
    '        If Running Then
    '            Player1Position = Player1
    '            If Player1Position.Duration = Player1Position.CurrentPosition Then
    '                RunAudio(Application.StartupPath & "\sounds\backmelody1.mp3", 1)
    '            End If
    '        Else
    '            Player1Position = Player1Position
    '            If Player1Position.Duration = Player1Position.CurrentPosition Then
    '                RunAudio(Application.StartupPath & "\sounds\backmelody2.mp3", 1)
    '            End If
    '    End If
    '    'If BTMusic = False Then
    '    'Player1.Pause()
    '    'End If
    'End Sub
    Public Sub RunAudio(Optional Number As Integer = 1)
        Select Case Number
            Case 0
                Back2.Stop()
                Back1.Stop()
            Case 1
                Back2.Stop()
                Back1.Play()
                If BTMusic = False Then Back1.Pause()
            Case 2
                Back1.Stop()
                Back2.Play()
                If BTMusic = False Then Back2.Pause()
        End Select
    End Sub
End Module