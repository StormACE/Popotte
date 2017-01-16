''' <summary>
''' Popotte v5
''' 1 mars 2016 au 13 Janvier 2017
''' Work on Vista sp2, Windows 7 sp1, windows 8, Windows 8.1 and Windows 10. Need .Net Framework 4.0
''' Copyright Martin Laflamme 2003/2017
''' Read licence.txt
''' </summary>

Public Class dlgCrypterDécrypter

    'Get Language
    Private LangINI As IniFile = frmMain.LangIni

    Private Sub CrypterDécrypter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - Encryption", "1")
        LabelMotdePasse.Text = LangINI.GetKeyValue("Popotte - Encryption", "2")
        LabelSalt.Text = LangINI.GetKeyValue("Popotte - Encryption", "3")
        CheckBoxCrypt.Text = LangINI.GetKeyValue("Popotte - Encryption", "4")
        CheckBoxDeCrypt.Text = LangINI.GetKeyValue("Popotte - Encryption", "5")
        OK_Button.Text = LangINI.GetKeyValue("Popotte - Encryption", "6")
        Cancel_Button.Text = LangINI.GetKeyValue("Popotte - Encryption", "7")
        LabelVerifyPass.Text = LangINI.GetKeyValue("Popotte - Encryption", "8")
        Label1.Text = LangINI.GetKeyValue("Popotte - Encryption", "9")

        'Add ToolTips To Controls
        Dim buttonToolTip1 As New ToolTip()
        Dim buttonToolTip2 As New ToolTip()
        Dim buttonToolTip3 As New ToolTip()
        Dim buttonToolTip4 As New ToolTip()
        Dim buttonToolTip5 As New ToolTip()
        Dim buttonToolTip6 As New ToolTip()

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

        buttonToolTip5.UseFading = True
        buttonToolTip5.UseAnimation = True
        buttonToolTip5.IsBalloon = True
        buttonToolTip5.ShowAlways = True
        buttonToolTip5.AutoPopDelay = 2500
        buttonToolTip5.InitialDelay = 500
        buttonToolTip5.ReshowDelay = 500
        buttonToolTip5.ToolTipIcon = ToolTipIcon.Info

        buttonToolTip6.UseFading = True
        buttonToolTip6.UseAnimation = True
        buttonToolTip6.IsBalloon = True
        buttonToolTip6.ShowAlways = True
        buttonToolTip6.AutoPopDelay = 2500
        buttonToolTip6.InitialDelay = 500
        buttonToolTip6.ReshowDelay = 500
        buttonToolTip6.ToolTipIcon = ToolTipIcon.Info

        buttonToolTip1.ToolTipTitle = LangINI.GetKeyValue("Popotte - Encryption", "10")
        buttonToolTip1.SetToolTip(CheckBoxCrypt, LangINI.GetKeyValue("Popotte - Encryption", "11"))
        buttonToolTip2.ToolTipTitle = LangINI.GetKeyValue("Popotte - Encryption", "12")
        buttonToolTip2.SetToolTip(CheckBoxDeCrypt, LangINI.GetKeyValue("Popotte - Encryption", "13"))
        buttonToolTip5.ToolTipTitle = LangINI.GetKeyValue("Popotte - Encryption", "14")
        buttonToolTip5.SetToolTip(TextBoxIteration, LangINI.GetKeyValue("Popotte - Encryption", "15"))
        buttonToolTip6.ToolTipTitle = LangINI.GetKeyValue("Popotte - Encryption", "16")
        buttonToolTip6.SetToolTip(TextBoxVerifyPass, LangINI.GetKeyValue("Popotte - Encryption", "17"))

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If frmMain.rtbDoc.SelectedText <> "" Then
            If TextBoxPass.Text <> "" Then
                If TextBoxPass.Text = TextBoxVerifyPass.Text Then

                    If CheckBoxCrypt.Checked Then
                        Dim text1 As String = Encrypt(frmMain.rtbDoc.SelectedText, TextBoxPass.Text, TextBoxSel.Text, Val(TextBoxIteration.Text))
                        If text1 <> "" Then
                            frmMain.rtbDoc.SelectedText = text1
                            frmMain.rtbDoc.Select(0, 0)
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()
                        End If
                    Else
                        Dim text2 As String = Decrypt(frmMain.rtbDoc.SelectedText, TextBoxPass.Text, TextBoxSel.Text, Val(TextBoxIteration.Text))
                        If text2 <> "" Then
                            frmMain.rtbDoc.SelectedText = text2
                            frmMain.rtbDoc.Select(0, 0)
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()
                        End If
                    End If

                Else

                    MsgBox(LangINI.GetKeyValue("Popotte - Encryption - MessageBox", "4"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - Encryption - MessageBox", "2"))

                End If
            Else
                MsgBox(LangINI.GetKeyValue("Popotte - Encryption - MessageBox", "1"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - Encryption - MessageBox", "2"))
                TextBoxPass.Focus()
            End If
        Else
            MsgBox(LangINI.GetKeyValue("Popotte - Encryption - MessageBox", "3"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - Encryption - MessageBox", "2"))
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBoxCrypt.Click
        CheckBoxCrypt.Checked = True
        CheckBoxDeCrypt.Checked = False
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBoxDeCrypt.Click
        CheckBoxCrypt.Checked = False
        CheckBoxDeCrypt.Checked = True
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxPass.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            OK_Button_Click(Me, e)
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxSel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSel.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            OK_Button_Click(Me, e)
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxIteration.KeyPress
        'Seulement des chiffres peuvent etre entrer dans cette textbox
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True   'eat it
        End If
    End Sub
End Class
