Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.IO

Module modClient
    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
    Dim readData As String
    Dim infiniteCounter As Integer

    Public Sub SendClient()
        Dim outStreamPack As String
        outStreamPack = "3&" & Gamer(myTank).UKey & ";" & Gamer(myTank).RKey & ";" & Gamer(myTank).DKey & ";" & Gamer(myTank).LKey & ";" & Gamer(myTank).FKey & ";" & Gamer(myTank).FBlocked & "$"
        If Gamer(myTank).FKey = True Then
            Gamer(myTank).FBlocked = True
        End If
        'Dim outStream As Byte() = _
        'System.Text.Encoding.ASCII.GetBytes(FrmvsMain.RTB1.Text + "$")
        'serverStream.Write(outStream, 0, outStream.Length)
        'serverStream.Flush()
        Dim outStream As Byte() = _
        System.Text.Encoding.ASCII.GetBytes(outStreamPack)
        serverStream.Write(outStream, 0, outStream.Length)
        serverStream.Flush()
    End Sub

    Private Sub msg()
        'If FrmvsMain.InvokeRequired Then
        '    FrmvsMain.Invoke(New MethodInvoker(AddressOf msg))
        'Else
        '    FrmvsMain.RTB1.Text = FrmvsMain.RTB1.Text + Environment.NewLine + " >> " + readData
        'End If

    End Sub


    Public Sub Connect_Clicked() ' Handles FrmvsMain.Button2.Click
        Dim iP As IPAddress = IPAddress.Any
        Dim isIp As Boolean = IPAddress.TryParse(FrmvsMain.txtIP.Text, iP)
        If isIp Then
            readData = "Conected ..."
            msg()
            clientSocket.Connect(FrmvsMain.txtIP.Text, 8888)
            'Label1.Text = "Client Socket Program - Server Connected ..."
            serverStream = clientSocket.GetStream()

            Dim outStream As Byte() = _
            System.Text.Encoding.ASCII.GetBytes(FrmvsMain.TextBox3.Text + "$")
            serverStream.Write(outStream, 0, outStream.Length)
            serverStream.Flush()

            Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf getMessage)
            ctThread.Start()
            FrmvsMain.GroupBox1.Visible = True
            isHost = False
            LANgame = True
        Else
            MsgBox("Проверьте правильность IP! * " & FrmvsMain.txtIP.Text & " * не является допустимым!", MsgBoxStyle.Exclamation, "ВаТанчики")
        End If
    End Sub

    Private Sub getMessage()
        Dim infiniteCounter As Integer, Flag As String, Data As String, datalen As Integer, buf() As Byte

        For infiniteCounter = 1 To 2
            infiniteCounter = 1
            serverStream = clientSocket.GetStream()
            'Dim inStream(10024) As Byte
            'Dim buffSize As Integer
            'buffSize = clientSocket.ReceiveBufferSize
            'Try
            '    serverStream.Read(inStream, 0, buffSize)
            'Catch ex As Exception

            'End Try

            datalen = 0
                While datalen = 0
                    ' data in read Buffer
                datalen = clientSocket.Available
                End While
            buf = New Byte(datalen - 1) {}
            'get entire bytes at once
            clientSocket.GetStream().Read(buf, 0, buf.Length)

            Dim returndata As String = Trim(System.Text.Encoding.ASCII.GetString(buf))
                Try
                    Flag = returndata.Substring(0, returndata.IndexOf("&"))
                    'MsgBox(Flag)
                Catch ex As Exception
                    'MsgBox(ex.Message)
                End Try
            'Try
            Select Case Flag
                Case "1"
                    Try
                        Using sr As StreamWriter = New StreamWriter("Tempmap.btm")
                            sr.Write(Data)
                        End Using
                    Catch ex As Exception
                        MsgBox("ex")
                    End Try
                    PathFile = "Tempmap.btm"
                    ReadMapNew()
                Case "2"
                    Running = True
                    myTank = returndata.Substring(returndata.IndexOf("&") + 1, 1)
                Case "3"
                    If Running = False Then Running = True
                    Data = returndata.Substring(2, returndata.IndexOf("*") - 2)
                    Dim TankArgs() As String = Data.Split("#")
                    Dim Args(0 To 9) As String
                    'Console.WriteLine(Data)
                    'Console.WriteLine(TankArgs(0))
                    Try
                        For i = 0 To TankArgs.GetLength(0) - 1
                            Args = TankArgs(i).Split(";")
                            'Console.WriteLine(Args(0))
                            'Console.WriteLine(Args(1))
                            'Console.WriteLine(Args(2))
                            'Console.WriteLine(Args(3))
                            'Console.WriteLine(Args(4))
                            'Console.WriteLine(Args(5))
                            'Console.WriteLine(Args(6))
                            'Console.WriteLine(Args(7))
                            'Console.WriteLine(Args(8))
                            'Console.WriteLine(Args(9))
                            Tank(i).X = CSng(Args(0))
                            Tank(i).Y = CSng(Args(1))
                            Tank(i).Angle = CSng(Args(2))
                            Tank(i).isDead = CBool(Args(3))
                            Tank(i).isShielded = CBool(Args(4))
                            Tank(i).Speed = CLng(Args(5))
                            Tank(i).Ammo = CLng(Args(6))
                            Tank(i).ShieldTime = CLng(Args(7))
                            Tank(i).Kills = CInt(Args(8))
                            Tank(i).Deaths = CInt(Args(9))
                        Next i
                    Catch ex As Exception
                    End Try
                    Data = returndata.Substring(returndata.IndexOf("*") + 1, returndata.IndexOf("+") - (returndata.IndexOf("*") + 1))
                    Dim ShotArgs() As String = Data.Split("#")
                    'Console.WriteLine(Data)
                    ReDim Args(0 To 5)
                    CurrentShotsA = ShotArgs.GetLength(0)
                    For i = 0 To CurrentShotsA - 2
                        Args = ShotArgs(i).Split(";")
                        If Shot(Args(0)).Initialized Then
                            Shot(Args(0)).X = CSng(Args(1))
                            Shot(Args(0)).Y = CSng(Args(2))
                            Shot(Args(0)).Angle = CSng(Args(3))
                            Shot(Args(0)).isMoving = CBool(Args(4))
                            Shot(Args(0)).isExploding = CBool(Args(5))
                        Else
                            Shot(Args(0)).Init(myTank, CSng(Args(1)) - 20, CSng(Args(2)) - 20, CSng(Args(3)))
                        End If
                    Next i

                    Data = returndata.Substring(returndata.IndexOf("+") + 1, returndata.IndexOf("@") - (returndata.IndexOf("+") + 1))
                    If Data.Length > 4 Then
                        Dim BonusArgs() As String = Data.Split("#")
                        ReDim Args(0 To 3)
                        For i = 0 To BonusArgs.GetLength(0) - 2
                            Args = BonusArgs(i).Split(";")
                            If Bonus(Args(0)).isOnField = False Then
                                Bonus(Args(0)).X = CSng(Args(1))
                                Bonus(Args(0)).Y = CSng(Args(2))
                                Bonus(Args(0)).WhatIsThis = CSng(Args(3))
                                Bonus(Args(0)).isOnField = True
                                Bonus(Args(0)).isExploding = True
                            End If
                        Next
                    End If
                    Data = returndata.Substring(returndata.IndexOf("@") + 1, returndata.IndexOf("$") - (returndata.IndexOf("@") + 1))
                    If Data.Length > 4 Then
                        Dim BoxArgs() As String = Data.Split("#")
                        ReDim Args(0 To 2)
                        For i = 1 To BoxArgs.GetLength(0) - 2
                            Args = BoxArgs(i).Split(";")
                            If WoodenBox(Args(0)).isRespawning = False Then
                                If CBool(Args(1)) = True Then
                                    WoodenBox(Args(0)).isRespawning = True
                                End If
                            End If
                            If WoodenBox(Args(0)).isExploding = False Then
                                If CBool(Args(2)) = True Then
                                    WoodenBox(Args(0)).isExploding = True
                                    WoodenBox(Args(0)).isOnField = False
                                End If
                            End If
                        Next
                    End If
                    'Catch ex As Exception
                    '    MsgBox(ex.Message)
                    'End Try
            End Select
            'Catch ex As Exception
            'End Try

            readData = "" + returndata
            msg()
        Next
    End Sub
End Module
