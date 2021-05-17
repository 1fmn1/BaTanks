Imports System.Net.Sockets
Imports System.Text
Imports System.IO

Module modServer
    Public clientsList As New Hashtable
    Public counts As Boolean
    Public Sub ServerMain()
        Dim serverSocket As New TcpListener(8888)
        Dim clientSocket As TcpClient
        Dim infiniteCounter As Integer
        Dim counter As Integer
        Try
            serverSocket.Start()
            isHost = True
            LANgame = True
        Catch ex As Exception
            msg("Server sosnyl tynca na porte 8888")
            Exit Sub
        Finally

        End Try
        'Dim RichTextBoxReader As TextReader = New  _
        '        StreamReader("d:\textwriter.txt")
        counts = True
        msg("BaTanks Server Started ....")
        msg("Listening connections on 8888")
        counter = 0
        infiniteCounter = 0
        For infiniteCounter = 1 To 2
            infiniteCounter = 1
            counter += 1
            If counter > 3 Then counter = 0
            clientSocket = serverSocket.AcceptTcpClient()

            Dim bytesFrom(10024) As Byte
            Dim dataFromClient As String

            Dim networkStream As NetworkStream = _
            clientSocket.GetStream()
            networkStream.Read(bytesFrom, 0, CInt(clientSocket.ReceiveBufferSize))
            dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom)
            dataFromClient = _
            dataFromClient.Substring(0, dataFromClient.IndexOf("$"))

            clientsList(dataFromClient) = clientSocket

            broadcast(dataFromClient + " Joined ", dataFromClient, False)
            counts = True
            msg(dataFromClient + " Joined game room ")

            'FrmvsMain.UpdateList("kek")
            Dim client As New handleClinet
            client.startClient(clientSocket, dataFromClient, counter, clientsList)
        Next

        clientSocket.Close()
        serverSocket.Stop()
        msg("exit")
        Console.ReadLine()
    End Sub
    Private Sub msg(Mesg As String)
        Mesg.Trim()
        Console.WriteLine(" >> " + Mesg)
        'If counts = True Then
        '    Me.Invoke(New MethodInvoker(AddressOf msg))
        '    counts = False
        'Else
        '    Me.RTB1.Text = Me.RTB1.Text + Environment.NewLine + " >> " + Mesg
        'End If
    End Sub
    Public Sub SendMap()
        Dim Buff As String
        Try
            Using sr As StreamReader = New StreamReader(PathFile)
                Buff = sr.ReadToEnd
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        broadcast("1&" & Buff & "$")
        msg("Карта отправлена размером " & Len(Buff))
    End Sub
    Public Sub SendStart()
        broadcast("2&" & "$")
    End Sub
    Public Sub SendHost()
        Dim outStreamPack As String

        For i = 0 To AutosOnMap
            outStreamPack = outStreamPack & Tank(i).X & ";" & Tank(i).Y & ";" & Tank(i).Angle _
                & ";" & Tank(i).isDead & ";" & Tank(i).isShielded & ";" & Tank(i).Speed & ";" & Tank(i).Ammo _
                & ";" & Tank(i).ShieldTime & ";" & Tank(i).Kills & ";" & Tank(i).Deaths
            If i = AutosOnMap Then
                outStreamPack = outStreamPack & "*"
            Else
                outStreamPack = outStreamPack & "#"
            End If
        Next
        For i = 0 To ShotLimit
            If Shot(i).isMoving = True Or Shot(i).isExploding = True Then
                outStreamPack = outStreamPack & i & ";" & Shot(i).X & ";" & Shot(i).Y & ";" & Shot(i).Angle & ";" & Shot(i).isMoving & ";" & Shot(i).isExploding
                If i <> ShotLimit Then
                    outStreamPack = outStreamPack & "#"
                End If
            End If
            If i = ShotLimit Then
                outStreamPack = outStreamPack & "+"
            End If
        Next
        For i = 0 To MaxBonuses
            If Bonus(i).isExploding = True And Bonus(i).isOnField = True Then
                outStreamPack = outStreamPack & i & ";" & Bonus(i).X & ";" & Bonus(i).Y & ";" & Bonus(i).WhatIsThis
                If i <> MaxBonuses Then
                    outStreamPack = outStreamPack & "#"
                End If
            End If
            If i = MaxBonuses Then
                outStreamPack = outStreamPack & "@"
            End If
        Next
        For i = 1 To ScoreBoxesOnMap
            If WoodenBox(i).isExploding = True Or WoodenBox(i).isRespawning = True Then
                outStreamPack = outStreamPack & i & ";" & WoodenBox(i).isRespawning & ";" & WoodenBox(i).isExploding
                If i <> ScoreBoxesOnMap Then
                    outStreamPack = outStreamPack & "#"
                End If
            End If
        Next
        broadcast("3&" & outStreamPack & "$")
    End Sub
    Private Sub broadcast(ByVal msg As String, _
    Optional ByVal uName As String = "", Optional ByVal flag As Boolean = False)
        Dim Item As DictionaryEntry
        For Each Item In clientsList
            Dim broadcastSocket As TcpClient
            broadcastSocket = CType(Item.Value, TcpClient)
            Dim broadcastStream As NetworkStream = _
                    broadcastSocket.GetStream()
            Dim broadcastBytes As [Byte]()

            If flag = True Then
                broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg)
            Else
                broadcastBytes = Encoding.ASCII.GetBytes(msg)
            End If

            broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length)
            broadcastStream.Flush()
        Next
    End Sub
    Delegate Sub Delegat(ByVal text As String)

    Public Class handleClinet
        Dim clientSocket As TcpClient
        Dim clNo As String
        Dim clNum As Integer
        Dim clientsList As Hashtable

        Public Sub startClient(ByVal inClientSocket As TcpClient, _
        ByVal clineNo As String, ByVal clineNum As Integer, ByVal cList As Hashtable)
            Me.clientSocket = inClientSocket
            Me.clNo = clineNo
            Me.clientsList = cList
            Me.clNum = clineNum
            Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf doChat)
            ctThread.Start()
        End Sub

        Private Sub doChat()
            Dim infiniteCounter As Integer
            Dim requestCount As Integer
            Dim bytesFrom(10024) As Byte
            Dim dataFromClient As String
            Dim flag As String
            'Dim sendBytes As [Byte]()
            ' Dim serverResponse As String
            Dim rCount As String
            requestCount = 0
            For infiniteCounter = 1 To 2
                infiniteCounter = 1
                Try
                    requestCount = requestCount + 1
                    Dim networkStream As NetworkStream = _
                            clientSocket.GetStream()
                    networkStream.Read(bytesFrom, 0, CInt(clientSocket.ReceiveBufferSize))
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom)
                    flag = dataFromClient.Substring(0, dataFromClient.IndexOf("&"))
                    dataFromClient = dataFromClient.Substring(dataFromClient.IndexOf("&") + 1, dataFromClient.IndexOf("$") - 2)
                    Select Case flag
                        Case "3"
                            Dim args() As String = dataFromClient.Split(";")
                            Try
                                Gamer(clNum).UKey = CBool(args(0))
                                Gamer(clNum).RKey = CBool(args(1))
                                Gamer(clNum).DKey = CBool(args(2))
                                Gamer(clNum).LKey = CBool(args(3))
                                Gamer(clNum).FKey = CBool(args(4))
                                Gamer(clNum).FBlocked = CBool(args(5))
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try

                    End Select
                    counts = True
                    msg("From client - " + clNo + " : " + dataFromClient)
                    rCount = Convert.ToString(requestCount)

                    'broadcast(dataFromClient, clNo, True)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
        End Sub

    End Class
End Module
