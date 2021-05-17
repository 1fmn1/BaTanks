Imports System.Runtime.InteropServices
Public Class ctrlColor
    Public hDC3 As HandleRef, ChValue As Integer, Color As Long
    Private Grp As Graphics
    Event ColorChanged()
    Private Sub ctrlColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChValue = 0
    End Sub
    Private Sub PictureBox1_HandleCreated(sender As Object, e As EventArgs) Handles PictureBox1.HandleCreated
        Grp = PictureBox1.CreateGraphics
        hDC3 = New HandleRef(Grp, Grp.GetHdc)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = Windows.Forms.CheckState.Checked Then
            ChValue = 0
            CheckBox2.CheckState = False
            CheckBox3.CheckState = False
            CheckBox4.CheckState = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = Windows.Forms.CheckState.Checked Then
            ChValue = 1
            CheckBox1.CheckState = False
            CheckBox3.CheckState = False
            CheckBox4.CheckState = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.CheckState = Windows.Forms.CheckState.Checked Then
            ChValue = 2
            CheckBox1.CheckState = False
            CheckBox2.CheckState = False
            CheckBox4.CheckState = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.CheckState = Windows.Forms.CheckState.Checked Then
            ChValue = 3
            CheckBox1.CheckState = False
            CheckBox3.CheckState = False
            CheckBox2.CheckState = False
        End If
    End Sub

    Private Sub PictureBox2_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseDown
        Static Img As New Bitmap(PictureBox2.Image)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Color = ARGB(128, Img.GetPixel(e.X, e.Y).R, Img.GetPixel(e.X, e.Y).G, Img.GetPixel(e.X, e.Y).B)
            RaiseEvent ColorChanged()
        End If
    End Sub

    Private Sub PictureBox2_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseMove
        Static Img As New Bitmap(PictureBox2.Image)
        On Error GoTo dno
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Color = ARGB(255, Img.GetPixel(e.X, e.Y).R, Img.GetPixel(e.X, e.Y).G, Img.GetPixel(e.X, e.Y).B)
            RaiseEvent ColorChanged()
        End If
dno:
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub
End Class
