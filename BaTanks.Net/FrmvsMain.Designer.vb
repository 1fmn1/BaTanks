<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmvsMain
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmvsMain))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.РедакторToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВаТанчикиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ФайлToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.НоваяToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СложнаяToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОткрітьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СохранітьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СохранитьКакToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.МузыкаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ЗвукToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ИИТанкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Танк1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Танк2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Танк3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Танк4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВыходToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ЗагрузитьТекстуруToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.МакросыToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.РамкаИзСтенокToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СвернутьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СетьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СоздатьИгруToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПодключитьсяToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.OD1 = New System.Windows.Forms.OpenFileDialog()
        Me.SD1 = New System.Windows.Forms.SaveFileDialog()
        Me.picRoad = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RTB1 = New System.Windows.Forms.RichTextBox()
        Me.CtrlColor1 = New BaTanks.ctrlColor()
        Me.CtrlHello1 = New BaTanks.ctrlHello()
        Me.CtrlEditor1 = New BaTanks.ctrlEditor()
        Me.CtrlOption1 = New BaTanks.ctrlOption()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.picRoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 25
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.DimGray
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.РедакторToolStripMenuItem, Me.ВаТанчикиToolStripMenuItem, Me.ФайлToolStripMenuItem, Me.МузыкаToolStripMenuItem, Me.ЗвукToolStripMenuItem1, Me.ИИТанкиToolStripMenuItem, Me.mnuMain, Me.ВыходToolStripMenuItem1, Me.ЗагрузитьТекстуруToolStripMenuItem, Me.МакросыToolStripMenuItem, Me.СвернутьToolStripMenuItem, Me.СетьToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1118, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'РедакторToolStripMenuItem
        '
        Me.РедакторToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.РедакторToolStripMenuItem.ForeColor = System.Drawing.Color.DarkTurquoise
        Me.РедакторToolStripMenuItem.Name = "РедакторToolStripMenuItem"
        Me.РедакторToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.РедакторToolStripMenuItem.Text = "Редактор"
        '
        'ВаТанчикиToolStripMenuItem
        '
        Me.ВаТанчикиToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ВаТанчикиToolStripMenuItem.ForeColor = System.Drawing.Color.DarkTurquoise
        Me.ВаТанчикиToolStripMenuItem.Name = "ВаТанчикиToolStripMenuItem"
        Me.ВаТанчикиToolStripMenuItem.Size = New System.Drawing.Size(82, 20)
        Me.ВаТанчикиToolStripMenuItem.Text = "ВаТанчики"
        Me.ВаТанчикиToolStripMenuItem.Visible = False
        '
        'ФайлToolStripMenuItem
        '
        Me.ФайлToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.НоваяToolStripMenuItem, Me.СложнаяToolStripMenuItem, Me.ОткрітьToolStripMenuItem, Me.СохранітьToolStripMenuItem, Me.СохранитьКакToolStripMenuItem})
        Me.ФайлToolStripMenuItem.Name = "ФайлToolStripMenuItem"
        Me.ФайлToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ФайлToolStripMenuItem.Text = "Файл"
        Me.ФайлToolStripMenuItem.Visible = False
        '
        'НоваяToolStripMenuItem
        '
        Me.НоваяToolStripMenuItem.Name = "НоваяToolStripMenuItem"
        Me.НоваяToolStripMenuItem.ShortcutKeyDisplayString = ""
        Me.НоваяToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.НоваяToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.НоваяToolStripMenuItem.Text = "Новая"
        '
        'СложнаяToolStripMenuItem
        '
        Me.СложнаяToolStripMenuItem.Name = "СложнаяToolStripMenuItem"
        Me.СложнаяToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.СложнаяToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.СложнаяToolStripMenuItem.Text = "Сложная Карта"
        Me.СложнаяToolStripMenuItem.Visible = False
        '
        'ОткрітьToolStripMenuItem
        '
        Me.ОткрітьToolStripMenuItem.Name = "ОткрітьToolStripMenuItem"
        Me.ОткрітьToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F2), System.Windows.Forms.Keys)
        Me.ОткрітьToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ОткрітьToolStripMenuItem.Text = "Открыть"
        '
        'СохранітьToolStripMenuItem
        '
        Me.СохранітьToolStripMenuItem.Name = "СохранітьToolStripMenuItem"
        Me.СохранітьToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.СохранітьToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.СохранітьToolStripMenuItem.Text = "Сохранить"
        '
        'СохранитьКакToolStripMenuItem
        '
        Me.СохранитьКакToolStripMenuItem.Name = "СохранитьКакToolStripMenuItem"
        Me.СохранитьКакToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.СохранитьКакToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.СохранитьКакToolStripMenuItem.Text = "Сохранить как"
        '
        'МузыкаToolStripMenuItem
        '
        Me.МузыкаToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.МузыкаToolStripMenuItem.Name = "МузыкаToolStripMenuItem"
        Me.МузыкаToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.МузыкаToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.МузыкаToolStripMenuItem.Text = "Музыка"
        '
        'ЗвукToolStripMenuItem1
        '
        Me.ЗвукToolStripMenuItem1.ForeColor = System.Drawing.Color.Red
        Me.ЗвукToolStripMenuItem1.Name = "ЗвукToolStripMenuItem1"
        Me.ЗвукToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ЗвукToolStripMenuItem1.Size = New System.Drawing.Size(44, 20)
        Me.ЗвукToolStripMenuItem1.Text = "Звук"
        '
        'ИИТанкиToolStripMenuItem
        '
        Me.ИИТанкиToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Танк1ToolStripMenuItem, Me.Танк2ToolStripMenuItem, Me.Танк3ToolStripMenuItem, Me.Танк4ToolStripMenuItem})
        Me.ИИТанкиToolStripMenuItem.Name = "ИИТанкиToolStripMenuItem"
        Me.ИИТанкиToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.ИИТанкиToolStripMenuItem.Text = "ИИ Танки"
        '
        'Танк1ToolStripMenuItem
        '
        Me.Танк1ToolStripMenuItem.Name = "Танк1ToolStripMenuItem"
        Me.Танк1ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.Танк1ToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.Танк1ToolStripMenuItem.Text = "Танк 1"
        '
        'Танк2ToolStripMenuItem
        '
        Me.Танк2ToolStripMenuItem.Checked = True
        Me.Танк2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Танк2ToolStripMenuItem.Name = "Танк2ToolStripMenuItem"
        Me.Танк2ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.Танк2ToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.Танк2ToolStripMenuItem.Text = "Танк 2"
        '
        'Танк3ToolStripMenuItem
        '
        Me.Танк3ToolStripMenuItem.Checked = True
        Me.Танк3ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Танк3ToolStripMenuItem.Name = "Танк3ToolStripMenuItem"
        Me.Танк3ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.Танк3ToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.Танк3ToolStripMenuItem.Text = "Танк 3"
        '
        'Танк4ToolStripMenuItem
        '
        Me.Танк4ToolStripMenuItem.Checked = True
        Me.Танк4ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Танк4ToolStripMenuItem.Name = "Танк4ToolStripMenuItem"
        Me.Танк4ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.Танк4ToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.Танк4ToolStripMenuItem.Text = "Танк 4"
        '
        'mnuMain
        '
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(145, 20)
        Me.mnuMain.Text = "Выйти в главное меню"
        '
        'ВыходToolStripMenuItem1
        '
        Me.ВыходToolStripMenuItem1.Name = "ВыходToolStripMenuItem1"
        Me.ВыходToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ВыходToolStripMenuItem1.Size = New System.Drawing.Size(115, 20)
        Me.ВыходToolStripMenuItem1.Text = "Выйти из BaTanks"
        '
        'ЗагрузитьТекстуруToolStripMenuItem
        '
        Me.ЗагрузитьТекстуруToolStripMenuItem.Name = "ЗагрузитьТекстуруToolStripMenuItem"
        Me.ЗагрузитьТекстуруToolStripMenuItem.Size = New System.Drawing.Size(123, 20)
        Me.ЗагрузитьТекстуруToolStripMenuItem.Text = "Загрузить текстуру"
        Me.ЗагрузитьТекстуруToolStripMenuItem.Visible = False
        '
        'МакросыToolStripMenuItem
        '
        Me.МакросыToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.РамкаИзСтенокToolStripMenuItem})
        Me.МакросыToolStripMenuItem.Name = "МакросыToolStripMenuItem"
        Me.МакросыToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.МакросыToolStripMenuItem.Text = "Макросы"
        Me.МакросыToolStripMenuItem.Visible = False
        '
        'РамкаИзСтенокToolStripMenuItem
        '
        Me.РамкаИзСтенокToolStripMenuItem.CheckOnClick = True
        Me.РамкаИзСтенокToolStripMenuItem.Name = "РамкаИзСтенокToolStripMenuItem"
        Me.РамкаИзСтенокToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.РамкаИзСтенокToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.РамкаИзСтенокToolStripMenuItem.Text = "Рамка из стенок"
        '
        'СвернутьToolStripMenuItem
        '
        Me.СвернутьToolStripMenuItem.Name = "СвернутьToolStripMenuItem"
        Me.СвернутьToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Oemtilde), System.Windows.Forms.Keys)
        Me.СвернутьToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.СвернутьToolStripMenuItem.Text = "Свернуть"
        '
        'СетьToolStripMenuItem
        '
        Me.СетьToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.СоздатьИгруToolStripMenuItem, Me.ПодключитьсяToolStripMenuItem})
        Me.СетьToolStripMenuItem.Name = "СетьToolStripMenuItem"
        Me.СетьToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.СетьToolStripMenuItem.Text = "Сеть"
        '
        'СоздатьИгруToolStripMenuItem
        '
        Me.СоздатьИгруToolStripMenuItem.Name = "СоздатьИгруToolStripMenuItem"
        Me.СоздатьИгруToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.СоздатьИгруToolStripMenuItem.Text = "Создать игру"
        '
        'ПодключитьсяToolStripMenuItem
        '
        Me.ПодключитьсяToolStripMenuItem.Name = "ПодключитьсяToolStripMenuItem"
        Me.ПодключитьсяToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ПодключитьсяToolStripMenuItem.Text = "Подключиться"
        '
        'Timer3
        '
        Me.Timer3.Interval = 25
        '
        'OD1
        '
        Me.OD1.DefaultExt = "png"
        Me.OD1.Filter = "PNG-изображения|*.png|Все файлы|*.*"
        Me.OD1.Title = "Открыть текстуру"
        '
        'SD1
        '
        Me.SD1.DefaultExt = "btm"
        Me.SD1.FileName = "New"
        Me.SD1.Filter = "BaTanks Map|*.btm"
        Me.SD1.InitialDirectory = "Карты"
        Me.SD1.Title = "Сохранить карту"
        '
        'picRoad
        '
        Me.picRoad.Location = New System.Drawing.Point(184, 33)
        Me.picRoad.Name = "picRoad"
        Me.picRoad.Size = New System.Drawing.Size(640, 640)
        Me.picRoad.TabIndex = 0
        Me.picRoad.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.Location = New System.Drawing.Point(1, 166)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(170, 39)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "В БОЙ"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(832, 289)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(153, 207)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Пользователи в игре:"
        Me.GroupBox1.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(23, 154)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(3, 16)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(148, 56)
        Me.ListBox1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtIP)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(829, 499)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(168, 158)
        Me.Panel1.TabIndex = 10
        Me.Panel1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Enter Server IP:"
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(8, 76)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(143, 20)
        Me.txtIP.TabIndex = 10
        Me.txtIP.Text = "10.65.16.25"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(41, 131)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(84, 24)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Cancel"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(8, 36)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(143, 20)
        Me.TextBox3.TabIndex = 8
        Me.TextBox3.Text = "Cow Boy"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(41, 102)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(84, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Connect"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Enter your name :"
        '
        'RTB1
        '
        Me.RTB1.Enabled = False
        Me.RTB1.Location = New System.Drawing.Point(4, 484)
        Me.RTB1.Name = "RTB1"
        Me.RTB1.ReadOnly = True
        Me.RTB1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.RTB1.Size = New System.Drawing.Size(174, 211)
        Me.RTB1.TabIndex = 1
        Me.RTB1.Text = ""
        Me.RTB1.Visible = False
        '
        'CtrlColor1
        '
        Me.CtrlColor1.AutoSize = True
        Me.CtrlColor1.Location = New System.Drawing.Point(830, 33)
        Me.CtrlColor1.Name = "CtrlColor1"
        Me.CtrlColor1.Size = New System.Drawing.Size(144, 250)
        Me.CtrlColor1.TabIndex = 5
        Me.CtrlColor1.Visible = False
        '
        'CtrlHello1
        '
        Me.CtrlHello1.Location = New System.Drawing.Point(1, 33)
        Me.CtrlHello1.MapPath = Nothing
        Me.CtrlHello1.Name = "CtrlHello1"
        Me.CtrlHello1.Size = New System.Drawing.Size(170, 460)
        Me.CtrlHello1.TabIndex = 3
        Me.CtrlHello1.Visible = False
        '
        'CtrlEditor1
        '
        Me.CtrlEditor1.Location = New System.Drawing.Point(0, 33)
        Me.CtrlEditor1.Name = "CtrlEditor1"
        Me.CtrlEditor1.Size = New System.Drawing.Size(171, 640)
        Me.CtrlEditor1.TabIndex = 6
        '
        'CtrlOption1
        '
        Me.CtrlOption1.Location = New System.Drawing.Point(830, 33)
        Me.CtrlOption1.Name = "CtrlOption1"
        Me.CtrlOption1.Size = New System.Drawing.Size(167, 527)
        Me.CtrlOption1.TabIndex = 7
        Me.CtrlOption1.Visible = False
        '
        'FrmvsMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1118, 698)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.RTB1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CtrlColor1)
        Me.Controls.Add(Me.CtrlHello1)
        Me.Controls.Add(Me.picRoad)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.CtrlEditor1)
        Me.Controls.Add(Me.CtrlOption1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmvsMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "-"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.picRoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picRoad As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents CtrlHello1 As BaTanks.ctrlHello
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents МузыкаToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ЗвукToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ИИТанкиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ВыходToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Танк1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Танк2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Танк3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Танк4ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CtrlColor1 As BaTanks.ctrlColor
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents РедакторToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ВаТанчикиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CtrlEditor1 As BaTanks.ctrlEditor
    Friend WithEvents ЗагрузитьТекстуруToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OD1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SD1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents CtrlOption1 As BaTanks.ctrlOption
    Friend WithEvents МакросыToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents РамкаИзСтенокToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ФайлToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents НоваяToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ОткрітьToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents СохранітьToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents СохранитьКакToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents СложнаяToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents СвернутьToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents СетьToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents СоздатьИгруToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ПодключитьсяToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RTB1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button4 As System.Windows.Forms.Button

End Class
