Imports System.Runtime.InteropServices

Public Class ctrlEditor
    Dim Chks() As System.Windows.Forms.CheckBox
    Public Item As Integer, Backstyle As Integer, Textureloaded As Boolean
    Event BackStyleChanged()
    Event MapSizeChangedX(ByVal sx As Integer)
    Event MapSizeChangedY(ByVal sy As Integer)
    Public Sub Changed(B As Integer, chX As Integer, chY As Integer)
        For g = 0 To 12
            If g = B Then
                Chks(g).Enabled = False
                Chks(g).Checked = True
                Chks(g).BackColor = Color.Aqua
            Else
                Chks(g).Checked = False
                Chks(g).Enabled = True
                Chks(g).BackColor = Color.WhiteSmoke
            End If
        Next
        If B = -1 Then
            Chks(12).Enabled = False
            Chks(12).Checked = True
            Chks(12).BackColor = Color.Aqua
            Textureloaded = True
        End If
        Backstyle = B
        ComboBox1.Text = MapSizeX
        ComboBox2.Text = MapSizeY
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False
            CheckBox12.Checked = False
            Item = 0
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            CheckBox1.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False
            CheckBox12.Checked = False
            Item = 1
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            CheckBox2.Checked = False
            CheckBox1.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False
            CheckBox12.Checked = False
            Item = 2
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox1.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False
            CheckBox12.Checked = False
            Item = 3
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox1.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False
            CheckBox12.Checked = False
            Item = 4
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox1.Checked = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False
            CheckBox12.Checked = False
            Item = 5
        End If
    End Sub
    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.CheckedChanged
        If CheckBox10.Checked Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox1.Checked = False
            CheckBox7.Checked = False
            CheckBox9.Checked = False
            CheckBox8.Checked = False
            CheckBox11.Checked = False
            CheckBox12.Checked = False
            Item = 9
        End If
    End Sub

    Private Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged
        If CheckBox11.Checked Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox1.Checked = False
            CheckBox7.Checked = False
            CheckBox9.Checked = False
            CheckBox8.Checked = False
            CheckBox10.Checked = False
            CheckBox12.Checked = False
            Item = 10
        End If
    End Sub

    Private Sub CheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox12.CheckedChanged
        If CheckBox12.Checked Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox1.Checked = False
            CheckBox7.Checked = False
            CheckBox9.Checked = False
            CheckBox8.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False
            Item = 11
        End If
    End Sub
    Public Sub UpdateXY(x As Integer, y As Integer, Wl As Integer, W As Integer, B As Integer, BL As Integer, BU As Integer, SWl As Integer, SW As Integer)
        Label1.Text = x
        Label2.Text = y
        Label3.Text = Wl
        Label4.Text = W
        Label5.Text = B
        Label6.Text = BL
        Label8.Text = BU
        Label9.Text = SWl
        Label10.Text = SW
    End Sub
    Private Sub chksClick(ByVal sender As System.Object, e As System.EventArgs)
        Dim i As Integer
        i = Array.IndexOf(Chks, sender)
        For g = 0 To 12
            If g = i Then
                Chks(g).Enabled = False
                Chks(g).Checked = True
                Chks(g).BackColor = Color.Aqua
            Else
                Chks(g).Checked = False
                Chks(g).Enabled = True
                Chks(g).BackColor = Color.WhiteSmoke
            End If
        Next
        If i = 12 And Textureloaded = True Then
            Backstyle = -1
        Else
            Backstyle = i
        End If
        RaiseEvent BackStyleChanged()
    End Sub

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        Dim i As Integer
        ReDim Preserve Chks(12)
        For i = 0 To 11
            Chks(i) = New CheckBox
            With Chks(i)
                If i < 6 Then
                    .Location() = New System.Drawing.Point(20, 450 + 30 * i)
                Else
                    .Location() = New System.Drawing.Point(50, 450 + 30 * (i - 6))
                End If
                .Text = i
                .AutoSize = False
                .Appearance = Appearance.Button
                .Height = 30
                .Width = 30
                .BackColor = Color.WhiteSmoke
            End With
            AddHandler Chks(i).Click, AddressOf chksClick
        Next
        Chks(0).Checked = True
        Chks(0).Enabled = False
        Chks(0).BackColor = Color.Aqua
        Chks(12) = New CheckBox
        With Chks(12)
            .Text = "T"
            .Checked = False
            .Enabled = True
            .AutoSize = False
            .Appearance = Appearance.Button
            .Height = 30
            .Width = 30
            .BackColor = Color.WhiteSmoke
            .Location() = New System.Drawing.Point(100, 525)
            AddHandler Chks(12).Click, AddressOf chksClick
        End With
        Me.Controls.AddRange(Me.Chks)
    End Sub
    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        If ComboBox1.Text Like "#" Or ComboBox1.Text Like "##" Then
        Else
            ComboBox1.Text = 16
        End If
        RaiseEvent MapSizeChangedX(ComboBox1.Text)
    End Sub
    Private Sub ComboBox2_TextChanged(sender As Object, e As EventArgs) Handles ComboBox2.TextChanged
        If ComboBox2.Text Like "#" Or ComboBox2.Text Like "##" Then
        Else
            ComboBox1.Text = 16
        End If
        RaiseEvent MapSizeChangedY(ComboBox2.Text)
    End Sub

    Public Sub SelectItem(ItemIndex As Integer)
        Select Case ItemIndex
            Case 1
                If CheckBox1.Checked Then
                    CheckBox11.Checked = True
                Else
                    CheckBox1.Checked = True
                End If
            Case 2
                If CheckBox2.Checked Then
                    CheckBox12.Checked = True
                Else
                    CheckBox2.Checked = True
                End If
            Case 3
                CheckBox3.Checked = True
            Case 4
                CheckBox4.Checked = True
            Case 5
                CheckBox10.Checked = True
            Case 6
                CheckBox6.Checked = True
            Case 7
                CheckBox5.Checked = True
        End Select
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox1.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False
            CheckBox12.Checked = False
            Item = 6
        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False
            CheckBox1.Checked = False
            CheckBox9.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False
            CheckBox12.Checked = False
            Item = 7
        End If
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.Checked Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox1.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False
            CheckBox12.Checked = False
            Item = 8
        End If
    End Sub
End Class
