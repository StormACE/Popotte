Imports System.IO

Public Class NouveauLivreDialog

    'Get Language
    Private LangINI As IniFile = frmMain.LangIni

    Private Sub NouveauLivreDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Controls Language
        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - NewBookDialog", "1")
        LabelLivre.Text = LangINI.GetKeyValue("Popotte - NewBookDialog", "2")
        OK_Button.Text = LangINI.GetKeyValue("Popotte - NewBookDialog", "3")
        Cancel_Button.Text = LangINI.GetKeyValue("Popotte - NewBookDialog", "4")
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim NLivre As String = TextBox.Text
        If NLivre <> "" Then
            Dim Path As String = frmMain.PopotteDir & NLivre
            If Not Directory.Exists(Path) Then
                If CreateFolder(Path) <> -1 Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            Else
                MsgBox(LangINI.GetKeyValue("Popotte - NewBookDialog - MessageBox", "1") & NLivre & LangINI.GetKeyValue("Popotte - NewBookDialog - MessageBox", "2"), MsgBoxStyle.Exclamation, "Popotte -" & LangINI.GetKeyValue("Popotte - NewBookDialog - MessageBox", "4"))
            End If
        Else
            MsgBox(LangINI.GetKeyValue("Popotte - NewBookDialog - MessageBox", "3"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - NewBookDialog - MessageBox", "4"))
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            OK_Button_Click(Me, e)
            e.Handled = True
        End If
    End Sub

End Class
