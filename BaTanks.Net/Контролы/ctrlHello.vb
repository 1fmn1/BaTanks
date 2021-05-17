Imports System.Runtime.InteropServices
Public Class ctrlHello
    Dim DI As New IO.DirectoryInfo(Application.StartupPath & "\Карты")
    'Public hDC3 As HandleRef
    Private mvarMapPath As String
    Event Start()
    Event ListBoxClick()
    Public GameMode As Integer
    Public Property MapPath As String
        Get
            MapPath = mvarMapPath
        End Get
        Set(value As String)

        End Set
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RaiseEvent Start()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        mvarMapPath = Application.StartupPath & "\Карты\" & ListBox1.SelectedItem.ToString & ".btm"
        RaiseEvent ListBoxClick()
    End Sub
    Public Sub UpdateInfo(mAuth As String, mBackst As Integer, mSize As String, mSShield As Integer, mBShield As Integer, _
                          mshots As Integer, mresp As Integer, mbonus As Integer, mspeed As Integer, mrspeed As Integer, _
                          mshspeed As Integer, mbrand As Integer)
        Label13.Text = mAuth
        If mBackst = -1 Then
            Label14.Text = "Уникальный"
        Else
            Label14.Text = "Стандартный"
        End If
        Label15.Text = mSize
        Label16.Text = mSShield
        Label17.Text = mBShield
        Label18.Text = mshots
        Label19.Text = mresp
        Label20.Text = mbonus
        Label21.Text = mspeed
        Label22.Text = mrspeed
        Label23.Text = mshspeed
        Label24.Text = mbrand
    End Sub
    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    Private Sub ctrlHello_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ListBox1.ClientSize = New System.Drawing.Size(Me.ClientSize.Width - 5, ListBox1.Size.Height)
        Button1.ClientSize = New System.Drawing.Size(Me.ClientSize.Width - 2, Button1.Size.Height)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Label25.Text = "Лимит убийств"
            CheckBox2.Checked = False
            CheckBox2.Enabled = True
            CheckBox1.Enabled = False
            GameMode = 0
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Label25.Text = "Лимит жизней"
            CheckBox1.Checked = False
            CheckBox1.Enabled = True
            CheckBox2.Enabled = False
            GameMode = 1
        End If
    End Sub
    Public Function GetTimeLimit() As Integer
        Return CInt(ComboBox2.Text)
    End Function
    Public Function GetFragLimit() As Integer
        Return CInt(ComboBox1.Text)
    End Function
    Public Sub RefreshList()
        ListBox1.Items.Clear()
        For Each dra As IO.FileInfo In DI.GetFiles("*.btm")
            ListBox1.Items.Add(Mid(dra.Name, 1, Len(dra.Name) - 4))
        Next
        ListBox1.SelectedIndex = 0
    End Sub
End Class
