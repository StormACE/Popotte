''' <summary>
''' Popotte v5
''' 1 mars 2016 au 13 Janvier 2017
''' Work on Vista sp2, Windows 7 sp1, windows 8, Windows 8.1 and Windows 10. Need .Net Framework 4.0
''' Copyright Martin Laflamme 2003/2017
''' Read licence.txt
''' </summary>
Public Class dlgConverter

    'Get Language
    Private LangINI As IniFile = frmMain.LangIni

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dialog1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Controls Language
        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - Converter", "26")
        LabelIn.Text = LangINI.GetKeyValue("Popotte - Converter", "27")
        LabelConv.Text = LangINI.GetKeyValue("Popotte - Converter", "28")
        LabelOut.Text = LangINI.GetKeyValue("Popotte - Converter", "29")
        Close_Button.Text = LangINI.GetKeyValue("Popotte - Converter", "30")


        'Add ToolTips To Controls
        Dim buttonToolTip1 As New ToolTip()
        Dim buttonToolTip2 As New ToolTip()
        Dim buttonToolTip3 As New ToolTip()
        Dim buttonToolTip4 As New ToolTip()

        buttonToolTip1.UseFading = True
        buttonToolTip1.UseAnimation = True
        buttonToolTip1.IsBalloon = True
        buttonToolTip1.ShowAlways = True
        buttonToolTip1.AutoPopDelay = 2500
        buttonToolTip1.InitialDelay = 500
        buttonToolTip1.ReshowDelay = 500
        buttonToolTip1.ToolTipIcon = ToolTipIcon.Info

        buttonToolTip2.UseFading = True
        buttonToolTip2.UseAnimation = True
        buttonToolTip2.IsBalloon = True
        buttonToolTip2.ShowAlways = True
        buttonToolTip2.AutoPopDelay = 2500
        buttonToolTip2.InitialDelay = 500
        buttonToolTip2.ReshowDelay = 500
        buttonToolTip2.ToolTipIcon = ToolTipIcon.Info

        buttonToolTip3.UseFading = True
        buttonToolTip3.UseAnimation = True
        buttonToolTip3.IsBalloon = True
        buttonToolTip3.ShowAlways = True
        buttonToolTip3.AutoPopDelay = 2500
        buttonToolTip3.InitialDelay = 500
        buttonToolTip3.ReshowDelay = 500
        buttonToolTip3.ToolTipIcon = ToolTipIcon.Info

        buttonToolTip4.UseFading = True
        buttonToolTip4.UseAnimation = True
        buttonToolTip4.IsBalloon = True
        buttonToolTip4.ShowAlways = True
        buttonToolTip4.AutoPopDelay = 2500
        buttonToolTip4.InitialDelay = 500
        buttonToolTip4.ReshowDelay = 500
        buttonToolTip4.ToolTipIcon = ToolTipIcon.Info

        buttonToolTip1.ToolTipTitle = LangINI.GetKeyValue("Popotte - Converter", "31")
        buttonToolTip1.SetToolTip(Close_Button, LangINI.GetKeyValue("Popotte - Converter", "32"))
        buttonToolTip2.ToolTipTitle = LangINI.GetKeyValue("Popotte - Converter", "33")
        buttonToolTip2.SetToolTip(TextBox1, LangINI.GetKeyValue("Popotte - Converter", "34"))
        buttonToolTip3.ToolTipTitle = LangINI.GetKeyValue("Popotte - Converter", "35")
        buttonToolTip3.SetToolTip(ConverterComboBox, LangINI.GetKeyValue("Popotte - Converter", "36"))
        buttonToolTip4.ToolTipTitle = LangINI.GetKeyValue("Popotte - Converter", "37")
        buttonToolTip4.SetToolTip(TextBox2, LangINI.GetKeyValue("Popotte - Converter", "38"))


        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "1"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "2"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "3"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "4"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "5"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "6"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "7"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "8"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "9"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "10"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "11"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "12"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "13"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "14"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "15"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "16"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "17"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "18"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "19"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "20"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "21"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "22"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "23"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "24"))
        Me.ConverterComboBox.Items.Add(LangINI.GetKeyValue("Popotte - Converter", "25"))
        ConverterComboBox.SelectedIndex = 0
        TextBox1.Text = "0"
    End Sub

    Private Sub ConverterComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ConverterComboBox.SelectedIndexChanged
        Dim Choice As Int32 = ConverterComboBox.SelectedIndex
        Dim NumbIn As Double = Val(TextBox1.Text)
        Dim NumbOut As Double

        Select Case Choice
            Case 1
                NumbOut = ((9 * NumbIn) / 5) + 32
                TextBox2.Text = NumbOut.ToString("F1")
            Case 2
                NumbOut = ((NumbIn - 32) * 5) / 9
                TextBox2.Text = NumbOut.ToString("F1")
            Case 3
                NumbOut = (NumbIn * 2.2)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 4
                NumbOut = (NumbIn / 2.2)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 5
                NumbOut = (NumbIn * 28.3495)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 6
                NumbOut = (NumbIn / 28.3495)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 7
                NumbOut = (NumbIn * 15.5)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 8
                NumbOut = (NumbIn / 15.5)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 9
                NumbOut = (NumbIn * 5.5)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 10
                NumbOut = (NumbIn / 5.5)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 11
                NumbOut = (NumbIn * 250)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 12
                NumbOut = (NumbIn / 250)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 13
                NumbOut = (NumbIn * 15)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 14
                NumbOut = (NumbIn / 15)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 15
                NumbOut = (NumbIn * 5)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 16
                NumbOut = (NumbIn / 5)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 17
                NumbOut = (NumbIn * 2.54)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 18
                NumbOut = (NumbIn / 2.54)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 19
                NumbOut = (NumbIn * 30.48)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 20
                NumbOut = (NumbIn / 30.48)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 21
                NumbOut = (NumbIn * 0.9144)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 22
                NumbOut = (NumbIn / 0.9144)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 23
                NumbOut = (NumbIn / 0.6214)
                TextBox2.Text = NumbOut.ToString("F1")
            Case 24
                NumbOut = (NumbIn * 0.6214)
                TextBox2.Text = NumbOut.ToString("F1")
        End Select
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'Seulement des chiffres peuvent etre entrer dans cette textbox
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not Char.ToString(e.KeyChar) = "." And Not Char.ToString(e.KeyChar) = "-" Then
            e.Handled = True   'eat it
        End If
    End Sub

End Class
