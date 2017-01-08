Imports Microsoft.Win32

Public Class dlgReplace

    'Get Language
    Private LangINI As IniFile = frmMain.LangIni
    Private regkey As RegistryKey


    Private Sub frmReplace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToScreen()

        'Controls Language
        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - Search&Replace", "1")
        LabelMot.Text = LangINI.GetKeyValue("Popotte - Search&Replace", "2")
        LabelRemplacer.Text = LangINI.GetKeyValue("Popotte - Search&Replace", "3")
        chkMatchCase.Text = LangINI.GetKeyValue("Popotte - Search&Replace", "4")
        btnFind.Text = LangINI.GetKeyValue("Popotte - Search&Replace", "5")
        btnFindNext.Text = LangINI.GetKeyValue("Popotte - Search&Replace", "6")
        btnReplace.Text = LangINI.GetKeyValue("Popotte - Search&Replace", "7")
        btnReplaceAll.Text = LangINI.GetKeyValue("Popotte - Search&Replace", "8")

        'set min and max scrollbar positions
        OpacityHScrollBar.Maximum = 100
        OpacityHScrollBar.Minimum = 10

        'Get dlg opacity
        regkey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\SearchOpacity", True)
        If regkey IsNot Nothing Then
            Dim SearchOpacity As Double = regkey.GetValue("", 100)
            OpacityHScrollBar.Value = SearchOpacity
        Else
            OpacityHScrollBar.Value = 100
        End If
        Me.Opacity = OpacityHScrollBar.Value / 100

    End Sub

    Private Sub frmReplace_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        frmMain.FindReplaceFormOpen = False
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click

        If txtSearchTerm.Text <> "" Then
            Dim StartPosition As Integer
            Dim SearchType As CompareMethod

            If chkMatchCase.Checked Then
                SearchType = CompareMethod.Binary
            Else
                SearchType = CompareMethod.Text
            End If

            StartPosition = InStr(1, frmMain.rtbDoc.Text, txtSearchTerm.Text, SearchType)

            If StartPosition = 0 Then
                MessageBox.Show(LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "3") & txtSearchTerm.Text.ToString() & LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "4"), "Popotte - " & LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "1"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            frmMain.rtbDoc.Select(StartPosition - 1, txtSearchTerm.Text.Length)
            frmMain.rtbDoc.ScrollToCaret()
            btnFindNext.Focus()
        Else
            MsgBox(LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "5"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "2"))
        End If

    End Sub



    Private Sub btnFindNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindNext.Click

        If txtSearchTerm.Text <> "" Then
            Dim StartPosition As Integer = frmMain.rtbDoc.SelectionStart + 2
            Dim SearchType As CompareMethod

            If chkMatchCase.Checked Then
                SearchType = CompareMethod.Binary
            Else
                SearchType = CompareMethod.Text
            End If

            StartPosition = InStr(StartPosition, frmMain.rtbDoc.Text, txtSearchTerm.Text, SearchType)

            If StartPosition = 0 Then
                MessageBox.Show(LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "3") & txtSearchTerm.Text.ToString() & LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "4"), "Popotte - " & LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "1"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            frmMain.rtbDoc.Select(StartPosition - 1, txtSearchTerm.Text.Length)
            frmMain.rtbDoc.ScrollToCaret()
            btnFindNext.Focus()
        Else
            MsgBox(LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "5"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "2"))
        End If


    End Sub



    Private Sub btnReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplace.Click

        If txtSearchTerm.Text <> "" And txtReplacementText.Text <> "" Then
            If frmMain.rtbDoc.SelectedText.Length <> 0 Then
                frmMain.rtbDoc.SelectedText = txtReplacementText.Text
            End If

            Dim StartPosition As Integer = frmMain.rtbDoc.SelectionStart + 2
            Dim SearchType As CompareMethod

            If chkMatchCase.Checked Then
                SearchType = CompareMethod.Binary
            Else
                SearchType = CompareMethod.Text
            End If

            StartPosition = InStr(StartPosition, frmMain.rtbDoc.Text, txtSearchTerm.Text, SearchType)

            If StartPosition = 0 Then
                MessageBox.Show(LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "3") & txtSearchTerm.Text.ToString() & LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "4"), "Popotte - " & LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "1"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            frmMain.rtbDoc.Select(StartPosition - 1, txtSearchTerm.Text.Length)
            frmMain.rtbDoc.ScrollToCaret()
            btnFindNext.Focus()
        Else
            MsgBox(LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "6"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "2"))
        End If


    End Sub



    Private Sub btnReplaceAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplaceAll.Click

        If txtSearchTerm.Text <> "" And txtReplacementText.Text <> "" Then
            Dim currentPosition As Integer = frmMain.rtbDoc.SelectionStart
            Dim currentSelect As Integer = frmMain.rtbDoc.SelectionLength

            frmMain.rtbDoc.Rtf = Replace(frmMain.rtbDoc.Rtf, Trim(txtSearchTerm.Text), Trim(txtReplacementText.Text))
            frmMain.rtbDoc.SelectionStart = currentPosition
            frmMain.rtbDoc.SelectionLength = currentSelect
        Else
            MsgBox(LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "6"), MsgBoxStyle.Exclamation, "Popotte -" & LangINI.GetKeyValue("Popotte - Search&Replace - MessageBox", "2"))
        End If

        frmMain.Focus()

    End Sub


    Private Sub txtSearchTerm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchTerm.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            btnFind_Click(Me, e)
            e.Handled = True
        End If
    End Sub

    Private Sub OpacityHScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles OpacityHScrollBar.Scroll
        Me.Opacity = e.NewValue / 100
        regkey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\SearchOpacity", True)
        If regkey Is Nothing Then
            regkey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regkey = regkey.CreateSubKey("SearchOpacity")
        End If
        regkey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\SearchOpacity", True)
        regkey.SetValue("", e.NewValue, RegistryValueKind.DWord)
    End Sub
End Class