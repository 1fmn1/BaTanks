Public Class ctrlOption
    Public Sub Reset()
        ComboBox1.Text = ComboBox1.Items.Item(0).ToString
        ComboBox2.Text = ComboBox2.Items.Item(0).ToString
        ComboBox3.Text = ComboBox3.Items.Item(0).ToString
        ComboBox4.Text = ComboBox4.Items.Item(0).ToString
        ComboBox5.Text = ComboBox5.Items.Item(0).ToString
        ComboBox6.Text = ComboBox6.Items.Item(0).ToString
        ComboBox7.Text = ComboBox7.Items.Item(0).ToString
        ComboBox8.Text = ComboBox8.Items.Item(0).ToString
        ComboBox9.Text = ComboBox9.Items.Item(0).ToString
        ComboBox10.Text = ComboBox10.Items.Item(0).ToString
        ComboBox11.Text = ComboBox11.Items.Item(0).ToString
        ComboBox12.Text = ComboBox12.Items.Item(0).ToString
        ComboBox13.Text = ComboBox13.Items.Item(0).ToString
        ComboBox14.Text = ComboBox14.Items.Item(0).ToString
        ComboBox15.Text = ComboBox15.Items.Item(0).ToString
        ComboBox16.Text = ComboBox16.Items.Item(0).ToString
    End Sub

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        'Reset()
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        If ComboBox1.Text Like "#*" Then

        Else
            ComboBox1.Text = ComboBox1.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox2_TextChanged(sender As Object, e As EventArgs) Handles ComboBox2.TextChanged
        If ComboBox2.Text Like "#*" Then

        Else
            ComboBox2.Text = ComboBox2.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox3_TextChanged(sender As Object, e As EventArgs) Handles ComboBox3.TextChanged
        If ComboBox3.Text Like "#*" Then

        Else
            ComboBox3.Text = ComboBox3.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox4_TextChanged(sender As Object, e As EventArgs) Handles ComboBox4.TextChanged
        If ComboBox4.Text Like "#*" Then

        Else
            ComboBox4.Text = ComboBox4.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox5_TextChanged(sender As Object, e As EventArgs) Handles ComboBox5.TextChanged
        If ComboBox5.Text Like "#*" Then

        Else
            ComboBox5.Text = ComboBox5.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox6_TextChanged(sender As Object, e As EventArgs) Handles ComboBox6.TextChanged
        If ComboBox6.Text Like "#*" Then

        Else
            ComboBox6.Text = ComboBox6.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox7_TextChanged(sender As Object, e As EventArgs) Handles ComboBox7.TextChanged
        If ComboBox7.Text Like "#*" Then

        Else
            ComboBox7.Text = ComboBox7.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox8_TextChanged(sender As Object, e As EventArgs) Handles ComboBox8.TextChanged
        If ComboBox8.Text Like "#*" Then

        Else
            ComboBox8.Text = ComboBox8.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox9_TextChanged(sender As Object, e As EventArgs) Handles ComboBox9.TextChanged
        If ComboBox9.Text Like "#*" Then

        Else
            ComboBox9.Text = ComboBox9.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox10_TextChanged(sender As Object, e As EventArgs) Handles ComboBox10.TextChanged
        If ComboBox10.Text Like "#*" Then

        Else
            ComboBox10.Text = ComboBox10.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox11_TextChanged(sender As Object, e As EventArgs) Handles ComboBox11.TextChanged
        If ComboBox11.Text Like "#*" Then

        Else
            ComboBox11.Text = ComboBox11.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox12_TextChanged(sender As Object, e As EventArgs) Handles ComboBox12.TextChanged
        If ComboBox12.Text Like "#*" Then

        Else
            ComboBox12.Text = ComboBox12.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox13_TextChanged(sender As Object, e As EventArgs) Handles ComboBox13.TextChanged
        If ComboBox13.Text Like "#*" Then

        Else
            ComboBox13.Text = ComboBox13.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox14_TextChanged(sender As Object, e As EventArgs) Handles ComboBox14.TextChanged
        If ComboBox14.Text Like "#*" Then

        Else
            ComboBox14.Text = ComboBox14.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox15_TextChanged(sender As Object, e As EventArgs) Handles ComboBox15.TextChanged
        If ComboBox15.Text Like "#*" Then

        Else
            ComboBox15.Text = ComboBox15.Items.Item(0).ToString
        End If
    End Sub
    Private Sub ComboBox16_TextChanged(sender As Object, e As EventArgs) Handles ComboBox16.TextChanged
        If ComboBox16.Text Like "#*" Then

        Else
            ComboBox16.Text = ComboBox16.Items.Item(0).ToString
        End If
    End Sub

    Private Sub ctrlOption_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
