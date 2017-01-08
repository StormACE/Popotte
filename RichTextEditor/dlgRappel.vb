Imports System.Windows.Forms

Public Class RappelDialog

    'Get Language
    Private LangINI As IniFile = frmMain.LangIni

    Private Sub RappelDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Controls Language
        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - AlertSave", "1")
        DelayLabel.Text = LangINI.GetKeyValue("Popotte - AlertSave", "2")
        ActivateButton.Text = LangINI.GetKeyValue("Popotte - AlertSave", "3")
        DeactivateButton.Text = LangINI.GetKeyValue("Popotte - AlertSave", "4")
        Cancel_Button.Text = LangINI.GetKeyValue("Popotte - AlertSave", "5")

        Dim delay As Integer = (frmMain.Delay / 1000)
        DelayTextBox.Text = delay
        If frmMain.RappelToolStripMenuItem.Checked Then
            DeactivateButton.TabIndex = 0
            DelayTextBox.TabIndex = 1
            ActivateButton.TabIndex = 2
            Cancel_Button.TabIndex = 3
        Else
            DelayTextBox.TabIndex = 0
            DeactivateButton.TabIndex = 2
            ActivateButton.TabIndex = 1
            Cancel_Button.TabIndex = 3
        End If

    End Sub

    Private Sub ActivateButton_Click_1(sender As Object, e As EventArgs) Handles ActivateButton.Click
        If Val(DelayTextBox.Text) >= 30 Then
            If (Val(DelayTextBox.Text)) > 21600 Then
                MessageBox.Show(LangINI.GetKeyValue("Popotte - AlertSave - MessageBox", "3") & Environment.NewLine & LangINI.GetKeyValue("Popotte - AlertSave - MessageBox", "4"), "Popotte - " & LangINI.GetKeyValue("Popotte - AlertSave - MessageBox", "2"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                frmMain.RappelToolStripMenuItem.Checked = True
                frmMain.regKey.SetValue("check", 1)
                frmMain.Delay = Val(DelayTextBox.Text * 1000)
                frmMain.RappelTimer.Interval = frmMain.Delay
                frmMain.regKey.SetValue("Delay", frmMain.Delay)
                If frmMain.RappelTimer.Enabled = False Then
                    frmMain.RappelTimer.Start()
                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            MessageBox.Show(LangINI.GetKeyValue("Popotte - AlertSave - MessageBox", "5"), "Popotte - " & LangINI.GetKeyValue("Popotte - AlertSave - MessageBox", "1"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub DeactivateButton_Click(sender As Object, e As EventArgs) Handles DeactivateButton.Click
        Dim result As DialogResult = MessageBox.Show(LangINI.GetKeyValue("Popotte - AlertSave - MessageBox", "6"), "Popotte - " & LangINI.GetKeyValue("Popotte - AlertSave - MessageBox", "1"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.No
            frmMain.RappelToolStripMenuItem.Checked = False
            frmMain.regKey.SetValue("check", 0)
            frmMain.RappelTimer.Stop()
            frmMain.RappelTimer.Dispose()
        End If
    End Sub

    Private Sub Cancel_Button_Click_1(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DelayTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DelayTextBox.KeyPress
        'Seulement des chiffres peuvent etre entrer dans cette textbox
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True   'eat it
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            ActivateButton_Click_1(Me, e)
            e.Handled = True
        End If
    End Sub

End Class
