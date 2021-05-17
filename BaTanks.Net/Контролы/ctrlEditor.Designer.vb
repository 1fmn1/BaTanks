<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlEditor
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CurAlign = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TrackBar3 = New System.Windows.Forms.TrackBar()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox12 = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(21, 19)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(88, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Стенка 40px"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(21, 67)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(77, 17)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.Text = "Вода 40px"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(21, 113)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(55, 17)
        Me.CheckBox3.TabIndex = 2
        Me.CheckBox3.Text = "Ящик"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(21, 136)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(51, 17)
        Me.CheckBox4.TabIndex = 3
        Me.CheckBox4.Text = "Блок"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(21, 203)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(79, 17)
        Me.CheckBox5.TabIndex = 4
        Me.CheckBox5.Text = "Затирачка"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(21, 180)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(51, 17)
        Me.CheckBox6.TabIndex = 5
        Me.CheckBox6.Text = "Танк"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(36, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(93, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Tomato
        Me.Label3.Location = New System.Drawing.Point(122, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Tomato
        Me.Label4.Location = New System.Drawing.Point(122, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Tomato
        Me.Label5.Location = New System.Drawing.Point(122, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Tomato
        Me.Label6.Location = New System.Drawing.Point(122, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "0"
        '
        'CurAlign
        '
        Me.CurAlign.AutoSize = True
        Me.CurAlign.Checked = True
        Me.CurAlign.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CurAlign.Location = New System.Drawing.Point(21, 19)
        Me.CurAlign.Name = "CurAlign"
        Me.CurAlign.Size = New System.Drawing.Size(101, 17)
        Me.CurAlign.TabIndex = 11
        Me.CurAlign.Text = "Выравнивание"
        Me.CurAlign.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(155, 39)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "КоординатыXY"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Controls.Add(Me.CurAlign)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(155, 66)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Настройки редактора"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(71, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "X"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"16"})
        Me.ComboBox2.Location = New System.Drawing.Point(91, 39)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(44, 21)
        Me.ComboBox2.TabIndex = 13
        Me.ComboBox2.Text = "16"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"16"})
        Me.ComboBox1.Location = New System.Drawing.Point(21, 39)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(44, 21)
        Me.ComboBox1.TabIndex = 12
        Me.ComboBox1.Text = "16"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TrackBar3)
        Me.GroupBox3.Controls.Add(Me.TrackBar2)
        Me.GroupBox3.Controls.Add(Me.TrackBar1)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.CheckBox9)
        Me.GroupBox3.Controls.Add(Me.CheckBox8)
        Me.GroupBox3.Controls.Add(Me.CheckBox7)
        Me.GroupBox3.Controls.Add(Me.CheckBox12)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.CheckBox11)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.CheckBox10)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.CheckBox2)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.CheckBox3)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.CheckBox4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.CheckBox5)
        Me.GroupBox3.Controls.Add(Me.CheckBox6)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 120)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(158, 312)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Панель элементов"
        '
        'TrackBar3
        '
        Me.TrackBar3.AutoSize = False
        Me.TrackBar3.Location = New System.Drawing.Point(75, 285)
        Me.TrackBar3.Name = "TrackBar3"
        Me.TrackBar3.Size = New System.Drawing.Size(77, 21)
        Me.TrackBar3.TabIndex = 27
        '
        'TrackBar2
        '
        Me.TrackBar2.AutoSize = False
        Me.TrackBar2.Location = New System.Drawing.Point(75, 262)
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Size = New System.Drawing.Size(77, 21)
        Me.TrackBar2.TabIndex = 26
        '
        'TrackBar1
        '
        Me.TrackBar1.AutoSize = False
        Me.TrackBar1.Location = New System.Drawing.Point(75, 239)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(77, 21)
        Me.TrackBar1.TabIndex = 25
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 223)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(139, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Кисти для сложной карты"
        '
        'CheckBox9
        '
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Location = New System.Drawing.Point(3, 289)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(79, 17)
        Me.CheckBox9.TabIndex = 23
        Me.CheckBox9.Text = "Затирачка"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Location = New System.Drawing.Point(3, 266)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(62, 17)
        Me.CheckBox8.TabIndex = 22
        Me.CheckBox8.Text = "Стенка"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(3, 243)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(51, 17)
        Me.CheckBox7.TabIndex = 19
        Me.CheckBox7.Text = "Вода"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox12
        '
        Me.CheckBox12.AutoSize = True
        Me.CheckBox12.Location = New System.Drawing.Point(21, 90)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(77, 17)
        Me.CheckBox12.TabIndex = 20
        Me.CheckBox12.Text = "Вода 20px"
        Me.CheckBox12.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Tomato
        Me.Label10.Location = New System.Drawing.Point(122, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(13, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Tomato
        Me.Label9.Location = New System.Drawing.Point(122, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "0"
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Location = New System.Drawing.Point(21, 42)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(88, 17)
        Me.CheckBox11.TabIndex = 18
        Me.CheckBox11.Text = "Стенка 20px"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Tomato
        Me.Label8.Location = New System.Drawing.Point(122, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "0"
        '
        'CheckBox10
        '
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Location = New System.Drawing.Point(21, 157)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(57, 17)
        Me.CheckBox10.TabIndex = 16
        Me.CheckBox10.Text = "Кусты"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'ctrlEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "ctrlEditor"
        Me.Size = New System.Drawing.Size(161, 534)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CurAlign As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CheckBox10 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox12 As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CheckBox11 As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CheckBox9 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox8 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents TrackBar3 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar

End Class
