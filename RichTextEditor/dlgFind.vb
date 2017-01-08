Imports Microsoft.Win32

Public Class dlgFind

    'Get Language
    Private LangINI As IniFile = frmMain.LangIni
    Private regkey As RegistryKey


    Private Sub frmFind_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToScreen()

        'Controls Language
        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - FindDialog", "1")
        LabelMot.Text = LangINI.GetKeyValue("Popotte - FindDialog", "2")
        chkMatchCase.Text = LangINI.GetKeyValue("Popotte - FindDialog", "3")
        btnFind.Text = LangINI.GetKeyValue("Popotte - FindDialog", "4")
        btnFindNext.Text = LangINI.GetKeyValue("Popotte - FindDialog", "5")

        'set min and max scrollbar positions
        OpacityHScrollBar.Maximum = 100
        OpacityHScrollBar.Minimum = 10

        'Get dlg opacity
        regkey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\SearchOpacity", True)
        If regKey IsNot Nothing Then
            Dim SearchOpacity As Double = regkey.GetValue("", 100)
            OpacityHScrollBar.Value = SearchOpacity
        Else
            OpacityHScrollBar.Value = 100
        End If
        Me.Opacity = OpacityHScrollBar.Value / 100

    End Sub

    Private Sub frmFind_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        frmMain.FindFormOpen = False
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim rechstr As String = txtSearchTerm.Text.Trim
        If rechstr <> "" Then
            Dim StartPosition As Integer
            Dim SearchType As CompareMethod

            If chkMatchCase.Checked Then
                SearchType = CompareMethod.Binary
            Else
                SearchType = CompareMethod.Text
            End If

            StartPosition = InStr(1, frmMain.rtbDoc.Text, rechstr, SearchType)

            If StartPosition = 0 Then
                MessageBox.Show(LangINI.GetKeyValue("Popotte - FindDialog - MessageBox", "1") & rechstr & LangINI.GetKeyValue("Popotte - FindDialog - MessageBox", "2"), "Popotte - " & LangINI.GetKeyValue("Popotte - FindDialog - MessageBox", "3"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            frmMain.rtbDoc.Select(StartPosition - 1, rechstr.Length)
            frmMain.rtbDoc.ScrollToCaret()
            btnFindNext.Focus()
        Else
            MsgBox(LangINI.GetKeyValue("Popotte - FindDialog - MessageBox", "4"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - FindDialog - MessageBox", "5"))
        End If


    End Sub


    Private Sub btnFindNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindNext.Click
        Dim rechstr As String = txtSearchTerm.Text.Trim
        If rechstr <> "" Then
            Dim StartPosition As Integer = frmMain.rtbDoc.SelectionStart + 2
            Dim SearchType As CompareMethod

            If chkMatchCase.Checked = True Then
                SearchType = CompareMethod.Binary
            Else
                SearchType = CompareMethod.Text
            End If

            StartPosition = InStr(StartPosition, frmMain.rtbDoc.Text, rechstr, SearchType)

            If StartPosition = 0 Then
                MessageBox.Show(LangINI.GetKeyValue("Popotte - FindDialog - MessageBox", "1") & rechstr & LangINI.GetKeyValue("Popotte - FindDialog - MessageBox", "2"), "Popotte - " & LangINI.GetKeyValue("Popotte - FindDialog - MessageBox", "3"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            frmMain.rtbDoc.Select(StartPosition - 1, rechstr.Length)
            frmMain.rtbDoc.ScrollToCaret()
            btnFindNext.Focus()
        Else
            MsgBox(LangINI.GetKeyValue("Popotte - FindDialog - MessageBox", "4"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - FindDialog - MessageBox", "5"))
        End If
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